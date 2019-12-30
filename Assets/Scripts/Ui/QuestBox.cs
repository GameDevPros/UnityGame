using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBox : MonoBehaviour
{
    public GameObject player;
    public Text txtBtnOk;
    public GameObject human;

    public void btnOk_Pressed()
    {
        txtBtnOk = GameObject.Find("btnText").GetComponent<Text>();

        if(txtBtnOk.text == "Next")
        {
            human.GetComponent<HumanSpeak>().Speak();
        }
        else
        {            
            player.GetComponent<ClickToMove>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
