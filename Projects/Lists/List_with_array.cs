using System;

class PosiçãoIncorreta : Exception{
    public PosiçãoIncorreta(string texto) : base(texto) {}
}

/*
###############################
###### Classe TAD lista #######
###############################
*/

class Lista {
    private object[] lista;
    private int tamanho;

    public Lista() {
        lista = new object[1];
        tamanho = 0;
    }

    public int Size() {
        return tamanho;
    }

    public bool IsEmpty() {
        return tamanho == 0;
    }

    public bool IsFirst(int n) {
        return n == 0;
    }

    public bool IsLast(int n) {
        return n == tamanho;
    }

    public No First() {
        return lista[0];
    }

    public No Last() {
        return lista[tamanho];
    }

    public No Before(int p) {
        if (p <= 0 || p > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }
        return lista[p-1];
    }

    public No After(int p) {
        if (p <= 0 || p > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }
        return lista[p+1];
    }

    public void ReplaceElement(int n, object o) {
        if (n <= 0 || n > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }
        lista[n] = o;
    }

    public void SwapElements(int n, int q) {
        if (n <= 0 || n > lista.Length || q <= 0 || q > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }
        object temp = lista[n];

        lista[n] = lista[q];
        lista[q] = temp;
    }

    public void InsertBefore(int n, object o) {
        if (n <= 0 || n > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }

        if (tamanho == lista.Length) {
            object[] newLista = new object[lista.Length * 2];

            for(int i = 0; i < tamanho; i++){
                newLista[i] = lista[i];
            }

            lista = newLista;
        }
        lista[n-1] = o;
        tamanho++;
    }

    public void InsertAfter(int n, object o) {
        if (n <= 0 || n > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }

        if (tamanho == lista.Length) {
            object[] newLista = new object[lista.Length * 2];

            for(int i = 0; i < tamanho; i++){
                newLista[i] = lista[i];
            }

            lista = newLista;
        }
        lista[n+1] = o;
        tamanho++;
    }

    public void InsertFirst(object o) {
        if (tamanho == lista.Length) {
            object[] newLista = new object[lista.Length * 2];
            newLista[0] = o;

            for(int i = 1; i <= tamanho; i++){
                newLista[i] = lista[i-1];
            }

            lista = newLista;
        }
        tamanho++;
    }

    public void InsertLast(object o) {
        if (tamanho == lista.Length) {
            object[] newLista = new object[lista.Length * 2];
   
            for(int i = 0; i < tamanho; i++){
                newLista[i] = lista[i];
            }

            lista = newLista;
        }

        newLista[tamanho++] = o;
    }

    public No Remove(int n) {
        if (n <= 0 || n > lista.Length) {
            throw new PosiçãoIncorreta("a posição informada não é possível ser acessada nesse metodo.");
        }

        int i = n;

        do{
            lista[i] = lista[+1];
            i++;
        } while (i < tamanho);

        tamanho--;
    }
}