using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Support
{
    
    public static int GetHash(this string value)
    {

        return value.GetHashCode();

    }

    public static T Clone<T>(this T source) where T : ICloneable
    {

        return (T)source.Clone();

    }

    public static T Cast<T>(this object source)
    {

        return (T)source;

    }

}
