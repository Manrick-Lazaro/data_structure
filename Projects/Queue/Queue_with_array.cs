using System;

class EmptyQueueException : Exception {
    public EmptyQueueException(string text) : base(text) {}
}

interface IQueueArray {
    void enqueue(object obj);
    object dequeue();
    object first();
    int size();
    bool isEmpty();
}

class Queue : IQueueArray {
    int i, f;
    object[] q;

    public Queue() {
        q = new object[5];
        i = 0;
        f = 0;
    }
    public void enqueue(object obj) {
        if(size() == q.Length - 1) {
            object[] newQ = new object[q.Length * 2];
            int ii = i;
            for(int ff=0; ff<q.Length; ff++) {
                newQ [ff] = q[ii];
                ii = (ii+1)%q.Length;
            }
            i = 0;
            f = q.Length;
            q = newQ;
        }
        q[f] = obj;
        f = (f+1) % q.Length;
    }
    public object dequeue() {
        if(isEmpty()) {
            throw new EmptyQueueException("Queue is empty");
        }
        object obj = q[i];
        i = (i+1)%q.Length;
        return obj;
    }
    public object first() {
        if(isEmpty()) {
            throw new EmptyQueueException("Queue is empty");
        }
        return q[i];
    }
    public int size() {
        return (q.Length - i + f) % q.Length;
    }
    public bool isEmpty() {
        return size() == 0;
    }
}

class MainClass {
    public static void Main(string[] argc) {
        Queue x = new Queue();

        // adicionando
        x.enqueue(2);
        x.enqueue(4);
        x.enqueue(6);

        // espiando o primeiro da fila
        Console.WriteLine(x.first());

        // removendo o primeiro da fila
        Console.WriteLine(x.dequeue());

        // adicionando elemento até aumentar o tamanho do array.
        x.enqueue(7);
        x.enqueue(8);
        x.enqueue(9);
        x.enqueue(10);

        // epiando o primeiro da fila.
        Console.WriteLine(x.first());
    }
}

