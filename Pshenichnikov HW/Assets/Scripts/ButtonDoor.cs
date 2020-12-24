using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Box") 
        {
            Door.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Box")
        {
            Door.GetComponent<Animator>().SetBool("Open", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
