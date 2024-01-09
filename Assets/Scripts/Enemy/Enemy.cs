using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool check;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           check = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        check = false;
    }
}
