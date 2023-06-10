void Insere(ref tp_no r, int x)
{
   if (r == null)
   {
      r = new tp_no();
      r.valor = x;
   }
   else if (x < r.valor)
      Insere(ref r.esq, x);
   else
      Insere(ref r.dir, x);
}

tp_no Busca(tp_no r, int x)
{
   if (r == null)
      return null;
   else if (x == r.valor)
      return r;
   else if (x < r.valor)
      return Busca(r.esq, x);
   else
      return Busca(r.dir, x);
}

tp_no RetornaMaior(ref tp_no r)
{
   if (r.dir == null)
   {
      tp_no p = r;
      r = r.esq;
      return p;
   }
   else
      return RetornaMaior(ref r.dir);
}

tp_no Remove(ref tp_no r, int x)
{
   if (r == null)
      return null;     
   else if (x == r.valor)
   {       
      tp_no p = r;
      if (r.esq == null)        // nao tem filho esquerdo
         r = r.dir;
      else if (r.dir == null)  // nao tem filho direito
         r = r.esq;
      else                          // tem ambos os filhos
      {
         p = RetornaMaior(ref r.esq);
         r.valor = p.valor;
      }
      return p;
   }
   else if (x < r.valor)
      return Remove(ref r.esq, x);
   else
      return Remove(ref r.dir, x);
}

void EmOrdem(tp_no r)
{
   if (r != null)
   {
      EmOrdem(r.esq);
      Console.WriteLine(r.valor);
      EmOrdem(r.dir);
   }
}

void PreOrdem(tp_no r)
{
   if (r != null)
   {
      Console.WriteLine(r.valor);
      PreOrdem(r.esq);
      PreOrdem(r.dir);
   }
}

void PosOrdem(tp_no r)
{
   if (r != null)
   {
      PosOrdem(r.esq);
      PosOrdem(r.dir);
      Console.WriteLine(r.valor);
   }
}

int menu()
{
    Console.Clear();
    System.Console.WriteLine("###### Menu ######");
    System.Console.WriteLine("1 - Inserir");
    System.Console.WriteLine("2 - Pesquisar");
    System.Console.WriteLine("3 - Remover");
    System.Console.WriteLine("4 - Exibir valores");
    System.Console.WriteLine("5 - Sair");
    System.Console.WriteLine("____________________");
    System.Console.WriteLine("Informe a opção desejada: ");
    int opc = Convert.ToInt32(Console.ReadLine());
    return opc;
}

tp_no raiz = null;


//Principal
int opcao = 0;
while (opcao != 5){
    Console.Clear();
    if (opcao == 1){
        System.Console.Write("Digite um valor inteiro para inserir: ");
        int valor = Convert.ToInt32(Console.ReadLine());
        Insere(ref raiz, valor);
        System.Console.WriteLine("Valor inserido com sucesso.");
        Console.ReadKey();
    }else if(opcao == 2){
         System.Console.Write("Digite um valor inteiro para pesquisar: ");
         int valor = Convert.ToInt32(Console.ReadLine());
      if (Busca(raiz, valor) == null){
         System.Console.WriteLine("Valor não encontrado. ");
         Console.ReadKey();
      }else{
         System.Console.WriteLine("Valor encontrado. ");
         Console.ReadKey();
      }
    }else if(opcao == 3){
         System.Console.Write("Digite um valor inteiro para remover: ");
         int valor = Convert.ToInt32(Console.ReadLine());
         if(Remove(ref raiz, valor) == null){
            System.Console.WriteLine("Valor não encontrado. ");
            Console.ReadKey();
         }else{
         System.Console.WriteLine("Valor removido com sucesso. ");
         Console.ReadKey();
         }
    }else if(opcao == 4){
      System.Console.WriteLine("Como você deseja exibir os resultados? \n1. Em Ordem\n2. Pré Ordem\n3. Pós Ordem\n_________");
      int exibir = Convert.ToInt32(Console.ReadLine());
      if (exibir == 1){
         EmOrdem(raiz);
         Console.ReadKey();
      }else if (exibir == 2){
         PreOrdem(raiz);
         Console.ReadKey();
      }else if (exibir == 3){
         PosOrdem(raiz);
         Console.ReadKey();
      }
    }
    opcao = menu();


}
class tp_no
{
   public tp_no esq = null;
   public int valor = 0;
   public tp_no dir = null;
}