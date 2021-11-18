using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour, INegotitionReciever
{
    public int health = 50;
    public int armor = 100;
    public int gold = 500;

    [Header("Negotiation")]
    [SerializeField] float succesTreshold = 100;
    public float SuccesTreshold => succesTreshold;
    [SerializeField] float frytyMultiplier = 5;
    public float FrytyMultiplier => frytyMultiplier;
    [SerializeField] float winoBialMultiplier = 15;
    public float WinoBialMultiplier => winoBialMultiplier;
    [SerializeField] float winoCzerwMultiplier = 7;
    public float WinoCzerwMultiplier => winoCzerwMultiplier;
    [SerializeField] float lapuchyMultiplier = 10;
    public float LapuchyMultiplier => lapuchyMultiplier;
    public float PatianceBase = 0.5f;
    public float PatienceChange = 0.1f;

    [Header("Negotiation Text")]
    public string[]WellcomeRespnses;
    public string[] HappyRespnses;
    public string[] AngryRespnses;
    public string competneces = "-Żyje\n-Pracuje\n-Nie Nażeka";


    public void SaveElf()
    {
        SaveSystem.SaveElf(this);
    }
    public void LoadElf()
    {
        ElfData data = SaveSystem.LoadElf();
        health = data.health;
        armor = data.armor;
        gold = data.gold;
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

    public void ChangeGold(int amount)
    {
        gold += amount;
    }

    public float GetPatiance(int triesSoFar)
    {
        return PatianceBase + PatienceChange * (float)triesSoFar;
    }

    int responseCounter=0;
    public string getNextWellcomeResponse()
    {
        return WellcomeRespnses[responseCounter++ %WellcomeRespnses.Length];
    }
    public string getNextExictedResponse()
    {
        return HappyRespnses[responseCounter++ % HappyRespnses.Length];
    }

    public string getNextAngryResponse()
    {
        return AngryRespnses[responseCounter++ % AngryRespnses.Length];
    }

    public string getCompetneces()
    {
        return competneces;
    }

    public void onNegotiationSucces()
    {
        Destroy(gameObject);
    }

    public void onNegotiationFail()
    {
        Destroy(gameObject);
    }

    #endregion

}
