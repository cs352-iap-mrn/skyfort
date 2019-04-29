using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static int lumber = 50;
    private static int mp = 0;

    private static TechTree tree = new TechTree();

    private static Tile selected;
    private static TowerInstance selectedTower;

    private static int numTiles = 9;

    private int waveNumber = 1;

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

    public static void Select(Tile tile)
    {
        selected = tile;
    }

    public static Tile GetSelected()
    {
        return selected;
    }

    public static void SelectTower(TowerInstance newTower)
    {
        selectedTower = newTower;
    }

    public static TowerInstance GetSelectedTower()
    {
        return selectedTower;
    }

    public static int GetNumTiles()
    {
        return numTiles;
    }

    public static void AddTile(int num)
    {
        numTiles += num;
    }
}
