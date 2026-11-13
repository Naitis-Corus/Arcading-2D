using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    [SerializeField] GameObject deathPanelUI;
    [SerializeField] Player player;
    [SerializeField] float lowerDeathEdjes = 12f;
    [SerializeField] CounterUI counterUI;
    Camera cameraMain;

    void Awake()
    {
        cameraMain = Camera.main;
    }
    void Update()
    {
        if (cameraMain.transform.position.y - lowerDeathEdjes > player.transform.position.y )
        {
            deathPanelUI.SetActive(true);
            Time.timeScale = 0f;
            player.gameObject.SetActive(false);
            int oldRecord = PlayerPrefs.GetInt("bestRecord", 0);
            if (counterUI.playerAltimeter > oldRecord)
            {

                PlayerPrefs.SetInt("bestRecord", counterUI.playerAltimeter);
                PlayerPrefs.Save();
            }
            this.enabled = false;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
