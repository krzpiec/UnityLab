using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZiemniakData
{
    public int health = 50;
    public int armor = 100;
    public float[] position;

    public ZiemniakData(Ziemniak ziemniak)
    {
        health = ziemniak.health;
        armor = ziemniak.armor;
        position = new float[3];
        position[0] = ziemniak.transform.position.x;
        position[1] = ziemniak.transform.position.y;
        position[2] = ziemniak.transform.position.z;

    }
}
