using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private int score = 0;

    // player health
    public int health = 5;
    public TMP_Text scoreText;
    public TMP_Text healthText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
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

            //disabled object after the player touch it
            Destroy(other.gameObject);

            // update scoreboard
            SetScoreText();

            // Outpt Debug.Log()
            //Debug.Log("Score: " + score);
        }

        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
            //Debug.Log("Health: " + health);
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    /// <summary>
    /// this method display the player score
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    /// <summary>
    /// Method that display the player health
    /// </summary>
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
}
