using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hobbit : MonoBehaviour
{
    public int health = 50;
    public int armor = 100;

    public void SaveHobbit()
    {
        SaveSystem.SaveHobbit(this);
    }
    public void LoadHobbit()
    {
        HobbitData data = SaveSystem.LoadHobbit();
        health = data.health;
        armor = data.armor;
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
    #region UI Methods
    public void ChangeHealth(int amount)
    {
        health += amount;
    }

    public void ChangeArmor(int amount)
    {
        armor += amount;
    }
    #endregion

}
