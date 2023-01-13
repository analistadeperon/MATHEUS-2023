using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class TelaPrincipal : Form
{
public string strConn;

public TelaPrincipal()
{
  InitializeComponent();
  strConn = ("Data Source=Boson-PC\\SQLEXPRESS;Initial Catalog=db_Biblioteca;Integrated Security=true");
}
 
 
public class Produto
{
    public Int32 idProduto { get; set; } = 0;
    public string descricao { get; set; } = "";
    public DateTime dataCompra { get; set; } = DateTime.Now;
    public DateTime? dataUltimaVenda { get; set; }
    public Boolean ativo { get; set; }
    public float valor { get; set; } = 0f;
 
    public Produto() { }
}
 
// Extensão de nossa classe 
 
public static class ProdutoExtentions
{
    /// <summary>
    /// Extensão para List<Produto> retornando uma tabela convertida com base nos dados de nosso List
    /// </summary>
    /// <param name="produtos"></param>
    /// <returns>DataTable</returns>
    public static DataTable getDataTable(this List<Produto> produtos)
    {
        // Criamos a tabela produtos
        DataTable table = new DataTable("produtos");
 
        // criamos a estrutura da tabela com base na estrutura de nossa classe
        table.Columns.Add("idProduto", typeof(Int32));
        table.Columns.Add("descricao", typeof(string));
        table.Columns.Add("dataCompra", typeof(DateTime));
        table.Columns.Add("dataUltimaVenda", typeof(DateTime));
        table.Columns.Add("ativo", typeof(Boolean));
        table.Columns.Add("valor", typeof(float));
 
        // criamos a instancia de nossa linha
        DataRow row = table.NewRow();
 
        // aqui vamos ler nosso list e inserir os dados em nossa tabela
        foreach (Produto produto in produtos)
        {
            row = table.NewRow();
 
            row["idProduto"] = produto.idProduto;
 
            row["descricao"] = produto.descricao;
 
 
            row["dataCompra"] = produto.dataCompra;
 
            // Quando existe a possibilidade de retorno de um valor nulo recomendo o tratamento deste modo
            // tive alguns problemas e esta foi a maneira que consegui resolver, 
            // se alguem resolveu de outra maneira por favor poste aqui para que possamos apresentar outras soluções !!!
 
            if (produto.dataUltimaVenda == null)
            {
                row["dataUltimaVenda"] = DBNull.Value;
            }
            else
            {
                row["dataUltimaVenda"] = produto.dataUltimaVenda;
            }
 
            row["ativo"] = produto.ativo;
 
            row["valor"] = produto.valor;
 
            table.Rows.Add(row);
 
        }
 
        // retorno de nossa tabela
        return table;
    }
 
}