using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals {
    GameObject fab;
    public static int portalNumber;
    private bool enabled;

    public static List<GameObject> portalList = new List<GameObject>();

    public Portals(GameObject fab, int portNum) {
        portalNumber = portNum;
        this.fab = fab;

        // Make them work properly
        int[] edges = Tiles.GetInstance().GetEndPositions();

        for (int i = 0; i < portalNumber; i++)
        {
            int direction = UnityEngine.Random.Range(0, 4);

            // LR
            if (direction == 0 || direction == 1)
            {
                portalList.Add(GameObject.Instantiate(fab, new Vector3(edges[direction] * 25, 7, UnityEngine.Random.Range(edges[2] * 15, edges[3] * 25)), Quaternion.Euler(new Vector3(0, 0, 90))));
            }
            // TR
            else
            {
                portalList.Add(GameObject.Instantiate(fab, new Vector3(UnityEngine.Random.Range(edges[0] * 15, edges[1] * 15), 7, edges[direction] * 25), Quaternion.Euler(new Vector3(0, 90, 90))));
            }
        }

        enabled = true;
    }

    public void RemoveAll()
    {
        foreach (GameObject p in portalList)
        {
            GameObject.Destroy(p);
        }
        enabled = false;
    }

    public bool IsAllDead()
    {
        return portalList.Count == 0;
    }

    public bool GetEnable() 
    {
        return enabled;
    }

    public Vector3[] GetPositions()
    {
        Vector3[] posList = new Vector3[portalNumber];
        for (int i = 0; i < portalNumber; i++)
        {
            posList[i] = portalList[i].transform.position;
        }

        return posList;
    }

    public void SetEnable(bool v) 
    {
        enabled = v;
    }
}