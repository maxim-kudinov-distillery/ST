using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.Models.jsTree
{
    //names should be in lower case to match json data
    public class JsTreeModel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name ="text")]
        public string Text { get; set; }

        [DataMember(Name ="type")]
        public string Type { get; set; }

        [DataMember(Name ="children")]
        public ICollection<JsTreeModel> Children { get; set; }
    }
}
