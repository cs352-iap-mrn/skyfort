using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTree
{
    private static List<Tower> availableTowers = new List<Tower>();
    private static List<Tower> lockedTowers = new List<Tower>();

    private static Dictionary<Tower, int> progress = new Dictionary<Tower, int>();

    // This bool is used to send updates to the shop UI
    public static bool researchCompleted = false;

    public static bool Research(Tower t)
    {
        bool researchFinished = false;

        if (progress.ContainsKey(t))
        {
            progress[t] += 1;
            if (progress[t] >= t.GetCost() * 1000)
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

    public static List<Tower> GetAvailable()
    {
        return availableTowers;
    }

    public static List<Tower> GetLocked()
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
            progress.Add(t, 0);
        }

        researchCompleted = true;
    }
}
