using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    //public float speed; //скорость патрулирования
    //public Transform[] moveSpots; //массив с точками патрулирования
    //private float waitTime; //остаток времени остановки на точке
    //public float startWaitTime; //изначальное время остановки
    public bool chase; //вкл/выкл преследование
    RaycastHit hit;



    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex; //перебор массива
    private Vector3 playerPosition;
    private GameObject player;

    //void Start()
    //{
    //    waitTime = startWaitTime; //при создании обнуляем время остановки на точке
    //}

    public void SpawnEnemy(Transform[] MoveSpots) //функция для присваивания переменным значений при появлении нового объекта
    {
        waypoints = MoveSpots;
        //waitTime = StartWaitTite;
        //startWaitTime = StartWaitTite;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            player = other.gameObject;
            var rayCast = Physics.Raycast(transform.position, other.gameObject.transform.position-transform.position, out hit, Mathf.Infinity);

            if (rayCast)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    chase = true;
                    StopAllCoroutines();
                    print("Вижу");
                }
            }

            //chase = true;
            //StopAllCoroutines();
            //print("Вижу");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            playerPosition = other.gameObject.transform.position;

            var rayCast = Physics.Raycast(transform.position, other.gameObject.transform.position - transform.position, out hit, Mathf.Infinity);

            if (rayCast)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    chase = true;
                    StopAllCoroutines();
                    print("Вижу");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //если это игрок
        {
            if (chase)
            {
                StartCoroutine(ChaseStop());
                print("не вижу");
            }
        }
    }

    IEnumerator ChaseStop()
    {
        var currentTime = 4f;
        while(0 < currentTime)
        {
            playerPosition = player.gameObject.transform.position;
            yield return null;
            currentTime -= Time.deltaTime;
        }
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        chase = false;
        print("ухожу");
    }

    //void FixedUpdate()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, moveSpots[m_CurrentWaypointIndex].position, speed * Time.fixedDeltaTime); //перемещение к точке 

    //    if (Vector3.Distance(transform.position, moveSpots[m_CurrentWaypointIndex].position) < 0.2f); //при приближении к точке
    //    {
    //        if (waitTime <=0)
    //        {
    //            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % moveSpots.Length;   //выбираем следующую точку             
    //            waitTime = startWaitTime; //сбрасываем время остановки
    //        }
    //        else
    //        {
    //            waitTime -= Time.fixedDeltaTime; 
    //        }
    //    }
    //}


    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (chase)
        {
            navMeshAgent.SetDestination(playerPosition);
            //if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            //{
            //    print("Ударил");
            //    //var p = player.GetComponent<PlayerController>();
            //    //p.Die();
            //    chase = false;
            //}
        }
        else 
        { 
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
        }
}

    //public GameObject _player;

    //private void FixedUpdate()
    //{
    //    RaycastHit hit;


    //    var rayCast = Physics.Raycast(transform.position, transform.forward,
    //    out hit, 10);

    //    if (rayCast)
    //    {
    //        if (hit.collider.gameObject.tag == "Player")
    //        {
    //            print("Вижу");
    //        }
    //    }

    //}

}
