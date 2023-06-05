using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Entities
{
    public class Category : FullAuditedEntity<int>
    {
        public string CategoryName { get; set; }

        public int DepartmentId { get; set; }

        public Department DepartmentName { get; set; }

    }
}
