using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    [Header("Dead Menu")]
    public GameObject deadMenuUI;
    [Header("Shop Menu")]
    public GameObject shopMenuUI;

    [Header("Player and Scene Fader")]
    public SceneFader sceneFader;
    public PlayerHealth playerHelth;

    public string menuSceneName;

    void Start()
    {
        playerHelth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDead();
    }

    public void togglePauseMenu()
    {
        if (!deadMenuUI.activeSelf && !shopMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

            if (pauseMenuUI.activeSelf)
            {
                Time.timeScale = 0f;
                //MINE (lock mouse)
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Time.timeScale = 1f;
                //MINE (lock mouse)
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void toggleShopMenu()
    {
        if (!deadMenuUI.activeSelf && !pauseMenuUI.activeSelf)
        {
            shopMenuUI.SetActive(!shopMenuUI.activeSelf);

            if (shopMenuUI.activeSelf)
            {
                Time.timeScale = 0f;
                //MINE (lock mouse)
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Time.timeScale = 1f;
                //MINE (lock mouse)
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void retry()
    {
        togglePauseMenu();
        Time.timeScale = 1f;
        sceneFader.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void menu()
    {
        togglePauseMenu();
        Time.timeScale = 1f;
        sceneFader.fadeTo(menuSceneName);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void playerDead()
    {
        if (playerHelth.getHealth() <= 0 && !deadMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            shopMenuUI.SetActive(false);
            deadMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }


}
