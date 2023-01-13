using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
namespace WebMPD
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["registros"] == null)
            {
                // Cria lista para o objeto
                List<Menssagem Recados> msg = new List<Menssagem Recados>();
 
                // Adiciona dados ao objeto
                msg.Add(new Menssagem recados(1, "IOS", "Olá Pessoal"));
                msg.Add(new Menssagem recados(2, "SKILL", "Bem-vindos ao Desenvolvimento Aberto," +
                                      " adicione, altere e exclua dados desta tabela"));
 
                // Adiciona objeto a sessão
                Session["registros"] = msg;
            }
 
            // Cria pagina no método HTTP GET
            if (Request.HttpMethod.Equals("GET"))
            {
                doGet();
            }
        }
 
        private void doGet()
        {
            // Cria estilo CSS
            Response.Write("<head>");
            Response.Write("<style>");
            Response.Write("td, th {");
            Response.Write("border: none;");
            Response.Write("background-color: #dddddd;");
            Response.Write("padding: 5px;");
            Response.Write("width: 200px; }");
            Response.Write("</style>");
            Response.Write("</head>");
 
            // Titulo da pagina
            Response.Write("<h1>Desenvolvimento Aberto - Listas </h1>");
 
            // Cria tabela
            Response.Write("<table>");
            Response.Write("<tr>");
            Response.Write("<th>ID:</th>");
            Response.Write("<th>Nome:</th>");
            Response.Write("<th>Comentário:</th>");
            Response.Write("<th>Ação:</th>");
            Response.Write("</tr>");
 
            // Recupera objeto da sessão
            List<Menssagem> registros = (List<Menssagem>)Session["registros"];
 
            // Itera objeto
            foreach (Menssagem reg in registros)
            {
                Response.Write("<tr>");
                Response.Write("<td>" + reg.Id + "</td>");
                Response.Write("<td>" + reg.Nome + "</td>");
                Response.Write("<td>" + reg.Msg + "</td>");
 
                // Link de edição
                Response.Write("<td><center>");
                Response.Write("<a href='udados.aspx?identificador=" + reg.Id + "'>Editar</a> | ");
                Response.Write("<a href='ddados.aspx?identificador=" + reg.Id + "'>Apagar</a>");
                Response.Write("</center></td>");
                Response.Write("</tr>");
            }
 
            Response.Write("</table>");
 
            // Define link para formulario de adicionar dados
            Response.Write("<P> <a href='adados.aspx'>Adicione um comentário</a> </p>");
        }
    }
}