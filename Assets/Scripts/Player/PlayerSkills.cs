using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Debug.Log("Skill 1");
        }

        if(Input.GetKeyDown("2"))
        {
            Debug.Log("Skill 2");
        }

        if(Input.GetKeyDown("3"))
        {
            Debug.Log("Skill 3");
        }
    }
}
