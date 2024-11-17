using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void NewGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
