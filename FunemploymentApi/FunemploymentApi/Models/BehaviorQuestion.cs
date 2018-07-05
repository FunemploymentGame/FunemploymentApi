using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunemploymentApi.Models
{
    public class BehaviorQuestion
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
