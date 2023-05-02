using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Buildings;
using ModuleClass;

public class ClassConverter<ToConvert> where ToConvert : Object
{
    public static ToConvert Convert(Object fromConvert)
    {
        ToConvert result;
        try
        {
            result = fromConvert as ToConvert;
        }
        catch (InvalidCastException e)
        {
            Debug.LogError("Произошла ошибка приведения типов: " + e.Message);
            return null;
        }

        return result;
    }

    internal static ToConvert Convert(System.Object fromConvert)
    {
        ToConvert result;
        try
        {
            result = fromConvert as ToConvert;
        }
        catch (InvalidCastException e)
        {
            Debug.LogError("Произошла ошибка приведения типов: " + e.Message);
            return null;
        }

        return result;
    }
}
