using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public bool isRunning;
    bool isObject;
    bool isHuman;
    bool isEnemy;
    RaycastHit hit;

    Animator animator;
		
    PlayerCombat playerCombat;
    PlayerSpeak playerSpeak;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
        playerSpeak = GetComponent<PlayerSpeak>();
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

                if(hit.collider.gameObject.tag == "Human")
                {
                    navMeshAgent.isStopped = false;
                    isHuman = true;
                    navMeshAgent.destination = hit.point;

                    playerSpeak.human = hit.collider.gameObject;
                }
            }
        }

        //When object is reached then interact with it
        if(Vector3.Distance(transform.position, navMeshAgent.destination) <= 1.2f)
        {
            if(isObject)
            {
                navMeshAgent.isStopped = true;
                isObject = false;
                Debug.Log("Open Chest");
            }

            if(isEnemy)
            {
                navMeshAgent.isStopped = true;
                isEnemy = false;
                playerCombat.Attack();
            }
            
            if(isHuman)
            {
                navMeshAgent.isStopped = true;
                isHuman = false;
                playerSpeak.SpeakWithHuman();
            }
        }

        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            isRunning = true;  
        else
            isRunning = false;  
    }
}
