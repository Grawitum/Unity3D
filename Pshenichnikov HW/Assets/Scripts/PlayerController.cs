using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam; //объект с камерой
    Quaternion startingRotation; //изначальное положение камеры
    float ver, hor, Jump,RotHor; //переменные перемещения, импульса прыжка, поворота камеры.
    public float speed,jumpSpeed,senssensitivity; //переменные скорости, высоты прыжка,скорости поворота камеры.
    public GameObject playerSpawn;
    public GameObject gameMenu;
    bool canJump; //проверка возможности прыжка
    private Animator m_Animator; 
    //int i = 10;

    private void Start() 
    {
        m_Animator = GetComponent<Animator>();
//#if UNITY_EDITOR
//        Cursor.visible = false;
//#endif
        startingRotation = transform.rotation; //задаем стартовое положение 
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Grounds") //проверка стоит ли объект на земле
        {
            canJump = true;
            m_Animator.SetBool("IsJump", false);
        }
    }

    private void OnCollisionExit(Collision other) //проверка в прыжке ли объект
    {
        if (other.gameObject.tag == "Grounds")
        {
            canJump = false;
            //m_Animator.SetBool("IsJump", true);
        }
    }
    
    public void Die()
    {
        gameObject.transform.position = playerSpawn.transform.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            gameMenu.SetActive(true);
            Time.timeScale = 0;
#if UNITY_EDITOR
            Cursor.visible = true;
#endif
        }
    }
    private void FixedUpdate()
    {
        //while (i > 0)
        //{
        //    print(i);
        //    i -= 1;
        //}
//        if (Input.GetKeyDown("p"))
//        {
//            gameMenu.SetActive(true);
//            //Time.timeScale = 0;
//#if UNITY_EDITOR
//            Cursor.visible = true;
//#endif
//        }
        RotHor += Input.GetAxis("Mouse X") * senssensitivity; //считывание поворота мыши 
        Quaternion RotX = Quaternion.AngleAxis(RotHor, Vector3.up); //создание кватертиона с поворотом камеры
        //cam.transform.rotation = StartingRotation * RotX;
        transform.rotation = startingRotation * RotX; //поворот персонажа
        ver = Input.GetAxis("Vertical") * Time.deltaTime * speed; //ускорение по вертикали
        hor = Input.GetAxis("Horizontal") * Time.deltaTime * speed; //ускорение по горизонтали
        if (ver!=0 || hor != 0 )
        {
            m_Animator.SetBool("IsWalk", true);
        }
        else
        {
            m_Animator.SetBool("IsWalk", false);
        }
            if (canJump) 
            {
                Jump = Input.GetAxis("Jump") * Time.deltaTime * jumpSpeed; //импульс прыжка
                GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse); //прыжек
                m_Animator.SetBool("IsJump", true);
            }
        transform.Translate(new Vector3(hor, 0, ver)); //передвижение персонажа
    }
}
