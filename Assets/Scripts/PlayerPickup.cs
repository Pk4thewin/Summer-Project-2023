using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private Transform _transform;
    private Transform carriedObject;
    private bool hasItem;

    void Start()
    {
        hasItem = false;
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickupable" && !hasItem)
        {
            carriedObject = other.transform.parent.gameObject.transform;
        }
    }

    void Update()
    {
        if (carriedObject != null && hasItem)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                carriedObject.position = _transform.position;
            }
        }
        else if (!hasItem && carriedObject != null)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                hasItem = true; 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (carriedObject == other.transform)
        {
            carriedObject = null;
            hasItem = false;
        }
    }
}
