using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    bool isRunning;
    bool isObject;
    bool isEnemy;
    RaycastHit hit;
    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            isObject = false;
            //move to point
            navMeshAgent.isStopped = false;
            if(Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.destination = hit.point;

                if(hit.collider.gameObject.tag != "Untagged")
                {
                    isObject = true;
                }
            }
        } 

        if(Input.GetMouseButtonDown(1))
        {
            isObject = false;
            //move to point
            navMeshAgent.isStopped = false;
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    navMeshAgent.destination = hit.point;
                    isEnemy = true;
                }
                else
                {
                    Debug.Log("Dies kann ich nicht angreifen");
                }
            }
        }              
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && isEnemy)
        {
            navMeshAgent.isStopped = true;
            Debug.Log("Attack");
            isEnemy = false;
        }

        if(other.gameObject.tag == "Chest" && isObject)
        {
            navMeshAgent.isStopped = true;
            Debug.Log("Open");
            isObject = false;
        }
    }
}
