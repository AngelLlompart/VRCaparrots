using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private float pickupRange = 5.0f;
    private PickUpController _pickUpController;
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        _pickUpController = FindObjectOfType<PickUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        
        // Creating a Ray
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // Selection Determination
        RaycastHit hit;
        if (_pickUpController.heldObj == null)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                var selection = hit.transform;
                if (selection.CompareTag("Selectable"))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = highlightMaterial;
                    }

                    _selection = selection; 
                }
            }
        }
       
    }
}
