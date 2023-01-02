using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public Camera _cam;
    public NavMeshAgent _player;
    public Animator _anim;
    public GameObject targetDest;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDest.transform.position = hitPoint.point;
                _player.SetDestination(hitPoint.point);
            }
        }

        if (_player.velocity != Vector3.zero)
        {
            _anim.SetBool("isWalking", true);

        }

        else if (_player.velocity == Vector3.zero)
        {
            _anim.SetBool("isWalking", false);
        }
    }
}