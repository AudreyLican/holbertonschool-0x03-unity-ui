using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // for collecting coin
    private int score = 0;

    // player health
    public int health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // move Horizontally
        float z = Input.GetAxis("Vertical"); // move vertically

        Vector3 move = new Vector3(x, 0.0f, z);

        // Apply the movement to the player, scaled by speed and deltaTime
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            // increment the value score when the player touch an object tagged Pickup
            score++;

            // Outpt Debug.Log()
            Debug.Log("Score: " + score);

            //disabled object after the player touch it
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }

        if (other.tag == "Teleporter")
        {
            transform.position = 
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
    }
}
