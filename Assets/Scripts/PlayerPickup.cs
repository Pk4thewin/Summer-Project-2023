using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform _transform;
    public Transform carriedObject;
    public bool hasItem;
    public bool isHolding;

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

    private void OnTriggerExit(Collider other)
    {
        if (carriedObject == other.transform)
        {
            carriedObject = null;
            hasItem = false;
        }
    }

    void Update()
    {
        // Check if the object is being carried and the left mouse button is pressed
        if (carriedObject != null && !hasItem && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isHolding = true;
            hasItem = true;
            if(carriedObject.gameObject.name == "Turret"){
                
            }
        }else if(hasItem && Input.GetKeyDown(KeyCode.Mouse0))
        {
            hasItem = false;
            isHolding = false;
        }
        
        // Move the carried object while the left mouse button is held down
        if (isHolding)
        {
            carriedObject.position = _transform.position;
        }
    }
}
