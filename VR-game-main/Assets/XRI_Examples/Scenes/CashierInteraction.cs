using UnityEngine;
using TMPro;
using System.Collections;

public class CashierInteraction : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI element
    public TextMeshProUGUI levelUpText; // Text element for displaying the level-up message
    public TextMeshProUGUI completedLevelText; // Text element for displaying the completed level
    public TextMeshProUGUI newLevelText; // Text element for displaying the new challenge
    public TextMeshProUGUI achievedScoreText; // Text element for displaying the achieved score
    public GameObject levelTransitionScreen; // The UI panel for the transition screen
    public int score = 0; // Player's score
    private bool isProcessing = false; // Prevent multiple triggers
    private int scoreTarget = 10; // Score needed to reach the next level
    private int level = 1; // The current level

    public AudioSource cashRegisterSound; // AudioSource for cash register sound
    public AudioSource transitionSound; // AudioSource for the transition sound

    void Start()
    {
        // Initially hide the level-up message and transition screen
        levelUpText.gameObject.SetActive(false);
        levelTransitionScreen.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is a Hamburger and no process is running
        if (collision.gameObject.CompareTag("Hamburger") && !isProcessing)
        {
            isProcessing = true; // Set flag to prevent multiple triggers
            StartCoroutine(HandleHamburger(collision.gameObject));
        }
    }

    private IEnumerator HandleHamburger(GameObject hamburger)
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Add $5 to the score
        score += 5;
        UpdateScoreText();

        // Play cash register sound (if it's assigned)
        if (cashRegisterSound != null)
        {
            cashRegisterSound.Play();
        }

        // Destroy the hamburger
        Destroy(hamburger);

        Debug.Log("Hamburger sold! Score updated.");

        // Check if the player reached the target score
        if (score >= scoreTarget)
        {
            StartCoroutine(LevelUp());
        }

        isProcessing = false; // Reset flag
    }

    private void UpdateScoreText()
    {
        // Update the score text
        scoreText.text = $"${score}";
    }

    private IEnumerator LevelUp()
    {
        // Show the level transition screen
        levelTransitionScreen.SetActive(true);

        // Play the transition sound
        if (transitionSound != null)
        {
            transitionSound.Play();
        }
        scoreTarget += 10; // Increase the target by 10 for the next level

        // Update the level transition texts
        completedLevelText.text = $"Level {level} Completed!";
        achievedScoreText.text = $"${score}"; // Show the achieved score
        newLevelText.text = $" ${scoreTarget}";

        // Wait for 15 seconds to display the transition message
        yield return new WaitForSeconds(15f);

        // Hide the transition screen
        levelTransitionScreen.SetActive(false);

        // Move to the next level
        level++;
        scoreTarget += 10; // Increase the target by 10 for the next level

        // Optionally reset the score or keep the previous score
        score = 0; // Reset the score or keep it, depending on your game design
        UpdateScoreText();

        Debug.Log($"Next level! New target: ${scoreTarget}");
    }
}