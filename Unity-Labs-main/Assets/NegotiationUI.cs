using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;


public interface INegotitionReciever
{
    float SuccesTreshold { get; }
    float FrytyMultiplier { get; }
    float WinoBialMultiplier { get; }
    float WinoCzerwMultiplier { get; }
    float LapuchyMultiplier { get; }

    float GetPatiance(int triesSoFar); // valueBeetwen 0 and 1 increeses with number of tries

    string getNextWellcomeResponse();
    string getNextExictedResponse();
    string getNextAngryResponse();

    string getCompetneces();

    void onNegotiationSucces();
    void onNegotiationFail();

}


public class NegotiationUI : MonoBehaviour
{

    private static NegotiationUI instance=null;
    public static NegotiationUI Instance { get => instance; }


    [Header("Refrences")]
    public Button makeOfferButton;
    public Text responseText;
    public Text competencesText;
    public OfferUI frytyOffer;
    public OfferUI lapuchOffer;
    public OfferUI winoBialeOffer;
    public OfferUI winoCzerwoneOffer;

    public Negotiation negotiationObjectInstace;
    public Negotiation negotiationObject;

    public TryUI[] tries;
    private OfferUI[] offers;

    


    int triesRemaining = 5;
    int tryCounter = 0;
    private INegotitionReciever negoitator;


    private void Start()
    {
        

    }

    private void Awake()
    {

        if (NegotiationUI.instance == null)
        {
            NegotiationUI.instance = this;
            offers = GetComponentsInChildren<OfferUI>();

            frytyOffer = offers.Where(offer => { return offer.tradeableType == Tradable.Fryty; }).FirstOrDefault();
            lapuchOffer = offers.Where(offer => { return offer.tradeableType == Tradable.Lapuchy; }).FirstOrDefault();
            winoBialeOffer = offers.Where(offer => { return offer.tradeableType == Tradable.WionBial; }).FirstOrDefault();
            winoCzerwoneOffer = offers.Where(offer => { return offer.tradeableType == Tradable.WinoCzerw; }).FirstOrDefault();

            tries = GetComponentsInChildren<TryUI>();

            makeOfferButton.onClick.AddListener(onSubmitButton);
            
        }

        gameObject.SetActive(false);
        GameObject negotiationObjectParent = GameObject.FindGameObjectWithTag("NegotiationObject");
        negotiationObject = negotiationObjectParent.gameObject.transform.GetChild(0).gameObject.GetComponent<Negotiation>();
       // negotiationObject = GameObject.FindGameObjectWithTag("NegotiationObject").GetComponentInChildren<Negotiation>();
    }


    public void BeginNegotiation(INegotitionReciever negoitator)
    {
        this.gameObject.SetActive(true);
        this.negoitator = negoitator;


        competencesText.text = negoitator.getCompetneces();
        responseText.text = negoitator.getNextWellcomeResponse();

        setTries(5);
        tryCounter = 0;

        foreach (var offer in offers)
        {
            offer.resetState();
        }

    }

    void setTries(int newTries)
    {
        triesRemaining = newTries;
        for (int i = 0; i < tries.Length; i++)
        {
            tries[i].setTryState(i < newTries);
        }
        
    }

    public void EndNegotiation()
    {
        Debug.Log("endnegotiation");
        StartCoroutine(negotiationObject.endNegotiation());
        //this.gameObject.SetActive(false);
    }

    float calcOfferStrangth()
    {
        float ammount = frytyOffer.amount * negoitator.FrytyMultiplier +
            winoBialeOffer.amount * negoitator.WinoBialMultiplier +
            winoCzerwoneOffer.amount * negoitator.WinoCzerwMultiplier +
            lapuchOffer.amount * negoitator.LapuchyMultiplier;

        return ammount;
            

    }


    void onSubmitButton()
    {
        float offerStrength = calcOfferStrangth();

        if (offerStrength >= negoitator.SuccesTreshold)
        {
            foreach (var pffer in offers)
            {
                pffer.sublitOffer();
            }
            negoitator.onNegotiationSucces();
            EndNegotiation();
            return;
        }else if(offerStrength >=negoitator.SuccesTreshold*negoitator.GetPatiance(tryCounter)){
            responseText.text = negoitator.getNextExictedResponse();
        }
        else
        {
            triesRemaining--;
            setTries(triesRemaining);
            responseText.text = negoitator.getNextAngryResponse();

            if(triesRemaining <= 0)
            {
                negoitator.onNegotiationFail();
                EndNegotiation();
                return;
            }
        }

        tryCounter++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
