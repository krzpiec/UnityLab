using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WitcherData
{
    public int health = 50;
    public int armor = 100;
    public int gold = 1000;
    public int silver = 450;
    public float[] position;

    public WitcherData (Witcher witcher)
    {
        health = witcher.health;
        armor = witcher.armor;
        gold = witcher.gold;
        silver = witcher.silver;
        position = new float[3];
        position[0] = witcher.transform.position.x;
        position[1] = witcher.transform.position.y;
        position[2] = witcher.transform.position.z;

    }
}
