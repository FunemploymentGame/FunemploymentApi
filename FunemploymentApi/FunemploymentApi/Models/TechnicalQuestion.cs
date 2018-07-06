using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunemploymentApi.Models
{
    public class TechnicalQuestion
    {
        public int ID { get; set; }

        [Required]
        public string ProblemDomain { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        [Required, Range(1,5, ErrorMessage = "Difficulty should be between 1 and 5")]
        public int Difficulty { get; set; }
        //public string SuggestedAnswer { get; set; }
        //public List<string> Companies { get; set; }
    }
}
