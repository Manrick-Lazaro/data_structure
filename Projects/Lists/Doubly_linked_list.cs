using System;

/*
###############################
###### Classe de exceção ######
###############################
*/

class RankIncorreto : Exception{
    public RankIncorreto(string texto) : base(texto) {}
}

/*
###############################
###### Classe Nó ######
###############################
*/

class No {
    private object elemento;
    private No proximo, anterior;

    public No (object elemento) {
        this.elemento = elemento;
    }

    public void setElemento(object elemento){
        this.elemento = elemento;
    }
    public void setNoProximo(No proximo){
        this.proximo = proximo;
    }
    public void setNoAnterior(No anterior){
        this.anterior = anterior;
    }

    public object getElemento(){
        return elemento;
    }
    public No getProximo(){
        return proximo;
    }
    public No getAnterior(){
        return anterior;
    }
}

/*
###############################
###### Classe TAD lista #######
###############################
*/

class Lista {
    private No inicio, fim;
    private int tamanho;

    public Lista() {
        inicio = new No(null);
        fim = new No(null);
 
        inicio.setNoProximo(fim);
        inicio.setNoAnterior(null);
        inicio.setElemento("inicio");
       
        fim.setNoProximo(null);
        fim.setNoAnterior(inicio);
        fim.setElemento("fim");
       
        tamanho = 0;
    }

    public int Size() {
        return tamanho;
    }

    public bool IsEmpty() {
        return tamanho == 0;
    }

    public bool IsFirst(No n) {
        return n == inicio.getProximo();
    }

    public bool IsLast(No n) {
        return n == fim.getAnterior();
    }

    public No First() {
        return inicio.getProximo();
    }

    public No Last() {
        return fim.getAnterior();
    }

    public No Before(int p) {
        if(p < 1 || p > tamanho){
            throw new RankIncorreto("Rank não existe");
        }
 
        No temp = inicio.getProximo();
 
        for(int i = 0; i < p; i++){
            temp = temp.getProximo();
        }

        return temp.getAnterior();
    }

    public No After(int p) {
        if(p < 1 || p > tamanho){
            throw new RankIncorreto("Rank não existe");
        }
 
        No temp = inicio.getProximo();
 
        for(int i = 0; i < p; i++){
            temp = temp.getProximo();
        }

        return temp.getProximo();
    }

    public void ReplaceElement(No n, object o) {
        n.setElemento(o);
    }

    public void SwapElements(No n, No q) {
        object temp = n.getElemento();
        n.setElemento(q.getElemento());
        q.setElemento(temp);
    }

    public void InsertBefore(No n, object o) {
        No newNo = new No(o);
       
        newNo.setNoProximo(n);
        newNo.setNoAnterior(n.getAnterior());

        (n.getAnterior()).setNoProximo(newNo);
        n.setNoAnterior(newNo);
    }

    public void InsertAfter(No n, object o) {
        No newNo = new No(o);
       
        newNo.setNoProximo(n.getProximo());
        newNo.setNoAnterior(n);

        (n.getProximo()).setNoAnterior(newNo);
        n.setNoProximo(newNo);
    }

    public void InsertFirst(object o) {
       No newNo = new No(o);

       newNo.setNoProximo(inicio.getProximo());
       newNo.setNoAnterior(inicio);

       (newNo.getProximo).setNoAnterior(newNo);    
       inicio.setNoProximo(newNo);
    }

    public void InsertLast(object o) {
       No newNo = new No(o);

       newNo.setNoProximo(fim);
       newNo.setNoAnterior(fim.getAnterior());

       (fim.getAnterior()).setNoProximo(newNo);
       fim.setNoAnterior(newNo);
    }

    public No Remove(No n) {
        (n.getProximo()).setNoAnterior(n.getAnterior());
        (n.getAnterior()).setNoProximo(n.getProximo());

        n.setNoProximo(null);
        n.setNoAnterior(null);
        n.setElemento(null);
    }
}

