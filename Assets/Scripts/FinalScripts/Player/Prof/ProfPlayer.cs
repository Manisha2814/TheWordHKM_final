using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfPlayer : MonoBehaviour
{
    Vector3 _Destination;
    private UnityEngine.AI.NavMeshPath _path;
    List<Vector3> _simplePath = new List<Vector3>();
    public CapsuleCollider _Collider;

    //[SerializeField] private AudioSource WalkingAudio;

    void Start()
    {
        _Destination = transform.position;
        _path = new UnityEngine.AI.NavMeshPath();
    }

    public void SetTarget(Vector3 TargetPos)
    {
        _Destination = TargetPos;

        bool foundPath = UnityEngine.AI.NavMesh.CalculatePath(transform.position, TargetPos, UnityEngine.AI.NavMesh.AllAreas, _path);
        _simplePath.Clear();
        for (int i = 0; i < _path.corners.Length; i++)
        {
            _simplePath.Add(_path.corners[i]);
        }
    }

    void Update()
    {

        Vector3 MoveDirection = Vector3.zero;

        while (_simplePath.Count > 0 && (transform.position - _simplePath[0]).magnitude < 0.5f)
        {
            _simplePath.RemoveAt(0);
        }

        if (_simplePath.Count > 0)
        {
            MoveDirection = _simplePath[0] - transform.position;
        }


        if (MoveDirection.magnitude > 0.5f)
        {
            //WalkingAudio.Play();
            MoveDirection.Normalize();

            Vector3 ProjectedMoveDirection = MoveDirection - (Vector3.up * Vector3.Dot(Vector3.up, MoveDirection));
            transform.rotation = Quaternion.LookRotation(ProjectedMoveDirection, Vector3.up);

            GetComponent<Animator>().SetFloat("WalkSpeed", 3.5f);
        }
        else
        {
            GetComponent<Animator>().SetFloat("WalkSpeed", 0.0f);
        }

        transform.position = transform.position + new Vector3(0.0f, -0.01f, 0.0f);

        Collider[] coliders = Physics.OverlapBox(transform.position, _Collider.bounds.extents);
        for (int i = 0; i < coliders.Length; i++)
        {
            if (coliders[i] != _Collider && !coliders[i].GetComponent<TriggerThiing>())
            {
                Vector3 hitDirection;
                float hitDistance;
                if (Physics.ComputePenetration(coliders[i], coliders[i].transform.position, coliders[i].transform.rotation, _Collider,
               _Collider.transform.position, _Collider.transform.rotation, out hitDirection, out hitDistance))
                {
                    hitDirection *= -1.0f;

                    float MinFloorDot = 0.7f;
                    if (Vector3.Dot(hitDirection, Vector3.up) > MinFloorDot)
                    {
                        Vector3 depenatrationDir = Vector3.up;

                        float denominator = Mathf.Abs(Vector3.Dot(depenatrationDir, hitDirection));
                        if (denominator > 0.0f)
                        {
                            transform.position += depenatrationDir * (hitDistance / denominator);
                        }
                    }
                    else
                    {
                        transform.position += hitDirection * hitDistance;
                    }
                }
            }
        }
    }
}