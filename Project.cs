/*
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

using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class Project
    {
        private DateTime _createdAt;
        private DateTime _updatedAt;

        public int Id { get; set; }
        public Guid TraceId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public string FileName { get; set; }
        public string InternalFileName { get; set; }
        public int FileSize { get; set; }

        public double? Mass { get; set; }
        public double? Area { get; set; }
        public double? TheoreticalCapacity { get; set; }
        public double? ActiveMaterialFraction { get; set; }

        public string TestName { get; set; }
        public string TestType { get; set; }
        public string Channel { get; set; }
        public string Tag { get; set; }
        public string Comments { get; set; }
        public string StitchedFrom { get; set; }
        public string StitchedFromNames { get; set; }
        public virtual IList<View> Views { get; set; }

        public bool IsAveragePlot { get; set; }

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

        public int NumCycles { get; set; }

        public bool IsReady { get; set; }
        public bool Failed { get; set; }
        public string Error { get; set; }
        public string JobId { get; set; }

        public bool IsPartialGathering { get; set; }

        public virtual AppUser User { get; set; }

        public virtual IList<AppUser> SharedUsers { get; set; }
      
        public string OwnerName {
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
            get => User.UserName;
        }

        private DateTime SpecifyUtcKindIfUnspecified(DateTime value)
        {
            return value.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(value, DateTimeKind.Utc) : value;
        }
    }
}
