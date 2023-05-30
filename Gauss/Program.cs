using System.Data.Common;

class Methods
{
    public static void Main()
    {
        double[,] Array = { { 1, 2, 3, 1 }
                           , { 2, 5, 6,4 }
                           , { 33, 15, 6, 1 } };
        /*
        2x2 
        double[,] Array = { { 1, 2, 3 }
                           , { 2, 5, 8 } };
        3x3 
        double[,] Array = { { 1, 2, 3, 1 }
                           , { 2, 5, 6,4 }
                           , { 33, 15, 6, 1 } };
        4x4
        double[,] Array = { { 1, 2, 3, 1, 8 }
                           , { 2, 5, 6, 4, 1 }
                           , { 33, 15, 6, 1, 10 }
                           , {15, 0, 14, 3, 11 }};
         */
        Print2DMas(Array);
        Console.WriteLine("Корни:");
        Print1DMas(Gauss(Array));
        
        //PrintMas(Array);
    }
    public static double[] Gauss(double[,] A)
    {
        int N = A.GetLength(0);
        //Console.Write(" N = " + N + "\n\n");
        // Приведение масива в треугольный вид
        for (int k = 0; k <= N - 2; k++)
        {
            //Console.Write("k = " + k);
            for (int j = 1 + k; j < N; j++)
            {
                double cof = A[j, k];
                //Console.Write(" j = " + j);
                for (int i = 0 + k; i < N + 1; i++)
                {
                    //Console.Write(" i = " + i + "\n\n");
                    A[j, i] = A[k, i] / A[k, k] * cof - A[j, i];
                    //Print2DMas(A);
                }
            }
        }
        double[] Answer = new double[N];
        //Answer[N - 1] = A[N, N + 1] / A[N, N];
        int sch = 0;
        for (int n = N - 1; n >= 0; n--) {
            if(sch == 0)
            {
                Answer[n] = A[n, N - 1 + 1] / A[n, n];
                sch++;
            }
            else
            {
                double SpecificSum = 0;
                for(int i = 0; i < sch; i++)
                {
                    SpecificSum += Answer[N - 1 - i] * A[n, N - 1 - i];
                }
                Answer[n]= (A[n, N - 1 + 1] - SpecificSum) / A[n, n];
                sch++;
            } 
        }
        return Answer;
    }
        
        /*
        A[j, i] = A[k, i] / A[k, k] * A[j, k] - A[j, i];
        
        j = 2  0 <= i < 4    k = 0
        A[2, 0] = A[0, 0] / A[0, 0] * A[2, 0] - A[2, 0];
        A[2, 1] = A[0, 1] / A[0, 0] * A[2, 0] - A[2, 1];
        A[2, 2] = A[0, 2] / A[0, 0] * A[2, 0] - A[2, 2];
        A[2, 3] = A[0, 3] / A[0, 0] * A[2, 0] - A[2, 3];
        
        j = 1  0 <= i < 4    k = 0
        A[1, 0] = A[0, 0] / A[0, 0] * A[1, 0] - A[1, 0];
        A[1, 1] = A[0, 1] / A[0, 0] * A[1, 0] - A[1, 1];
        A[1, 2] = A[0, 2] / A[0, 0] * A[1, 0] - A[1, 2];
        A[1, 3] = A[0, 3] / A[0, 0] * A[1, 0] - A[1, 3];

        j = 2  0 < i < 4    k = 1
        A[2, 1] = A[1, 1] / A[1, 1] * A[2, 1] - A[2, 1];
        A[2, 2] = A[1, 2] / A[1, 1] * A[2, 1] - A[2, 2];
        A[2, 3] = A[1, 3] / A[1, 1] * A[2, 1] - A[2, 3];
        */
    public static void Print2DMas(double[,] A)
    {
        int N = A.GetLength(0);
        for (int j = 0; j < N; j++)
        {
            for (int i = 0; i < N+1; i++)
            {
                Console.Write(A[j,i]+" ");
            }
            Console.Write("\n");
        }
        Console.Write("\n");
    }
    public static void Print1DMas(double[] A)
    {
        int N = A.GetLength(0);
        for (int j = 0; j < N; j++)
        {
                Console.Write(A[j] + " ");
        }
        Console.Write("\n");
    }
}


