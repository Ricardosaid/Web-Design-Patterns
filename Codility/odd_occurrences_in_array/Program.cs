//int[] A = {9,9,2,3,2,4,5,3,5,4,3};
// int[] A = {1004, 1002, 1005, 1004,1003, 1001, 1002,1002, 1002, 1000,1001, 1000, 1003, 1000, 1002, 1002, 1003, 1003, 1005, 1005, 1002, 1000, 1000, 1003, 1002, 1002, 1002, 1000, 1004, 1003, 1003, 1004, 1004, 1004, 1002, 1000, 1005, 1000, 1002, 1000, 1003, 1002, 1001, 1003, 1000, 1004, 1004, 1004, 1001, 1001, 1002, 1002, 1001, 1003, 1005, 1005, 1002, 1002, 1004, 1003, 1001, 1004, 1003, 1000, 1004, 1002, 1004, 1004, 1005, 1005, 1002, 1001, 1003, 1005, 1003, 1001, 1000, 1005, 1001, 1004, 1000, 1001, 1004, 1004, 1003, 1005, 1000, 1004, 1005, 1002, 1003, 1004, 1005, 1001, 1004, 1001, 1001, 1001, 1005, 1005, 1001, 1004, 1005};
//int[] A = {3,3,3,3,3,3,3,3,3,3,6};

int[] A = { 9, 3, 9, 3, 9, 7, 9 };
var result = solution(A);
Console.WriteLine(result);
static int solution(int[] A)
{
    var count = 0;
    var tam = A.Length;
    int helper = 0;
    int estado = 0; 
    int estado2 = 0;

    if (tam==1) return (A[0]);

    do
    {
        for (int i = 0; i < tam; i++)
        {
            
            if (count==i) continue;
            if (A[count]==A[i])
            {
                helper++;
                estado = i;
            }
            else estado2 = count;
        }

        if (helper == 0)
        {
            Console.WriteLine(estado2);
            return(A[estado2]); 
        }

        if(helper%2 == 0)
        {
            Console.WriteLine(estado);
            return (A[estado]);
        }

        count++;
        helper = 0;
        
    } while (helper==0);
    
    return (A[0]);
    
    // for (int i = 1; i < tam; i++)
    // {
    //     var estado = A[count];
    //     if (A[i] == estado)
    //     {
    //         helper++;
    //         flag = true;
    //     }
        
    // }


    // while (tam != 1)
    // {
    //     for (int i = 1; i < tam; i++)
    //     {
    //         var estado = A[count];
    //         if (A[i] == estado)
    //         {
    //             helper = i;
    //             i = tam - 1;
    //             flag = true;

    //         }


    //     }
    //     if (flag)
    //     {
    //         flag = false;
    //         A = A.Where((val,idx)=>idx!=helper).ToArray();
    //         A = A.Where((val,idx)=>idx!=count).ToArray();
    //         //A=B;
    //         /*
    //         var numbers = A.ToList();
    //         numbers.RemoveAt(helper);
    //         numbers.RemoveAt(count);
    //         */
    //         //A = numbers.ToArray();
    //         tam = A.Length;
    //         if (tam == 1)
    //         {
    //             return (A[0]);
    //         }
    //     } else
    //     {
    //         if(tam==0)
    //         {
    //             return 0;
    //         }
    //         else
    //         {
    //          return (A[0]);   
    //         }
    //     }
        

    // }
    // return (A[0]);
}