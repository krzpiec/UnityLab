using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public struct MonsterAttack{
    public float targetCoverage;// beetwen 0 and 1
    public float attackDelay; // in second
    public float attackffset;//beetwen 0 and 1 make sure that targetCoverage+attackffset <1
    public float damage;

    public float getTargetStartTimestamp()
    {
        return attackDelay * attackffset;
    }

    public float getTargetEndTimestamp()
    {
        return attackDelay * (attackffset+targetCoverage);
    }
}

public struct PlayerAttack
{
    public float damage;
    public float attackDelay; // in seconds
    public string attackName;
}




public interface IMonseterFighter
{
    MonsterAttack getNextMonsterAttack();
    void recieveDamage(float damage);
    event Action deathEvent;
    float getMonsterHealth();

    
}


public interface IPlayerFighter
{
    PlayerAttack getNextPlayerAttack();
    void recieveDamage(float damage);
    float getPlayerHealth();
    event Action deathEvent;
}


enum DefendState
{
    None,
    Partial,
    Perfect
}

public class FightUI : MonoBehaviour
{
    private static FightUI instance;
    public static FightUI Instance { get => instance; }

    public Fight fightObjectInstance;

    [Header("Refrences")]
    public Text enemyHealthText;
    public Text playerHealthText;
    public Button attackButton;
    public Text attackButtonLabel;
    public Button defendButton;
    public RectTransform barTarget;
    public RectTransform barFill;
    public RectTransform barContainer;

    [Header("Settings")]
    public float perfectDefenseDamageMultiplier = 0;
    public float partiaDefenseDamageMultiplier = 0.75f;

    private IPlayerFighter playerFighter;
    private IMonseterFighter monsterFighter;
    private PlayerAttack playerAttack;
    private MonsterAttack monsterAttack;

    float playerCounter=0;
    float monsterCounter=0;

    DefendState defendState = DefendState.None;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            attackButton.onClick.AddListener(onAttackButton);
            defendButton.onClick.AddListener(onDefendButton);

        }

        GameObject fightObjectParent = GameObject.FindGameObjectWithTag("FightObject");
        fightObjectInstance = fightObjectParent.gameObject.transform.GetChild(0).gameObject.GetComponent<Fight>();
    
        this.gameObject.SetActive(false);
    }


    void onPlayerDeath()
    {
        endFight();
    }

    void onMonsterDeath()
    {
        endFight();
    }

    public void beginFight(IPlayerFighter player,IMonseterFighter monster)
    {

        if(player==null || monster == null)
        {
            Debug.LogWarning("Started fight with null participant");
            return;
        }

        playerFighter = player;
        monsterFighter = monster;
        playerFighter.deathEvent += onPlayerDeath;
        monsterFighter.deathEvent += onMonsterDeath;
        
        gameObject.SetActive(true);
        initPlayerAttack(player.getNextPlayerAttack());
        initMonsterAttack(monster.getNextMonsterAttack());
        enemyHealthText.text = monster.getMonsterHealth().ToString();
        playerHealthText.text = player.getPlayerHealth().ToString();
    }





    public void endFight()
    {
        
        playerFighter.deathEvent -= onPlayerDeath;
        monsterFighter.deathEvent -= onMonsterDeath;
        Debug.Log("endFight");
        StartCoroutine(fightObjectInstance.endFight());
    }


    string getFormatedAttackName(PlayerAttack attack, float counter)
    {
        float countdown = attack.attackDelay - counter;

        if (countdown <= 0)
        {
            return attack.attackName;
        }
        else
        {
            return attack.attackName +" ("+ ((int)countdown).ToString()+")";
        }


    }

    void initPlayerAttack(PlayerAttack attack)
    {
        playerCounter = 0;
        playerAttack = attack;
        attackButtonLabel.text = getFormatedAttackName(attack, playerCounter);
        attackButton.enabled = false;
    }

    void initMonsterAttack(MonsterAttack attack)
    {
        barFill.sizeDelta = new Vector2(0, barFill.sizeDelta.y);
        monsterCounter = 0;
        monsterAttack = attack;

        float width = barContainer.sizeDelta.x;

        barTarget.sizeDelta = new Vector2(attack.targetCoverage * width, barTarget.sizeDelta.y);
        barTarget.anchoredPosition = new Vector3(attack.attackffset * width, 0, 0);
        defendState = DefendState.None;
        defendButton.enabled = true;
    }

    void onAttackButton()
    {
        if (playerCounter >= playerAttack.attackDelay)
        {
            monsterFighter.recieveDamage(playerAttack.damage);
            initPlayerAttack(playerFighter.getNextPlayerAttack());
            enemyHealthText.text = monsterFighter.getMonsterHealth().ToString();
        }
    }

    void onDefendButton()
    {
        defendButton.enabled = false;
        if (monsterCounter < monsterAttack.getTargetStartTimestamp())
        {
            defendState = DefendState.None;
        }else if(monsterCounter < monsterAttack.getTargetEndTimestamp())
        {
            defendState = DefendState.Perfect;
        }
        else
        {
            defendState = DefendState.Partial;
        }

    }

    private void Update()
    {
        playerCounter += Time.deltaTime;
        monsterCounter += Time.deltaTime;

        float playerCountDown = playerAttack.attackDelay - playerCounter;
        float monsterCountDown = monsterAttack.attackDelay - monsterCounter;


        attackButtonLabel.text = getFormatedAttackName(playerAttack, playerCounter);
        if (playerCountDown <= 0)
        {
            attackButton.enabled = true;
        }

        float width = barContainer.sizeDelta.x;
        barFill.sizeDelta = new Vector2(width * (monsterCounter / monsterAttack.attackDelay), barFill.sizeDelta.y);



        if (monsterCountDown <= 0)
        {
            float multiplier = 1;

            switch (defendState)
            {
                case DefendState.None:
                    multiplier = 1;
                    break;
                case DefendState.Partial:
                    multiplier = partiaDefenseDamageMultiplier;
                    break;
                case DefendState.Perfect:
                    multiplier = perfectDefenseDamageMultiplier;
                    break;
                default:
                    break;
            }

            Debug.Log(monsterAttack.damage * multiplier);
            playerFighter.recieveDamage(monsterAttack.damage* multiplier);
            playerHealthText.text = playerFighter.getPlayerHealth().ToString();
            initMonsterAttack(monsterFighter.getNextMonsterAttack());
        }

    }

}
