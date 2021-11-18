using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyReceivingDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI textMesH;
    public int _damage = 0;

    void Start()
    {
        textMesH = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_damage == 0)
        {
            textMesH.text = "";
        }
        else
        {
            textMesH.text = _damage.ToString();
        }

    }

    public void setTextDamage(float damage)
    {
        _damage = (int)damage;
    }
}
