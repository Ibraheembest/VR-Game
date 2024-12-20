using UnityEngine;

public class TextureChangeOnCollision : MonoBehaviour
{
    private Renderer objectRenderer;
    public Material blackMaterial; // Material to change to (black material)

    void Start()
    {
        // Get the Renderer component to modify the material
        objectRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collides with the cube
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Collision detected! Changing texture to black.");

            // Change the material to black
            objectRenderer.material = blackMaterial;
        }
    }
}
