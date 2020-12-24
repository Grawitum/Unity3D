using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int health; //переменная для жизней нужна будет для стрельбы(но это не точно)
    public GameObject spawnPoint; //переменная для точки спавна

    public void Hurt(int damage) //функция нанесения урона 
    {
        print("Ouch: " + damage); //вывод сообщения об уроне
        health -= damage; ; //уменьшения жизни на урон
        if (health <= 0) //действие при отсутствие жизни
        {
            Die(); //вызов функции смерти
        }
    }

    public void SpawnEnemy(GameObject obj)
    {
        spawnPoint = obj; //передача объекта спавн поинт при создании нового объекта.
    }

    private void Die() //функция смерти
    {
        spawnPoint.transform.GetComponent<SpawnPoint>().Cooldown(); //установка перезарядки на точке спавна
        Destroy(gameObject); //удаление объекта
    }

}
