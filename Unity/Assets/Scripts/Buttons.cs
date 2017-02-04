using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public  Sprite  boxChecked;
    public  Sprite  boxNotChecked;

    public void Resume ()
    {
        GetComponent<GameManager>().mapManager.GetComponent<MapManager>().Resume();
    }

    public void Options()
    {
        GetComponent<GameManager>().hudPanelMenu.SetActive(false);
        GetComponent<GameManager>().hudPanelOptions.SetActive(true);
        GetComponent<GameManager>().isInOptions = true;
    }

    public void StartBoss()
    {
        NewGame();
        Application.LoadLevel("TestGameplay");
        GetComponent<GameManager>().cam = GameObject.Find("Main Camera");
    }

    public void StartCapture()
    {
        NewGame();
        Application.LoadLevel("GameplayCapture");
        GetComponent<GameManager>().cam = GameObject.Find("Main Camera");
    }

    public void StartDefense()
    {
        NewGame();
        Application.LoadLevel("GameplayDefense");
        GetComponent<GameManager>().cam = GameObject.Find("Main Camera");
    }

    void NewGame()
    {
        GetComponent<GameManager>().capturePanel.SetActive(false);
        GetComponent<GameManager>().defensePanel.SetActive(false);
        GetComponent<GameManager>().bossPanel.SetActive(false);
        GetComponent<GameManager>().hudStar1.SetActive(false);
        GetComponent<GameManager>().hudStar2.SetActive(false);
        GetComponent<GameManager>().hudStar3.SetActive(false);
        GetComponent<GameManager>().hudVictory.SetActive(false);
        GetComponent<GameManager>().hudDefeat.SetActive(false);
        GetComponent<GameManager>().hudButtonTryAgain.SetActive(false);
        GetComponent<GameManager>().hudButtonReturnToMenu.SetActive(false);
        GetComponent<GameManager>().fioleRed.SetActive(false);
        GetComponent<GameManager>().fioleOrange.SetActive(false);
        GetComponent<GameManager>().fioleYellow.SetActive(false);
        GetComponent<GameManager>().fioleGreen.SetActive(true);
        GetComponent<GameManager>().agentLevel2.SetActive(false);
        GetComponent<GameManager>().agentLevel3.SetActive(false);
        GetComponent<GameManager>().agentLevel4.SetActive(false);
        GetComponent<GameManager>().agentLevel5.SetActive(false);
        GetComponent<GameManager>().agentLevel6.SetActive(false);
        GetComponent<GameManager>().agentLevel7.SetActive(false);
        GetComponent<GameManager>().agentLevel8.SetActive(false);
        GetComponent<GameManager>().agentLevel9.SetActive(false);
        GetComponent<GameManager>().agentLevel10.SetActive(false);
        GetComponent<GameManager>().usingSpell1Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell2Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell3Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell4Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell5Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell6Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell7Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell8Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell1Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell2Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell3Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell4Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell5Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell6Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell7Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().usingSpell8Icon.GetComponent<UsingSpell>().player = null;
        GetComponent<GameManager>().gamePaused = false;
        GetComponent<GameManager>().gameOver = false;
        GetComponent<GameManager>().isInGame = true;
        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().hudInGame.SetActive(true);
    }

    public void LeaveOptions()
    {
        GetComponent<GameManager>().mapManager.GetComponent<MapManager>().CloseOptions();
    }

    public void PlayAgain()
    {
        NewGame();
        if (Application.loadedLevel == 2)
            Application.LoadLevel(2);
        else if (Application.loadedLevel == 3)
            Application.LoadLevel(3);
        else if (Application.loadedLevel == 4)
            Application.LoadLevel(4);
        Resume();

    }

    public void ReturnToMenu()
    {
        GetComponent<GameManager>().hudInGame.SetActive(false);
        GetComponent<GameManager>().hudPanelMenu.SetActive(false);
        GetComponent<GameManager>().hudPanelOptions.SetActive(false);
        GetComponent<GameManager>().isInOptions = false;
        Time.timeScale = 1.0f;
        GetComponent<GameManager>().isInMenu = false;
        GetComponent<GameManager>().panelMenu.SetActive(true);
        GetComponent<GameManager>().hudStar1.SetActive(false);
        GetComponent<GameManager>().hudStar2.SetActive(false);
        GetComponent<GameManager>().hudStar3.SetActive(false);
        GetComponent<GameManager>().hudVictory.SetActive(false);
        GetComponent<GameManager>().hudDefeat.SetActive(false);
        GetComponent<GameManager>().hudButtonTryAgain.SetActive(false);
        GetComponent<GameManager>().hudButtonReturnToMenu.SetActive(false);
        GetComponent<GameManager>().fioleRed.SetActive(false);
        GetComponent<GameManager>().fioleOrange.SetActive(false);
        GetComponent<GameManager>().fioleYellow.SetActive(false);
        GetComponent<GameManager>().fioleGreen.SetActive(false);
        GetComponent<GameManager>().agentLevel2.SetActive(false);
        GetComponent<GameManager>().agentLevel3.SetActive(false);
        GetComponent<GameManager>().agentLevel4.SetActive(false);
        GetComponent<GameManager>().agentLevel5.SetActive(false);
        GetComponent<GameManager>().agentLevel6.SetActive(false);
        GetComponent<GameManager>().agentLevel7.SetActive(false);
        GetComponent<GameManager>().agentLevel8.SetActive(false);
        GetComponent<GameManager>().agentLevel9.SetActive(false);
        GetComponent<GameManager>().agentLevel10.SetActive(false);
        GetComponent<GameManager>().usingSpell1Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell2Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell3Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell4Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell5Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell6Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell7Icon.SetActive(false);
        GetComponent<GameManager>().usingSpell8Icon.SetActive(false);
        GetComponent<GameManager>().gamePaused = true;
        GetComponent<GameManager>().gameOver = true;
        GetComponent<GameManager>().isInGame = false;
        Application.LoadLevel("SceneMenu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void SmartCast(GameObject obj)
    {
        if (GetComponent<GameManager>().smartcast == false)
        {
            GetComponent<GameManager>().smartcast = true;
            obj.GetComponent<Image>().sprite = boxChecked;
        }
        else
        {
            GetComponent<GameManager>().smartcast = false;
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
    }

    public void MusicMinus(GameObject obj)
    {
        GetComponent<GameManager>().volumeMusic -= 10;
        if (GetComponent<GameManager>().volumeMusic < 0)
            GetComponent<GameManager>().volumeMusic = 0;
        obj.GetComponent<Text>().text = "Volume music : " + GetComponent<GameManager>().volumeMusic;
    }

    public void MusicPlus(GameObject obj)
    {
        GetComponent<GameManager>().volumeMusic += 10;
        if (GetComponent<GameManager>().volumeMusic > 100)
            GetComponent<GameManager>().volumeMusic = 100;
        obj.GetComponent<Text>().text = "Volume music : " + GetComponent<GameManager>().volumeMusic;
    }

    public void BloodTrigger(GameObject obj)
    {
        if (GetComponent<GameManager>().bloodless == true)
        {
            GetComponent<GameManager>().ActivateBlood();
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
        else
        {
            GetComponent<GameManager>().DesactivateBlood();
            obj.GetComponent<Image>().sprite = boxChecked;
        }
    }
}
