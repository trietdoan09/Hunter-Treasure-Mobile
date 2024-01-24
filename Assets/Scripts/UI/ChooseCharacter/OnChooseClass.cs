using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChooseClass : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject active;
    public bool onClassChoosed;
    void Start()
    {
        active.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (onClassChoosed)
        {
            active.SetActive(true);
        }
        else
        {
            active.SetActive(false);
        }
    }


}
