using System.Collections.Generic;
int [] A = {9,3,9,3,9,7,9};
var result = solution(A);
Console.WriteLine(result);
static int solution(int [] A)
{
    var count = 0;
    var tam = A.Length;
    //var count_two = 1;
    //var flag = false;
    var helper = 0;
    int[] numbers = {};


    while (tam!=1)
    {
        for (int i = 1; i < tam; i++)
        {
            var estado = A[count];
            if (A[i]==estado)
            {
                helper = A[i];
                i = tam-1;
            }
        }
        numbers = A.Where(q=>q!=helper).ToArray();

        A=numbers;
        tam = A.Length;
        if (tam==1)
        {
            return (numbers[0]);
        }
    }
    return (A[0]);
    
    // for (int i = 2; i < tam; i++)
    // {
    //     var estado = A[count_one];
    //     //var helper = A[count_two];
    //     if (A[i]==estado)
    //     {
    //         count_one++;
    //         if (helper == A[i])
    //         {

                
    //         }
    //     }
    //     else
    //     {
    //         helper = A[i];
    //         flag = true;

    //         // foreach (var item in B)
    //         // {
    //         //     if (helper==item)
    //         //     {
                    
    //         //     }
    //         //     else
    //         //     {
                    
    //         //     }
    //         // }
    //     }
        
    // }


}



/*
foreach (var item in A)
    {
        var estado = A[count];
        if (item == estado)
        {
            if(status)
            {
            count++;
            //status = false;
            }
            else
            {
                status=true;
            }
        }
        else
        {
            helper=item;
            status = false;
        }
    }
*/