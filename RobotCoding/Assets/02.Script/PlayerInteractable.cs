using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Legacy.LJH;
public class PlayerInteractable : MonoBehaviour
{
    private InteractableObject currInteractableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Interact()
    {
        currInteractableObject?.Interact();
    }

    public void SetInteractableObject(InteractableObject interactableObject)
    {
        currInteractableObject = interactableObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
