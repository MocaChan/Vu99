using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int total = 0;
    public List<FireWall> FireWall = new List<FireWall>();
}

[Serializable]
public class FireWall
{
    public float x = 0;
    public float y = 0;
    public float z = -1;
    public int rotate = 0;
    public float type = 0;
}