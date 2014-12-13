using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTeeL
{
    class Letter
    {
        public string Id { get; set; }
        public string First { get; set; }
        public string Mid { get; set; }
        public string Final { get; set; }
        public string Iso { get; set; }
        public bool ToPrev { get; set; }
        public bool ToNext { get; set; }
        public string LA { get; set; }
    }
}
