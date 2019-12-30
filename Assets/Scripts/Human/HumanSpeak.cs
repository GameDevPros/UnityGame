using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HumanSpeak : MonoBehaviour
{
    TextMeshProUGUI txtQuestHead;
    TextMeshProUGUI txtConversation;
    Text txtBtnOk;

    public TextAsset[] conv;
    public int convId = 0;

    public void Speak()
    {
        txtQuestHead = GameObject.Find("txtQuestHead").GetComponent<TextMeshProUGUI>();
        txtConversation = GameObject.Find("txtConversation").GetComponent<TextMeshProUGUI>();
        txtBtnOk = GameObject.Find("btnText").GetComponent<Text>();

        txtQuestHead.text = name;
        txtConversation.text = conv[convId].text;
        convId ++;

        if(convId < conv.Length)
        {
            txtBtnOk.text = "Next";
        }
        else
        {
            txtBtnOk.text = "End";
            convId = 0;
        }
    }
}
