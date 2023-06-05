public static class CacheStrings
{
    private static string[] cacheNums;
    
    public static string GetCacheNum(int num)
    {

        if (cacheNums == null)
        {
            CreateNumCache(num+1);
        }
        if(num >=  cacheNums.Length)
        {
            ResizeNumCache(num+1);
        }

        return cacheNums[num];
    }

    private static void CreateNumCache(int maxNum)
    {
        cacheNums = new string[maxNum];

        for(int i = 0; i < maxNum; i++)
        {
            cacheNums[i] = i.ToString();
        }
    }

    private static void ResizeNumCache(int maxNum)
    {
        string[] tempCacheArray = new string[maxNum];
        int counter = 0;

        for(; counter < cacheNums.Length; counter++)
            tempCacheArray[counter] = cacheNums[counter];

        for(;counter < tempCacheArray.Length; counter++)
            tempCacheArray[counter] = counter.ToString();

        cacheNums = tempCacheArray;
    }
}
