using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Termin4CSharp.Utils {
    class Utils {

        public static Dictionary<string, object> GetAttributeInfo(Object paramObj) {
            Dictionary<string, object> attributeValues = new Dictionary<string, object>();
            Type t = paramObj.GetType();
            var names = t.GetMembers()
                        .Select(x => x.Name)
                        .Where(x => !Regex.IsMatch(x, "([g|s]et)|(ToString|Equals|GetHashCode|GetType|.ctor)"));
            //Console.WriteLine(string.Join(", ", names));

            foreach (string attName in names) {
                PropertyInfo pi = t.GetProperty(attName);
                attributeValues[attName] = pi == null ? "" : pi.GetValue(paramObj, null);
            }
            return attributeValues;
        }
    }
}
