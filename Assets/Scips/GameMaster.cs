using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

