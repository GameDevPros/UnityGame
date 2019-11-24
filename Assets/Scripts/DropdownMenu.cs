using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour
{
    public GameObject[] prefabs;
    GameObject player;
    int prefabid;

    public void PlayerSwitch()
    {
        Dropdown dpmenu = GetComponent<Dropdown>();
        prefabid = dpmenu.value;

        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Instantiate(prefabs[prefabid], new Vector3(0, 2.41f, 0), Quaternion.identity);
    }
}
