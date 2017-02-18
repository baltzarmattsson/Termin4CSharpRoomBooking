using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model {
    public interface IModel {
        Dictionary<string, object> GetIdentifyingAttributes();
        Dictionary<string, object> GetReferencedModels();
    }
}
