using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnTriggerEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        print("Конец игры");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Конец игры");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
