using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{

    public GameObject skrollBar;
    public GameObject Button;
    public GameObject mainMenu;
    public GameObject toggle;
    public float i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         i = skrollBar.GetComponent<Scrollbar>().value * 20;
        Button.transform.Rotate(i, 0, 0);
        Button.gameObject.SetActive(toggle.GetComponent<Toggle>().isOn);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
