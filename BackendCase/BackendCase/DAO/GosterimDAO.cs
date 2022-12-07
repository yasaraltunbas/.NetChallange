using LinqToDB.Mapping;

namespace BackendCase.DAO
{

    [Table(Name = "gosterim")]
    public class GosterimDAO
    {
        [Column(Name = "gosterimId"), PrimaryKey]  
        public int GosterimId { get; set; }

        [Column(Name = "filmId")]
        public int FilmID { get; set; }
        [Column(Name = "salonID")]
        public int SalonID { get; set; }
        [Column(Name = "gosterimYili")]
        public int GosterimYil { get; set; }
    }
}
