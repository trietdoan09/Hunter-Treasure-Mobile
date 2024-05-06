using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationContent : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public int count;
    public Image imageItem;

    NotificationItem item;
    private void Start()
    {
        item = FindAnyObjectByType<NotificationItem>();
        Notification();
    }

    public void Notification()
    {
        count = item.golds;
        imageItem.sprite = item.items.image;
        itemName.text = item.items.name + "  x " + count;

        Destroy(gameObject, 2);
    }

}
