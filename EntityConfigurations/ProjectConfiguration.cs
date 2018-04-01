﻿/*
Copyright(c) <2018> <University of Washington>
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityConfigurations
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        ////////////////////////////////////////////////////////////
        // Constructors
        ////////////////////////////////////////////////////////////

        /// <summary>
        /// ctor
        /// </summary>
        public ProjectConfiguration()
        {
            ToTable("Projects");

            HasKey(e => e.Id);

            Property(e => e.Name).IsRequired().HasMaxLength(256);
            Property(e => e.FileName).IsRequired().HasMaxLength(256);
            Property(e => e.InternalFileName).HasMaxLength(256);
            Property(e => e.TestName).HasMaxLength(256);
            Property(e => e.TestType).HasMaxLength(256);
            Property(e => e.Channel).HasMaxLength(256);
            Property(e => e.Tag).HasMaxLength(256);
            Property(e => e.Comments).HasMaxLength(256);
            Property(e => e.Error).HasMaxLength(256);
            Property(e => e.IsAveragePlot).IsRequired();
            Property(e => e.IsPartialGathering).IsRequired();

            HasRequired(e => e.User)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.UserId);

            Ignore(t => t.OwnerName);
        }
    }
}
