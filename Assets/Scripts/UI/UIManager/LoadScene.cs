using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{

   public GameObject notificationLoadscene;

    void Start()
    {
        notificationLoadscene.SetActive(false);

    }

   public void LoadMapVillage()
    {
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MapVillage", LoadSceneMode.Additive);

    }

    public void LoadMapDungeon()
    {
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MapDungeon", LoadSceneMode.Additive);

    }

    public void LoadMapJungle()
    {
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MapJungle", LoadSceneMode.Additive);

    }

    public void LoadMapDesert()
    {
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MapDesert", LoadSceneMode.Additive);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            notificationLoadscene.SetActive(true);
        }
    }
}
