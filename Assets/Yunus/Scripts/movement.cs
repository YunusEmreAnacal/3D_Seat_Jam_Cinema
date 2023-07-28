using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class movement : MonoBehaviour
{
    public NavMeshAgent agent;
    private bool isSelected = false;
    private Vector3 targetPosition;
    public static movement instance;
    private static movement[] allCapsules;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Get references to all the capsules in the scene
        allCapsules = FindObjectsOfType<movement>();
    
    }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isSelected)
        {
            // If a capsule is selected, move it to the clicked position
            if (isSelected && Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    // Check if the plane's collider is occupied by another object
                        targetPosition = hitInfo.point;
                        agent.SetDestination(targetPosition);
                    
                }
            }
        }
        else
        {
            // If no capsule is selected, check if a capsule is clicked and select it
            if (!isSelected && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    if (hitInfo.collider.gameObject == gameObject)
                    {
                        // Deselect all other capsules and select the current one
                        foreach (movement capsule in allCapsules)
                        {
                            if (capsule != this)
                                capsule.isSelected = false;
                        }
                        isSelected = true;
                    }
                }
            }

        }
    }

    
}