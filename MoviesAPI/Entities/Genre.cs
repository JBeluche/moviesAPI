using MoviesAPI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Genre : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
       [FirstLetterUppercase]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var firstLetter = Name[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                yield return new ValidationResult("First letter is not uppercase", new string[] { nameof(Name) });
            }
        }
    }
}
