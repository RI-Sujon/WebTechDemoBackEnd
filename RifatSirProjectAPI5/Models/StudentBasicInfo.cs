using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RifatSirProjectAPI5.Models
{
    public class StudentBasicInfo 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BSSEROLL { get; set; }
        public string BatchNo { get; set; }
        public string StudentName { get; set; }
        public string Session { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HallName { get; set; }
    }
}
