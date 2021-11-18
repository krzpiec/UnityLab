using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WinnaBabaData
{
    public int health = 50;
    public int armor = 100;
    public float[] position;

    public WinnaBabaData(WinnaBaba winnaBaba)
    {
        health = winnaBaba.health;
        armor = winnaBaba.armor;
        position = new float[3];
        position[0] = winnaBaba.transform.position.x;
        position[1] = winnaBaba.transform.position.y;
        position[2] = winnaBaba.transform.position.z;

    }
}
