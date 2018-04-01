using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class PlotTemplate
    {
        private DateTime _createdAt;
        private DateTime _updatedAt;

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public virtual AppUser User { get; set; }
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

        public virtual IList<AppUser> SharedUsers { get; set; }

        public string OwnerName
        {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
            get => User.UserName;
        }
        public virtual IList<View> Views { get; set; }
    }
}
