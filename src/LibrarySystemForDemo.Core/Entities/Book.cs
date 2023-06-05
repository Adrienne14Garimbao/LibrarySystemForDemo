using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystemForDemo.Entities
{
    public class Book : FullAuditedEntity<int>
    {
        public string BookTitle { get; set; }

        public string BookPublisher { get; set; }

        public bool? IsBorrowed { get; set; }

        public int? BookCategoryId { get; set; }

        public Category BookCategory { get; set; }

        public int? AuthorId { get; set; }  /* <<<< I Add this   */

        public Author Author { get; set; } /* <<<< I Add this   */

    }
}
