using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public virtual List<Assignment> Assignments { get; set; }
    }
}
