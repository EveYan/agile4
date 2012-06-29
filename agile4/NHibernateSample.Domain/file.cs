using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateSample.Domain
{
    public class file
    {
        public virtual int id { get; set; }
        public virtual string title { get; set; }
        public virtual string type { get; set; }
        public virtual DateTime time { get; set; }
        public virtual string text { get; set; }
        public virtual int userid { get; set; }
        public virtual String path { get; set; }
        public virtual String audit { get; set; }

        /*
        public void changename(string btitle)
        {
            title = btitle;
        }
        */

        
    }
}
