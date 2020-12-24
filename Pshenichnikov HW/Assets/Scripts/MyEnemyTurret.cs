using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyTurret : MonoBehaviour
{
    [SerializeField] private int health; //переменная для жизней нужна будет для стрельбы(но это не точно)

    public void Hurt(int damage) //функция нанесения урона переработанная так как по ТЗ нужен взрыв который "Взрывает всё", а после такого не живут)
    {
        print("Ouch: " + damage);
        health -= damage; ;
        if (health <= 0)
        {
            Die(); //вызов функции смерти
        }
    }


    private void Die() //функция смерти
    {
        Destroy(gameObject); //удаление объекта
    }
}
