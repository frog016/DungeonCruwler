using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{
    public enum Race
    {
        Human,
        Gnome,
        Elf,
    }

    public enum Class
    {
        Warrior,
        Sorcerer,
        Rogue,
    }

    [SerializeField] Race playerRace;
    [SerializeField] Class playerClass;

    [SerializeField] float maxHealth;
    [SerializeField] float health;

    [SerializeField] float strength;
    [SerializeField] float agility;
    [SerializeField] float intelligence;
    [SerializeField] float endurance;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnValidate()
    {
        OnClassChange();
        OnRaceChange();
    }

    private void OnClassChange()
    {
        switch (playerClass)
        {
            case Class.Warrior:
                strength = 5f;
                agility = 1f;
                intelligence = 1f;
                break;

            case Class.Sorcerer:
                strength = 1f;
                agility = 2f;
                intelligence = 5f;
                break;

            case Class.Rogue:
                strength = 2f;
                agility = 4f;
                intelligence = 1f;
                break;
        }
    }

    private void OnRaceChange()
    {
        switch (playerRace)
        {
            case Race.Human:
                SetMaxHealth(100);
                endurance = 4f;
                break;

            case Race.Gnome:
                SetMaxHealth(115);
                endurance = 3f;
                break;

            case Race.Elf:
                SetMaxHealth(85);
                endurance = 5f;
                break;
        }
    }

    private void SetMaxHealth(float newMaxHealth)
    {
        float diff = newMaxHealth - maxHealth;
        maxHealth += diff;
        health += diff;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // To Do
    }
}
