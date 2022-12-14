using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalPlacedGeneral : MonoBehaviour
{
    private ObjectComparerGeneral _objectComparer;
    public int num;
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        _objectComparer = FindObjectOfType<ObjectComparerGeneral>();
        text = gameObject.GetComponentInChildren<TextMeshPro>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == GameObject.Find(text))
        {
            _objectComparer.goalPlaced[num] = true;
        }
        else
        {
            _objectComparer.goalPlaced[num] = false;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        _objectComparer.goalPlaced[num] = false;
    }
}