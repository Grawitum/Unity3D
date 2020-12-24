using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //[SerializeField] private float speed = 2; //скорость пули
    public GameObject bulletTarget; //обьект для сохранинея позиции игрока на момент выстрела
    private GameObject target; //обьект для сохранинея позиции игрока на момент выстрела
    private Rigidbody rb;
    private float lifeTime = 100;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) //действия при попадании
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            print("попал"); //выводим попадание
            Destroy(target); //уничтажаем точку таргета
            Destroy(this.gameObject); //уничтожаем пулю
        }
        if (other.gameObject.CompareTag("Walls"))
        {
            print("стена"); //выводим попадание
            Destroy(target); //удалить цель
            Destroy(this.gameObject); //удалить пулю
        }
    }


    public void BulletCreate(Transform Target) //функция передачи позиции игрока в момент выстрела
    {
        target = Instantiate(bulletTarget, Target.position, Target.rotation); //создание объекта в позиции игрока на момент выстрела
    }

    public void FixedUpdate()
    {
        rb.AddForce(target.transform.forward,ForceMode.Impulse);
        lifeTime -= 1;
        if (lifeTime < 0)
        {
            Destroy(target); //удалить цель
            Destroy(this.gameObject); //удалить пулю
        }
        // transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); //движение пули к цели

        //if (transform.position == target.transform.position) //при достижении цели
        //{
        //    Destroy(target); //удалить цель
        //    Destroy(this.gameObject); //удалить пулю
        //}
    }
}

