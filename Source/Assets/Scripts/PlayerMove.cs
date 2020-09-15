using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    int keyboardMoveSpeed = 18, mouseMoveSpeed = 8;
    Vector3 playerpos;

    void Start()
    {
        playerpos = transform.position;
    }

    void Update()
    {
        float posX;
        Vector3 vecPos;

        if (Input.GetAxis("Mouse X") > 0f|| Input.GetAxis("Mouse X") < 0f)
        {
            posX = transform.position.x + Input.GetAxis("Mouse X") * mouseMoveSpeed * Time.deltaTime;
            vecPos = new Vector3(Mathf.Clamp(posX,-2.8f,5.97f), playerpos.y, playerpos.z);

        }
        else
        {
            posX = transform.position.x + Input.GetAxis("Horizontal") * keyboardMoveSpeed * Time.deltaTime;
            vecPos = new Vector3(Mathf.Clamp(posX, -2.8f, 5.97f), playerpos.y, playerpos.z);
        }

        transform.position = vecPos;
    }
}
