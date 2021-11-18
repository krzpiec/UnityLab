using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaluchData
{
    public int health = 50;
    public int armor = 100;
    public float[] position;

    public PaluchData(Paluch paluch)
    {
        health = paluch.health;
        armor = paluch.armor;
        position = new float[3];
        position[0] = paluch.transform.position.x;
        position[1] = paluch.transform.position.y;
        position[2] = paluch.transform.position.z;

    }
}
