using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mine; // Наша мина
    [SerializeField] private Transform mineSpawnPlace; // точка, где создается мина

    private void Update()
    {
        // Если нажата кнопка  
        if (Time.timeScale != 0)
        {


            if (Input.GetButtonDown("Fire1")) //проверяем нажатие ЛКМ
            {
                Instantiate(mine, mineSpawnPlace.position, mineSpawnPlace.rotation); // Создаем _mine в точке _mineSpawnPlace
            }
        }
    }

}
