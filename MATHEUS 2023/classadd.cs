using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Caminho do arquivo XML
        string sXMLFile = MapPath("~/app_data/clientes.xml");

        //Criar o DataSet
        DataSet ds = new DataSet();
        //Preenche o DataSet com o XML
        ds.ReadXml(sXMLFile);

        //Verifica se existe extrutura
        if (ds.Tables.Count == 0)
        {
            //Cria a extrutura (colunas)
            DataTable dt = new DataTable("cliente");
            dt.Columns.Add("id");
            dt.Columns.Add("nome");
            dt.Columns.Add("email");
            dt.Columns.Add("telefone");
            ds.Tables.Add(dt);
        }
        //Cria uma nova linha
        DataRow dRow = ds.Tables[0].NewRow();

        //Seta os valores
        dRow["id"] = Guid.NewGuid(); //Adiciona um identificador único com ID
        dRow["nome"] = txtNome.Text;
        dRow["email"] = txtEmail.Text;
        dRow["telefone"] = txtPhone.Text;

        //Adiciona a linha no DataSet
        ds.Tables["cliente"].Rows.Add(dRow);

        //Salva no XML
        ds.WriteXml(sXMLFile);

        //Redireciona para a lista de clientes
        Response.Redirect("default.aspx");
    } 
    #endregion
}