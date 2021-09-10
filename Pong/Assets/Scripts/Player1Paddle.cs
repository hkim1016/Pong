using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 6f;
    [SerializeField] float minYPos = 1.5f;
    [SerializeField] float maxYPos = 16.5f;

    Rigidbody2D paddleRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        paddleRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer1Paddle();
        ClampPaddlePosition();

        //Debug.Log(GetComponent<Collider2D>().bounds.size);
    }

    private void MovePlayer1Paddle()
    {
        if(Input.GetKey(KeyCode.W))
        {
            paddleRigidbody.velocity = new Vector2(0, paddleSpeed);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            paddleRigidbody.velocity = new Vector2(0, -1 * paddleSpeed);
        }
        else
        {
            paddleRigidbody.velocity = new Vector2(0, 0);
        }
    }

    // Makes sure paddle doesn't move out of the camera
    private void ClampPaddlePosition()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(transform.position.y, minYPos, maxYPos);
        transform.position = paddlePos;
    }

    public Vector2 GetPlayer1PaddleVel()
    {
        return paddleRigidbody.velocity;
    }
}
