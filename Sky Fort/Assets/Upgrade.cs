using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    public enum UpgradeType
    {
        Health,
        Damage,
        AttackSpeed,
        Range,
        Gain
    }

    private UpgradeType upType;
    private double percentBonus;
    private int cost;
    private bool researched;
    private string name;

    public Upgrade(UpgradeType ut, double amount, int c, string n)
    {
        upType = ut;
        percentBonus = amount;
        cost = c;
        researched = false;
        name = n;
    }

    public void SetResearched(bool r)
    {
        researched = r;
    }

    public int GetCost()
    {
        return cost;
    }

    internal string GetDescription()
    {
        return "Increases " + upType.ToString() + " by " + (percentBonus * 100) + "%"; 
    }

    public string GetName()
    {
        return name;
    }
}
