using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KnobController : MonoBehaviour
{
    public ParticleSystem flameParticle; // Reference to the flame's particle system
    public float maxEmissionRate = 50f; // Maximum intensity of flame
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor;
    private float currentAngle = 0f;
    private float maxRotation = 90f; // Maximum knob rotation

    void Start()
    {
        if (flameParticle != null)
        {
            var emission = flameParticle.emission;
            emission.rateOverTime = 0f; // Start with no flame
        }
    }

    public void OnKnobTurn(SelectEnterEventArgs args)
    {
        interactor = args.interactorObject as UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor;
    }

    public void OnKnobRelease(SelectExitEventArgs args)
    {
        interactor = null;
    }

    void Update()
    {
        if (interactor != null)
        {
            // Rotate the knob based on interactor's movement
            float rotationInput = interactor.transform.eulerAngles.y;
            currentAngle = Mathf.Clamp(rotationInput, 0, maxRotation);
            transform.localRotation = Quaternion.Euler(0, 0, currentAngle);

            // Adjust flame intensity based on knob rotation
            if (flameParticle != null)
            {
                var emission = flameParticle.emission;
                emission.rateOverTime = (currentAngle / maxRotation) * maxEmissionRate;
            }
        }
    }
}
