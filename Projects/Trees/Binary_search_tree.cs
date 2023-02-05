using System;
using System.Collections;
 
 
class Program {
    public static void Main(){
        AB x = new AB();
 
        x.Insert(30);
        x.Insert(20);
        x.Insert(40);
        x.Insert(19);
        x.Insert(25);
        x.Insert(35);
        x.Insert(41);
        x.Insert(38);
 
        /*
                    30
               20         40
            19   25   35       41
                         38
        */
     
        x.Mostrar();
       
        No n = x.Search(25);


        Console.WriteLine(x.depth(n));
    }
}
 
class AB {
    private int size;
    private No root;
 
    public No Root() {
        return this.root;
    }
    public void Mostrar(){
        ArrayList x = new ArrayList();
 
        ArrayList y = Nos(root, x);  
 
        int altura = Heigth(root);
       
        string [,] z = new string[altura + 1, y.Count];
     
        for(int i = 0; i < altura; i++){
            for(int j = 0; j < y.Count; j++){
                z[i,j] = "";
            }
        }
       
        for(int i = 0; i < y.Count; i++){
            No p = (No)y[i];
 
            int profNo = depth(p);
           
            z[profNo,i] = p.GetKey().ToString();
        }
     
        string pri = "";
     
        for(int i = 0; i <= altura; i++){
            for(int j = 0; j < y.Count; j++){
                if(z[i,j] != "")
                    pri +=  z[i,j] + "\t";
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
    public ArrayList Children(No n) {
        ArrayList x = new ArrayList();
        x.Add(n.GetEsquerdo());
        x.Add(n.GetDireito());
        return x;
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
    public No LeftChild (No v) {
        return v.GetEsquerdo();
    }  
    public No RigthChild (No v) {
        return v.GetDireito();
    }
    public bool HasLeft(No n) {
        return n.GetEsquerdo() != null;
    }
    public bool HasRigth(No n) {
        return n.GetDireito() != null;
    }
    public void Remove(int key){
        Remove(Search(key));
    }
    public void Remove (No v) {
        int filhos = 0;
       
        if (HasLeft(v)) {filhos++;}
        if (HasRigth(v)) {filhos++;}        
 
        switch(filhos) {
            case 0:
                Remove1(v);        
                break;
            case 1:
                Remove2(v);      
                break;
            case 2:
                Remove3(v);
                break;
        }
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
    private void Remove2 (No noDelet) {
        if (IsRoot(noDelet)) {
            if(HasLeft(noDelet)) {
                root = noDelet.GetEsquerdo();
                Console.WriteLine("{0}", root.GetPai().GetKey());
                root.SetPai(null);
            } else {
                root = noDelet.GetDireito();
                root.SetPai(null);
            }
        } else {
            if(noDelet.GetPai().GetEsquerdo() == noDelet) {
                if(noDelet.GetEsquerdo() != null) {
                    noDelet.GetEsquerdo().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetEsquerdo(noDelet.GetEsquerdo());
                    noDelet.SetEsquerdo(null);
                    noDelet.SetPai(null);
                } else {
                    noDelet.GetDireito().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetEsquerdo(noDelet.GetDireito());
                    noDelet.SetDireito(null);
                    noDelet.SetPai(null);
                }
            } else {
                if(noDelet.GetEsquerdo() != null) {
                    noDelet.GetEsquerdo().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetDireito(noDelet.GetEsquerdo());
                    noDelet.SetEsquerdo(null);
                    noDelet.SetPai(null);
                } else {
                    noDelet.GetDireito().SetPai(noDelet.GetPai());
                    noDelet.GetPai().SetDireito(noDelet.GetDireito());
                    noDelet.SetDireito(null);
                    noDelet.SetPai(null);
                }
            }
        }
        size--;
    }
    private void Remove3 (No noDelet) {
        No ss = Successor(noDelet);
        Remove(ss);
    }
    public No Successor (No v) {
        No aux = new No(0);
        No aux2 = new No (0);
       
        aux = v.GetEsquerdo();
        aux2.SetKey(v.GetKey());
 
        while(aux.GetDireito() != null) {
            aux = aux.GetDireito();
        }
 
        v.SetKey(aux.GetKey());
        aux.SetKey(aux2.GetKey());        
 
        return aux;
    }
    public int Size() {
        return size;
    }
    public void SwapElements(No n, No v) {
        int temp = n.GetKey();
        n.SetKey(v.GetKey());
        v.SetKey(temp);
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
}
 
class No {
    private No esquerdo, direito, pai;
    private int key;
   
    // Construtor
    public No (int key) {
        this.key = key;
        this.esquerdo = null;
        this.direito = null;
        this.pai = null;
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
 
    public override string ToString(){
      return key.ToString();
    }
}