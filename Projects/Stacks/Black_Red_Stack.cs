using System; // biblioteca padrão do C#

class EmptyStackException : Exception { // classe de exceção
    public EmptyStackException(string text) : base(text) {}
}


public interface IPilhaRubroNegra { // interface da pilha rubro negra
    // metodos da pilha Rubro
    void pushNegro(object obj);
    object popNegro();
    object topNegro();
    bool isEmptyNegro();
    int sizeNegro();


    // metodos da pilha Negra
    void pushRubro(object obj);
    object popRubro();
    object topRubro();
    bool isEmptyRubro();
    int sizeRubro();
}


class StackRubroNegro : IPilhaRubroNegra { // classe Pilha
    private int tR, tN; // topo Rubro e topo Negro.
    private object[] stack; // array em que as duas pilhas vão ter acesso.

    public StackRubroNegro() { // construtor da classe Pilha
        tR = -1; // valor padrao -1 pra indica que está vazio, o topo.
        tN = -1; // valor padrao -1 pra indica que está vazio, o topo.
        stack = new object[5]; // definindo o tamanho da pilha.
    }


    // métodos da piha negra
    public void pushNegro(object obj) {
        if((tR+1) + (tN+1) == stack.Length) { // se a soma dos dois topos for igual ao tamanho do array.
            object[] newStack = new object[stack.Length * 2]; // construir um novo array com o dobro de tamanho.


            // caso o topo seja -1 evita que caia no loop, caso só uma das pilhas tenha enchido todo o espaço do array.
            if(tN >= 0) {
                for (int i = 0; i <= tN; i++) {
                    newStack[(newStack.Length - 1) - i] = stack[(stack.Length - 1) - i];
                    // se o topo negro for 0(0 != de vazio) ele so vai precisar adicionar o objeto do antigo array no fim do novo array
                }
            }
            if(tR >= 0) {
                for(int i = 0; i <= tR; i++){
                    newStack[i] = stack[i];
                }
            }
            stack = newStack;
        }
        stack[(stack.Length - 1) - (++tN)] = obj;
    }
   
    public object popNegro() {
        if(isEmptyNegro()){
            throw new EmptyStackException("A pilha tá vazia.");
        }
        return stack[(stack.Length - 1) - (tN--)];
    }

    public object topNegro() {
        if(isEmptyNegro()){
            throw new EmptyStackException("A pilha tá vazia.");
        }
        return stack[(stack.Length - 1) - (tN)];
    }

    public int sizeNegro() {
        return tN;
    }

    public bool isEmptyNegro() {
        return tN == -1;
    }


    // Rubro
    public void pushRubro(object obj) {
        if((tR+1) + (tN+1) == stack.Length) {
            object[] newStack = new object[stack.Length * 2];
            if(tN >= 0) {
                for (int i = 0; i <= tN; i++) {
                    newStack[(newStack.Length - 1) - i] = stack[(stack.Length - 1) - i];
                }
            }
            if(tR >= 0) {
                for(int i = 0; i <= tR; i++){
                    newStack[i] = stack[i];
                }
            }
            stack = newStack;
        }
        stack[++tR] = obj;
    }
   
    public object popRubro() {
        if(isEmptyRubro()){
            throw new EmptyStackException("A pilha tá vazia.");
        }
        return stack[tR--];
    }

    public object topRubro() {
        if(isEmptyRubro()){
            throw new EmptyStackException("A pilha tá vazia.");
        }
        return stack[tR];
    }

    public int sizeRubro() {
        return tR+1;
    }

    public bool isEmptyRubro() {
        return tR==-1;
    }
}


class MainClass {
    public static void Main() {
        StackRubroNegro x = new StackRubroNegro();
       
        // adicionando no rubro
        x.pushRubro(1);
        x.pushRubro(2);
        x.pushRubro(3);
        x.pushRubro(4);
        x.pushRubro(5); // pilha cheia

        // olhando o topo de rubro
        Console.WriteLine("{0} - topo de rubro", x.topRubro());

        // forçando a duplicação do tamanho do array, adicionando no negro.
        x.pushNegro("a");
        Console.WriteLine(":) {0}", x.topNegro());
        x.pushNegro("b");
        Console.WriteLine(":) {0}", x.topNegro());
        x.pushNegro("c");
        Console.WriteLine(":) {0}", x.topNegro());

        // olhando o topo negro e rubro
        Console.WriteLine("{0} - topo de negro", x.topNegro());
        Console.WriteLine("{0} - topo de rubro", x.topRubro());

        // removendo elementos de rubro
        Console.WriteLine(x.popRubro());
        Console.WriteLine(x.popRubro());
        Console.WriteLine(x.popRubro());
        Console.WriteLine(x.popRubro());
        Console.WriteLine(x.popRubro());

        // olhando top negro
        Console.WriteLine(":D {0}", x.topNegro());

        // removendo elementos de negro
        Console.WriteLine("Removendo negro: {0}", x.popNegro());
        Console.WriteLine("Removendo negro: {0}", x.popNegro());
        Console.WriteLine("Removendo negro: {0}", x.popNegro());
    }
}

