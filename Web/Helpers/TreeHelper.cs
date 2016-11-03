using Data.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Web.Helpers
{
    public static class TreeHelper
    {
        public static MvcHtmlString RenderJsTree<T>(T node) where T : ITreeRenderable<T>
        {
            var nodeLi = new TagBuilder("li");
            nodeLi.MergeAttribute("Id", node.Id.ToString());
            nodeLi.InnerHtml = node.Name;

            if (node.Children != null && node.Children.Any())
            {
                nodeLi.MergeAttribute("data-jstree", "{\"opened\": true, \"type\": \"folder\", \"id\": " + node.Id.ToString() + "}");
                var ul = new TagBuilder("ul");
                foreach (var childNode in node.Children)
                {
                    ul.InnerHtml += RenderJsTree(childNode); 
                }

                nodeLi.InnerHtml += ul.ToString();
            }
            else
            {
                nodeLi.MergeAttribute("data-jstree", "{\"type\": \"leaf\", \"id\": " + node.Id.ToString() + "}");
            }

            return MvcHtmlString.Create(nodeLi.ToString());
        }
    }
}
