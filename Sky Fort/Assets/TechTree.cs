using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTree
{
    public interface ITechtreeable
    {
        void Refresh();
    }

    private static List<Tower> availableTowers = new List<Tower>();
    private static List<Tower> lockedTowers = new List<Tower>();

    private static Dictionary<Tower, int> towerProgress = new Dictionary<Tower, int>();

    private static List<Upgrade> availableUpgrades = new List<Upgrade>();
    private static List<Upgrade> lockedUpgrades = new List<Upgrade>();

    private static Dictionary<Upgrade, int> upgradeProgress = new Dictionary<Upgrade, int>();

    // This bool is used to send updates to the shop UI
    public static bool researchCompleted = false;

    public static List<ITechtreeable> callbacks = new List<ITechtreeable>();

    public static void Update()
    {
        if (researchCompleted)
        {
            foreach (ITechtreeable i in callbacks)
            {
                i.Refresh();
            }

            researchCompleted = false;
        }
    }

    public static void ResearchTower(Tower t)
    {
        if (towerProgress.ContainsKey(t) && Game.GetMP() > 0)
        {
            Game.AddMP(-1);
            towerProgress[t] += 1;
            if (towerProgress[t] >= t.GetCost())
            {
                lockedTowers.Remove(t);
                availableTowers.Add(t);
                t.SetResearched(true);

                researchCompleted = true;
            }
        }
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
    }

    public static void ResearchUpgrade(Upgrade t)
    {
        if (upgradeProgress.ContainsKey(t) && Game.GetMP() > 0)
        {
            Game.AddMP(-1);
            upgradeProgress[t] += 1;
            if (upgradeProgress[t] >= t.GetCost())
            {
                lockedUpgrades.Remove(t);
                availableUpgrades.Add(t);
                t.SetResearched(true);

                researchCompleted = true;
            }
        }
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
    }

    public static int GetProgress(Tower t)
    {
        return towerProgress[t];
    }

    public static int GetProgress(Upgrade t)
    {
        return upgradeProgress[t];
    }
}
