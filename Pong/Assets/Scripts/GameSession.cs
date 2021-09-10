using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Serialized for debugging
    [SerializeField] string playerChosen;
    [SerializeField] string loser;
    [SerializeField] int player1Points = 0;
    [SerializeField] int player2Points = 0;

    SceneLoader sceneLoader;

    private void Awake()
    {
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if (gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player1Chosen()
    {
        playerChosen = "Player 1";
    }

    public void Player2Chosen()
    {
        playerChosen = "Player 2";
    }

    public string GetChosenPlayer()
    {
        return playerChosen;
    }

    public void Player1Lose()
    {
        loser = "Player 1";
    }

    public void Player2Lose()
    {
        loser = "Player 2";
    }

    public string GetLoser()
    {
        return loser;
    }

    public void AddPlayer1Points()
    {
        player1Points++;
    }

    public void AddPlayer2Points()
    {
        player2Points++;
    }

    public int GetPlayer1Points()
    {
        return player1Points;
    }

    public int GetPlayer2Points()
    {
        return player2Points;
    }
}
