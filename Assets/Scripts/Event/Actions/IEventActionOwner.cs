using System.Collections.Generic;

public interface IEventActionOwner
{
    IEnumerable<IEventAction> Actions { get; }
}