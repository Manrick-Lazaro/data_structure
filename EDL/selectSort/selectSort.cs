using System;

class Program {
    static void Main() {
        SelectSort selectSortInstance = new SelectSort();

        int[] disorderedElements = new int[] {5,4,2,3,1,42,99,54,76,78,35,64,5,4,23,6,76,45,24,32,77,54,56,6};

        int[] asceElements = selectSortInstance.Asce(disorderedElements);
        int[] descElements = selectSortInstance.Desc(disorderedElements);

        Console.WriteLine("ELEMENTOS DA LISTA ORDENADOS DE FORMA CRESCENTE.");
        Console.WriteLine(String.Join(", ", asceElements));

        Console.WriteLine("\nELEMENTOS DA LISTA ORDENADOS DE FORMA DECRESCENTE.");
        Console.WriteLine(string.Join(", ", descElements));
    }
}

// O(n²)
class SelectSort {
    public int[] Asce(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 0; i < orderedElements.Length - 1; i++) {
            for(int j = i + 1; j < orderedElements.Length; j++) {
                if(orderedElements[j] < orderedElements[i]) {
                    int auxiliaryElement = orderedElements[j];
                    orderedElements[j] = orderedElements[i];
                    orderedElements[i] = auxiliaryElement;
                }
            }
        }

        return orderedElements;
    }

    public int[] Desc(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 0; i < orderedElements.Length - 1; i++){
            for(int j = i + 1; j < orderedElements.Length; j++) {
                if(orderedElements[j] > orderedElements[i]) {
                    int auxiliaryElement = orderedElements[j];
                    orderedElements[j] = orderedElements[i];
                    orderedElements[i] = auxiliaryElement;
                }
            }
        }

        return orderedElements;
    }
}