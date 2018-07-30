using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace TestWebGraph
{
    /// <summary>
    /// ist die Verbindung zur Homepage
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
    [System.Web.Script.Services.ScriptService]
    public class Content : System.Web.Services.WebService
    {
        public Content()
        {

            //Heben Sie die Kommentarmarkierung für die folgende Zeile auf, wenn Designkomponenten verwendet werden 
            //InitializeComponent(); 
        }
        [WebMethod]
        public List<Edge> MST(List<Node> nodes, List<Edge> edges)
        {
            List<Edge> cloneEdges = edges.Select(item => (Edge)item.Clone()).ToList();
            cloneEdges.ForEach(s => s.color = "blue");
            var graph = new WebGraph(nodes, edges);
            if (graph.Connectivity())
            {
                return null;
            }
            graph.GetMST();

            for (int i = 0; i< cloneEdges.Count; ++i)
            {
                if (graph.edges[i].color == "red")
                    cloneEdges.Where(x => x.id == graph.edges[i].id).ToList().ForEach( s => s.color ="red");
            }
            
            return cloneEdges;
        }
    }
}//TestWebGraph
