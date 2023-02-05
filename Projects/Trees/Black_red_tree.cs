using System;
using System.Collections;
 
 
class Program {
    public static void Main(){
        ARN x = new ARN();
 
        x.Inserir(100);
        x.Inserir(80);
        x.Inserir(150);
        x.Inserir(130);
        x.Inserir(50);
        x.Inserir(27);
        x.Inserir(18);
        x.Inserir(45);


        x.Mostrar();


        Console.WriteLine("----------------------------");


        x.Remover(50);


        x.Mostrar();
    }
}
 
class ARN : AB {
    public void Inserir (int key) {
        Insert(key);
 
        No v = Search(key);
 
        if (v != Root())
            v.SetCor("red");
 
        VerificaCasos(v);
    }
    public void VerificaCasos(No v) {
        if (v.GetPai() != null) {
            if (Avo(v) != null ) {
                if (Tio(v) != null) {
                    if (Tio(v).GetCor() == "black" && v.GetPai().GetCor() == "red" && Avo(v).GetCor() == "black") {
                        Caso3(v);
                    }
                    else {
                        No pai = v.GetPai();
                        No avo = Avo(v);
                        No bisavo = null;
                        No tio = Tio(v);
 
                        if (avo.GetPai() != null)
                            bisavo = avo.GetPai();
                       
                        if (pai.GetCor() == "red" && avo.GetCor() == "black" && tio.GetCor() ==  "red") {
                            if (bisavo != null) {
                                if (bisavo.GetCor() == "red") {
                                    Caso2(v);
                                    VerificaCasos(avo);
                                } else
                                    Caso2(v);
                            } else
                                Caso2(v);  
                        }
                    }
                } else if (v.GetPai().GetCor() == "red" && Avo(v).GetCor() == "black") {
                    Caso3(v);
                }
            }
        }  
    }
    public void Caso2(No v) {
        No pai = v.GetPai();
        No avo = Avo(v);
        No tio = Tio(v);
 
        if (avo != Root())
            avo.SetCor("red"); // black -> red
       
        tio.SetCor("black"); // red -> black
        pai.SetCor("black"); // red -> black
    }
    public void Caso3(No v) {
        if (IsLeft(v) && IsLeft(v.GetPai())) {
            RotacaoSimplesDireita(Avo(v));
        } else if (IsRight(v) && IsRight(v.GetPai())) {
            RotacaoSimplesEsquerda(Avo(v));
        } else if (IsLeft(v) && IsRight(v.GetPai())) {
            No avo = Avo(v);
            RotacaoSimplesDireita(v.GetPai());
            RotacaoSimplesEsquerda(avo);
        } else if (IsRight(v) && IsLeft(v.GetPai())) {
            No avo = Avo(v);
            RotacaoSimplesEsquerda(v.GetPai());
            RotacaoSimplesDireita(avo);
        }
    }
    public void RotacaoSimplesDireita(No n) {
        No filhoEsquerdoN = n.GetEsquerdo();
       
        bool flag = false;
       
        if (filhoEsquerdoN.GetDireito() != null)
            flag = true;
 
        if(n == Root()) {
            No aux;
   
            if(flag == true){
                aux = filhoEsquerdoN.GetDireito();
 
                aux.SetPai(n);
                n.SetEsquerdo(aux);
            } else
                n.SetEsquerdo(null);
 
            filhoEsquerdoN.SetDireito(n);
            filhoEsquerdoN.SetPai(null);
            filhoEsquerdoN.SetCor("black");
 
            n.SetPai(filhoEsquerdoN);
            n.SetCor("red");
 
            SetRoot(filhoEsquerdoN);
        } else {
            No aux;
           
            if(flag == true){
                aux = filhoEsquerdoN.GetDireito();
 
                aux.SetPai(n);
                n.SetEsquerdo(aux);
            } else
                n.SetEsquerdo(null);
 
            filhoEsquerdoN.SetDireito(n);
            filhoEsquerdoN.SetPai(n.GetPai());
            filhoEsquerdoN.SetCor("black");
 
            if (IsLeft(n))
                n.GetPai().SetEsquerdo(filhoEsquerdoN);
            else
                n.GetPai().SetDireito(filhoEsquerdoN);
 
            n.SetPai(filhoEsquerdoN);
            n.SetCor("red");
        }
    }
    public void RotacaoSimplesEsquerda(No n) {
            No filhoDireitoN = n.GetDireito();
       
        bool flag = false;
 
 
        if (filhoDireitoN.GetEsquerdo() != null)
            flag = true;
 
        if(n == Root()) {
            No aux;
           
            if(flag == true){
                aux = filhoDireitoN.GetEsquerdo();
 
                aux.SetPai(n);
                n.SetDireito(aux);
            } else
                n.SetDireito(null);
 
            filhoDireitoN.SetEsquerdo(n);
            filhoDireitoN.SetPai(null);
            filhoDireitoN.SetCor("black");
 
            n.SetPai(filhoDireitoN);
            n.SetCor("red");
 
            SetRoot(filhoDireitoN);
 
        } else {
            No aux;
       
            if(flag == true){
                aux = filhoDireitoN.GetEsquerdo();
 
                aux.SetPai(n);
                n.SetDireito(aux);
            } else  
                n.SetDireito(null);
 
            filhoDireitoN.SetEsquerdo(n);
            filhoDireitoN.SetPai(n.GetPai());
            filhoDireitoN.SetCor("black");
 
            if (IsLeft(n))
                n.GetPai().SetEsquerdo(filhoDireitoN);
            else
                n.GetPai().SetDireito(filhoDireitoN);
 
            n.SetPai(filhoDireitoN);
            n.SetCor("red");
        }
    }
    public void Remover(int key) {
        No n = Search(key);
        No sucessorN = Remove(n);
        No irmaoN = null;
       
        if (sucessorN != null) {
            irmaoN = Irmao(sucessorN);  


            if(n.GetCor() == "red" && sucessorN.GetCor() == "red") { // situação 01
                sucessorN.SetCor("red");
            } else if(n.GetCor() == "black" && sucessorN.GetCor() == "red") { // sitação 02
                sucessorN.SetCor("black");
            } else if(n.GetCor() == "black" && sucessorN.GetCor() == "black") { // situação 03
                if(irmaoN.GetCor() == "red" && sucessorN.GetPai().GetCor() == "black") { // caso 1
                    sucessorN.SetDuplo(true);
                    RotacaoSimplesEsquerda(sucessorN);
                    irmaoN.SetCor("black");
                    sucessorN.GetPai().SetCor("red");
                } else if (sucessorN.GetPai().GetCor() == "black" && irmaoN.GetCor() == "black" && irmaoN.GetEsquerdo().GetCor() == "black" && irmaoN.GetDireito().GetCor() == "black") { // caso 2a.
                    irmaoN.SetCor("red");
                } else if (irmaoN.GetCor() == "black" && irmaoN.GetEsquerdo().GetCor() == "black" && irmaoN.GetDireito().GetCor() == "black" && sucessorN.GetPai().GetCor() == "red") { // caso 2b.
                    sucessorN.GetPai().SetCor("black");
                    irmaoN.SetCor("red");
                } else if (irmaoN.GetCor() == "black" && irmaoN.GetEsquerdo().GetCor() == "red" && irmaoN.GetDireito().GetCor() == "black") { // caso 3.
                    RotacaoSimplesDireita(irmaoN);
                    irmaoN.GetPai().SetCor("black");
                    irmaoN.SetCor("red");
                } else if (irmaoN.GetCor() == "black" && irmaoN.GetDireito().GetCor() == "red") { //caso 4
                    string corPaiX = sucessorN.GetPai().GetCor();


                    RotacaoSimplesEsquerda(irmaoN);
                    irmaoN.GetPai().SetCor("black");
                    irmaoN.SetCor(corPaiX);
                    irmaoN.GetDireito().SetCor("black");
                }
            } else if (n.GetCor() == "red" && sucessorN.GetCor() == "black") { // situação 04
                sucessorN.SetCor("red");
                // situação 3.
            }
        }
    }
}
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 class AB {
    private int size;
    private No root;
 
    public No Root() {
        return this.root;
    }
    public void SetRoot(No root){
        this.root = root;
    }
    public void Mostrar(){
        ArrayList x = new ArrayList();
       
        ArrayList y = Nos(root, x);  
 
        int altura = Heigth(root);
       
        No [,] z = new No[altura + 1, y.Count];
     
        for(int i = 0; i < y.Count; i++){
            No p = (No)y[i];
           
            int profNo = depth(p);
           
            z[profNo,i] = p;
        }
     
        string pri = "";
     
        for(int i = 0; i <= altura; i++){
            for(int j = 0; j < y.Count; j++){
                if(z[i,j] != null)
                    pri +=  z[i,j] + "    ";
                else
                    pri += "\t";
            }
          pri += "\n";
        }
     
        Console.WriteLine(pri);
    }
    public int Heigth(No n){
        if(n == null || n.GetDireito() == null && n.GetEsquerdo() == null) {
            return 0;
        }
        else {
            int es = 1 + Heigth(n.GetEsquerdo());
            int di = 1 + Heigth(n.GetDireito());
 
            return Math.Max(es, di);
        }
    }
    public int depth(No n) {
        int profundidade = this.Depth(n);
        return profundidade;
    }
    public int Depth(No n) {
        if(IsRoot(n)) {
            return 0;
        }
        else {
            return 1 + Depth(n.GetPai());
        }
    }
    public ArrayList Nos(No v, ArrayList a) {
        if(v.GetEsquerdo() != null) {
            Nos(v.GetEsquerdo(), a);
        }
        a.Add(v);
        if(v.GetDireito() != null) {
            Nos(v.GetDireito(), a);
        }
        return a;
    }
    public ArrayList Elements(No v, ArrayList a) {
        if(v.GetEsquerdo() != null) {
            Elements(v.GetEsquerdo(), a);
        }
        a.Add(v.GetKey());
        if(v.GetDireito() != null) {
            Elements(v.GetDireito(), a);
        }
        return a;
    }
    public No Parent(No n) {
        return n.GetPai();
    }
    public No Avo(No n) {
        if (n.GetPai() == null)
            return null;
        No pai = (n.GetPai());
        if (pai.GetPai() == null)
            return null;
        else
            return pai.GetPai();
    }
    public No Tio(No n) {
        No avo = Avo(n);
        No pai = n.GetPai();
 
        if (avo == null)
            return null;
       
        if (IsLeft(pai))
            return avo.GetDireito();
        else
            return avo.GetEsquerdo();
    }
    public No Irmao(No n) {
        if (IsLeft(n))
            return n.GetPai().GetDireito();
        else
            return n.GetPai().GetEsquerdo();
    }
    public ArrayList Children(No n) {
        ArrayList x = new ArrayList();
        x.Add(n.GetEsquerdo());
        x.Add(n.GetDireito());
        return x;
    }
    public No LeftChild (No v) {
        return v.GetEsquerdo();
    }
    public No RigthChild (No v) {
        return v.GetDireito();
    }
    public void Insert(int key){
        if(IsEmpty()){
            root = new No(key);
            size++;
        } else {
            if(key < root.GetKey())
                if(root.GetEsquerdo() == null) {
                    No nod = new No(key);
                    root.SetEsquerdo(nod);
                    nod.SetPai(root);
                    size++;
                } else
                    Insert(root.GetEsquerdo(), key);  
            else
                if(key > root.GetKey())
                    if(root.GetDireito() == null) {
                        No nod = new No(key);
                        root.SetDireito(nod);
                        nod.SetPai(root);
                        size++;
                    } else    
                        Insert(root.GetDireito(), key);
        }
    }
    public void Insert(No n, int key) {
        if(key < n.GetKey()) {
            if(n.GetEsquerdo() == null) {
                No nod = new No(key);
                n.SetEsquerdo(nod);
                nod.SetPai(n);
                size++;
            }
            else
                Insert(n.GetEsquerdo(), key);
        }
        else {
            if(key > n.GetKey()) {
                if(n.GetDireito() == null) {
                    No nod = new No(key);
                    n.SetDireito(nod);  
                    nod.SetPai(n);
                    size++;
                }
                else    
                   Insert(n.GetDireito(), key);
            }
        }
    }
    public bool IsEmpty(){
        return size == 0;
    }
    public bool IsRoot(No n){
        return n == root;
    }
    public No Search(int key) {
        return Search(root, key);
    }
    private No Search(No v, int key) {
        if ((v.GetKey()) == key)
            return v;
        else {
            if (key < (v.GetKey())){
                if(HasLeft(v))
                    return Search(v.GetEsquerdo(),  key);
                else  
                    return null;
            } else {
                if(HasRigth(v))
                    return Search(v.GetDireito(), key);
                else
                    return null;
                }
        }
    }
    public bool HasLeft(No n) {
        return n.GetEsquerdo() != null;
    }
    public bool HasRigth(No n) {
        return n.GetDireito() != null;
    }
    public void SwapElements(No n, No v) {
        int temp = n.GetKey();


        n.SetKey(v.GetKey());
        v.SetKey(temp);
    }
    public No Remove(int key){
        No x = Remove(Search(key));
        return x;
    }
    public No Remove (No v) {
        int filhos = 0;
        No x = null;


        if (HasLeft(v)) {filhos++;}
        if (HasRigth(v)) {filhos++;}        
 
        switch(filhos) {
            case 0:
                Remove1(v);        
                break;
            case 1:
                x = Remove2(v);      
                break;
            case 2:
                x = Remove3(v);
                break;
        }
 
        return x;
    }
    private void Remove1 (No noDelet) {  
        if((int)noDelet.GetKey() < (int)noDelet.GetPai().GetKey())  
            noDelet.GetPai().SetEsquerdo(null);
        else
            noDelet.GetPai().SetDireito(null);
   
        noDelet.SetPai(null);
        noDelet.SetKey(0);
        size--;
    }
    private No Remove2 (No noDelet) {
        No ret;
        if (IsRoot(noDelet)) {
            if(HasLeft(noDelet)) {
                root = noDelet.GetEsquerdo();
                root.SetPai(null);
 
                ret = noDelet.GetEsquerdo();
 
                size--;
 
                return ret;
            } else {
                root = noDelet.GetDireito();
                root.SetPai(null);
 
                ret = noDelet.GetDireito();
 
                size--;
 
                return ret;
            }
        } else {
            if(noDelet.GetPai().GetEsquerdo() == noDelet) {
                if(noDelet.GetEsquerdo() != null) {
                    ret = noDelet.GetEsquerdo();
 
                    noDelet.GetEsquerdo().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetEsquerdo(noDelet.GetEsquerdo());
                    noDelet.SetEsquerdo(null);
                    noDelet.SetPai(null);
                   
                    size--;
 
                    return ret;
                } else {
                    ret = noDelet.GetDireito();
 
                    noDelet.GetDireito().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetEsquerdo(noDelet.GetDireito());
                    noDelet.SetDireito(null);
                    noDelet.SetPai(null);
 
                    size--;
 
                    return ret;
                }
            } else {
                if(noDelet.GetEsquerdo() != null) {
                    ret = noDelet.GetEsquerdo();
 
                    noDelet.GetEsquerdo().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetDireito(noDelet.GetEsquerdo());
                    noDelet.SetEsquerdo(null);
                    noDelet.SetPai(null);
 
                    size--;
 
                    return ret;
                } else {
                    ret = noDelet.GetDireito();
 
                    noDelet.GetDireito().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetDireito(noDelet.GetDireito());
                    noDelet.SetDireito(null);
                    noDelet.SetPai(null);
 
                    size--;
 
                    return ret;
                }
            }
        }
    }
    private No Remove3 (No noDelet) {
        No ss = Successor(noDelet);
       
        No ret = ss;
       
        SwapElements(ss, noDelet);


        if (ss.GetPai().GetEsquerdo() == ss) {
            ss.GetPai().SetEsquerdo(null);
            ss.SetPai(null);
        } else {
            ss.GetPai().SetDireito(null);
            ss.SetPai(null);
        }


        return noDelet;
    }
    public No Successor (No v) {
        No aux = new No(0);
       
        if (v.GetDireito() != null) {
            aux = v.GetDireito();
       
            while(aux.GetEsquerdo() != null) {
                aux = aux.GetEsquerdo();
            }
        } else {
            aux = v.GetEsquerdo();
       
            while(aux.GetDireito() != null) {
                aux = aux.GetDireito();
            }
        }
 
        return aux;
    }
    public int Size() {
        return size;
    }
    public void PreOrder(No n) {
        Console.WriteLine(n.GetKey().ToString());
        if(n.GetEsquerdo() != null)
            PreOrder(n.GetEsquerdo());
        if(n.GetDireito() != null)
            PreOrder(n.GetDireito());
    }
    public void PosOrder(No n){
        if(n.GetEsquerdo() != null)
            PosOrder(n.GetEsquerdo());
        if(n.GetDireito() != null)
            PosOrder(n.GetDireito());
        Console.WriteLine(n.GetKey().ToString());
    }
    public void InOrder(No n){
        if(n.GetEsquerdo() != null)
            InOrder(n.GetEsquerdo());
        Console.WriteLine(n.GetKey().ToString());
        if(n.GetDireito() != null)
            InOrder(n.GetDireito());
    }
    public bool IsLeft (No n){
        No pai = n.GetPai();
 
        if(pai.GetEsquerdo() == n)
            return true;
        else
            return false;
    }
    public bool IsRight (No n){
        No pai = n.GetPai();
 
        if(pai.GetDireito() == n)
            return true;
        else
            return false;
    }
    public bool IsLeaf (No n){
        return HasLeft(n) == false && HasRigth(n) == false;
    }
}
 
class No {
    private No esquerdo, direito, pai;
    private int key;
    private string cor;
    private bool duploNegro;
   
    // Construtor
    public No (int key) {
        this.key = key;
        this.esquerdo = null;
        this.direito = null;
        this.pai = null;
        this.cor = "black";
        this.duploNegro = false;
    }
 
    // Sets
    public void SetEsquerdo (No esquerdo) {
        this.esquerdo = esquerdo;
    }
    public void SetDireito (No direito) {
        this.direito = direito;
    }
    public void SetPai (No pai) {
        this.pai = pai;
    }
    public void SetKey (int key) {
        this.key = key;
    }
    public void SetCor(string cor){
        this.cor = cor;
    }
    public void SetDuplo(bool x){
        this.duploNegro = x;
    }
 
    // Gets
    public No GetEsquerdo () {
        return this.esquerdo;
    }
    public No GetDireito () {
        return this.direito;
    }
    public No GetPai () {
        return this.pai;
    }
    public int GetKey () {
        return this.key;
    }
    public string GetCor (){
        return this.cor;
    }
    public bool GetDuplo(){
        return this.duploNegro;
    }
 
    public override string ToString(){
      return this.key + "[" + this.cor + "]";
    }
}