using System;

public interface IHiddenObject
{
    event Action Discovered;
    bool Detected { get; }
    void Discover(ICharacter character);
}