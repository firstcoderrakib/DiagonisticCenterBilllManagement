using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagonisticCenterBilllManagement.Model
{
    [Serializable]
    public class Types
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public Types()
        {

        }

        public Types(string typeName)
        {

            this.TypeName = typeName;
        }

    }
}