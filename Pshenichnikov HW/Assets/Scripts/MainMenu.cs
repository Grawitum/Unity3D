using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsConvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonOptions()
    {
        optionsConvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
