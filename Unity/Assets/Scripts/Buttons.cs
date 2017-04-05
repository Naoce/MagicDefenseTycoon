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

        GetComponent<GameManager>().agent1Levels[1].SetActive(false);
        GetComponent<GameManager>().agent1Levels[2].SetActive(false);
        GetComponent<GameManager>().agent1Levels[3].SetActive(false);
        GetComponent<GameManager>().agent1Levels[4].SetActive(false);
        GetComponent<GameManager>().agent1Levels[5].SetActive(false);
        GetComponent<GameManager>().agent1Levels[6].SetActive(false);
        GetComponent<GameManager>().agent1Levels[7].SetActive(false);
        GetComponent<GameManager>().agent1Levels[8].SetActive(false);
        GetComponent<GameManager>().agent1Levels[9].SetActive(false);

        GetComponent<GameManager>().agent2Levels[1].SetActive(false);
        GetComponent<GameManager>().agent2Levels[2].SetActive(false);
        GetComponent<GameManager>().agent2Levels[3].SetActive(false);
        GetComponent<GameManager>().agent2Levels[4].SetActive(false);
        GetComponent<GameManager>().agent2Levels[5].SetActive(false);
        GetComponent<GameManager>().agent2Levels[6].SetActive(false);
        GetComponent<GameManager>().agent2Levels[7].SetActive(false);
        GetComponent<GameManager>().agent2Levels[8].SetActive(false);
        GetComponent<GameManager>().agent2Levels[9].SetActive(false);

        GetComponent<GameManager>().agent3Levels[1].SetActive(false);
        GetComponent<GameManager>().agent3Levels[2].SetActive(false);
        GetComponent<GameManager>().agent3Levels[3].SetActive(false);
        GetComponent<GameManager>().agent3Levels[4].SetActive(false);
        GetComponent<GameManager>().agent3Levels[5].SetActive(false);
        GetComponent<GameManager>().agent3Levels[6].SetActive(false);
        GetComponent<GameManager>().agent3Levels[7].SetActive(false);
        GetComponent<GameManager>().agent3Levels[8].SetActive(false);
        GetComponent<GameManager>().agent3Levels[9].SetActive(false);

        GetComponent<GameManager>().agent4Levels[1].SetActive(false);
        GetComponent<GameManager>().agent4Levels[2].SetActive(false);
        GetComponent<GameManager>().agent4Levels[3].SetActive(false);
        GetComponent<GameManager>().agent4Levels[4].SetActive(false);
        GetComponent<GameManager>().agent4Levels[5].SetActive(false);
        GetComponent<GameManager>().agent4Levels[6].SetActive(false);
        GetComponent<GameManager>().agent4Levels[7].SetActive(false);
        GetComponent<GameManager>().agent4Levels[8].SetActive(false);
        GetComponent<GameManager>().agent4Levels[9].SetActive(false);

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
        Application.LoadLevel(Application.loadedLevel);
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

        GetComponent<GameManager>().agent1Levels[1].SetActive(false);
        GetComponent<GameManager>().agent1Levels[2].SetActive(false);
        GetComponent<GameManager>().agent1Levels[3].SetActive(false);
        GetComponent<GameManager>().agent1Levels[4].SetActive(false);
        GetComponent<GameManager>().agent1Levels[5].SetActive(false);
        GetComponent<GameManager>().agent1Levels[6].SetActive(false);
        GetComponent<GameManager>().agent1Levels[7].SetActive(false);
        GetComponent<GameManager>().agent1Levels[8].SetActive(false);
        GetComponent<GameManager>().agent1Levels[9].SetActive(false);

        GetComponent<GameManager>().agent2Levels[1].SetActive(false);
        GetComponent<GameManager>().agent2Levels[2].SetActive(false);
        GetComponent<GameManager>().agent2Levels[3].SetActive(false);
        GetComponent<GameManager>().agent2Levels[4].SetActive(false);
        GetComponent<GameManager>().agent2Levels[5].SetActive(false);
        GetComponent<GameManager>().agent2Levels[6].SetActive(false);
        GetComponent<GameManager>().agent2Levels[7].SetActive(false);
        GetComponent<GameManager>().agent2Levels[8].SetActive(false);
        GetComponent<GameManager>().agent2Levels[9].SetActive(false);

        GetComponent<GameManager>().agent3Levels[1].SetActive(false);
        GetComponent<GameManager>().agent3Levels[2].SetActive(false);
        GetComponent<GameManager>().agent3Levels[3].SetActive(false);
        GetComponent<GameManager>().agent3Levels[4].SetActive(false);
        GetComponent<GameManager>().agent3Levels[5].SetActive(false);
        GetComponent<GameManager>().agent3Levels[6].SetActive(false);
        GetComponent<GameManager>().agent3Levels[7].SetActive(false);
        GetComponent<GameManager>().agent3Levels[8].SetActive(false);
        GetComponent<GameManager>().agent3Levels[9].SetActive(false);

        GetComponent<GameManager>().agent4Levels[1].SetActive(false);
        GetComponent<GameManager>().agent4Levels[2].SetActive(false);
        GetComponent<GameManager>().agent4Levels[3].SetActive(false);
        GetComponent<GameManager>().agent4Levels[4].SetActive(false);
        GetComponent<GameManager>().agent4Levels[5].SetActive(false);
        GetComponent<GameManager>().agent4Levels[6].SetActive(false);
        GetComponent<GameManager>().agent4Levels[7].SetActive(false);
        GetComponent<GameManager>().agent4Levels[8].SetActive(false);
        GetComponent<GameManager>().agent4Levels[9].SetActive(false);

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

    public void SpellInfosTrigger(GameObject obj)
    {
        if (GetComponent<GameManager>().showSpellsInfo == true)
        {
            GetComponent<GameManager>().showSpellsInfo = false;
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
        else
        {
            GetComponent<GameManager>().showSpellsInfo = true;
            obj.GetComponent<Image>().sprite = boxChecked;
        }
    }

    public void SetOnTextDifficulty(int difficulty)
    {
        GetComponent<GameManager>().textDifficulty.SetActive(true);
        if (difficulty == 0)
            GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "For players searching for a more\nrelaxed experience.";
        else if (difficulty == 1)
            GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "For players that search for a\nnormal experience.";
        else if (difficulty == 2)
            GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "Only play this if you enjoy dying.\nA lot.";
    }

    public void SetOffTextDifficulty()
    {
        GetComponent<GameManager>().textDifficulty.SetActive(false);
    }

    public void SetDifficultyToEasy()
    {
        if (GetComponent<GameManager>().currSave == 1)
        {
            PlayerPrefs.SetInt("Load1DifficultySet", 1);
            PlayerPrefs.SetInt("Load1Difficulty", 0);
            GetComponent<GameManager>().difficulty = 0;
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            PlayerPrefs.SetInt("Load2DifficultySet", 1);
            PlayerPrefs.SetInt("Load2Difficulty", 0);
            GetComponent<GameManager>().difficulty = 0;
        }
        else if (GetComponent<GameManager>().currSave == 3)
        {
            PlayerPrefs.SetInt("Load3DifficultySet", 1);
            PlayerPrefs.SetInt("Load3Difficulty", 0);
            GetComponent<GameManager>().difficulty = 0;
        }
        GetComponent<GameManager>().panelDifficulty.SetActive(false);
        GetComponent<GameManager>().panelMenu.SetActive(true);
    }

    public void SetDifficultyToNormal()
    {
        if (GetComponent<GameManager>().currSave == 1)
        {
            PlayerPrefs.SetInt("Load1DifficultySet", 1);
            PlayerPrefs.SetInt("Load1Difficulty", 1);
            GetComponent<GameManager>().difficulty = 1;
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            PlayerPrefs.SetInt("Load2DifficultySet", 1);
            PlayerPrefs.SetInt("Load2Difficulty", 1);
            GetComponent<GameManager>().difficulty = 1;
        }
        else if (GetComponent<GameManager>().currSave == 3)
        {
            PlayerPrefs.SetInt("Load3DifficultySet", 1);
            PlayerPrefs.SetInt("Load3Difficulty", 1);
            GetComponent<GameManager>().difficulty = 1;
        }
        GetComponent<GameManager>().panelDifficulty.SetActive(false);
        GetComponent<GameManager>().panelMenu.SetActive(true);
    }

    public void SetDifficultyToDifficult()
    {
        if (GetComponent<GameManager>().currSave == 1)
        {
            PlayerPrefs.SetInt("Load1DifficultySet", 1);
            PlayerPrefs.SetInt("Load1Difficulty", 2);
            GetComponent<GameManager>().difficulty = 2;
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            PlayerPrefs.SetInt("Load2DifficultySet", 1);
            PlayerPrefs.SetInt("Load2Difficulty", 2);
            GetComponent<GameManager>().difficulty = 2;
        }
        else if (GetComponent<GameManager>().currSave == 3)
        {
            PlayerPrefs.SetInt("Load3DifficultySet", 1);
            PlayerPrefs.SetInt("Load3Difficulty", 2);
            GetComponent<GameManager>().difficulty = 2;
        }
        GetComponent<GameManager>().panelDifficulty.SetActive(false);
        GetComponent<GameManager>().panelMenu.SetActive(true);
    }

    public void LoadFile1()
    {
        if (GetComponent<GameManager>().load1Created == false)
        {
            SetLoad1Name();
        }
        else
        {
            GetComponent<GameManager>().currSave = 1;
            GetComponent<GameManager>().panelSave.SetActive(false);
            if (PlayerPrefs.GetInt("Load1DifficultySet") == 1)
            {
                GetComponent<GameManager>().difficulty = PlayerPrefs.GetInt("Load1Difficulty");
                GetComponent<GameManager>().panelMenu.SetActive(true);
            }
            else
                GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void SetLoad1Name()
    {
        GetComponent<GameManager>().bulleInfoCreateSave.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad1Name.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad1Name.GetComponent<InputField>().Select();
        GetComponent<GameManager>().load1Name.SetActive(false);
    }

    public void SetLoad1NameEnd(Text newText)
    {
        if (newText.text.Length > 0)
        {
            GetComponent<GameManager>().bulleInfoCreateSave.SetActive(false);
            GetComponent<GameManager>().load1Created = true;
            PlayerPrefs.SetString("Load1Name", newText.text);
            PlayerPrefs.SetInt("Load1Created", 1);
            GetComponent<GameManager>().load1Name.GetComponent<Text>().text = newText.text;
            GetComponent<GameManager>().inputFieldLoad1Name.SetActive(false);
            GetComponent<GameManager>().load1Name.SetActive(true);
            GetComponent<GameManager>().currSave = 1;
            PlayerPrefs.SetInt("Load1DifficultySet", 0);
            PlayerPrefs.SetInt("Load1PlayerStockHealthPotion", 1);
            PlayerPrefs.SetInt("Load1PlayerStockManaPotion", 1);
            GetComponent<GameManager>().panelSave.SetActive(false);
            GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void DeleteSave1()
    {
        PlayerPrefs.SetInt("Load1Created", 0);
        PlayerPrefs.SetInt("Load1PlayerLevel", 0);
        PlayerPrefs.SetInt("Load1PlayerXP", 0);

        PlayerPrefs.SetInt("Load1PlayerStockHealthPotion", 0);
        PlayerPrefs.SetInt("Load1PlayerStockManaPotion", 0);

        PlayerPrefs.SetInt("Load1Agent1Level", 0);
        PlayerPrefs.SetInt("Load1Agent1XP", 0);
        PlayerPrefs.SetInt("Load1Agent2Level", 0);
        PlayerPrefs.SetInt("Load1Agent2XP", 0);
        PlayerPrefs.SetInt("Load1Agent3Level", 0);
        PlayerPrefs.SetInt("Load1Agent3XP", 0);
        PlayerPrefs.SetInt("Load1Agent4Level", 0);
        PlayerPrefs.SetInt("Load1Agent4XP", 0);
        PlayerPrefs.SetInt("Load1Agent1StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load1Agent1StockManaPotion", 0);
        PlayerPrefs.SetInt("Load1Agent2StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load1Agent2StockManaPotion", 0);
        PlayerPrefs.SetInt("Load1Agent3StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load1Agent3StockManaPotion", 0);
        PlayerPrefs.SetInt("Load1Agent4StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load1Agent4StockManaPotion", 0);

        PlayerPrefs.SetInt("Load1DifficultySet", 0);
        GetComponent<GameManager>().load1Created = false;
        GetComponent<GameManager>().load1Name.GetComponent<Text>().text = "Empty save";
    }

    public void LoadFile2()
    {
        if (GetComponent<GameManager>().load2Created == false)
        {
            SetLoad2Name();
        }
        else
        {
            GetComponent<GameManager>().currSave = 2;
            GetComponent<GameManager>().panelSave.SetActive(false);
            if (PlayerPrefs.GetInt("Load2DifficultySet") == 1)
            {
                GetComponent<GameManager>().difficulty = PlayerPrefs.GetInt("Load2Difficulty");
                GetComponent<GameManager>().panelMenu.SetActive(true);
            }
            else
                GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void SetLoad2Name()
    {
        GetComponent<GameManager>().bulleInfoCreateSave.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad2Name.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad2Name.GetComponent<InputField>().Select();
        GetComponent<GameManager>().load2Name.SetActive(false);
    }

    public void SetLoad2NameEnd(Text newText)
    {
        if (newText.text.Length > 0)
        {
            GetComponent<GameManager>().bulleInfoCreateSave.SetActive(false);
            GetComponent<GameManager>().load2Created = true;
            PlayerPrefs.SetString("Load2Name", newText.text);
            PlayerPrefs.SetInt("Load2Created", 1);
            GetComponent<GameManager>().load2Name.GetComponent<Text>().text = newText.text;
            GetComponent<GameManager>().inputFieldLoad2Name.SetActive(false);
            GetComponent<GameManager>().load2Name.SetActive(true);
            GetComponent<GameManager>().currSave = 2;
            PlayerPrefs.SetInt("Load2DifficultySet", 0);
            PlayerPrefs.SetInt("Load2PlayerStockHealthPotion", 1);
            PlayerPrefs.SetInt("Load2PlayerStockManaPotion", 1);
            GetComponent<GameManager>().panelSave.SetActive(false);
            GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void DeleteSave2()
    {
        PlayerPrefs.SetInt("Load2Created", 0);
        PlayerPrefs.SetInt("Load2PlayerLevel", 0);
        PlayerPrefs.SetInt("Load2PlayerXP", 0);

        PlayerPrefs.SetInt("Load2PlayerStockHealthPotion", 0);
        PlayerPrefs.SetInt("Load2PlayerStockManaPotion", 0);

        PlayerPrefs.SetInt("Load2Agent1Level", 0);
        PlayerPrefs.SetInt("Load2Agent1XP", 0);
        PlayerPrefs.SetInt("Load2Agent2Level", 0);
        PlayerPrefs.SetInt("Load2Agent2XP", 0);
        PlayerPrefs.SetInt("Load2Agent3Level", 0);
        PlayerPrefs.SetInt("Load2Agent3XP", 0);
        PlayerPrefs.SetInt("Load1Agent4Level", 0);
        PlayerPrefs.SetInt("Load2Agent4XP", 0);
        PlayerPrefs.SetInt("Load2Agent1StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load2Agent1StockManaPotion", 0);
        PlayerPrefs.SetInt("Load2Agent2StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load2Agent2StockManaPotion", 0);
        PlayerPrefs.SetInt("Load2Agent3StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load2Agent3StockManaPotion", 0);
        PlayerPrefs.SetInt("Load2Agent4StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load2Agent4StockManaPotion", 0);

        PlayerPrefs.SetInt("Load2DifficultySet", 0);
        GetComponent<GameManager>().load2Created = false;
        GetComponent<GameManager>().load2Name.GetComponent<Text>().text = "Empty save";
    }

    public void LoadFile3()
    {
        if (GetComponent<GameManager>().load3Created == false)
        {
            SetLoad3Name();
        }
        else
        {
            GetComponent<GameManager>().currSave = 3;
            GetComponent<GameManager>().panelSave.SetActive(false);
            if (PlayerPrefs.GetInt("Load3DifficultySet") == 1)
            {
                GetComponent<GameManager>().difficulty = PlayerPrefs.GetInt("Load3Difficulty");
                GetComponent<GameManager>().panelMenu.SetActive(true);
            }
            else
                GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void SetLoad3Name()
    {
        GetComponent<GameManager>().bulleInfoCreateSave.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad3Name.SetActive(true);
        GetComponent<GameManager>().inputFieldLoad3Name.GetComponent<InputField>().Select();
        GetComponent<GameManager>().load3Name.SetActive(false);
    }

    public void SetLoad3NameEnd(Text newText)
    {
        if (newText.text.Length > 0)
        {
            GetComponent<GameManager>().bulleInfoCreateSave.SetActive(false);
            GetComponent<GameManager>().load3Created = true;
            PlayerPrefs.SetString("Load3Name", newText.text);
            PlayerPrefs.SetInt("Load3Created", 1);
            GetComponent<GameManager>().load3Name.GetComponent<Text>().text = newText.text;
            GetComponent<GameManager>().inputFieldLoad3Name.SetActive(false);
            GetComponent<GameManager>().load3Name.SetActive(true);
            GetComponent<GameManager>().currSave = 3;
            PlayerPrefs.SetInt("Load3DifficultySet", 0);
            PlayerPrefs.SetInt("Load3PlayerStockHealthPotion", 1);
            PlayerPrefs.SetInt("Load3PlayerStockManaPotion", 1);
            GetComponent<GameManager>().panelSave.SetActive(false);
            GetComponent<GameManager>().panelDifficulty.SetActive(true);
        }
    }

    public void DeleteSave3()
    {
        PlayerPrefs.SetInt("Load3Created", 0);
        PlayerPrefs.SetInt("Load3PlayerLevel", 0);
        PlayerPrefs.SetInt("Load3PlayerXP", 0);

        PlayerPrefs.SetInt("Load3PlayerStockHealthPotion", 0);
        PlayerPrefs.SetInt("Load3PlayerStockManaPotion", 0);

        PlayerPrefs.SetInt("Load3Agent1Level", 0);
        PlayerPrefs.SetInt("Load3Agent1XP", 0);
        PlayerPrefs.SetInt("Load3Agent2Level", 0);
        PlayerPrefs.SetInt("Load3Agent2XP", 0);
        PlayerPrefs.SetInt("Load3Agent3Level", 0);
        PlayerPrefs.SetInt("Load3Agent3XP", 0);
        PlayerPrefs.SetInt("Load3Agent4Level", 0);
        PlayerPrefs.SetInt("Load3Agent4XP", 0);
        PlayerPrefs.SetInt("Load3Agent1StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load3Agent1StockManaPotion", 0);
        PlayerPrefs.SetInt("Load3Agent2StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load3Agent2StockManaPotion", 0);
        PlayerPrefs.SetInt("Load3Agent3StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load3Agent3StockManaPotion", 0);
        PlayerPrefs.SetInt("Load3Agent4StockHealthPotion", 0);
        PlayerPrefs.SetInt("Load3Agent4StockManaPotion", 0);

        PlayerPrefs.SetInt("Load3DifficultySet", 0);
        GetComponent<GameManager>().load3Created = false;
        GetComponent<GameManager>().load3Name.GetComponent<Text>().text = "Empty save";
    }
}
