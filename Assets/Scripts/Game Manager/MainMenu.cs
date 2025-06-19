using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public GameObject ui;
    public string levelName;

    public void play()
    {
        sceneFader.fadeTo(levelName);
    }

    public void goToRuleMenu()
    {
        ui.SetActive(true);
    }    

    public void goToMainMenu()
    {
        ui.SetActive(false);
    }
}
