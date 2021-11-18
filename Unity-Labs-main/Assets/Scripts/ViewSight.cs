using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewSight : MonoBehaviour
{
    public Fight fight;


    public Witcher witcher;
    public Rigidbody rigbod;
    public Mover mover;
    public Camera camera;
    public Ziemniak ziemniakEnemy;
    public Paluch paluchEnemy;
    public WinnaBaba winnaBabaEnemy;
    public Elf elfProgrammer;
    public Vector3 cameraVecBeforeFight;
    public Vector3 cameraEulBeforeFight;
    public Vector3 witcherVecBeforeFight;
   
    public EndGameMenu endGameMenu;
    public FightUI fightUI;
    public WitcherReceivingDamage witcherReceivingDamage;
    public EnemyReceivingDamage enemyReceivingDamage;
    public string actualdialogue;
    public int elfChatIndex;
    public int witcherChatIndex;
    public bool witcherTalking;
    public int witcherDialogueOption;
    public int elfDialogueOption;

    private GameObject marker;

    void Start()
    {
        actualdialogue = "Jestem głodnym elfem programistą, popracuje dla cb za co nieco";
        elfChatIndex = 0;
        witcherChatIndex = 0;
        witcherTalking = false;
        witcherDialogueOption = 0;

    }

    // Update is called once per frame
    void Update()
    {
       
        //#region Elf Trading
        //if (elfProgrammer)
        //{
        //    //dialog z elfem
        //    //Debug.Log("Chat Index: " + witcherChatIndex.ToString() + " Option index: " + witcherDialogueOption.ToString());
        //    string[,] elfdialogue = new string[4, 3] {
        //        {"Super! jestem twoj","Spokojnie, juz odchodze","Chce siedem win, trzy paczki paluszkow i trzy frytek"},
        //        {"", "Hmm... kuszaca propozycja, zgadzam sie!", "" },
        //        {"", "","" },
        //        {" ", "", "" } };
        //    string[,] witcherdialogue = new string[4, 3] {
        //        {" F1. Chetnie cie zatrudnie, proponuje pięć win, dwie paczki paluszków i cztery frytek  F2.Nie chce z toba wspolpracowac   F3. zatrudnie cie mow ile chcesz",
        //        "", "" },
        //        {"Super, zaczynamy od jutra", "",""}, //odp na F1
        //        {"No raczej!", "",""},//odp na F2
        //        {"Oki biore", "",""} };//odp na F3
        //    if (witcherChatIndex == 1 && witcherDialogueOption == 0)
        //    {
        //        if (Input.GetKeyDown(KeyCode.F1))
        //        {
        //            elfDialogueOption = 0;
        //            elfChatIndex = 0;
        //            witcherDialogueOption = 1;
        //            witcherChatIndex = 0;
        //        }
        //        if (Input.GetKeyDown(KeyCode.F2))
        //        {
        //            elfDialogueOption = 0;
        //            elfChatIndex = 1;
        //            witcherDialogueOption = 2;
        //            witcherChatIndex = 0;
        //        }
        //        if (Input.GetKeyDown(KeyCode.F3))
        //        {
        //            elfDialogueOption = 0;
        //            elfChatIndex = 2;
        //            witcherDialogueOption = 3;
        //            witcherChatIndex = 0;
        //        }

        //        if (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.F3))
        //        {
        //            if (witcherTalking)
        //            {
        //                Debug.Log(witcherChatIndex);
        //                actualdialogue = elfdialogue[elfDialogueOption, elfChatIndex];
        //            }
        //            else
        //            {
        //                actualdialogue = witcherdialogue[witcherDialogueOption, witcherChatIndex];
        //            }
        //            witcherTalking = !witcherTalking;
        //        }

        //    }
        //    if (Input.GetKeyDown(KeyCode.P))
        //    {

        //        if (witcherTalking)
        //        {
        //            Debug.Log(witcherChatIndex);
        //            actualdialogue = elfdialogue[elfDialogueOption, elfChatIndex];
        //        }
        //        else
        //        {
        //            actualdialogue = witcherdialogue[witcherDialogueOption, witcherChatIndex++];
        //        }
        //        witcherTalking = !witcherTalking;
        //    }
        //    Debug.Log(actualdialogue);

        //}

        //#endregion
    }


    private void OnTriggerEnter(Collider other)
    {

        ziemniakEnemy = other.GetComponent<Ziemniak>();
        paluchEnemy = other.GetComponent<Paluch>();
        winnaBabaEnemy = other.GetComponent<WinnaBaba>();
        elfProgrammer = other.GetComponent<Elf>();

        IMonseterFighter monseterFighter = other.GetComponent<IMonseterFighter>();
        INegotitionReciever negotitionReciever = other.GetComponent<INegotitionReciever>();

        if (monseterFighter != null)//tutaj przeniesc do sceny walki
        {
            Debug.Log("asd");
            GameObject fightObjectParent = GameObject.FindGameObjectWithTag("FightObject");
            GameObject fightObject = fightObjectParent.gameObject.transform.GetChild(0).gameObject;
            fightObject.GetComponent<Fight>().enemy = other.gameObject;
            fightObject.GetComponent<Fight>().witcher = this.gameObject;
            fightObject.SetActive(true);

            if (FightUI.Instance.gameObject.activeSelf == false)
            {
                FightUI.Instance.beginFight(witcher, monseterFighter);
            }

            return;
        }

        if (negotitionReciever != null)//tutaj przeniesc do sceny negocjacji
        {
            GameObject negotiationObjectParent = GameObject.FindGameObjectWithTag("NegotiationObject");
            GameObject negotiationObject = negotiationObjectParent.gameObject.transform.GetChild(0).gameObject;
            negotiationObject.GetComponent<Negotiation>().negotiator = other.gameObject;
            negotiationObject.GetComponent<Negotiation>().witcher = this.gameObject;
            negotiationObject.SetActive(true);
            NegotiationUI ui = NegotiationUI.Instance;
            Debug.Log(ui.ToString());
            if (ui.gameObject.activeSelf == false)
            {
                NegotiationUI.Instance.BeginNegotiation(negotitionReciever);
            }

            return;

        }
    }
}


