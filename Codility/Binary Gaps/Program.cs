var result = solution(1041);


static int solution(int n)
{
    string binaryNumber = Convert.ToString(n,2);
    bool helper = true;
    bool helper2 = false;
    int count = 0;
    List<int> lista = new List<int>();
    foreach (var item in binaryNumber)
    {
        if (item.ToString()!="1")
        {
            if (helper)
            {
                helper2 = true;
                count++;
            }
            
        }
        else if (helper && helper2)
        {
            lista.Add(count);
            count = 0;
        }
    }
    var item2= 0;
    foreach (var item in lista)
    {
        if (item > item2) item2 = item;
    }
    return item2;

}
