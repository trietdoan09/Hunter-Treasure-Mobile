using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystickBackground;
    public GameObject joystickMovement;

    public Vector2 joystickVec;
    public Vector2 joystickTouchPos;
    public Vector2 joystickOriginalPos;
    //vị trí chạm - vt ban đầu - bán kính
    public float joystickRadius;

    void Start()
    {
        joystickOriginalPos = joystickBackground.transform.position;
        joystickRadius = joystickBackground.GetComponent<RectTransform>()
            .sizeDelta.y / 4;

    }


    void Update()
    {

    }
    //chạm màn hình
    public void PointerDown()
    {
        //joystickMovement.transform.position = Input.mousePosition;
        //joystickBackground.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    //bỏ chạm
    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystickMovement.transform.position = joystickOriginalPos;
        //joystickBackground.transform.position = joystickOriginalPos;

    }
    // tele điểm chạm
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystickMovement.transform.position = joystickTouchPos
                + joystickVec * joystickDist;

        }
        else
        {
            joystickMovement.transform.position = joystickTouchPos
                + joystickVec * joystickRadius;
        }

    }
}
