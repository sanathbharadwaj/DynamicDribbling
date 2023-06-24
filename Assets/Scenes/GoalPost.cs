using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Provides access to Unity's UI elements

public class GoalPost : MonoBehaviour
{
    public int position = 0;  // Variable to track the position of the goal post
    public Text scoreText;  // Text element to display the score
    public GameObject ball;  // Reference to the ball object
    public int left;  // Variable possibly tracking which goal was scored last
    public GameObject button;  // Reference to a button, probably for restarting the game or round

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial score text
        scoreText.text = ScoreManager.score[0] + " - " + ScoreManager.score[1];
        Time.timeScale = 1;  // Ensure that time is moving normally
    }

    // OnTrigger is a built-in Unity method which gets called when another object with a collider enters this object's collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Reset the ball position to the center
        ball.transform.position = new Vector3(0, 1, 0);

        // Reset the ball velocity to zero
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // Increment the score for the player who didn't score (position-1)
        ScoreManager.score[Mathf.Abs(position - 1)] += 1;

        // Update the score display
        scoreText.text = ScoreManager.score[0] + " - " + ScoreManager.score[1];

        // Update which side scored last
        ScoreManager.lastWinner = left;

        // Activate the button (possibly for restarting the game or round)
        button.SetActive(true);

        // Stop time (this might be to pause the game after a goal is scored until the button is pressed)
        Time.timeScale = 0;
    }
}
