using System.Collections.Generic;

public interface ICollection<T>
{
    void Add(T element);
    void Remove(T element);
    IEnumerable<T> GetAll();
}