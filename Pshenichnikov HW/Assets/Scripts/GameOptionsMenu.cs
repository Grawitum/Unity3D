using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameOptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject skrollBar;
    public AudioMixer audioSrc;
    public Slider sl;
    //private float musicVolue;


    public void Back()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        audioSrc.SetFloat("Vol", sl.value);
    }


}
    