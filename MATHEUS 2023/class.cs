readonly Class.Orders order = new Class.Orders();
readonly Class.Items items = new Class.Items();

  Class ItemsList
  {
    public int ID {get; set;}
    public int Quantidade{get; set;}
  }

  List<Items> list = new List<Items>();

  .
  .
  .

   public void AdicionaItens() //Se produto já existe na lista, apenas somo a quantidade
   {
      int index = list.FindIndex(x=> x.ID == items.prod.ID);
      if(index == -1)
      {
        list.Add (Items {ID = items.prod.ID, Quantidade= items.prod.Quantidade});
      }
      else
      {
        list[index].Quantidade += qtd;
      }
   }

   public void EnviaLista()
   {
     orders.Imprimir(ref list);
   }
   StringBuilder sbString = new StringBuilder();

public void Imprimir(ref List<T>ListaSeparado)
{
  foreach(var i in ListaSeparado)
  {
    sbString.AppendLine(i)
  }
}