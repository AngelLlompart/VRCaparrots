using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.Grounded = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.Grounded = false;
    }

    private void OnTriggerStay(Collider     collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.Grounded = true;
    }
}
