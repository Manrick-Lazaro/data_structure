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
##########################################
###### Classe vetor com lista dupla ######
##########################################
*/


class Vetor {
    private No inicio, fim;
    private int tamanho;


    public Vetor() {
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


    public object elementAtRank(int rank){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("Rank não existe");
        }


        No temp = inicio.getProximo();


        for(int i = 0; i < rank; i++){
            temp = temp.getProximo();
        }    
       
        return temp.getElemento();
    }


    public object replaceAtRank(int rank, object elemento){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("Rank não existe");
        }


        No temp = inicio.getProximo();


        for(int i = 0; i < rank; i++){
            temp = temp.getProximo();
        }


        object elementoRetorno = temp.getElemento();


        temp.setElemento(elemento);


        return elementoRetorno;
    }


    public void insertAtRank(int rank, object elemento){
        if(rank < 0 || rank > tamanho){
            throw new RankIncorreto("Rank não existe");
        }
       
        No x = new No(elemento);


        if(inicio.getProximo() == fim && fim.getAnterior() == inicio){
            x.setNoProximo(inicio.getProximo());
            x.setNoAnterior(fim.getAnterior());


            inicio.setNoProximo(x);
            fim.setNoAnterior(x);
            tamanho++;  
        } else {
            No temp = inicio.getProximo();


            for(int i = 0; i < rank; i++){
                temp = temp.getProximo();
            }
       
            x.setNoProximo(temp);
            x.setNoAnterior(temp.getAnterior());


            (temp.getAnterior()).setNoProximo(x);
            temp.setNoAnterior(x);      
            tamanho++;      
        }
    }


    public object removeAtRank(int rank){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("Rank não existe");
        }
       
        No temp = inicio.getProximo();


        for(int i = 0; i < rank; i++){
            temp = temp.getProximo();
        }


       object elementoRetorno = temp.getElemento();
       
        (temp.getProximo()).setNoAnterior(temp.getAnterior());
        (temp.getAnterior()).setNoProximo(temp.getProximo());


        tamanho--;


        return "elementoRetorno";
    }


    public int size(){
        return tamanho;
    }


    public bool isEmpty(){
        return tamanho == 0;
    }
}






/*
#############################
###### Classe de teste ######
#############################
*/


class MainClass{
    public static void Main(){
        Vetor x = new Vetor();


        x.insertAtRank(0, 1);
        x.insertAtRank(1, 2);


        Console.WriteLine(x.elementAtRank(0));
        Console.WriteLine(x.elementAtRank(1));


        x.removeAtRank(0);


        Console.WriteLine("Removendo - {0}", x.elementAtRank(0));


        x.replaceAtRank(0, 5);


        Console.WriteLine("Alterando - {0}", x.elementAtRank(0));


        x.insertAtRank(1, "w");
        x.insertAtRank(2, 9);
        x.insertAtRank(3, "b");


        x.replaceAtRank(3, "alterando elemento");


        Console.WriteLine("Alterando - {0}", x.elementAtRank(3));
    }
}

