using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.Model
{
    public interface IModel
    {
        /// <summary>
        /// Get the IModels identifying attributes, with key as attributename and value is the attributevalue
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> GetIdentifyingAttributes();

        /// <summary>
        /// Gets, if any, the referenced IModel(s) for the IModel
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> GetReferencedModels();
    }
}
