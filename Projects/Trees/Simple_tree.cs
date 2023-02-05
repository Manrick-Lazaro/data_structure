using System;
using System.Collections;


// ############# CLASSE DE TESTES ############# //
class MainClass {
    public static void Main() {
        ArvoreSimples simples=new  ArvoreSimples(1);
        simples.addChild(simples.root(),2);
        simples.addChild(simples.root(),3);


        Console.WriteLine(simples.height(simples.root()));


        IEnumerator x = simples.children(simples.root());


        while(x.MoveNext()){
            No y = (No)x.Current;
            Console.WriteLine(y.element());
        }
    }
}
// ############# CLASSE NÓ ############# //
class No {
    private Object elemento;
    private No pai;
    private ArrayList filhos;


    // construtor
    public No(No pai, Object elemento) {
        this.pai = pai;
        this.elemento = elemento;
        filhos = new ArrayList();
    }


    // SETs
    public void setElement(Object elemento) {
        this.elemento = elemento;
    }
    public void setPai(No pai) {
        this.pai = pai;
    }
    public void addChild(No filho) {
        this.filhos.Add(filho);
    }


    // GETs
    public Object element() {
        return this.elemento;
    }
    public No parent() {
        return this.pai;
    }
    public IEnumerator children() {
        return this.filhos.GetEnumerator();
    }
    public int childrenNumber() {
        return this.filhos.Count;
    }


    // REMOVE
    public void removeChild(No filho) {
        this.filhos.Remove(filho);
    }
}
// ############# CLASSE ARVORE SIMPLES ############# //
class ArvoreSimples {
    No raiz;
    int tamanho;


    // construtor
    public ArvoreSimples(Object objeto) {
        raiz = new No(null, objeto);
        tamanho = 0;
    }


    // metodos genéricos
    public int size() {
        return tamanho;
    }
    public int height(No v) {
        int altura = this.Height(v);
        return altura;
    }
    public int Height(No v) {
        if(isExternal(v)) {
            return 0;
        }
        int h = 0;
        IEnumerator x = children(v);
        while(x.MoveNext()){
            No y = (No)x.Current;
            h = Math.Max(h,Height(y));
        }
        return 1 + h;
    }
    public bool isEmpty() {
        return tamanho == 0;
    }
    public IEnumerator elements() {
        ArrayList emt = new ArrayList();
        emt.Add(PosOrder(raiz));
        return emt.GetEnumerator();
    }
    public Object PosOrder(No v) {
        if(isExternal(v)) {
            return v.element();
        }
        object o = v.element();
        IEnumerator x = children(v);
        while(x.MoveNext()){
            No y = (No)x.Current;
            PosOrder(y);
        }
        return o;
    }
    public IEnumerator nos() {
        ArrayList n = new ArrayList();
        n.Add(PosOrder(raiz));
        return n.GetEnumerator();
    }
    public No Nos(No n) {
        if(isExternal(n)) {
            return n;
        }
        No v = n;
        IEnumerator x = children(v);
        while(x.MoveNext()){
            No y = (No)x.Current;
            PosOrder(y);
        }
        return v;
    }


    // metodos de acesso
    public No root() {
        return raiz;
    }
    public No parent(No n) {
        return n.parent();
    }
    public IEnumerator children(No n) {
        return n.children();
    }


    // metodos consulta
    public bool isInternal(No n) {
        return (n.childrenNumber() > 0);
    }
    public bool isExternal(No n) {
        return (n.childrenNumber() == 0);
    }
    public bool isRoot(No n) {
        return n == raiz;
    }
    public int depth(No n) {
        int profundidade = this.Depth(n);
        return profundidade;
    }
    public int Depth(No n) {
        if(isRoot(n)) {
            return 0;
        }
        else {
            return 1 + Depth(n.parent());
        }
    }
   


    // metodos de atualização
    public void replace(No n, object o) {
        n.setElement(o);
    }
    public void swapElements(No n, No v) {
        Object temp = n.element();
        n.setElement(v.element());
        v.setElement(temp);
    }
    public void addChild(No n, object o) {
        No filho = new No(n, o);
        n.addChild(filho);
        tamanho++;
    }
    public Object remove(No n) {
        No pai = n.parent();
        if(pai != null) {
            pai.removeChild(n);
        }
        else {
            throw new SystemException();
        }
        object o = n.element();
        tamanho--;
        return o;
    }
}



