using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectComparerGeneral : MonoBehaviour
{

    public bool[] goalPlaced = new []{false, false, false};
    public List<GameObject> goals;
    private GameManager _gameManager;
    
    [SerializeField] private float pickupRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
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
                    Debug.Log("A");
                    StartCoroutine(button(hit.transform));
                    if (goalPlaced[0])
                    {
                        Debug.Log("B");
                        goals[0].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        goals[0].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (goalPlaced[1])
                    {
                        goals[1].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        goals[1].GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    
                    if (goalPlaced[2])
                    {
                        goals[2].GetComponent<MeshRenderer>().material.color = Color.green;
                    }
                    else
                    {
                        goals[2].GetComponent<MeshRenderer>().material.color = Color.red;
                    }


                    if (goalPlaced[0] && goalPlaced[1] && goalPlaced[2])
                    {
                        _gameManager.end = true;
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
