using System;
 
class Program {
    public static void Main(){
        // criando objetos nó.
        No x1 = new No(4,null);
        No x2 = new No(5,null);
        No x3 = new No(6,null);
        No x4 = new No(7,null);

        // instanciando a pilha.
        PilhaListaSimples y = new PilhaListaSimples();

        // adicionando elementos.
        y.push(x1);
        y.push(x2);
        y.push(x3);
        y.push(x4);

        Console.WriteLine((y.top()).getText());

        // removendo elementos
        y.pop();
        y.pop();

        Console.WriteLine((y.top()).getText());

        // removendo elementos até da erro.
        y.pop();
        y.pop();
        y.pop();
    }
}
 
class PilhaVaziaExcecao : Exception {
    public PilhaVaziaExcecao(string text) : base(text) {
 
    }
}
 
class No {
    private object noObject;
    private No next;
 
    public No (object noObject, No next) {
        this.noObject = noObject;
        this.next = next;
    }
 
    public void setText(object noObject) {
        this.noObject = noObject;
    }
 
    public void setNext(No next) {
        this.next = next;
    }
 
    public object getText() {
        return noObject;
    }
 
    public No getNext() {
        return next;
    }
 
    public string ToString() {
        return noObject.ToString();
    }
}
 
class PilhaListaSimples {
    private No inicio;
    private int tamanho;
 
    public PilhaListaSimples () {
        inicio = new No(null, null);
        tamanho = 0;
    }
 
    public void push(No obj) {
        obj.setNext(inicio.getNext());
        inicio.setNext(obj);
        tamanho++;
    }
 
    public No pop() {
        if(isEmpty()) {
            throw new PilhaVaziaExcecao("a pilha está vazia.");
        }
        No retorna = inicio.getNext();
        inicio.setNext(retorna.getNext());
        tamanho--;
        return retorna;
    }
 
    public No top() {
        if(isEmpty()) {
            throw new PilhaVaziaExcecao("a pilha está vazia.");
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

