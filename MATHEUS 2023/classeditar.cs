using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Editar : System.Web.UI.Page
{
    DataSet ds;
    string sXMLFile = HttpContext.Current.Server.MapPath("~/app_data/clientes.xml");

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Pegando o ID do cliente através da QueryString id.
            string strID = Request.QueryString["id"];
            //Criando o DataSet
            ds = new DataSet();
            //Preenche o DataSet com o XML
            ds.ReadXml(sXMLFile);
            //Fazer uma busca no DataSet para encontrar o cliente com o ID da QueryString
            DataRow dRow = ds.Tables["cliente"].Select(" id = '" + strID + "'")[0];
            //Preenchendo os campos com os valores do DataRow
            txtNome.Text = Convert.ToString(dRow["nome"]);
            txtEmail.Text = Convert.ToString(dRow["email"]);
            txtPhone.Text = Convert.ToString(dRow["telefone"]);
        }
    } 
    #endregion

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Pegando o ID do cliente através da QueryString.
        string strID = Request.QueryString["id"];
        //Criando o DataSet
        ds = new DataSet();
        //Preenche o DataSet com o XML
        ds.ReadXml(sXMLFile);

        //Fazer uma busca no DataSet para encontrar o cliente com o ID da QueryString
        DataRow dRow = ds.Tables["cliente"].Select(" id = '" + strID + "'")[0];
        //Definindo os valores do DataRow com os valores do formulário.
        dRow["nome"] = txtNome.Text;
        dRow["email"] = txtEmail.Text;
        dRow["telefone"] = txtPhone.Text;

        //Atualizar o XML com os novos valores.
        ds.WriteXml(sXMLFile);
        Response.Redirect("default.aspx");

    } 
    #endregion
}
