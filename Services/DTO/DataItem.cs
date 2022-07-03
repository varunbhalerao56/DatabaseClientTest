using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseClient.Services
{
    public class DataItem
    {
        public DataItem(string fieldName, dynamic value)
        {
            FieldName = fieldName;
            Value = value;
        }

        public string FieldName { get; set; }
        public dynamic Value { get; set; }

        public Dictionary<string, dynamic> ToDictionary()
        {

            return new Dictionary<string, dynamic> 
            {
                {"fieldName", FieldName},
                {"value", Value}
            };
        }
    }
}
