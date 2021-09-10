using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerLost;

    // Start is called before the first frame update
    void Start()
    {
        playerLost.text = FindObjectOfType<GameSession>().GetLoser() + " HAS LOST";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
