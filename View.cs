using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class View
    {
        private DateTime _createdAt;
        private DateTime _updatedAt;
        public int Id { get; set; }
        public int PlotTemplateId { get; set; }
        public string Comments { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public virtual IList<Project> Projects { get; set; }
        public virtual AppUser User { get; set; }
        public virtual PlotTemplate PlotTemplate { get; set; }
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = SpecifyUtcKindIfUnspecified(value);
        }

        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = SpecifyUtcKindIfUnspecified(value);
        }
        private DateTime SpecifyUtcKindIfUnspecified(DateTime value)
        {
            return value.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(value, DateTimeKind.Utc) : value;
        }
    }
}
