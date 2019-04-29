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
        Range
    }

    private UpgradeType upType;
    private double percentBonus;
    private int cost;
    private bool researched;

    public Upgrade(UpgradeType ut, double amount, int c)
    {
        upType = ut;
        percentBonus = amount;
        cost = c;
        researched = false;
    }

    public void SetResearched(bool r)
    {
        researched = r;
    }

    public int GetCost()
    {
        return cost;
    }
}
