using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public bool isRunning;
    bool isObject;
    bool isEnemy;
    RaycastHit hit;

    Animator animator;
		
    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            isObject = false;
            //move to point   
            if(Physics.Raycast(ray, out hit, 1000))
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;

                if(hit.collider.gameObject.tag == "Chest")
                {
                    isObject = true;
                    navMeshAgent.destination = hit.point;
                }

                if(hit.collider.gameObject.tag == "Enemy")
                {
                    navMeshAgent.isStopped = false;
                    isEnemy = true;
                    navMeshAgent.destination = hit.point;
                }
            }
        }

        //When object is reached then interact with it
        if(Vector3.Distance(transform.position, navMeshAgent.destination) <= 1)
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

        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            isRunning = true;  
        else
            isRunning = false;  
    }
}
