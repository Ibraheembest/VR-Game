using UnityEngine;
using System.Collections;

public class CubeColorChange : MonoBehaviour
{
    private Renderer cubeRenderer; // Reference to the Renderer component of Cube 2
    private bool isWaiting = false; // Flag to check if the wait has started
    private Coroutine cookingCoroutine; // Reference to the cooking coroutine

    public Material cookedMaterial; // Reference to the "Cooked" material
    public Material burnedMaterial; // Reference to the "Burned" material
    public AudioSource grillSound; // Audio source for grill sound

    void Start()
    {
        // Get the Renderer component of Cube 2 to change its material later
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if Cube 2 collides with Cube 1 (the grill)
        if (collision.gameObject.CompareTag("Cube1") && !isWaiting)
        {
            if (grillSound != null && !grillSound.isPlaying)
            {
                grillSound.Play(); // Play grill sound
            }

            // Start the coroutine to handle material changes
            cookingCoroutine = StartCoroutine(ChangeMaterialSequence());
            isWaiting = true; // Set the flag to true to prevent multiple triggers
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if Cube 2 stops colliding with Cube 1 (the grill)
        if (collision.gameObject.CompareTag("Cube1"))
        {
            if (grillSound != null && grillSound.isPlaying)
            {
                grillSound.Stop(); // Stop the grill sound
            }

            if (cookingCoroutine != null)
            {
                StopCoroutine(cookingCoroutine); // Stop the cooking process
                isWaiting = false; // Reset the flag
                Debug.Log("Cooking stopped as the steak left the grill!");
                // Optionally reset the material to the original state (uncooked)
                // cubeRenderer.material = uncookedMaterial; // You can assign an uncooked material here if needed.
            }
        }
    }

    // Coroutine to handle the material changes over time
    private IEnumerator ChangeMaterialSequence()
    {
        // Change to "Cooked" after 5 seconds
        yield return new WaitForSeconds(5f);
        cubeRenderer.material = cookedMaterial; // Change the material to "Cooked"
        Debug.Log("Cube 2 changed material to Cooked after 5 seconds!");

        // Wait an additional 10 seconds to change to "Burned" (15 seconds total)
        yield return new WaitForSeconds(10f);
        cubeRenderer.material = burnedMaterial; // Change the material to "Burned"

        if (grillSound != null && grillSound.isPlaying)
        {
            grillSound.Stop(); // Stop the grill sound
        }

        Debug.Log("Cube 2 changed material to Burned after 15 seconds!");
    }
}