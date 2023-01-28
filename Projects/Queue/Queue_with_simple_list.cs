using System;
 
class Program {
    public static void Main(){
        // criando objetos nó.
        No x1 = new No(4,null);
        No x2 = new No(5,null);
        No x3 = new No(6,null);
        No x4 = new No(7,null);

        // instanciando a pilha.
        FilaListaSimples y = new FilaListaSimples();

        // adicionando elementos.
        y.equeue(x1);
        y.equeue(x2);
        y.equeue(x3);
        y.equeue(x4);

        Console.WriteLine((y.first()).getObject());

        // removendo elementos
        y.dequeue();
        y.dequeue();

        Console.WriteLine((y.first()).getObject());

        // removendo elementos até da erro.
        y.dequeue();
        y.dequeue();
        y.dequeue();
 
    }
}
 
class FilaVaziaExcecao : Exception {
    public FilaVaziaExcecao(string text) : base(text) {
 
    }
}
 
class No {
    private object noObject;
    private No next;
 
    public No (object noObject, No next) {
        this.noObject = noObject;
        this.next = next;
    }
 
    public void setObject(object noObject) {
        this.noObject = noObject;
    }
 
    public void setNext(No next) {
        this.next = next;
    }
 
    public object getObject() {
        return noObject;
    }
 
    public No getNext() {
        return next;
    }
}
 
class FilaListaSimples {
    int tamanho;
    No inicio;
    No fim;

    public FilaListaSimples() {
        inicio = new No (null, null);
        fim = new No (null, null);
        tamanho = 0;
    }

    public void equeue(No obj) {
        if(isEmpty()) { // se a fila for vazia então inicio e fim apontam para o obj
            inicio.setNext(obj);
            fim.setNext(obj);
        }
        fim.getNext().setNext(obj); // o objeto para qual o fim aponta, apontará para o novo obj na fila.
        fim.setNext(obj); // fim também aponta para o objeto novo.
        tamanho++;
    }

    public No dequeue() {
        if(isEmpty()) {
            throw new FilaVaziaExcecao("a fila está vazia.");
        }
        No temporario = inicio.getNext(); // recebe o proximo obj de inicio.
        inicio.setNext(temporario.getNext()); // inicio recebe o proximo obj do objeto que ele aponta.
        tamanho--; // autoexplicativo.
        return temporario; // retorna objeto excluído da lista.
    }

    public No first() {
        if(isEmpty()) {
            throw new FilaVaziaExcecao("a fila está vazia.");
        }
        return inicio.getNext();
    }

    public int size() {
        return tamanho;
    }

    public bool isEmpty() {
        return tamanho == 0;
    }
}

