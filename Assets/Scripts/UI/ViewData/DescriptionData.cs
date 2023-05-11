using System;
using UnityEngine;

[Serializable]
public class DescriptionData
{
    [Header("Description")]
    [SerializeField] private string _name;
    [SerializeField, TextArea] private string _description;

    public string Name => _name;
    public string Description => _description;
}