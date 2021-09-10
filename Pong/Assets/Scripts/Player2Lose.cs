using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Lose : MonoBehaviour
{
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.Player1Chosen();
        FindObjectOfType<Ball>().AttachBallToPaddle();
        gameSession.AddPlayer1Points();

        if (gameSession.GetPlayer1Points() >= 5)
        {
            gameSession.Player2Lose();
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
