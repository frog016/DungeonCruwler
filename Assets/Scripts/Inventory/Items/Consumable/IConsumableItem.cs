using System;

public interface IConsumableItem : IItem
{
    int Count { get; set; }
}