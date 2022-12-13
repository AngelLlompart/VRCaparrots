using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectComparer : MonoBehaviour
{

    public bool spherePlaced = false;
    public bool cubePlaced = false;
    public bool cylinderPlaced = false;

    [SerializeField] private GameObject cubeGoal;
    [SerializeField] private GameObject sphereGoal;
    [SerializeField] private GameObject cylinderGoal;
    
    [SerializeField] private float pickupRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    pickupRange))
            {
                if (hit.transform.CompareTag("Button"))
                {
                    StartCoroutine(button(hit.transform));
                    if (spherePlaced)
                    {
                        sphereGoal.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        sphereGoal.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (cubePlaced)
                    {
                        cubeGoal.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        cubeGoal.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (cylinderPlaced)
                    {
                        cylinderGoal.GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        cylinderGoal.GetComponent<MeshRenderer>().material.color = Color.red;
                    }

                }
            }
        }
    }

    IEnumerator button(Transform transform)
    {
        transform.position -= new Vector3(0, 0.05f, 0);
        yield return new WaitForSecondsRealtime(0.05f);
        transform.position += new Vector3(0, 0.05f, 0);
    }
}
