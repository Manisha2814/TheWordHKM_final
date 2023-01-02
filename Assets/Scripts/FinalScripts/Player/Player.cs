using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public NavMeshAgent _navMeshAgent;
    public Camera _camera;
    public Animator _anim;
    public bool isWalking;

    Rigidbody _rigid;

    GameObject _gameObject;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _raycastHit;

            if (Physics.Raycast(myRay, out _raycastHit))
            {
                _navMeshAgent.SetDestination(_raycastHit.point);
                _rigid = GetComponent<Rigidbody>();
            }
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        _anim.SetBool("isWalking", isWalking);
    }

}