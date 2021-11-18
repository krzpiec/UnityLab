using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witcher : MonoBehaviour,IPlayerFighter
{
    public int attack = 10;
    public int health = 50;
    public int armor = 100;
    public int gold = 1000;
    public int silver = 450;
    public bool _inFight = false;
    public float punchAttackCooldown = 5.0f;
    public float kickAttackCooldown = 3.0f;
    public float overallCooldown = 2.0f;
    public float guardDefenceCooldown = 3.0f;
    public float guardDefenceDuration = 1.0f;
    public bool _isGuardDefenceActive = false;

    public event System.Action deathEvent;

    public int internalAttackCounter = 0;
    public PlayerAttack getNextPlayerAttack()
    {
        PlayerAttack punch = new PlayerAttack
        {
            damage = 15,
            attackDelay = 5.0f, 
            attackName = "Cios"
        };

        PlayerAttack kick = new PlayerAttack
        {
            damage = 10,
            attackDelay = 3.0f,
            attackName = "Kick"
        };


        return internalAttackCounter++ % 2 == 0 ? punch : kick;
    }

    public void recieveDamage(float damage)
    {
        health -= (int)damage;
        if (health <= 0)
        {
            deathEvent?.Invoke();
        }
    }
    public float getPlayerHealth()
    {
        return health;
    }

    public void SaveWitcher()
    {
        SaveSystem.SaveWitcher(this);
    }
    public void LoadWitcher()
    {
        
        WitcherData data = SaveSystem.LoadWitcher();
        health = data.health;
        armor = data.armor;
        gold = data.gold;
        silver = data.silver;
        transform.position = new Vector3(data.position[0],data.position[1],data.position[2]);
        Debug.Log(new Vector3(data.position[0], data.position[1], data.position[2]));
        Debug.Log(gameObject.name);
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

    public void ChangeGold(int amount)
    {
        gold += amount;
    }

    public void ChangeSilver(int amount)
    {
        silver += amount;
    }

    public int PunchAttack()
    {
        return (int)(this.attack * 1.1);
    }

    public int KickAttack()
    {
        return (int)(this.attack * 0.7);
    }

    public float ShieldBlockValue()
    {
        if (isAttackBlocked() == true)
        {
            return 0.8f;
        }
        return 0.0f;
    }

    public float GuardDefenceValue()
    {
        if (this._isGuardDefenceActive == true)
        {
            return 0.3f;
        }
        return 0.0f;
    }

    public bool isAttackBlocked()
    {
        int numberId = Random.Range(0, 100);
        return numberId <= 5; // 5% na zablokowanie ciosu
    }

    public float DefenceValue()
    {
        if (GuardDefenceValue() != 0.0f && ShieldBlockValue() != 0.0f)
        {
            
            return 0.85f;
        }
        else if (GuardDefenceValue() != 0.0f && ShieldBlockValue() == 0.0f)
        {
            
            return GuardDefenceValue();
        }
        else if (GuardDefenceValue() == 0.0f && ShieldBlockValue() != 0.0f)
        {
           
            return ShieldBlockValue();
        }
        else
        {
            
            return 0.0f;
        }
    }



    #endregion
}
