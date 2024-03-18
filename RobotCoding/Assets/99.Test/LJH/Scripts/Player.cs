using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Legacy.LJH
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        private InteractableObject currInteractableObject;

        public void Move(Vector3 dst)
        {
            agent.SetDestination(dst);
        }

        public void Interact()
        {
            currInteractableObject?.Interact();
        }

        public void SetInteractableObject(InteractableObject interactableObject)
        {
            currInteractableObject = interactableObject;
        }
    }
}