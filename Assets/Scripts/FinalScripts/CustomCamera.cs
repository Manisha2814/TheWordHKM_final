using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    Vector3 OffsetDirection;
    public Vector3 TargetOffset;
    public float OffsetDistance = 1.0f;

    void Start()
    {
        OffsetDirection = new Vector3(0.0f, 2.0f, -2.0f);
        OffsetDirection.Normalize();
    }

    public GameObject _Target;
    public float Sensitivity = 1.0f;
    void Update()
    {
        Vector3 TargetPosition = _Target.transform.position + TargetOffset;
        Vector3 CameraPosition = TargetPosition + (OffsetDirection * OffsetDistance);
        Ray myRay = new Ray(TargetPosition, OffsetDirection);
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, OffsetDistance))
        {
            CameraPosition = hit.point;
        }
        transform.position = CameraPosition;
        transform.rotation = Quaternion.LookRotation(-OffsetDirection, Vector3.up);

        if (Input.GetMouseButton(1))
        {
            float deltaX = Input.GetAxis("Mouse X");
            Quaternion Rot = Quaternion.AngleAxis(deltaX * Sensitivity, Vector3.up);
            OffsetDirection = Rot * OffsetDirection;


        }

    }
}
