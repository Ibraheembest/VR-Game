using UnityEngine;
using System.Collections;

public class TableInteraction : MonoBehaviour
{
    public GameObject[] itemsOnTable; // Array of items placed on Cube 3
    public GameObject hamburgerPrefab; // Prefab of the Hamburger
    public Transform tablePosition; // Position where the hamburger will appear

    private bool isProcessing = false; // Prevent multiple triggers

    void OnCollisionEnter(Collision collision)
    {
        // Check if an item is placed on Cube 3 and no process is running
        if (collision.gameObject.CompareTag("Item") && !isProcessing)
        {
            StartCoroutine(ReplaceItemsWithHamburger());
            isProcessing = true; // Prevent additional triggers
        }
    }

    private IEnumerator ReplaceItemsWithHamburger()
    {
        // Wait for 60 seconds
        yield return new WaitForSeconds(60f);

        // Remove all items on the table
        foreach (GameObject item in itemsOnTable)
        {
            if (item != null)
            {
                Destroy(item); // Destroy the item GameObject
            }
        }

        // Instantiate the Hamburger on the table
        Instantiate(hamburgerPrefab, tablePosition.position, Quaternion.identity);

        Debug.Log("Items replaced with Hamburger!");
    }
}