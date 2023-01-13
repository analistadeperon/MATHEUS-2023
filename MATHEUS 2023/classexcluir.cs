using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Excluir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Caminho do arquivo XML
        string sXMLFile = MapPath("~/app_data/clientes.xml");

        //Criar o DataSet
        DataSet ds = new DataSet();
        //Preenche o DataSet com o XML
        ds.ReadXml(sXMLFile);

        string strID = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(strID))
        {
            //Selecionar e deletar a linha com o ID da QueryString
            ds.Tables["cliente"].Select(" id = '" + strID + "'")[0].Delete();
            //Aplicar as alterações no DataSet
            ds.AcceptChanges();

            //Salva no XML
            ds.WriteXml(sXMLFile);

            //Redireciona para a lista de clientes
            Response.Redirect("default.aspx");
        }
    }
}