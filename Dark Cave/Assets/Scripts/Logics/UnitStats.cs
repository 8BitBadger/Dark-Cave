using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

public enum ActorType
{
    Player,
    Slime,
    Spider,
    Skeleton,
    Beholder,
    VoidWanderer
};

[CreateAssetMenu(menuName = "Actor Stats")]

public class UnitStats : ScriptableObject
{
    //
    public float BaseValue;


    public virtual float Value
    {
        get
        {
            if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;
    protected readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public UnitStats()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public UnitStats(float baseValue) : this()
    {
        BaseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public virtual bool RemoveModifier(StatModifier mod)
    {
        
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if(a.Order < b.Order)
        {
            return -1;
        }
        else if(a.Order > b.Order)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;
        for(int i = statModifiers.Count - 1; i >= 0 ; i --)
        {
            if(statModifiers[i].Source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            }
            else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;

                if(i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }

            }
            else if(mod.Type == StatModType.PercentMult)
            {
                finalValue *= 1 + mod.Value;
            }

        }

        return (float)Math.Round(finalValue, 4);
    }








    //Identifies if the player is human or non human
    public bool AI;

    public ActorType type;

    public int strength;
    public int agility;
    public int stamina;
    public int intelligence;

    //he health of the actor
    public int health;
    //The endurance of the Actor used for attacking, blocking and mining
    public int endurance;
    //The walk speed of the actor
    [HideInInspector] public float speed;
    public float walkSpeed;
    public float sprintSpeed;

    //Stat modifiers for the charecter
    [HideInInspector] public int strengthModifier;
    [HideInInspector] public int agilityModifier;
    [HideInInspector] public int staminaModifier;
    [HideInInspector] public int intelligenceModifier;

    //The wander distance of the AI
    public float wanderDistance;

    //Attack range used for the player as well as the ai
    public float attackRange;
    //The times the player or AI can attack in a certain time
    public float attackInterval;

    //Used for the fow script
    public float viewRadius;
    public float viewAngle;
    public float viewDistance; //Used for the players field of view
    public LayerMask obstacleMask;
    public LayerMask targetLayer;

    //The abilities of the actor
    public List<AbilitySystem.Ability> abilities;

}
