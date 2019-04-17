using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static int lumber = 30;
    private static int mp = 0;

    public static void AddLumber(int amount)
    {
        lumber += amount;
    }

    public static int GetLumber()
    {
        return lumber;
    }

    public static void AddMP(int amount)
    {
        mp += amount;
    }

    public static int GetMP()
    {
        return mp;
    }
}
