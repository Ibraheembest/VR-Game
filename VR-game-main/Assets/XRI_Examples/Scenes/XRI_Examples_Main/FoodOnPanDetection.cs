using UnityEngine;

public class FoodOnPanDetection : MonoBehaviour
{
    public CookingSystem cookingSystem;

    // When the food collides with the pan
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("Food placed on the pan.");
            cookingSystem.StartCooking(); // Start cooking the food
        }
    }

    // When the food is removed from the pan
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("Food removed from the pan.");
            cookingSystem.StopCooking(); // Stop cooking the food
        }
    }
}
