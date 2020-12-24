using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject optionsConvas;
    public void ButtonExit()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonOptions()
    {
        optionsConvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
#if UNITY_EDITOR
        Cursor.visible = false;
#endif
    }
}
