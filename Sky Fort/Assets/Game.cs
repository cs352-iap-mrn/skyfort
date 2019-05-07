using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static int lumber = 100;
    private static int mp = 1500;

    private static TechTree tree = new TechTree();

    private static Tile selected;
    private static TowerInstance selectedTower;

    private static int numTiles = 9;

    private static int waveNumber = 0;

    private static bool gameOver = false;

    public static TowerInstance baseTower;

    public static Canvas progressCanvas;
    public static Canvas tilePurchaseCanvas;

    public static int score = 0;

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
    
    public static int GetWaveNumber()
    {
        return waveNumber;
    }

    public static void AddWaveNumber()
    {
        waveNumber += 1;
    }

    public static bool GetGameover()
    {
        return gameOver;
    }

    public static void SetGameover(bool b)
    {
        gameOver = b;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void IncreaseScore(int s)
    {
        score += s;
    }
}
