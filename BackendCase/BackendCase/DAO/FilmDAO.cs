using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace BackendCase.DAO
{

    [Table(Name = "film")]
    public class FilmDAO
    {

        [Column(Name = "filmID"), PrimaryKey]
        public int FilmId { get; set; }

        [Column(Name = "filmAdi")]
        public string FilmAd { get; set; }
        
        [Column(Name = "filmYapimYil")]
        public int FilmYapimYil { get; set; }
    }
}
