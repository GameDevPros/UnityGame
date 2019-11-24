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

        //Left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            isObject = false;
            //move to point   
            if(Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;

                if(hit.collider.gameObject.tag == "Chest")
                {
                    isObject = true;
                    navMeshAgent.destination = hit.point;
                    
                }
            }
        } 

        //right mouse button
        if(Input.GetMouseButtonDown(1))
        {
            //move to point         
            if(Physics.Raycast(ray, out hit, 100))
            {
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    navMeshAgent.isStopped = false;
                    isEnemy = true;
                    navMeshAgent.destination = hit.point;
                }
                else
                {
                    Debug.Log("You can't attack this target.");
                }
            }
        }

        //When object is reached then interact with it
        if(Vector3.Distance(transform.position, navMeshAgent.destination) <= 4)
        {
            if(isObject)
            {
                navMeshAgent.isStopped = true;
                Debug.Log("Open Chest");
                isObject = false;
            }

            if(isEnemy)
            {
                navMeshAgent.isStopped = true;
                Debug.Log("Attack Enemy");
                isEnemy = false;
            }
            
        }              
    }
}
