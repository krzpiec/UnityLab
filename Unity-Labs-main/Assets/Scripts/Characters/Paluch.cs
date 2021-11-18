using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paluch : MonoBehaviour
{
    public int attack = 30;
    public int health = 50;
    public int armor = 50;
    public float overallCooldown = 6.0f;

    public void SavePaluch()
    {
        SaveSystem.SavePaluch(this);
    }
    public void LoadPaluch()
    {
        PaluchData data = SaveSystem.LoadPaluch();
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

    public int SwordAttack()
    {
        return (int)(this.attack * 1.3);
    }

    public int QuickStabAttack()
    {
        return (int)(this.attack * 0.9);
    }
    #endregion

}
