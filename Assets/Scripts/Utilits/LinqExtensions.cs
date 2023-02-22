using System.Collections.Generic;
using System.Linq;

public static class LinqExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this T[,] matrix)
    {
        return matrix.Cast<T>();
    }
}