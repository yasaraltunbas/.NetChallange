using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace BackendCase.DAO
{

    [Table(Name = "salon")]
    public class SalonDAO
    {

        [Column(Name = "salonID"), PrimaryKey]  
        public int SalonId { get; set; }

        [Column(Name = "salonAd")]
        public string SalonAd { get; set; }
        
    }
}
