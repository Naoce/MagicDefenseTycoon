using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public void PlayAgain()
    {
        Application.LoadLevel(0);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
