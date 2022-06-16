using Bootstrap.Models;
using System.Collections.Generic;

namespace Bootstrap.ViewModels
{
    public class HomeVM
    {
        public List<Caption> captions { get; set; }
        public List<Card> cards { get; set; }
        public List<About> abouts { get; set; }
        public List<Settings> settings { get; set; }
    }
}
