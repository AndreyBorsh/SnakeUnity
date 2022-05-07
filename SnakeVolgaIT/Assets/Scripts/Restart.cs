using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().isMove = true;
        SceneManager.LoadScene("SampleScene");
    }
    public void ShowMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ShowElements(Text gameOverText, Button gameOverButton)
    {
        gameOverText.enabled = true;
        gameOverButton.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
