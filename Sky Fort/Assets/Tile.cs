using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private bool exists;
    private bool used;

    //private GameObject held;
    private TowerInstance held;

    private int x;
    private int y;

    public bool hover;

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

    public void SetUsed(bool v)
    {
        used = v;
    }

    public bool Exists()
    {
        return exists;
    }

    public bool Used()
    {
        return used;
    }

    public int[] GetPosition()
    {
        return new int[] { x, y };
    }

    public TowerInstance GetHeld()
    {
        return held;
    }

    public void Hold(TowerInstance t)
    {
        held = t;
    }
}
