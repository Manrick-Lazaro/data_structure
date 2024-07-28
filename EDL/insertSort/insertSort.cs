using System;

class Program {
    static void Main() {
        InsertSort insertSortInstance = new InsertSort();

        int[] disorderedElements = new int[] {5,4,2,3,1,42,99,54,76,78,35,64,5,4,23,6,76,45,24,32,77,54,56,6};

        int[] asceElements = insertSortInstance.Asce(disorderedElements);
        int[] descElements = insertSortInstance.Desc(disorderedElements);

        Console.WriteLine("ELEMENTOS ORDENADOS DE FORMA CRESCENTE. ");
        Console.WriteLine(string.Join(", ", asceElements));
        
        Console.WriteLine("\nELEMENTOS ORDENADOS DE FORMA DECRESCENTE. ");
        Console.WriteLine(string.Join(", ", descElements));
    }
}

class InsertSort {
    public int[] Asce(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 1; i < orderedElements.Length; i++){
            int aux = orderedElements[i];
            int j = i - 1;

            while(j >= 0 && aux < orderedElements[j]) {
                orderedElements[j + 1] = orderedElements[j];
                j--;
            }

            orderedElements[j + 1] = aux;
        }

        return orderedElements;
    }

    public int[] Desc(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 1; i < orderedElements.Length; i++){
            int aux = orderedElements[i];
            int j = i - 1;

            while(j >= 0 && aux > orderedElements[j]) {
                orderedElements[j+1] = orderedElements[j];
                j--;
            }

            orderedElements[j + 1] = aux;
        }

        return orderedElements;
    }
}