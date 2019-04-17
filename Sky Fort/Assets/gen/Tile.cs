using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private bool exists;
    private bool used;

    private int x;
    private int y;

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.exists = false;
        this.used = false;
    }

    public void SetExists(bool v)
    {
        exists = v;
    }

    public bool Exists()
    {
        return exists;
    }

    public int[] getPosition()
    {
        return new int[] { x, y };
    }
}
