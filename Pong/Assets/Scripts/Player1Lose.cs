using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Lose : MonoBehaviour
{
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.Player2Chosen();
        FindObjectOfType<Ball>().AttachBallToPaddle();
        gameSession.AddPlayer2Points();

        if (gameSession.GetPlayer2Points() >= 5)
        {
            gameSession.Player1Lose();
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
