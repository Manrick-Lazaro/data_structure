using System;
using System.Collections;


class Grafo {
  private ArrayList vertice;
  private ArrayList aresta;
  private int numVertice, numAresta;
  private int[,] matriz;


  public Grafo () {
    this.vertice = new ArrayList();
    this.aresta = new ArrayList();
    this.numVertice = 0;
    this.numAresta = 0;
  }


  // ACESSO
  public bool Adjacente (Vertice v, Vertice w) {
    for (int i = 0; i < this.numAresta; i++) {
      Aresta aresta = (Aresta)this.aresta[i];
     
      Vertice inicio = aresta.GetInicio();
      Vertice fim = aresta.GetFim();


      if (
        v == inicio && w == fim ||
        v == fim && w == inicio
      )
        return true;
      else
        return false;
    }
    return false;
  }


  public void  Substituir (Vertice v, object o) {
    v.SetValue(o);
  }


  public void Substituir (Aresta w, object o) {
    w.SetValue(o);
  }


  public int GetGrau (Vertice v) {
    return v.GetGrau();
  }


  public object Oposto (Vertice v, Aresta a) {
    Vertice inicio = a.GetInicio();
    Vertice fim = a.GetFim();


    if (inicio == null || fim == null)
      return null;
    else if (inicio == v)
      return fim;
    else if (fim == v)
      return inicio;


    return null;
  }


  // ATUALIZAÇÃO
  public void InsertVertice (Vertice v) {
    vertice.Add(v);    
    numVertice++;
  }


  public Aresta InsertAresta (Vertice v, Vertice w, object o) {
    Aresta a = new Aresta(o);


    v.SetAresta(a);
    w.SetAresta(a);


    a.SetVertice(v, w);


    aresta.Add(a);
    numAresta++;


    return a;
  }


  public void InsertArestaDirecionada (Vertice v, Vertice w, object o) {
   
  }


  public void RemoverVertice (Vertice v) {
    ArrayList arestasV = v.GetAresta();


    Aresta aresta;
    Vertice inicio;
    Vertice fim;


    for (int i = 0; i < arestasV.Count; i++) {
      aresta = (Aresta)arestasV[i];


      inicio = aresta.GetInicio();
      fim = aresta.GetFim();


      inicio.RemoveAresta(aresta);
      fim.RemoveAresta(aresta);


      aresta.RemoveVerticeInicio();
      aresta.RemoveVerticeFim();


      this.aresta.Remove(aresta);
    }


    this.vertice.Remove(v);
    numVertice--;
    numAresta--;
  }


  public void RemoveAresta (Aresta a) {
    Vertice fim = a.GetFim();
    Vertice inicio = a.GetInicio();


    fim.RemoveAresta(a);
    inicio.RemoveAresta(a);


    a.RemoveVerticeFim();
    a.RemoveVerticeInicio();


    this.aresta.Remove(a);


    this.numAresta--;
  }


  // INTERAÇÃO
  public ArrayList Vertices () {
    return this.vertice;
  }


  public ArrayList Arestas () {
    return this.aresta;
  }


  public ArrayList ArestasIncidentes (Vertice v) {
    return v.GetAresta();
  }
 
 


  public void PrintMatriz () {
    matriz = new int [this.numVertice , this.numVertice];
    string valorMatriz = "";


    for (int i = 0; i < this.numVertice; i++) {
      for (int j = 0; j < this.numVertice; j++) {
        bool adj = Adjacente((Vertice)this.vertice[i], (Vertice)this.vertice[j]);
        if (adj)
          matriz[i, j] = 1;
        else
          matriz[i, j] = 0;
      }
    }


    for (int i = 0; i < this.numVertice; i++) {
      for (int j = 0; j < this.numVertice; j++) {
        valorMatriz += matriz[i, j] + "\t";
      }
      valorMatriz += "\n";
    }


    Console.WriteLine(valorMatriz);
  }


 
}


class Vertice {
  private object value;
  private ArrayList aresta;


  public Vertice (object value) {
    this.value = value;
    this.aresta = new ArrayList();
  }


  public Vertice () {
    this.value = null;
    this.aresta = new ArrayList();
  }


  // SETs
  public void SetValue (object value) {
    this.value = value;
  }


  public void SetAresta (Aresta aresta) {
    this.aresta.Add(aresta);
  }
 
  // GETs
  public object GetValue () {
    return this.value;
  }


  public ArrayList GetAresta () {
    return this.aresta;
  }


  public int GetGrau () {
    return aresta.Count;
  }


  // REMOVE
  public void RemoveAresta (Aresta a) {
    aresta.Remove(a);
  }
}


class Aresta {
  private object value;
  private Vertice verticeInicio;
  private Vertice verticeFim;


  // construtor
  public Aresta (object value, Vertice v, Vertice w) {
    this.value = value;
    verticeInicio = v;
    verticeFim = w;
  }


  public Aresta (object value) {
    this.value = value;
    verticeInicio = null;
    verticeFim = null;
  }


  public Aresta () {
    this.value = null;
    verticeInicio = null;
    verticeFim = null;
  }


   // SETs
  public void SetValue (object value) {
    this.value = value;
  }


  public void SetVertice (Vertice v, Vertice w) {
    this.verticeInicio = v;
    this.verticeFim = w;
  }


  // GETs
  public object GetValue () {
    return this.value;
  }


  public Vertice GetInicio () {
    return this.verticeInicio;
  }


  public Vertice GetFim () {
    return this.verticeFim;
  }




  // REMOVE
  public void RemoveVerticeInicio () {
    this.verticeInicio = null;
  }


  public void RemoveVerticeFim () {
    this.verticeFim = null;
  }
}


class Program {
  public static void Main (string[] args) {
    //Console.WriteLine ("Hello World");


    Vertice v1 = new Vertice("A");
    Vertice v2 = new Vertice("B");
    Vertice v3 = new Vertice("C");


    Grafo x = new Grafo ();


    x.InsertVertice(v1);
    x.InsertVertice(v2);
    x.InsertVertice(v3);


    x.InsertAresta(v1, v1, "valor 01 da aresta.");


    ArrayList vertices = x.Vertices();


    for (int i = 0; i < vertices.Count; i++) {
      Vertice y = (Vertice)vertices[i];
      Console.Write("{0} ", y.GetValue());
    }


    Console.WriteLine("");


    x.PrintMatriz();


    Console.WriteLine("---------------------");


    x.RemoverVertice(v1);


    vertices = x.Vertices();


    for (int i = 0; i < vertices.Count; i++) {
      Vertice y = (Vertice)vertices[i];
      Console.Write("{0} ", y.GetValue());
    }


    Console.WriteLine("");


    x.PrintMatriz();
  }
}