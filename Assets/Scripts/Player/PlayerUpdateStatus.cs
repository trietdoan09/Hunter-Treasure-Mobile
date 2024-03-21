using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUpdateStatus : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject activeStatusPoint;
    private GameObject playerManager;

    public enum StatusPointName
    {
        Attack,
        Defend,
        Health,
        Mana
    }

    [SerializeField] private StatusPointName currentPointName;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.GetComponent<PlayerManager>().playerStatusPoint > 0)
        {
            activeStatusPoint.SetActive(true);
        }
        else
        {
            activeStatusPoint.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(playerManager.GetComponent<PlayerManager>().playerStatusPoint > 0)
        {
            switch (currentPointName)
            {
                case StatusPointName.Attack:
                    {
                        playerManager.GetComponent<PlayerManager>().playerAttackPoint += 10;
                        playerManager.GetComponent<PlayerManager>().playerStatusPoint -= 1;
                        Debug.Log("Attack");
                        break;
                    }
                case StatusPointName.Defend:
                    {
                        playerManager.GetComponent<PlayerManager>().playerDefendPoint += 10;
                        playerManager.GetComponent<PlayerManager>().playerStatusPoint -= 1;
                        Debug.Log("Defend");
                        break;
                    }
                case StatusPointName.Health:
                    {
                        playerManager.GetComponent<PlayerManager>().playerMaxHealPoint += 100;
                        playerManager.GetComponent<PlayerManager>().playerStatusPoint -= 1;
                        Debug.Log("Health");
                        break;
                    }
                case StatusPointName.Mana:
                    {
                        playerManager.GetComponent<PlayerManager>().playerMaxManaPoint += 100;
                        playerManager.GetComponent<PlayerManager>().playerStatusPoint -= 1;
                        Debug.Log("Mana");
                        break;
                    }
                default: break;
            }
        }
    }

}
