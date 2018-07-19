using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public bool walkable;
    public Vector3 worldPosition;
    int hCost;
    int gCost;
    

    public Node(bool _walkable, Vector3 _worldPosition)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
    }

    //figure out how to math
    public void SetGCost()
    {
        //??
    }
    private int GetGCost()
    {
        return gCost;
    }

    //Heuristic cost calculated as Euclidian Distance and rounded to integer
    public void SetHCost(Vector3 _endPosition)
    {
        hCost = Mathf.RoundToInt(Mathf.Sqrt(Mathf.Pow((worldPosition.x - _endPosition.x), 2) + Mathf.Pow((worldPosition.y - _endPosition.y), 2) + Mathf.Pow((worldPosition.z - _endPosition.z), 2)));
    }
    private int GetHCost()
    {
        return hCost;
    }

    public int GetFCost()
    {
        return GetGCost() + GetHCost();
    }
}
