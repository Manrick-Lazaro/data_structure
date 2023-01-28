using System;
using System.Collections.Generic;
 
class MainClass {
    public static void Main() {
        Fila x = new Fila();

        x.equeue("z");

        Console.WriteLine(x.first());
        Console.WriteLine(x.size());
        Console.WriteLine(x.isEmpty());

        x.equeue("a");
        x.equeue("b");

        Console.WriteLine(x.dequeue());
        Console.WriteLine(x.dequeue());
        Console.WriteLine(x.dequeue());

        Console.WriteLine(x.size());
        Console.WriteLine(x.isEmpty());
    }
}
 
// ########################################################### //
 
class FilaVaziaExcecao : Exception {
    public FilaVaziaExcecao(string text) : base(text) {}
}
 
// ########################################################### //
 
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