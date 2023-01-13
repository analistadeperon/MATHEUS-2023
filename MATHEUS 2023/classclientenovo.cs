using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Caminho do arquivo XML
        string sXMLFile = Server.MapPath("~/app_data/clientes.xml");
        //Criar o DataSet
        DataSet ds = new DataSet();
        //Preenche o DataSet com o XML
        ds.ReadXml(sXMLFile);

        /*Verificando se existem dados, caso exista, vai popular o repeater
        Se não existir dados no DataSet, mostará a tr noRows com a mensagem "Nenhum item encontrado"*/
        if (ds.Tables["cliente"] != null)
        {
            //DataSet como DataSource do repeater
            repClenetes.DataSource = ds;
            repClenetes.DataBind();
        }
        else
            noRows.Visible = true;
    }
}