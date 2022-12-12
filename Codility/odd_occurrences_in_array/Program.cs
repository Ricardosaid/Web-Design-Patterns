using System.Collections.Generic;
int[] A = {9,9,2,3,2,4,5,3,5,4,3};
var result = solution(A);
Console.WriteLine(result);
static int solution(int[] A)
{
    var count = 0;
    var tam = A.Length;
    int helper = 0;//declarar entero nulo
    //List<int> numbers = new List<int>();
    int[] B = {};
    bool flag = false;

    while (tam != 1)
    {
        for (int i = 1; i < tam; i++)
        {
            var estado = A[count];
            if (A[i] == estado)
            {
                helper = i;
                i = tam - 1;
                flag = true;

            }


        }
        if (flag)
        {
            flag = false;
            A = A.Where((val,idx)=>idx!=helper).ToArray();
            A = A.Where((val,idx)=>idx!=count).ToArray();
            //A=B;
            /*
            var numbers = A.ToList();
            numbers.RemoveAt(helper);
            numbers.RemoveAt(count);
            */
            //A = numbers.ToArray();
            tam = A.Length;
            if (tam == 1)
            {
                return (A[0]);
            }
        } else
        {
            if(tam==0)
            {
                return 0;
            }
            else
            {
             return (A[0]);   
            }
        }
        

    }
    return (A[0]);
}