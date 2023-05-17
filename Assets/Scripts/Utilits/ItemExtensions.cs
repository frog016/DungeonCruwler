using System;

public static class ItemExtensions
{
    public static Weapon GetWeapon(this IItemUser user)
    {
        if (user.EquipmentWearer.TryGetItem(EquipmentSlot.TwoHand, out var item) ||
            user.EquipmentWearer.TryGetItem(EquipmentSlot.RightHand, out item) ||
            user.EquipmentWearer.TryGetItem(EquipmentSlot.LeftHand, out item))
            return item as Weapon;

        throw new Exception($"Character not wear weapon.");
    }
}