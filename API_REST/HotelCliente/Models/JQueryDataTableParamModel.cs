using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelCliente.Models
{
    public class JQueryDataTableParamModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Dictionary<string, string> search { get; set; }
        public List<JQDTColumnOrder/*Dictionary<string, string>*/> order { get; set; }
        public List<JQDTColumn/*Dictionary<string, string>*/> columns { get; set; }

    }

    public enum JQDTColumnOrderDirection
    {
        asc, desc
    }

    public class JQDTColumnOrder
    {
        public int column { get; set; }
        public JQDTColumnOrderDirection dir { get; set; }
    }

    public class JQDTColumnSearch
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class JQDTColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public JQDTColumnSearch search { get; set; }
    }
}