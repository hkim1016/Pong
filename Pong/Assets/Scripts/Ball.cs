using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Serialized for debugging
    [SerializeField] bool hasStarted = false;
    [SerializeField] float paddle1BallPos = 2.48f;
    [SerializeField] float paddle2BallPos = 29.52f;

    [SerializeField] float minVel = -13f;
    [SerializeField] float maxVel = 13f;

    [SerializeField] Player1Paddle paddle1;
    [SerializeField] Player2Paddle paddle2;

    GameSession gameSession;
    Rigidbody2D ballRigidbody;

    Vector2 paddleToBall;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        AttachBallToPaddle();
    }

    public void AttachBallToPaddle()
    {
        hasStarted = false;
        if (gameSession.GetChosenPlayer().Equals("Player 1"))
        {
            transform.position = new Vector2(paddle1BallPos, paddle1.transform.position.y);
            paddleToBall = transform.position - paddle1.transform.position;
        }
        else if (gameSession.GetChosenPlayer().Equals("Player 2"))
        {
            transform.position = new Vector2(paddle2BallPos, paddle2.transform.position.y);
            paddleToBall = paddle2.transform.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
        else
        {
            ClampBallVelocity();
        }
    }

    // Launched ball in a random direction
    private void LaunchBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            ballRigidbody.velocity = new Vector2(maxVel, Random.Range(minVel, maxVel));
        }
    }

    // Makes sure the ball doesn't go too fast
    private void ClampBallVelocity()
    {
        Vector2 ballVel = ballRigidbody.velocity;
        ballVel.x = Mathf.Clamp(ballVel.x, minVel, maxVel);
        ballVel.y = Mathf.Clamp(ballVel.y, minVel, maxVel);
        ballRigidbody.velocity = ballVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeBallDirection(collision);
    }

    // Changes direction when ball hits paddle while paddle is moving
    private void ChangeBallDirection(Collision2D collision)
    {
        float paddle1Vel = paddle1.GetPlayer1PaddleVel().y;
        float paddle2Vel = paddle2.GetPlayer2PaddleVel().y;
        Vector2 ballVel = ballRigidbody.velocity;
        if (collision.collider.name.Equals("Player 1 Paddle"))
        {
            ballRigidbody.velocity = new Vector2(ballVel.x, ballVel.y + (0.2f * paddle1Vel));
        }
        else if (collision.collider.name.Equals("Player 2 Paddle"))
        {
            ballRigidbody.velocity = new Vector2(ballVel.x, ballVel.y + (0.2f * paddle2Vel));
        }
    }

    private void LockBallToPaddle()
    {   
        string chosenPlayer = gameSession.GetChosenPlayer();
        if (chosenPlayer.Equals("Player 1"))
        {
            Vector2 paddlePos = paddle1.transform.position;
            transform.position = paddlePos + paddleToBall;
        }
        else if (chosenPlayer.Equals("Player 2"))
        {
            Vector2 paddlePos = paddle2.transform.position;
            transform.position = paddlePos - paddleToBall;
        }
    }
}
