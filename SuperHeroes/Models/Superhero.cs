using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroes.Models
{
    public class Superhero
    {
        [Key]
        public string name { get; set; }
        public string alterEgo { get; set; }
        public string primaryAbility { get; set; }
        public string secondaryAbility { get; set; }
        public string catchPhrase { get; set; }
    }
}