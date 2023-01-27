using System;
using System.Collections.Generic;
 
class MainClass {
    public static void Main() {
        Pilha x = new Pilha();

        x.push("Z");
        x.push("G");
        x.push("S");
        x.push("A");

        Console.WriteLine(x.pop());
        Console.WriteLine(x.top());
    }
}
 
class FilaVaziaExcecao : Exception {
    public FilaVaziaExcecao(string text) : base(text) {}
}
class PilhaVaziaExcecao : Exception {
    public PilhaVaziaExcecao(string text) : base(text) {}
}
 
class Fila {
    private List<object> fila;
 
    public Fila() {
        fila = new List<object>();
    }
 
    public void equeue(object obj) {
        fila.Add(obj);
    }
 
    public object dequeue() {
        if(isEmpty()) {
            throw new FilaVaziaExcecao("a fila está vazia");
        }
        object temporario =  fila[0];
        fila.RemoveAt(0);
        return temporario;
    }

    public object dequeueEnd() {
        object temp = fila[fila.Count - 1];
        fila.RemoveAt(fila.Count - 1);
        return temp;
    }
 
    public object first() {
        if(isEmpty()) {
            throw new FilaVaziaExcecao("a fila está vazia");
        }
        return fila[0];
    }
 
    public int size() {
        return fila.Count;
    }
 
    public bool isEmpty() {
        return size() == 0;
    }
}

class Pilha {
    private Fila fila01;
    private Fila fila02;

    public Pilha() {
        fila01 = new Fila();
        fila02 = new Fila();
    }

    public void push(object obj){
        fila01.equeue(obj);
    }

    public object pop() {
        if(isEmpty()){
            throw new PilhaVaziaExcecao("a pilha está vazia.");
        }

        if(fila02.isEmpty() != true){
            return fila02.dequeue();
        } else {
            while(fila01.isEmpty() != true) {
                fila02.equeue(fila01.dequeueEnd());
            }
        }
        return fila02.dequeue();
    }

    public object top(){
            if(isEmpty()){
            throw new PilhaVaziaExcecao("a pilha está vazia.");
        }


        if(fila02.isEmpty() != true){
            return fila02.dequeue();
        } else {
            while(fila01.isEmpty() != true) {
                fila02.equeue(fila01.dequeueEnd());
            }
        }
        return fila02.dequeue();
    }

    public int size(){
        return fila01.size() + fila02.size();
    }  

    public bool isEmpty(){
        return size() == 0;
    }
}

