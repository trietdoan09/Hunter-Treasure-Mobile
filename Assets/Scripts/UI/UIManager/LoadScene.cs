using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScene : MonoBehaviour
{
   [SerializeField] private Button village;

    void Start()
    {
        village.onClick.AddListener(() =>
        {
            LoadMap();
        });
    }

   public void LoadMap()
    {
        SceneManager.LoadScene("Scene1");

        SceneManager.LoadScene("MapDesert", LoadSceneMode.Additive);

    }
}
