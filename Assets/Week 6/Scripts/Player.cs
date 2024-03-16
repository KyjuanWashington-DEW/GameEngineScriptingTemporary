using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private int health = 100;
    [SerializeField] private int coins = 0;
    public Text healthText;
    public Text coinsText;

    private bool hasKey = false;

    public bool HasKey 
    {
        get { return hasKey; }
        set { hasKey = value; }
    }

    public void CollectCoin() 
    {
        coins++;
        UpdateUI();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        CheckForInteraction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            TakeDamage(10);
        }
        else if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            hasKey = true;
            UpdateUI();
        }
        else if (other.CompareTag("Door"))
        {
            AttemptToOpenDoor();
        }
        else if (other.CompareTag("Coin"))
        {
            CollectCoin();
            Destroy(other.gameObject);
            UpdateUI();
        }
    }

    private void TakeDamage(int amount)
    {
        health -= amount;
        UpdateUI();
    }

    private void AttemptToOpenDoor()
    {
        if (hasKey)
        {
            GameObject door = GameObject.FindGameObjectWithTag("Door");
            door.transform.Rotate(Vector3.up, 90f);
            Debug.Log("Door opened!");
        }
        else
        {
            Debug.Log("You need a key to open this door!");
        }
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void CheckForInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            Debug.Log("Interaction key pressed.");
        }
    }

    private void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;

        if (coinsText != null)
            coinsText.text = "Coins: " + coins;
    }
}

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HasKey = true;
                Debug.Log("Key collected!");
                Destroy(gameObject); 
            }
        }
    }
}

public class CoinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.CollectCoin();
                Debug.Log("Coin collected!");
                Destroy(gameObject); 
            }
        }
    }
}
