using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeColorOnInteract : MonoBehaviour
{
    private Renderer cubeRenderer;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        // Change to a random color
        cubeRenderer.material.color = new Color(
            Random.value, Random.value, Random.value
        );
    }
}
