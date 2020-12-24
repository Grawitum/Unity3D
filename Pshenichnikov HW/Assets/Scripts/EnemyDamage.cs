using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            player = other.gameObject;
            var p = player.GetComponent<PlayerController>();
            p.Die();
            var e = gameObject.GetComponentInParent<Patrol>();
            e.chase = false;
            print("Ударил");

        }
    }

            // Update is called once per frame
            void Update()
    {
        
    }
}
