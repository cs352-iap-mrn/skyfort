using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tiles
{
    private static readonly int SIZE = 12;
    //private static readonly int NUM_INITIAL = 9;

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
                GameObject tileInstance = GameObject.Instantiate(tileFab, new Vector3(c * 15, 0, r * 15), Quaternion.identity);
                tileInstance.SendMessage("SetXY", new int[]{ c, r });
            }
        }

        System.Random rand = new System.Random();

        for (int r = SIZE / 2 - 1; r <= SIZE / 2 + 1; r++)
        {
            for (int c = SIZE / 2 - 1; c <= SIZE / 2 + 1; c++)
            {
                tiles[r, c].SetExists(true);
            }
        }

        //Camera.main.transform.Translate(new Vector3((SIZE / 2) * 15, 0, (SIZE / 2) * 15));
        Camera.main.transform.Translate(new Vector3((SIZE / 2) * 15, 0, (SIZE / 2 - 7) * 15));

        //int x = (int)Math.Round(SIZE / 2.0);
        //int y = (int)Math.Round(SIZE / 2.0);
        //for (int i = 0; i < NUM_INITIAL; i++)
        //{
        //    tiles[y, x].SetExists(true);

        //    while (tiles[y, x].Exists())
        //    {
        //        if (rand.NextDouble() < 0.5)
        //        {
        //            x = x + rand.Next(-1, 1);
        //        }
        //        else
        //        {
        //            y = y + rand.Next(-1, 1);
        //        }
        //    }
        //}
    }

    public static Tiles GetInstance()
    {
        return instance;
    }

    public Tile GetTile(int x, int y)
    {
        return tiles[y, x];
    }

    public bool HasAdjacentExist(int x, int y)
    {
        bool left = (x > 0) ? tiles[y, x - 1].Exists() : false;
        bool right = (x < SIZE - 1) ? tiles[y, x + 1].Exists() : false;
        bool up = (y > 0) ? tiles[y - 1, x].Exists() : false;
        bool down = (y < SIZE - 1) ? tiles[y + 1, x].Exists() : false;

        return (left || right || up || down);
    }
}
