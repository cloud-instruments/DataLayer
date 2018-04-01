using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer
{
    public class AppUser : IdentityUser
    {
        public virtual IList<Project> Projects { get; set; }

        public virtual IList<PlotTemplate> PlotTemplates { get; set; }

        public virtual IList<View> Views { get; set; }

        public virtual IList<Project> SharedProjects { get; set; }

        public virtual IList<PlotTemplate> SharedTemplates { get; set; }
    }
}
