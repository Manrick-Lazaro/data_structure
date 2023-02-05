using System;


/*
#####################################
######### CLASSE DE EXCEÇÃO #########
#####################################
*/


class RankIncorreto : Exception {
    public RankIncorreto(string texto) : base(texto) {}
}


/*
#############################
######### TAD VETOR #########
#############################
*/


class Vetor {
    private object[] vetor;
    private int tamanho;


    public Vetor(){
        this.tamanho = 0;
        vetor = new object[1];
    }


    public object elementAtRank(int rank){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("o rank informado não existe.");
        }
        return vetor[rank];
    }


    public object replaceAtRank(int rank, object element){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("o rank informado não existe.");
        }
        object temp = vetor[rank];
        vetor[rank] = element;
        return temp;
    }


    public void insertAtRank(int rank, object element){
        if(rank < 0 || rank > tamanho){
            throw new RankIncorreto("o rank informado não existe.");
        }
        if(tamanho == vetor.Length){
            object[] novoVetor = new object[vetor.Length * 2];
            for(int i = 0; i < vetor.Length; i++){
                novoVetor[i] = vetor[i];
            }
            vetor = novoVetor;
        }
        for(int i = vetor.Length - 1; i > rank; i--){
            vetor[i] = vetor[i-1];
        }
        vetor[rank] = element;
        tamanho++;
    }


    public object removeAtRank(int rank){
        if(rank < 0 || rank >= tamanho){
            throw new RankIncorreto("o rank informado não existe.");
        }
        object temp = vetor[rank];
        for(int i = rank; i < tamanho; i++){
            vetor[rank] = vetor[rank + 1];
            vetor[rank + 1] = null;
        }
       
        tamanho--;
        return temp;
    }


    public int size() {
        return tamanho;
    }


    public bool isEmpty() {
        return tamanho == 0;
    }
}


/*
####################################
######### Classe de testes #########
####################################
*/


class MainClass {
    public static void Main(){
        Vetor x = new Vetor();


        x.insertAtRank(0, 1);
        x.insertAtRank(1, 2);
        x.insertAtRank(2, 3);


        Console.WriteLine(x.elementAtRank(0));
        Console.WriteLine(x.elementAtRank(1));
        Console.WriteLine(x.elementAtRank(2));


        Console.WriteLine("size - {0}", x.size());


        x.removeAtRank(1);


        Console.WriteLine("lugar 0 - {0}", x.elementAtRank(0));
        Console.WriteLine("lugar 1 - {0}", x.elementAtRank(1));


        Console.WriteLine("size - {0}", x.size());


        Console.WriteLine("lugar 2 - {0}", x.elementAtRank(2));
    }
}

