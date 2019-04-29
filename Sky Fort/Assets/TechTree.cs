using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTree
{
    private static List<Tower> availableTowers = new List<Tower>();
    private static List<Tower> lockedTowers = new List<Tower>();

    private static Dictionary<Tower, int> towerProgress = new Dictionary<Tower, int>();

    private static List<Upgrade> availableUpgrades = new List<Upgrade>();
    private static List<Upgrade> lockedUpgrades = new List<Upgrade>();

    private static Dictionary<Upgrade, int> upgradeProgress = new Dictionary<Upgrade, int>();

    // This bool is used to send updates to the shop UI
    public static bool researchCompleted = false;

    public static bool ResearchTower(Tower t)
    {
        bool researchFinished = false;

        if (towerProgress.ContainsKey(t))
        {
            towerProgress[t] += 1;
            if (towerProgress[t] >= t.GetCost() * 1000)
            {
                lockedTowers.Remove(t);
                availableTowers.Add(t);
                t.SetResearched(true);

                researchCompleted = true;
                researchFinished = true;
            }
        }
        return researchFinished;
    }

    public static List<Tower> GetAvailableTowers()
    {
        return availableTowers;
    }

    public static List<Tower> GetLockedTowers()
    {
        return lockedTowers;
    }

    public static void AddTower(bool locked, Tower t)
    {
        if (!locked)
        {
            availableTowers.Add(t);
        }
        else
        {
            lockedTowers.Add(t);
            towerProgress.Add(t, 0);
        }

        researchCompleted = true;
    }

    public static bool ResearchUpgrade(Upgrade t)
    {
        bool researchFinished = false;

        if (upgradeProgress.ContainsKey(t))
        {
            upgradeProgress[t] += 1;
            if (upgradeProgress[t] >= t.GetCost() * 1000)
            {
                lockedUpgrades.Remove(t);
                availableUpgrades.Add(t);
                t.SetResearched(true);

                researchCompleted = true;
                researchFinished = true;
            }
        }
        return researchFinished;
    }

    public static List<Upgrade> GetAvailableUpgrades()
    {
        return availableUpgrades;
    }

    public static List<Upgrade> GetLockedUpgrades()
    {
        return lockedUpgrades;
    }

    public static void AddUpgrade(bool locked, Upgrade t)
    {
        if (!locked)
        {
            availableUpgrades.Add(t);
        }
        else
        {
            lockedUpgrades.Add(t);
            upgradeProgress.Add(t, 0);
        }

        researchCompleted = true;
    }
}
