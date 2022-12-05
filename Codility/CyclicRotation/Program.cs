var numbers = new int[] { };
int iterator = 3;
var result = solution(numbers, iterator);

static int[] solution(int[] array, int k)
{
    if (k == 0 || array.Length == 1) return array;
    var tam = array.Length;
    while (k != 0)
    {
        var arrayMod = new int[tam]; // creo uno nuevo
                                     // Ojo, existe la referencia aún
                                     //Array.Clear(arrayMod);
        for (int i = 1; i < tam; i++)
        {
            arrayMod[0] = array[tam - 1];
            arrayMod[i] = array[i - 1];
        }
        k--;
        array = arrayMod;
    }

    return array;
}
