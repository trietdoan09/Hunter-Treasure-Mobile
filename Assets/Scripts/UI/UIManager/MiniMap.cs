using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    //public Transform player;

    //void LateUpdate()
    //{
    //    Vector3 newPosition = player.position;
    //    newPosition.y = transform.position.y;
    //    transform.position = newPosition;

    //    transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    //}

    void Update()
    {
       var cam = transform.localPosition;
        cam = cam + new Vector3(0, 0, 0);
    }
}