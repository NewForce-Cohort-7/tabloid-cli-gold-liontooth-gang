using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TabloidCLI.Models
{

    public class Journal

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }

        //needed to return a string that rep the obj Journal, when using method list() to display each journals in JournalManager.cs
        public override string ToString()
        {
            return $"{Title}| {CreateDateTime}";
        }
    }
}
