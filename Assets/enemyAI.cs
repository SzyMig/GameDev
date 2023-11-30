using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    Transform player; // Reference to the player's position.
    NavMeshAgent nav; // Reference to the nav mesh agent.
    public int enemyHP = 3;
    public float chaseStartDistance = 3.0f; // Example value, in Unity units
    public float chaseStopDistance = 5.0f;  // Example value, in Unity units
    public float safeDistance = 20.0f;       // Example value, in Unity units
    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    public enum States
    {
        idle,
        chase,
        escape
    }
    public States _state = States.idle;

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0) 
        {
            Destroy(gameObject);
        }
        switch (_state)
        {
            case States.idle:
                // Implement Idle behavior
                CheckForChase();
                break;
            case States.chase:
                // Implement Chase behavior
                ChasePlayer();
                break;
            case States.escape:
                // Implement Escape behavior
                EscapeFromPlayer();
                break;
        }
    }
    void CheckForChase()
    {
        float distance = Vector3.Distance(transform.position, player.position); // Assuming 'player' is a Transform
        if (distance < chaseStartDistance) // 'chaseStartDistance' is the distance at which chasing starts
        {
            _state = States.chase;
        }
    }
    void ChasePlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > chaseStopDistance) // 'chaseStopDistance' is the distance at which chasing stops
        {
            _state = States.idle;
        }
        else if (enemyHP <= 1) // 'ghostHealth' tracks the health of the ghost
        {
            _state = States.escape;
        }
        else
        {
            nav.SetDestination(player.position); // Assuming 'nav' is a NavMeshAgent
        }
    }

    void EscapeFromPlayer()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        Vector3 runTo = transform.position + transform.forward * 10;
        nav.SetDestination(runTo);

        // Optionally, switch back to idle after escaping a certain distance
        if (Vector3.Distance(transform.position, player.position) > safeDistance) // 'safeDistance' is how far it runs
        {
            _state = States.idle;
        }
    }


    

}
