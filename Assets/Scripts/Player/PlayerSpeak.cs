using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeak : MonoBehaviour
{
    public GameObject human;
    public GameObject questBox;
    
    public void SpeakWithHuman()
    {   
        if(human.GetComponent<HumanSpeak>().conv.Length != 0)
        {
            //Open questbox
            questBox.SetActive(true);
            questBox.GetComponent<QuestBox>().human = human;

            //Desable moveScript
            GetComponent<ClickToMove>().enabled = false;

            //Load conversation
            human.GetComponent<HumanSpeak>().Speak();
        }
    }
}
