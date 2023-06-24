using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;

public class BallScript : MonoBehaviour
{
    public float drag = 1;  // Drag factor that will be applied on Rigidbody's y velocity.

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;  // Set the time scale back to normal, since it will be changed to 0 when a goal is scored.
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4 * ScoreManager.lastWinner, 0);
        // Set initial velocity direction of the Rigidbody in the opposite direction of the last winner.
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        float force = 0.05f;  // Force that will be applied on the Rigidbody.
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();  // Reference to the Rigidbody component.
        Vector2 velocity = rigidbody2D.velocity;  // Current velocity of the Rigidbody.
        rigidbody2D.AddForce(new Vector2(0, -1 * velocity.y * drag));
        // Apply a drag force against the current y-direction velocity.

        // The following code checks for different key presses and applies different forces to the Rigidbody based on what key is pressed.
        // The force is applied as an impulse, meaning it will be applied instantaneously.

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A");
            rigidbody2D.AddForce(new Vector2(0, force), ForceMode2D.Impulse);  // Apply upwards force.
            return;
        }

        if (Input.GetKey(KeyCode.B))
        {
            Debug.Log("Pressed B");
            rigidbody2D.AddForce(new Vector2(0, 2 * force), ForceMode2D.Impulse);  // Apply double upwards force.
            return;
        }

        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Pressed C");
            rigidbody2D.AddForce(new Vector2(0, 3 * force), ForceMode2D.Impulse);  // Apply triple upwards force.
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D");
            rigidbody2D.AddForce(new Vector2(0, -1 * force), ForceMode2D.Impulse);  // Apply downwards force.
            return;
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Pressed E");
            rigidbody2D.AddForce(new Vector2(0, -2 * force), ForceMode2D.Impulse);  // Apply double downwards force.
            return;
        }

        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("Pressed F");
            rigidbody2D.AddForce(new Vector2(0, -3 * force), ForceMode2D.Impulse);  // Apply triple downwards force.
            return;
        }
    }
}
