using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    Text gameOverText;

    Button gameOverButton;

    Restart restart = new();
    void Start()
    {
        gameOverText = Move.gameOverText;
        gameOverButton = Move.gameOverButton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Head")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().isMove = false;
            restart.ShowElements(gameOverText, gameOverButton);
        }
    }
    void Update()
    {
        
    }
}
