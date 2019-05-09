using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tiles
{
    public static readonly int SIZE = 12;

    private static Tiles instance;
    private Tile[,] tiles;

    public GameObject tileFab;

    public Tiles(GameObject tileFab)
    {
        instance = this;

        this.tileFab = tileFab;

        tiles = new Tile[SIZE, SIZE];

        
        Camera.main.transform.Translate(new Vector3((SIZE / 2) * 15, 65, (SIZE / 2 - 2) * 15));
        Camera.main.transform.Rotate(55, 0, 0);

        for (int r = 0; r < SIZE; r++)
        {
            for (int c = 0; c < SIZE; c++)
            {
                tiles[r, c] = new Tile(c, r);
                GameObject tileInstance = GameObject.Instantiate(tileFab, new Vector3(c * 15, 0, r * 15), Quaternion.identity);
                tileInstance.SendMessage("SetXY", new int[]{ c, r });
            }
        }

        for (int r = SIZE / 2 - 1; r <= SIZE / 2 + 1; r++)
        {
            for (int c = SIZE / 2 - 1; c <= SIZE / 2 + 1; c++)
            {
                tiles[r, c].SetExists(true);
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

    public bool HasAdjacentExist(int x, int y)
    {
        bool left = (x > 0) ? tiles[y, x - 1].Exists() : false;
        bool right = (x < SIZE - 1) ? tiles[y, x + 1].Exists() : false;
        bool up = (y > 0) ? tiles[y - 1, x].Exists() : false;
        bool down = (y < SIZE - 1) ? tiles[y + 1, x].Exists() : false;

        return (left || right || up || down);
    }

    // TODO Does work But check again
    public int[] GetEndPositions() {
        int leftMost = 0;
        int rightMost = 0;
        int topMost = 0;
        int bottomMost = 0;

        for (int r = 0; r < SIZE; r++)
        {
            for (int c = 0; c < SIZE; c++)
            {
                if (tiles[r, c].Exists())
                {
                    if (c > leftMost)
                    {
                        leftMost = c;
                    }

                    if (c < rightMost)
                    {
                        rightMost = c;                       
                    }

                    if (r > topMost)
                    {
                        topMost = r;
                    }

                    if (r < bottomMost)
                    {
                        bottomMost = r;                       
                    }
                }
            }
        }
        int[] ret = {leftMost, rightMost, bottomMost, topMost};
        return ret;
    }
}
