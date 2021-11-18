using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElfData
{
    public int health = 50;
    public int armor = 100;
    public int gold = 500;
    public float[] position;

    public ElfData(Elf elf)
    {
        health = elf.health;
        armor = elf.armor;
        gold = elf.gold;
        position = new float[3];
        position[0] = elf.transform.position.x;
        position[1] = elf.transform.position.y;
        position[2] = elf.transform.position.z;

    }
}
