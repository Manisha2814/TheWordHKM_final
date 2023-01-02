using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ItemKey : MonoBehaviour
{
    Rigidbody _rigid;
    SphereCollider _sphereCollider;

    public UIKey _uiKey;
    [SerializeField] private AudioSource KeyCollectEffect;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();

    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ProfPlayer>())
        {
            KeyCollectEffect.Play();
            Debug.Log("collected key!");

            _uiKey.isCollected = true;
            Destroy(gameObject);
        }
    }
}
