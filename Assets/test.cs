using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity += new Vector2(2 * Time.deltaTime, 0);
        if (transform.position.x > 0)
        {
            rigidbody2D.velocity += new Vector2(-2 *Time.deltaTime, 0);
            a.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
