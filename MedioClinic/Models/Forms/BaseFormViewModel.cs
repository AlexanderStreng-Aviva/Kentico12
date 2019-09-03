using System.Collections.Generic;
using System.Linq;

namespace MedioClinic.Models.Forms
{
    public abstract class BaseFormViewModel
    {
        protected IDictionary<string, object> GetFields(params KeyValuePair<string, object>[] fields) => fields.ToDictionary(field => field.Key, field => field.Value);
    }
}