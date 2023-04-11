using System;
using System.Collections.Generic;
using System.Linq;

public static class LinqExtensions
{
    public static IEnumerable<T> Apply<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        var sequence = enumerable.ToArray();
        foreach (var element in sequence)
        {
            action?.Invoke(element);
        }

        return sequence;
    }

    public static IEnumerable<T> ApplyLazy<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var element in enumerable)
        {
            action?.Invoke(element);
            yield return element;
        }
    }

    public static IEnumerable<T> AsEnumerable<T>(this T[,] matrix)
    {
        return matrix.Cast<T>();
    }
}