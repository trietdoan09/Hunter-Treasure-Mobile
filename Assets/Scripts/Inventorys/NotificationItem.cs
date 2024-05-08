using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationItem : MonoBehaviour
{
    NotificationContent content;

    public GameObject notificationItemObj;
    public Transform notificationPos;

   public Item items;
    public int golds;

    private void Start()
    {
        content = FindAnyObjectByType<NotificationContent>();
    }

    public void NotificationItems(Item item, int gold)
    {
        items = item;
        golds = gold;

        Instantiate(notificationItemObj, notificationPos);
    }
}
