using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private int damage; //переменная для дамага
    public GameObject explosion; //объект с частицами взрыва
    public float startLifeTime; //стартовое время до взрыва мины
    private float lifeTime; //время до взрыва мины
    private bool explosivTime = false; //переменная можно ли взорватся)



    public float explosionRadius = 7;// радиус поражения
    public float power = 700;// сила взрыва



    private void Start()
    {
        lifeTime = startLifeTime; //устанавливаем таймер до взрыва
    }




    private void OnTriggerStay(Collider other)
    {
        if (explosivTime)
        {
            if (other.gameObject.CompareTag("Enemy")) //если это враг
            {
                var enemyRB = other.GetComponent<Rigidbody>(); //задаем переменной связь с RB врага
                var enemy = other.GetComponent<MyEnemy>(); //задаем переменной связь со скриптом врага
                enemyRB.AddExplosionForce(power, transform.position, explosionRadius);// Создание взрыва, с силой power, в позиции transform.position, c радиусом explosionRadius
                enemy.Hurt(damage); //вызываем функцию у врага ненесения урона
                Destroy(gameObject); //удаляем объект

            }
        }
    }

    public void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime; //таймер до взрыва
        if (lifeTime <=0) //если таймер истек
        {
            explosivTime = true; //переменная взрыва включена
            print("всё взрывается!"); //взрываем всё как сказанно в ТЗ)
            Instantiate(explosion, transform.position, transform.rotation);//создание объекта с частицами взрыва
            Destroy(gameObject); //удаляем объект
        }
    }


}

//добавить немного лвла 
//не вызывать сет дистонейшен каждый кадр , чтобы нав меш агент переопределял путь при определенном условии.
