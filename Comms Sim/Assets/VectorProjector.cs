using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProjector : MonoBehaviour{
public Transform otherObject; // Reference to the other object
public GameObject targetObject; // Reference to the object you want to check for intersection
public float radius = 696; // Radius of the target object

private void Update()
{
    // Step 1: Calculate the direction vector of the ray
    Vector3 direction = otherObject.position - transform.position;

    // Step 2: Perform vector projection
    Vector3 normalizedDirection = direction.normalized;
    Vector3 projection = Vector3.Dot(normalizedDirection, targetObject.transform.position - transform.position) * normalizedDirection;

    // Step 3: Determine if the ray intersects the object
    float magnitude = projection.magnitude;
    bool intersectsObject = magnitude <= radius;

    // Debug visualization (optional)
    Debug.DrawRay(transform.position, direction, Color.blue);
    Debug.DrawRay(transform.position, projection, Color.red);

    if (intersectsObject)
    {
        // The ray intersects the target object
        Debug.Log("Ray intersects the object!");
    }
    
    }
}

