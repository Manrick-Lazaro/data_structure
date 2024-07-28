using System;

class Program {
    static void Main () {
        BubbleSort bubbleSortInstace = new BubbleSort();

        int[] disorderedElements = new int[] {5,4,2,3,1,42,99,54,76,78,35,64,5,4,23,6,76,45,24,32,77,54,56,6};

        int[] descElements = bubbleSortInstace.Desc(disorderedElements);
        int[] asceElements = bubbleSortInstace.Asce(disorderedElements);

        Console.WriteLine("ordenados de forma ascendente");
        Console.WriteLine("{0}", String.Join(", ", asceElements));

        Console.WriteLine("\nordenados de forma decrecente");
        Console.WriteLine("{0}", String.Join(", ", descElements));
    }
}

// O(n²)
class BubbleSort {
    public int[] Desc(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 0; i < orderedElements.Length - 1; i++) {
            for(int j = 0; j < orderedElements.Length - 1 - i; j++) {
                if(orderedElements[j] < orderedElements[j + 1]) {
                    int auxiliaryElement = orderedElements[j + 1];
                    orderedElements[j + 1] = orderedElements[j];
                    orderedElements[j] = auxiliaryElement; 
                }
            }
        }

        return orderedElements;
    }

    public int[] Asce(int[] elements) {
        int[] orderedElements = (int[])elements.Clone();

        for(int i = 0; i < orderedElements.Length - 1; i++) {
            for(int j = 0; j < orderedElements.Length - 1 - i; j++) {
                if(orderedElements[j] > orderedElements[j + 1]) {
                    int auxiliaryElement = orderedElements[j];
                    orderedElements[j] = orderedElements[j + 1];
                    orderedElements[j + 1] = auxiliaryElement; 
                }
            }
        }

        return orderedElements;
    }
}