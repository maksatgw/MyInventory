﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class AssignmentHistory
    {
        public int AssignmentHistoryId { get; set; }
        public string EquipmentId { get; set; }
        public string AssignedUser { get; set; }
        public string AssignedUserLocation { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? AssignedFinishedDate { get; set; }
        public string? AssignmentFilePath { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
    }
}
