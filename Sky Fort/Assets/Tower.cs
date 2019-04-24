using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    private int cost;
    private string name;


    private bool researched = false;

    public Tower(int cost, string name, int range, int damage, double attackSpeed)
    {
        this.cost = cost;
        this.name = name;
    }

    public void Research()
    {
        researched = true;
    }

    public bool IsAvailable()
    {
        return researched;
    }

    public int GetCost()
    {
        return cost;
    }

    public void SetResearched(bool r)
    {
        researched = r;
    }

    public string GetName()
    {
        return name;
    }

    public void Update()
    {

    }
}
