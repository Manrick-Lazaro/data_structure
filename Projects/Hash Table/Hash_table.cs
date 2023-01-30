using System;
using System.Collections;

class MainClass
{
  public static void Main()
  {
    Hash x = new Hash();

    x.Insert(50, "valor 01");
    x.Insert(41, "valor 02");

    IEnumerator z = x.Elementos();

    Console.WriteLine("Quantidade de itens - {0}", x.Size());

    while(z.MoveNext()){
        No y = (No)z.Current;
        Console.WriteLine(y.GetElement());
    }

    Console.WriteLine("--------------------");

    x.Remove(41);

    Console.WriteLine("Quantidade de itens - {0}", x.Size());

    z = x.Elementos();

    while(z.MoveNext()){
        No y = (No)z.Current;
        Console.WriteLine(y.GetElement());
    }

    Console.WriteLine("--------------------");

    x.Insert(70, "Valor 03");
    x.Insert(12, "Valor 04");
    x.Insert(25, "Valor 05");

    Console.WriteLine("Quantidade de elementos - {0}",x.Size());

    z = x.Elementos();

    while(z.MoveNext()){
        No y = (No)z.Current;
        Console.WriteLine(y.GetElement());
    }

    Console.WriteLine("--------------------");

    No i = x.Search(12);

    Console.WriteLine("key: {0} - elemento {1}", i.GetKey(), i.GetElement());
  }
}

class NO_SUCH_KEY : Exception
{
    public NO_SUCH_KEY(string text) : base(text)
    {
 
    }    
}

class Hash
{
  private int quantItens;
  private int size;
  private No[] estrutura;

  public Hash()
  {
    size = 3;
    estrutura = new No[size];
    quantItens = 0;
  }

  public int Size()
  {
    return quantItens;
  }
 
  public bool IsEmpty()
  {
    return Size() == 0;
  }

  public int FunçãoHash (int key)
  {
    return key % size;
  }
 
   public bool FC ()
  {
    double x = (double)Size();
    double y = (double)size;
    double valor = x / y;

    return valor >= 0.50;
  }

    public void Insert (int key, object element)
  {
    No n = new No (key, element);
   
    int indice = 0;
   
    if(FC())
    {
      IEnumerator x = Elementos();
     
      size = size * 2;
     
      No[] newArray = new No[size];

      while(x.MoveNext())
      {
        No y = (No)x.Current;
        indice = FunçãoHash(y.GetKey());
        newArray[indice] = y;
      }

      estrutura = newArray;
    }
   
    indice = FunçãoHash(n.GetKey());
   
    bool flag = true;
   
    while(flag == true)
    {
      if(estrutura[indice] != null)
        if((estrutura[indice]).GetKey() != -1)
          indice = (indice+1) % size;
        else
          flag = false;
      else
        flag = false;
    }

    estrutura[indice] = n;  
    quantItens++;
  }

    public No Remove (int key)
  {
    int indice = FunçãoHash(key);
    int  flag2 = 1;
    bool flag =  true;
    No n = new No(-1, null);

    while(flag == true)
    {
      if(estrutura[indice] == null)
      {
        flag = false;
        throw new NO_SUCH_KEY("Chave não encontrada");
      }
      else
      {
        if(estrutura[indice].GetKey() == key)
        {
          n.SetKey(estrutura[indice].GetKey());
          n.SetElemento(estrutura[indice].GetElement());

          estrutura[indice].SetElemento(null);
          estrutura[indice].SetKey(-1);
         
          flag = false;

          quantItens--;
        }
        else
        {
          indice = (indice + 1) % size;
          flag2++;
        }
      }
    }
    if(flag==true)
    {
      throw new NO_SUCH_KEY("Chave não encontrada");
    }

    return n;
  }

  public No Search(int key)
  {
    int indice = FunçãoHash(key);
    int  flag2 = 1;
    bool flag =  true;

    while(flag == true)
    {
      if(estrutura[indice] == null)
      {
        flag = false;
        throw new NO_SUCH_KEY("Chave não encontrada");
      }
      else
      {
        if(estrutura[indice].GetKey() == key)
        {
          return estrutura[indice];
        }
        else
        {
          indice = (indice + 1) % size;
          flag2++;
        }
      }
    }
    if(flag==true)
    {
      throw new NO_SUCH_KEY("Chave não encontrada");
    }
    return null;
  }

  public IEnumerator Elementos()
  {
    ArrayList keys = new ArrayList();
   
    for (int i = 0; i < size; i++)
    {
      if(estrutura[i] != null)
        if((estrutura[i]).GetKey() != -1)
          keys.Add((estrutura[i]));
    }
   
    return keys.GetEnumerator();
  }

  public IEnumerator Keys()
  {
    ArrayList keys = new ArrayList();
   
    for (int i = 0; i < size; i++)
    {
      if(estrutura[i] != null)
        if((estrutura[i]).GetKey() != -1)
          keys.Add((estrutura[i]).GetKey());
    }
   
    return keys.GetEnumerator();
  }
}

class No
{
  private int key;
  private object elemento;

  public No(int key, object elemento)
  {
    this.key = key;
    this.elemento = elemento;
  }

  public No()
  {
    this.key = -1;
    this.elemento = null;
  }

  public void SetElemento(object elemento)
  {
    this.elemento = elemento;
  }

  public void SetKey(int key)
  {
    this.key = key;
  }

  public int GetKey()
  {
    return key;
  }

  public object GetElement()
  {
    return elemento;
  }
}