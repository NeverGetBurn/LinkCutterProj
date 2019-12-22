using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkCutter.Models
{
    public class Link
    {
        public Guid Id { get; set; }

        [Required (ErrorMessage = "Не указан URL")] 
        [Url (ErrorMessage = "Неверный формат URL")]
        public string LongName { get; set; } //полная ссылка

        public string ShortName { get; set; } // короткая ссылка

        public string CreationTime { get; set; } // DateTime.Now.ToString("dd:MM:yyyy")

        public int RedirectCount { get; set; }
    }
}
