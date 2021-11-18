using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HobbitData
{
    public int health = 50;
    public int armor = 100;
    public float[] position;

    public HobbitData(Hobbit hobbit)
    {
        health = hobbit.health;
        armor = hobbit.armor;
        position = new float[3];
        position[0] = hobbit.transform.position.x;
        position[1] = hobbit.transform.position.y;
        position[2] = hobbit.transform.position.z;

    }
}
