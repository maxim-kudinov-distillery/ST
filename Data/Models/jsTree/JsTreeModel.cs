using System.Collections.Generic;

namespace Data.Models.jsTree
{
    //names should be in lower case to match json data
    public class JsTreeModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public ICollection<JsTreeModel> children { get; set; }
    }
}
