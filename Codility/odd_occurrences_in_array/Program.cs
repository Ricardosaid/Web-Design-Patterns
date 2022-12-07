using System.Collections.Generic;
int [] A = {0,0,7,1,7};
var result = solution(A);
static int solution(int [] A)
{
    var count = 0;
    var tam = A.Length;
    int status = 0;
    int helper=0;
    
    for (int i = 1; i < tam; i++)
    {
        var estado = A[count];//9
        //helper=estado;
        if (A[i]==estado)//3=9 o 9==3
        {
            count++;
            status = A[i];//statusdebe ser un numero
        }
        else if(status==estado)
        {
            count++;
            //status=false;
            //helper = A[i];
        }
        
    }

    return helper;
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