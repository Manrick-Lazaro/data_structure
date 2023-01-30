using System;
 
class Program {
  public static void Main () {
    Heap x = new Heap();
 
    x.Insert(30, "valor 1");
 
    Console.WriteLine("size - {0}", x.Size());
    Console.WriteLine("Valor minimo - {0}\n\n", x.Min().getKey());
 
    x.Insert(31, "valor 2");
 
    Console.WriteLine("size - {0}", x.Size());
    Console.WriteLine("Valor minimo - {0}\n\n", x.Min().getKey());
 
    x.Insert(28, "valor 3");
 
    Console.WriteLine("size - {0}", x.Size());
    Console.WriteLine("Valor minimo - {0}\n\n", x.Min().getKey());
 
    x.Remove();
 
    Console.WriteLine("size - {0}", x.Size());
    Console.WriteLine("Valor minimo - {0}\n\n", x.Min().getKey());
  }
}
 
class ErroVazio : Exception {
  public ErroVazio(string texto) : base(texto) {}
}
 
class Heap {
  private int tamanho;
  private No[] elements;
 
  public Heap () {
    tamanho = 1;
    elements = new No[10];
  }
 
  public void Insert (int key, object element) {
    No n = new No (key, element); // crio um novo no
   
    if (tamanho == elements.Length) { // verifico se esta cheio
      No[] newVector = new No[elements.Length * 2];
      for (int i = 1; i < elements.Length; i++) {
        newVector[i] = elements[i];
      }
      elements = newVector;
    }
   
    elements[tamanho] = n; // adiciono novo no a ultima posição da lista.
   
    if(Size() > 1) {
      if(n.getKey() < elements[tamanho / 2].getKey()){ // comparo com o pai
        UpHeap(tamanho);
      }
    }
   
    tamanho++;
  }
 
  public No Remove () {
    if(Size() == 0) {
      throw new ErroVazio("Vetor vazio");
    }
   
    No r = elements[1];
   
    SwampNos(1, tamanho-1);
   
    elements[tamanho-1].setElement("");
    elements[tamanho-1].setKey(-1);

    tamanho--;

    DownHeap(1);
   
    return r;
  }
 
  public bool IsEmpty() {
    return Size == 0;
  }
 
  public int Size() {
    return tamanho - 1;
  }
 
  public No Min() {
    return elements[1];
  }
 
  public void UpHeap(int indice) {
    SwampNos(indice, indice/2);
   
    indice = indice / 2;
   
    if(indice > 1) {
      if(elements[indice/2].getKey() > elements[indice].getKey()){
        UpHeap(indice);
      }
    }
  }
 
  public void DownHeap(int indice) {
    if ((indice*2)+1 <= tamanho) {
      if (elements[(indice*2)+1].getKey() != -1) {
        int valor01 = elements[(indice*2)].getKey();
        int valor02 = elements[(indice*2)+1].getKey();
        int valorMin;

        if (valor01 < valor02) {
          valorMin = indice*2;
        } else {
          valorMin = (indice*2)+1;
        }

        if (elements[indice].getKey() > elements[valorMin].getKey()){
          SwampNos(indice, valorMin);
          DownHeap(valorMin);
        }
      }
      else {
        if (elements[indice].getKey() > elements[indice*2].getKey()){
          SwampNos(indice, indice*2);
          DownHeap(indice*2);
        }
      }
    }
  }
 
  public void  SwampNos (int tam, int indice) { // troca os nods
    int key = elements[tam].getKey();
    object elem = elements[tam].getElement();

    elements[tam].setElement(elements[indice].getElement());
    elements[tam].setKey(elements[indice].getKey());

    elements[indice].setElement(elem);
    elements[indice].setKey(key);
  }
}

class No {
    private int key;
    private object element;
   
    // Construtor
    public No (int key, object element) {
        this.element = element;
        this.key = key;
    }
 
    // Sets
    public void setKey (int key) {
        this.key = key;
    }
    public void setElement (object element) {
        this.element = element;
    }
 
    // Gets
    public int getKey () {
        return this.key;
    }
    public object getElement () {
        return this.element;
    }
 
    public override string ToString(){
      return element.ToString();
    }
}