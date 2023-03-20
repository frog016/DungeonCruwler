using UnityEngine;

[CreateAssetMenu(menuName = "Mapper/DamageType to Defense-Resist", fileName = "DamageTypeMapper")]
public class DamageTypeMapper : TypeMapper<DamageType, CompositeStatType>
{
}