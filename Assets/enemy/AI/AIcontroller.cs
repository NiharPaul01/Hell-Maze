using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class AIcontroller : MonoBehaviour
{

    Transform destination;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private GameObject gameobj;
    private Animator _animator;
    private float waitTime = 2f;
    bool isMoving;
    private void Start()
    {
        destination = GameObject.FindWithTag("Player")?.transform;
        gameobj = GameObject.FindWithTag("PlayerAround");
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {

        _navMeshAgent.SetDestination(destination.position);
        isMoving = GetComponent<Rigidbody>().velocity.magnitude > 0.1f;
        _animator.SetBool("mo", isMoving);

        if (Vector3.Distance(transform.position, gameobj.transform.position) <= _navMeshAgent.stoppingDistance)
        {

            _animator.SetBool("punch", true);
            _animator.SetBool("mo", !isMoving);
            StartCoroutine(WaitForAnimationAndLoadScene());
        }


    }
    IEnumerator WaitForAnimationAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }
}