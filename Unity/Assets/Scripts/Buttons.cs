using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public void Resume ()
    {
        GetComponent<GameManager>().hudMenuResume.SetActive(false);
        GetComponent<GameManager>().hudMenuOptions.SetActive(false);
        GetComponent<GameManager>().hudMenuRestart.SetActive(false);
        GetComponent<GameManager>().hudMenuAbandon.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Options()
    {

    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
