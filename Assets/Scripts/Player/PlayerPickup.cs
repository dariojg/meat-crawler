using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    
    [SerializeField]
    GameObject inventoryContainer;


    private void Start()
    {
        inventoryContainer.SetActive(false); // Hide the inventory UI at start;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I key pressed, toggling inventory UI visibility.");
            inventoryContainer.SetActive(!inventoryContainer.activeSelf); // Toggle inventory UI visibility
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collectable item detected: " + other.name);
            ItemCollectable item = other.GetComponent<ItemCollectable>();
            if (item != null && item.IsCollectable)
            {
                item.Pickup();
            }
            else
            {
                Debug.LogWarning("ItemCollectable component not found on the collectable object.");
            }
        }
    }
}
