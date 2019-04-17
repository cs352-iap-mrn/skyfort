using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tiles : MonoBehaviour
{
    private static readonly int SIZE = 12;
    private static readonly int NUM_INITIAL = 9;

    private static Tiles instance;
    private Tile[,] tiles;

    public GameObject tileFab;

    public Tiles(GameObject tileFab)
    {
        instance = this;

        this.tileFab = tileFab;

        tiles = new Tile[SIZE, SIZE];

        for (int r = 0; r < SIZE; r++)
        {
            for (int c = 0; c < SIZE; c++)
            {
                tiles[r, c] = new Tile(c, r);
                GameObject tileInstance = Instantiate(tileFab, new Vector3(c * 15, 0, r * 15), Quaternion.identity);
                tileInstance.SendMessage("SetXY", new int[]{ c, r });
            }
        }

        System.Random rand = new System.Random();

        int x = (int)Math.Round(SIZE / 2.0);
        int y = (int)Math.Round(SIZE / 2.0);
        for (int i = 0; i < NUM_INITIAL; i++)
        {
            tiles[y, x].SetExists(true);

            while (tiles[y, x].Exists())
            {
                if (rand.NextDouble() < 0.5)
                {
                    x = x + rand.Next(-1, 1);
                }
                else
                {
                    y = y + rand.Next(-1, 1);
                }
            }
        }
    }

    public static Tiles GetInstance()
    {
        return instance;
    }

    public Tile GetTile(int x, int y)
    {
        return tiles[y, x];
    }
}
