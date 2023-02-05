using System;
using System.Collections;
 
class Program {
    public static void Main(){
        AVL x = new AVL();
 
        /*
            formula fator de balanceamento inserção:
                ESQUERDO:
                FB_Pai_novo = FB_antigo_pai + 1 - min(FB_antigo_filho, 0)
                FB_filho_novo = FB_antigo_filho + 1 + max(FB_novo_pai, 0)


                DIREITO:
                FB_Pai_novo = FB_antigo_pai - 1 - max(FB_antigo_filho, 0)
                FB_filho_novo = FB_antigo_filho - 1 + min(FB_novo_pai, 0)
        */


        x.Inserir(50);
        x.Inserir(40);
        x.Inserir(30);
        x.Inserir(20);
        x.Inserir(10);
        x.Inserir(55);
        x.Inserir(45);
        x.Inserir(44);
        x.Inserir(43);
        x.Inserir(46);


        x.Mostrar();


        Console.WriteLine("----------------------------------------");


        x.Remover(43);


        x.Mostrar();


        Console.WriteLine("----------------------------------------");


        x.Remover(44);


        x.Mostrar();


        Console.WriteLine("----------------------------------------");


        x.Remover(45);


        x.Mostrar();


        Console.WriteLine("----------------------------------------");
    }
}


class AVL:AB {
    public void Remover (int key) {
        No noRemovido = Search(key);
        No x;


        if (IsLeaf(noRemovido)) {
            x = noRemovido.GetPai();
            if (IsLeft(noRemovido)) {
                Remove(noRemovido);
                AtualizarFbRemove(x, 0);
            } else {
                Remove(noRemovido);
                AtualizarFbRemove(x, 1);
            }
        }
        else if (HasLeft(noRemovido) != true || HasRigth(noRemovido) != true) {
            if (IsLeft(noRemovido)) {
                x = Remove(key);
                AtualizarFbRemove(x, 0);
            } else if (IsRight(noRemovido)) {
                x = Remove(key);
                AtualizarFbRemove(x, 1);
            }
        } else {
            x = Remove(noRemovido);
            AtualizarFbRemove(x, 0);
        }
    }
    public void AtualizarFbRemove(No n, int lado){
        int fb = n.GetFb();
        int ladoN;


        if (lado == 0) {
            fb -= 1;
            n.SetFb(fb);
        } else {
            fb += 1;
            n.SetFb(fb);
        }


        if (IsLeft(n))
            ladoN = 0;
        else
            ladoN = 1;


        if (fb == 2 || fb == -2) {
            VerificaFbRemove(n);
        }
        else if (fb == 0)
            AtualizarFbRemove(n.GetPai(), ladoN);


    }
    public void VerificaFbRemove (No x) {
        if(HasRigth(x)) {
            if (x.GetDireito().GetFb() == -1 && x.GetFb() == 2)
                RotacaoDuplaDireita(x.GetDireito(), x);
        }
        if(HasLeft(x)) {
            if(x.GetEsquerdo().GetFb() == 1 && x.GetFb() == -2)
                RotacaoDuplaEsquerda(x.GetEsquerdo(), x);
        }
        if(x.GetFb() == 2)
            RotacaoSimplesDireita(x);
        else if(x.GetFb() == -2)
            RotacaoSimplesEsquerda(x);
    }
    public void Inserir (int key) {
        Insert(key);


        No inserido = Search(key);
       
        if(inserido != Root()) {
            if(inserido.GetDireito() == null && inserido.GetEsquerdo() == null) {
                inserido.SetFb(0);
            }
            AtualizarFbInsert(inserido);
        }
    }
    public void AtualizarFbInsert(No x){
        int fbPai = 0;
        No pai = x.GetPai();


        if(x != Root()) {
            if(IsLeft(x)){
                fbPai = pai.GetFb();
                fbPai += 1;
                pai.SetFb(fbPai);


                if(pai.GetFb() == 2 || pai.GetFb() == -2)
                    VerificaFB(x);
                else if(pai != Root()) {
                    if (pai.GetFb() != 0)
                        AtualizarFbInsert(x.GetPai());
                }


            } else {
                fbPai = pai.GetFb();
                fbPai -= 1;
                pai.SetFb(fbPai);
               
                if(pai.GetFb() == 2 || pai.GetFb() == -2)
                    VerificaFB(x);
                else if(pai != Root()) {
                    if (pai.GetFb() != 0)
                        AtualizarFbInsert(x.GetPai());
                }
            }
        }    
    }
    public void VerificaFB(No x){
        if(x.GetFb() == -1 && x.GetPai().GetFb() == 2){
            RotacaoDuplaDireita(x, x.GetPai());}
        else if(x.GetFb() == 1 && x.GetPai().GetFb() == -2)
            RotacaoDuplaEsquerda(x, x.GetPai());
        else if(x.GetPai().GetFb() == 2)
            RotacaoSimplesDireita(x.GetPai());
        else if(x.GetPai().GetFb() == -2)
            RotacaoSimplesEsquerda(x.GetPai());
    }
    public void RotacaoDuplaDireita(No n, No pai) {
        RotacaoSimplesEsquerda(n);
        RotacaoSimplesDireita(pai);
    }
    public void RotacaoDuplaEsquerda(No n, No pai) {
        RotacaoSimplesDireita(n);
        RotacaoSimplesEsquerda(pai);
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


            n.SetPai(filhoEsquerdoN);


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


            if (IsLeft(n))
                n.GetPai().SetEsquerdo(filhoEsquerdoN);
            else
                n.GetPai().SetDireito(filhoEsquerdoN);


            n.SetPai(filhoEsquerdoN);
        }


        n.SetFb(n.GetFb() - 1 - Math.Max(filhoEsquerdoN.GetFb(), 0));
        filhoEsquerdoN.SetFb(filhoEsquerdoN.GetFb() - 1 + Math.Min(n.GetFb(), 0));
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


            n.SetPai(filhoDireitoN);


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


            if (IsLeft(n))
                n.GetPai().SetEsquerdo(filhoDireitoN);
            else
                n.GetPai().SetDireito(filhoDireitoN);


            n.SetPai(filhoDireitoN);
        }
       
        n.SetFb(n.GetFb() + 1 - Math.Min(filhoDireitoN.GetFb(), 0));
        filhoDireitoN.SetFb(filhoDireitoN.GetFb() + 1 + Math.Max(n.GetFb(), 0));
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


        Remove(ss);


        return ret;
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
    private int fb;
   
    // Construtor
    public No (int key) {
        this.key = key;
        this.esquerdo = null;
        this.direito = null;
        this.pai = null;
        this.fb = 0;
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
    public void SetFb(int fb){
        this.fb = fb;
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
    public int GetFb (){
        return this.fb;
    }
 
    public override string ToString(){
      return key + "[" + fb + "]";
    }
}