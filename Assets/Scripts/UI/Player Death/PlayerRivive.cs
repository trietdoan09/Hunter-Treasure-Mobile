using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRivive : MonoBehaviour
{
    public GameObject riviveObj;

    void Start()
    {
        riviveObj.SetActive(false);
    }

   public void OffRivive()
    {
        riviveObj.SetActive(false);
        Time.timeScale = 1;
    }
}
