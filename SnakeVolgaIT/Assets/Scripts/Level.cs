using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChooseEasyLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChooseMediumLevel()
    {
        SceneManager.LoadScene("MediumLevel");
    }
    public void ChooseHardLevel()
    {
        SceneManager.LoadScene("HardLevel");
    }
    public void RestartHardLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().isMove = true;
        SceneManager.LoadScene("HardLevel");
    }
    public void RestartMedLevel()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Move>().isMove = true;
        SceneManager.LoadScene("MediumLevel");
    }
    public void ShowElements(Text gameOverText, Button gameOverButton)
    {
        gameOverText.enabled = true;
        gameOverButton.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
