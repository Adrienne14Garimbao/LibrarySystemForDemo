using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySystemForDemo.Entities
{
    public class Borrower : FullAuditedEntity<int>
    {
        public DateTime BorrowDate { get; set; }

        public DateTime ExpectedReturnDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int? BookId { get; set; }

        public Book Books { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }
    }
}
