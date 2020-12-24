using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject enemy; //объект для прифаба врага
    public Transform[] moveSpots; //масив с точками для патрулирования
    public bool wait; //вкл/выкл таймер
    public float waitTime; //остаток времени
    public float startWaitTime; //начальное время ожидания
    public GameObject player; 

    void Start() //при старте мы создаем первого врага из точки
    {
        wait = false;
        var newEnemy = Instantiate(enemy, transform.position, transform.rotation); //создаем прифаб на текущей позиции
        newEnemy.transform.GetComponent<Patrol>().SpawnEnemy(moveSpots); //задаем ему параменты и точки для патрулирования
        newEnemy.transform.GetComponent<MyEnemy>().SpawnEnemy(this.gameObject); //задаем ему точку спавна
    }

    public void Cooldown() //обнуляем перезарядку спавна врага
    {
        waitTime = startWaitTime;  //задаем время
        wait = true; //включаем отсчет
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wait)
        {

            if (waitTime <= 0) //по истечению времени как в фанкции Start создаем врага из точки
            {
                wait = false;
                var newEnemy = Instantiate(enemy, transform.position, transform.rotation);
                newEnemy.transform.GetComponent<Patrol>().SpawnEnemy(moveSpots);
                newEnemy.transform.GetComponent<MyEnemy>().SpawnEnemy(this.gameObject);
            }
            else
            {
                waitTime -= Time.fixedDeltaTime; //отнимаем время
            }

        }
    }
}
