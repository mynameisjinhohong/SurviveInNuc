using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Legacy.LJH
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public virtual void Interact()
        {
            Debug.Log("Interact " + gameObject.name);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(StringValues.PlayerTag))
                other.GetComponent<Player>().SetInteractableObject(this);
        }
    }
}