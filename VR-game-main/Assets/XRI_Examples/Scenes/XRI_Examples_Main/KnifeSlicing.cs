using UnityEngine;
using UnityEngine.XR;

public class KnifeSlicing : MonoBehaviour
{
    public XRNode controllerNode; // Reference to the VR controller
    public AudioClip slicingSound; // Slicing sound effect
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Adds an AudioSource to the knife
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object is sliceable
        if (collision.gameObject.CompareTag("Sliceable"))
        {
            Debug.Log("Slicing object: " + collision.gameObject.name);

            // Play slicing sound
            if (slicingSound != null)
                audioSource.PlayOneShot(slicingSound);

            // Provide haptic feedback
            ProvideHapticFeedback();

            // Slice the object
            SliceObject(collision.gameObject);
        }
    }

    void ProvideHapticFeedback()
    {
        // Provide haptic feedback to the controller
        InputDevice controller = InputDevices.GetDeviceAtXRNode(controllerNode);
        if (controller != null && controller.TryGetHapticCapabilities(out HapticCapabilities capabilities) && capabilities.supportsImpulse)
        {
            controller.SendHapticImpulse(0, 0.5f, 0.1f); // Channel 0, amplitude 0.5, duration 0.1s
        }
    }

    void SliceObject(GameObject sliceable)
    {
        // Find and enable cut pieces
        foreach (Transform child in sliceable.transform)
        {
            if (child.CompareTag("CutPiece"))
            {
                child.gameObject.SetActive(true);

                // Add Rigidbody to enable physics for cut pieces
                Rigidbody rb = child.gameObject.AddComponent<Rigidbody>();
                rb.AddForce(Vector3.up * 2f + Random.insideUnitSphere, ForceMode.Impulse);
            }
        }

        // Disable the original object
        sliceable.SetActive(false);
    }
}
