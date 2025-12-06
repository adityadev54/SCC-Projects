using System.ComponentModel.DataAnnotations;

namespace GoldenMenu.Models.Auth
{
    public class Preference
    {
        [Key]
        public int PrefID { get; set; }
        public int UserID { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Allergies { get; set; }
    }
}
