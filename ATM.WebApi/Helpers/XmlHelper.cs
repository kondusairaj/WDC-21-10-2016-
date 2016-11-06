using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;
using System.Xml;
using System.IO;
using System.Web;

namespace ATM.Helpers
{
    public class XmlHelper
    {
        public List<CurrencyDenomination> CurrencyDenominations(string fileName)
        {
            var denominations = new List<CurrencyDenomination>();

            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            
            FileStream fs = new FileStream(GetAbsolutePath(fileName), FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Denomination");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                denominations.Add(new CurrencyDenomination {
                    Value = Convert.ToInt32(xmlnode[i].ChildNodes.Item(0).InnerText.Trim())
                });
            }
            return denominations;
        }

        public string GetAbsolutePath(string file)
        {
            if (HttpContext.Current == null)
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\" + file;
            }
            return HttpContext.Current.Server.MapPath("~/App_Data/"+file);
        }
    }
}
