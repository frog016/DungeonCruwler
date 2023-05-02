using System;
using UnityEngine;

[Serializable]
public class EditorInventory : IInventory
{
    [SerializeField] private Weapon _weapon;
    public Weapon Weapon => _weapon;
}