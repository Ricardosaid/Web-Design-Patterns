using System.Collections.Generic;
int[] A = {7, 0, 0, 1, 1,7,3};
var result = solution(A);
Console.WriteLine(result);
static int solution(int[] A)
{
    var count = 0;
    var tam = A.Length;
    int? helper = null;//declarar entero nulo
    int[] numbers = { };
    bool flag = false;

    while (tam != 1)
    {
        for (int i = 1; i < tam; i++)
        {
            var estado = A[count];
            if (A[i] == estado)
            {
                helper = A[i];
                i = tam - 1;
                flag = true;

            }
        }
        if (flag)
        {
            numbers = A.Where(q => q != helper).ToArray();
            A = numbers;
            tam = A.Length;
            if (tam == 1)
            {
                return (numbers[0]);
            }
        } else return (A[0]);

    }
    return (A[0]);
}