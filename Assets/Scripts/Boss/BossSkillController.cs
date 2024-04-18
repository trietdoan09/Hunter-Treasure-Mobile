using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillController : MonoBehaviour
{
    public int idSkill;
    [SerializeField] private float speed;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        AutoDestroy();
    }

    // Update is called once per frame
    void Update()
    {
        if(idSkill < 2)
        {
            transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
        }
    }

    private void AutoDestroy()
    {
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Skill " + idSkill + " give dame");
            Destroy(gameObject);
        }
    }
}
