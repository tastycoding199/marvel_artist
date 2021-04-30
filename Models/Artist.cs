using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class Artist
    {
        [Required()]
        public int ArtistId { get; set; }

        [StringLength(50,ErrorMessage ="The name can not be greater than 50 character.")]
        [Required(ErrorMessage ="Artist name must be not NULL.")]
        public string Name { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Day Of Birth can not be null.")]
        public DateTime DayOfBirth { get; set; }

        [StringLength(70)]
        public string Education { get; set; }

        [StringLength(70)]
        public string Hometown { get; set; }


        public MavelCharacter MavelCharacter { get; set; }

        public List<Movies> Movies  { get; set; }
    }
}
