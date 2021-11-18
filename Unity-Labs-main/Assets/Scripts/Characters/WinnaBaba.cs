using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnaBaba : MonoBehaviour
{
    public int attack = 20;
    public int health = 60;
    public int armor = 30;
    public float overallCooldown = 5.0f;

    public void SaveWinnaBaba()
    {
        SaveSystem.SaveWinnaBaba(this);
    }
    public void LoadWinnaBaba()
    {
        WinnaBabaData data = SaveSystem.LoadWinnaBaba();
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

    public int HandAttack()
    {
        return (int)(this.attack * 0.5);
    }

    public int HighkickAttack()
    {
        return (int)(this.attack * 1.2);
    }

    #endregion

}
