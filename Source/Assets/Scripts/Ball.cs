using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool alive = true, start = true;
    public GameObject prefabBroken, prefabColl, PrefBall, stick;
    bool startGame = true;

    void Start()
    {
    }

    void Update()
    {
        if (GameCache.IsRelife == true)
        {
            ReLife();
            Destroy(gameObject, 0);
        }
        if (Input.GetKey(KeyCode.Mouse0) && start == true && GameCache.IsPlaying == true)  
        {
            if (startGame == true)
            {
                startGame = false;
            }

            start = false;
            transform.parent = null;

            AddForceAtAngle(90);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "ColCenter":
                {
                    AddForceAtAngle(90);
                    break;
                }
            case "ColLeft1":
                {
                    AddForceAtAngle(115);
                    break;
                }
            case "ColLeft2":
                {
                    AddForceAtAngle(135);
                    break;
                }
            case "ColRight1":
                {
                    AddForceAtAngle(65);
                    break;
                }
            case "ColRight2":
                {
                    AddForceAtAngle(45);
                    break;
                }

        }

        if (other.CompareTag("Crusher"))
        {
            ReLife();
            GameCache.actiCrusher = true;
            var effectObj = Instantiate(prefabBroken, transform.position, Quaternion.identity);

            Destroy(effectObj, 0.6f);
            Destroy(gameObject, 0f);
            GameCache.HP--;
        }
    }

    void ReLife()
    {
        var obj = Instantiate(PrefBall, new Vector3(stick.GetComponent<Transform>().position.x, stick.GetComponent<Transform>().position.y + 0.5f, stick.GetComponent<Transform>().position.z), Quaternion.identity);
        obj.transform.parent = stick.transform;
        GameCache.IsRelife = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
            ColEffect();
    }

    public void AddForceAtAngle(float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * GameCache.Force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * GameCache.Force;

        Rigidbody ri = gameObject.GetComponent<Rigidbody>();

        ri.isKinematic = true;
        ri.isKinematic = false;

        ri.AddForce(xcomponent,ycomponent,0);

        ColEffect();
    }

    void ColEffect()
    {
        GameCache.actiCollision = true;
        var objEffect = Instantiate(prefabColl, transform.position, Quaternion.identity);
        Destroy(objEffect, 0.5f);
    }
}
