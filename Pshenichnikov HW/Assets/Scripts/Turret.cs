using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private bool lurking = false; //переменная вкл/выкл отслеживания
    public GameObject player; //объект отслеживания
    public GameObject bullet; //объект пули
    public GameObject spawnBullet; //точка спавна пули
    private float bulletCooldown; //перезарядка выстрела

    private void OnTriggerEnter(Collider other) //действие при вхождение в врадиус турели
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            bulletCooldown = 1; //перезарядка перед выстрелом
            lurking = true; //включение отслеживания позиции игрока
        }
    }

    private void OnTriggerExit(Collider other) //действие при выходе объекта из радиуса действия турели
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            lurking = false; //выключение отслеживания позиции игрока
        }
    }


    private void FixedUpdate()
    {
        bulletCooldown -= Time.fixedDeltaTime; //таймер перезарядки выстрела
    }


    void Update()
    {
        if (lurking) //если отслеживание включено
        {
            Vector3 relativePos = player.transform.position - transform.position; //создаем вектор поворота к игроку
            Quaternion rotation = Quaternion.LookRotation(relativePos); //создание кватерниона поворота
            transform.rotation = rotation; //поворот к игроку
            if (bulletCooldown <= 0) //если перезарядка пули кончилась 
            {
                bulletCooldown = 3; //выставляем перезарядку заного
                var newBullet = Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation); //создаем пулю и ссылку на неё
                newBullet.transform.GetComponent<Bullet>().BulletCreate(gameObject.transform); //передаем позицию игрока в пулю
            }
        }
    }
}
