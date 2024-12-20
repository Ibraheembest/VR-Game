using UnityEngine;

public class KnobFlameToggle : MonoBehaviour
{
    public ParticleSystem flameParticle; // Reference to the flame particle system
    public AudioSource grillSound; // Audio source for grill sound
    private bool isFlameOn = false; // Track flame state

    public void ToggleFlame()
    {
        if (flameParticle != null)
        {
            isFlameOn = !isFlameOn; // Toggle the flame state

            if (isFlameOn)
            {
                flameParticle.Play(); // Turn on the flame
                if (grillSound != null && !grillSound.isPlaying)
                {
                    grillSound.Play(); // Play grill sound
                }
            }
            else
            {
                flameParticle.Stop(); // Turn off the flame
                if (grillSound != null && grillSound.isPlaying)
                {
                    grillSound.Stop(); // Stop grill sound
                }
            }
        }
    }
}