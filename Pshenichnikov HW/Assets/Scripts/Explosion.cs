using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Explosion : MonoBehaviour
{
    private float lifeTime = 2; //время жизни объекта со взрывом
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime; //таймер жизни объекта
        if (lifeTime < 0) //когда таймер истек
        {
            Destroy(this.gameObject); //удалить обьект
        }
    }
}
