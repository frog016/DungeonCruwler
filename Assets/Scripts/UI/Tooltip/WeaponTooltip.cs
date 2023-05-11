using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WeaponTooltip : ItemTooltip
{
    [SerializeField] private TextMeshProUGUI _slotText;
    [SerializeField] private TextMeshProUGUI _requiredText;
    [SerializeField] private TextMeshProUGUI _damageFormulaText;
    [SerializeField] private TextMeshProUGUI _damageText;
    //[SerializeField] private object _effectDescription;   //TODO: Write class for effectDescription
    [SerializeField] private AttackTooltip[] _attackTooltips;

    public override void Close()
    {
        base.Close();
        _attackTooltips.Apply(tooltip => tooltip.gameObject.SetActive(false));
    }

    public override void Initialize(ScriptableItemContainer item, ICharacter owner)
    {
        base.Initialize(item, owner);

        var weapon = item as Weapon;
        InitializeDescription(weapon, owner);
        InitializeAttackTooltips(weapon);
    }

    private void InitializeDescription(Weapon item, IStatsUser itemOwner)
    {
        _slotText.text = item.Slot.ToString();
        _requiredText.text = string.Join(", ", ParseRequiredStats(item));
        _damageFormulaText.text = string.Join(" + ", ParseRequiredStatsToFormula(item));
        _damageText.text = item.GetMaximumDamage(itemOwner).ToString();
    }

    private void InitializeAttackTooltips(Weapon item)
    {
        var attackViewPair = item.Attacks.Zip(_attackTooltips, Tuple.Create);
        foreach (var (attack, view) in attackViewPair)
        {
            view.gameObject.SetActive(true);
            view.Initialize(attack.name, 0, "", item.GetAttackData(attack).DamageThreshold);    //TODO: Turn DamageThreshold to EffectChance.
        }
    }

    private static IEnumerable<string> ParseRequiredStats(Weapon item)
    {
        return item.RequiredStats
            .Select(requiredStat => $"{requiredStat.Stat} {requiredStat.Count}");
    }

    private static IEnumerable<string> ParseRequiredStatsToFormula(Weapon item)
    {
        yield return item.Damage.ToString();
        foreach (var requiredStat in item.RequiredStats)
            yield return $"{(int)(requiredStat.UsagePercentage * 100)}% от {requiredStat.Stat}";
    }
}