using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class URL
    {
        string url;
        string title;
        string browser;
        public URL(string url, string title, string browser)
        {
            this.url = url;
            this.title = title;
            this.browser = browser;
        }

        public string getData()
        {
            return browser + " - " + title + " - " + url;
        }
    }

}
