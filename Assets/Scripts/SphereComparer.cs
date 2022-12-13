using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereComparer : MonoBehaviour
{
    private ObjectComparer _objectComparer;
    // Start is called before the first frame update
    void Start()
    {
        _objectComparer = FindObjectOfType<ObjectComparer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == GameObject.Find("Sphere"))
        {
            _objectComparer.spherePlaced = true;
            //gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            _objectComparer.spherePlaced = false;
            //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _objectComparer.spherePlaced = false;
        // gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
