using System;


class EmptyStackException : Exception {
    public EmptyStackException(string text) : base(text) {}    
}

public interface IStackArray {
    void push(object obj);
    object pop();
    object top();
    int size();
    bool isEmpty();
}

class Stack : IStackArray {
    private int t;
    private object[] stack;

    public Stack() {
        t = -1;
        stack = new object[1];
    }

    public void push(object obj) {
        if(t+1 == stack.Length) {
            object[] newStack = new object[stack.Length * 2];
            for(int i = 0; i < stack.Length; i++) {
                newStack[i] = stack[i];
            }
            stack = newStack;
        }
        stack[++t] = obj;
    }

    public object pop() {
        if(isEmpty()) {
            throw new EmptyStackException("empty stack");
        }
        return stack[t--];
    }

    public object top() {
        if(isEmpty()) {
            throw new EmptyStackException("empty stack");
        }
        return stack[t];
    }

    public int size() {
        return t + 1;
    }

    public bool isEmpty() {
        return t == -1;
    }
}

class MainClass {
    public static void Main() {
        Stack x = new Stack();

        // adicionar objeto
        x.push(1);
       
        x.push(2);

        x.push(3);

        // retornar um objeto
        Console.WriteLine(x.top());

        // tamanho
        Console.WriteLine(x.size());

        // vazio?
        Console.WriteLine(x.isEmpty());

        // removendo
        x.pop();
        x.pop();

        Console.WriteLine(x.top());
    }
}

