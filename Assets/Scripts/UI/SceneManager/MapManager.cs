using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    AudioManager audioManager;

    public static MapManager Instance;
    public GameObject loader;
    public Image progressBar;
    public TextMeshProUGUI progressText;
    public float target;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        progressText.text = progressBar.fillAmount.ToString();
    }

    public async void Loader(string sceneName)
    {
        audioManager.musicSource.Stop();
        audioManager.PlayMusic("LoadScene");

        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loader.SetActive(true);

        do
        {
            await Task.Delay(1000);
           target = scene.progress;

        } while (scene.progress < 0.9f);

        await Task.Delay(500);

        scene.allowSceneActivation = true;
        Invoke(nameof(DeplayLoader), 0.5f);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3 * Time.deltaTime);
        var total = progressBar.fillAmount * 100;
        progressText.text = total.ToString("0") + "%";

    }

    public void DeplayLoader()
    {
        Time.timeScale = 1;

        loader.SetActive(false);

    }
}
