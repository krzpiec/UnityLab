using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryUI : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image =GetComponent<Image>();
    }

    public void setTryState(bool state)
    {
        float alpha = state ? 1 : 0;
        image.color  =new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}
