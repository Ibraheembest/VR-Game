using UnityEngine;

public class CookingSystem : MonoBehaviour
{
    public GameObject foodObject; // Raw food object
    public GameObject cookedFoodObject; // Cooked food object (hidden initially)
    public ParticleSystem flameParticle; // Flame particle system
    public float cookingTime = 5f; // Time to cook the food in seconds
    private bool isCooking = false;
    private float cookingTimer = 0f;

    void Start()
    {
        // Make cooked food invisible initially
        cookedFoodObject.SetActive(false);
    }

    void Update()
    {
        // Check if the food is on the pan and the pan is over the flame
        if (isCooking)
        {
            cookingTimer += Time.deltaTime;
            if (cookingTimer >= cookingTime)
            {
                CookFood();
            }
        }
    }

    // Call this method when food is placed on the pan over the flame
    public void StartCooking()
    {
        // Ensure the flame is active
        if (flameParticle.isPlaying)
        {
            isCooking = true;
            cookingTimer = 0f;
            Debug.Log("Cooking started!");
        }
    }

    void CookFood()
    {
        // Set cooked food to be visible and raw food to be hidden
        foodObject.SetActive(false);
        cookedFoodObject.SetActive(true);

        // Reset cooking state
        isCooking = false;

        Debug.Log("Food is cooked!");
    }

    // Call this method when food is removed from the pan or no longer in contact with the flame
    public void StopCooking()
    {
        isCooking = false;
        cookingTimer = 0f;
        Debug.Log("Cooking stopped.");
    }
}
