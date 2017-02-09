using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Utils {
    class Utils { 

        public static Dictionary<string, object> GetAttributeInfo(Type t) {

            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
                Console.WriteLine(m.Name);


            return null;
        }

    }
}
