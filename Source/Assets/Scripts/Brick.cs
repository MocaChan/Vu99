using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject prefDesEffect, prefDesEffect1, prefDesEffect2, prefDesEffect3, prefDesEffect4;
    Vector3 vec;
    bool isAlive = true;

    void Start()
    {
        vec = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && GameCache.IsPlaying == true)
        {
            if(isAlive==true)
            {
                isAlive = false;
                GameCache.countDes++;
                GameCache.actiCollision = true;
            }


            GameCache.Score += 100 + 10*GameCache.round*((60 - GameCache.Time) / 60);
            var objEffect = Instantiate(prefDesEffect, vec, Quaternion.identity);

            switch (gameObject.tag)
            {
                case "Type1":
                    {
                        var objEffect1 = Instantiate(prefDesEffect1, vec, transform.rotation * Quaternion.Euler(0f, 0f, transform.rotation.z));
                        Destroy(objEffect1, 0.5f);
                        break;
                    }
                case "Type2":
                    {
                        var objEffect1 = Instantiate(prefDesEffect2, vec, transform.rotation * Quaternion.Euler(0f, 0f, transform.rotation.z));
                        Destroy(objEffect1, 0.5f);
                        break;
                    }
                case "Type3":
                    {
                        var objEffect1 = Instantiate(prefDesEffect3, vec, transform.rotation * Quaternion.Euler(0f, 0f, transform.rotation.z));
                        Destroy(objEffect1, 0.5f);
                        break;
                    }
                case "Type4":
                    {
                        var objEffect1 = Instantiate(prefDesEffect4, vec, transform.rotation * Quaternion.Euler(0f, 0f, transform.rotation.z));
                        Destroy(objEffect1, 0.5f);
                        break;
                    }
            }
            
            Destroy(objEffect, 0.5f);
            Destroy(gameObject, 0.15f);
        }
    }
}
