using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1Score;
    [SerializeField] TextMeshProUGUI player2Score;

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        player1Score.text = gameSession.GetPlayer1Points().ToString();
        player2Score.text = gameSession.GetPlayer2Points().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        player1Score.text = gameSession.GetPlayer1Points().ToString();
        player2Score.text = gameSession.GetPlayer2Points().ToString();
    }
}
