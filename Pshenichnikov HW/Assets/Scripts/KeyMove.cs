using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
    public GameObject Door; //объект двери

    private void OnTriggerEnter(Collider other) //действие при соприкосновении с обьектом
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            Door.transform.Rotate(0,90, 0); //поворот двери
            Destroy(this.gameObject); //удаление ключа
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0, Time.fixedDeltaTime * 30, 0); //вращение ключа
    }
}
