using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using DataLayer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;

namespace DataLayer
{
    public class DqdvContext : IdentityDbContext<AppUser>
    {
        [Obsolete]
        public DqdvContext()
            : base("Data Source=.;Initial Catalog=dqdv;Integrated Security=true")
        {
            //DbInterception.Add(new MyInterceptor());
        }

        public DqdvContext(string connectionString, TimeSpan defaultCommandTimeout)
            : base(connectionString)
        {
            (this as IObjectContextAdapter).ObjectContext.CommandTimeout = (int)defaultCommandTimeout.TotalSeconds;
            //DbInterception.Add(new MyInterceptor());
        }

        public DbSet<AppUserPreferences> UserPreferences { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PlotTemplate> PlotTemplates { get; set; }
        public DbSet<View> Views { get; set; }

        public static void Migrate(string connectionString, string providerName)
        {
            var configuration = new Configuration
            {
                TargetDatabase = new DbConnectionInfo(connectionString, providerName)
            };

            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type =>
                    type.BaseType != null &&
                    type.BaseType.IsGenericType &&
                    (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>) ||
                        type.BaseType.GetGenericTypeDefinition() == typeof(ComplexTypeConfiguration<>)));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public int SP_RemoveViewsWithoutProjects()
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spRemoveViewsWithoutProjects]");
        }

        public int SP_ShareView(string userId, string shareUserId, int viewId)
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spShareView] @UserId, @ShareUserId, @ViewId ", new SqlParameter("@UserId", userId), new SqlParameter("@ShareUserId", shareUserId), new SqlParameter("@ViewId", viewId));
        }

        public int SP_ShareProject(string userId, string shareUserId, int projectId)
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spShareProject] @UserId, @ShareUserId, @ProjectId ", new SqlParameter("@UserId", userId), new SqlParameter("@ShareUserId", shareUserId), new SqlParameter("@ProjectId", projectId));
        }
        public int SP_ShareTemplate(string userId, string shareUserId, int templateId)
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spShareTemplate] @UserId, @ShareUserId, @TemplateId ", new SqlParameter("@UserId", userId), new SqlParameter("@ShareUserId", shareUserId), new SqlParameter("@TemplateId", templateId));
        }

        public int SP_DeleteTemplate(string userId, int templateId)
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spDeleteTemplate] @UserId, @TemplateId ", new SqlParameter("@UserId", userId), new SqlParameter("@TemplateId", templateId));
        }

        public int SP_DeleteProject(string userId, int projectId)
        {
            return Database.ExecuteSqlCommand("EXEC [dbo].[spDeleteProject] @UserId, @ProjectId ", new SqlParameter("@UserId", userId), new SqlParameter("@ProjectId", projectId));
        }
    }


    public class MyInterceptor : DbCommandInterceptor, IDbCommandTreeInterceptor
    {
        private Dictionary<string, object> _parameterValueMap;

        public MyInterceptor()
        {
            _parameterValueMap = new Dictionary<string, object>();
        }

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.CSpace)
            {
                _parameterValueMap.Clear();
                if (interceptionContext.OriginalResult.CommandTreeKind == DbCommandTreeKind.Query)
                {
                    var queryCommandTree = (DbQueryCommandTree)interceptionContext.OriginalResult;
                    var originalParameterCount = queryCommandTree.Parameters.Count();

                    var visitor = new ConstantExpressionReplacingVisitor(originalParameterCount);

                    var newExpression = queryCommandTree.Query.Accept(visitor);
                    _parameterValueMap = visitor.ParameterValueMap;

                    if (visitor.ParameterValueMap.Count > 0)
                    {
                        interceptionContext.Result = new DbQueryCommandTree(
                            queryCommandTree.MetadataWorkspace,
                            queryCommandTree.DataSpace,
                            newExpression);
                    }
                }
            }
        }

        public override void ReaderExecuting(
            DbCommand command,
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            ProcessParameters(command);
            base.ReaderExecuting(command, interceptionContext);
        }

        public override void ScalarExecuting(
            DbCommand command,
            DbCommandInterceptionContext<object> interceptionContext)
        {
            ProcessParameters(command);
            base.ScalarExecuting(command, interceptionContext);
        }

        public override void NonQueryExecuting(
            DbCommand command,
            DbCommandInterceptionContext<int> interceptionContext)
        {
            ProcessParameters(command);
            base.NonQueryExecuting(command, interceptionContext);
        }

        private void ProcessParameters(DbCommand command)
        {
            if (_parameterValueMap.Count > 0)
            {
                foreach (DbParameter prm in command.Parameters)
                {
                    if (_parameterValueMap.TryGetValue(prm.ParameterName, out var parameterValue))
                    {
                        prm.Value = parameterValue;
                    }
                }
            }

            //_parameterValueMap.Clear();
        }
    }

    public class ConstantExpressionReplacingVisitor : DefaultExpressionVisitor
    {
        private int _originalParameterCount;

        public Dictionary<string, object> ParameterValueMap { get; private set; }

        public ConstantExpressionReplacingVisitor(int originalParameterCount)
        {
            _originalParameterCount = originalParameterCount;
            ParameterValueMap = new Dictionary<string, object>();
        }

        public override DbExpression Visit(DbConstantExpression expression)
        {
            var count = _originalParameterCount + ParameterValueMap.Count;
            var result = expression.ResultType.Parameter("p__linq__" + count);
            ParameterValueMap.Add(result.ParameterName, expression.Value);

            return result;
        }
    }
}
