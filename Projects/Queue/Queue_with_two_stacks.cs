using System;

class MainClass {
    public static void Main(string[] argc) {
        Fila x = new Fila();

        // tá vazio?
        Console.WriteLine("Vazio? {0}", x.isEmpty());

        // adicionando objetos
        x.equeue(1);
        x.equeue(2);
        x.equeue("c");

        x.dequeue();

        // tá vazio?
        Console.WriteLine("Vazio? {0}", x.isEmpty());

        // quantos elementos?
        Console.WriteLine("Quantidade de elementos: {0}", x.size());

        // olhando o primeiro da fila
        Console.WriteLine("first: {0}", x.first());

        // adicionando mais um
        x.equeue("D");

        // Quantidade de elementos
        Console.WriteLine("Quantidade: {0}", x.size());

        // primeiro da fila
        Console.WriteLine("primeiro: {0}", x.first());

        // removendo elementos
        for(int i = 0; i < 3; i++) {
            Console.WriteLine("Removendo elemento: {0}", x.dequeue());
        }

        // ta vazio?
        Console.WriteLine("Vazio? {0}", x.isEmpty());
        Console.WriteLine("Quantidade de elementos: {0}", x.size());
    }
}

// ################################################################################## //

public class ExcecaoFilaVazia : Exception {
    public ExcecaoFilaVazia(string text) : base(text) { }
}
public class ExcecaoPilhaVazia : Exception {
    public ExcecaoPilhaVazia (string text) : base (text) { }
}

// ################################################################################## //

class Pilha{
    private int topo;
    private object[] stack;

    public Pilha () {
        topo = -1;
        stack = new object[5];
    }
    public void push (object obj) {
        if(this.size() == stack.Length) {
            object[] newStack = new object[stack.Length * 2];
            for(int i = 0; i < stack.Length; i++) {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }
        stack[++topo] = obj;
    }
    public object pop () {
        if (isEmpty()) {
            throw new ExcecaoPilhaVazia ("A pilha está vazia");
        }
        return stack[topo--];
    }
    public object top () {
        if (isEmpty()) {
            throw new ExcecaoPilhaVazia ("A pilha está vazia");
        }
        return stack[topo];
    }
    public int size () {
        return topo + 1;
    }
    public bool isEmpty () {
        return topo == -1;
    }
}

// ################################################################################## //

class Fila {
    private Pilha pilhaEmpilha;
    private Pilha pilhaDesempilha;

    public Fila() {
        pilhaEmpilha = new Pilha();
        pilhaDesempilha = new Pilha();
    }

    public void equeue(object obj) {
        pilhaEmpilha.push(obj);
    }

    public object dequeue() {
        // A fila só estará vazia se as duas pilhas estiverem vazio.
        if(pilhaEmpilha.isEmpty() && pilhaDesempilha.isEmpty()) {
            throw new ExcecaoFilaVazia("A fila está vazia.");
        }

        // se a pilha desempilha não estiver vazia ele já retorna o valor.
        // mas se a pilha desempilha estiver vazia quando for chamada, ela receberá os objetos da
        // pilha empilha, invertendo a posição dos objetos, o objeto que antes era base agora passa
        // a ser topo.
        if(pilhaDesempilha.isEmpty() != true) {
            return pilhaDesempilha.pop();
        } else {
            while(pilhaEmpilha.isEmpty() != true) {
                pilhaDesempilha.push(pilhaEmpilha.pop());
            }
        }
        return pilhaDesempilha.pop();
    }

    public object first() {
        if(pilhaEmpilha.isEmpty() && pilhaDesempilha.isEmpty()) {
            throw new ExcecaoFilaVazia("A fila está vazia.");
        }
        if(pilhaDesempilha.isEmpty() != true) {
            return pilhaDesempilha.top();
        } else {
            while(pilhaEmpilha.isEmpty() != true) {
                pilhaDesempilha.push(pilhaEmpilha.pop());
            }
        }
        return pilhaDesempilha.top();
    }

    public int size() {
        return pilhaEmpilha.size() + pilhaDesempilha.size();
    }

    public bool isEmpty() {
        return this.size() == 0;
    }
}

