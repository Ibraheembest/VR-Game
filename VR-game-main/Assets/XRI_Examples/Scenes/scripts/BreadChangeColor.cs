using UnityEngine;
using System.Collections;

public class BreadChangeColor : MonoBehaviour
{
    private Renderer cubeRenderer; // Reference to the Renderer component of Cube 2
    private bool isWaiting = false; // Flag to check if the wait has started

    public Material wellDoneMaterial; // Reference to the "Well Done" material

    void Start()
    {
        // Get the Renderer component of Cube 2 to change its material later
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if Cube 2 collides with Cube 1
        if (collision.gameObject.CompareTag("Cube1") && !isWaiting)
        {
            // Start the coroutine to wait for 5 seconds before changing material
            StartCoroutine(ChangeMaterialAfterDelay());
            isWaiting = true; // Set the flag to true to prevent multiple triggers
        }
    }

    // Coroutine to change the material after a delay
    private IEnumerator ChangeMaterialAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        cubeRenderer.material = wellDoneMaterial; // Change the material to "Well Done" after 5 seconds
        Debug.Log("Cube 2 changed material to Well Done after 5 seconds!");
    }
}