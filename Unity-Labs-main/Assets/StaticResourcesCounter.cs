using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticResourcesCounter : MonoBehaviour
{

    public Text WinoCzerwoneText;
    public Text WInoBialeText;
    public Text LapuszkiText;
    public Text FrytkiText;
    public Text HajsZlotyText;
    public Text HajsSrebrnyText;



    void updateResources()
    {
        WinoCzerwoneText.text = StaticValues.WinoCzerwone.ToString();
        WInoBialeText.text = StaticValues.WInoBiale.ToString();
        LapuszkiText.text = StaticValues.Lapuszki.ToString();
        FrytkiText.text = StaticValues.Frytki.ToString();
        HajsZlotyText.text = StaticValues.HajsZloty.ToString();
        HajsSrebrnyText.text = StaticValues.HajsSrebrny.ToString();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        updateResources();
        StaticValues.updateEvent += updateResources;
    }


    void OnDisable()
    {
        StaticValues.updateEvent -= updateResources;
    }



}
