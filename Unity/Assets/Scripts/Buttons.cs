using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public  Sprite  boxChecked;
    public  Sprite  boxNotChecked;

    void Awake()
    {
        ReturnToIntro();
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("WASDModeSet") == 0)
        {
            PlayerPrefs.SetInt("WASDMode", 1);
            GetComponent<GameManager>().wasdMode = true;
            GetComponent<GameManager>().wasdModeButton.GetComponent<Image>().sprite = boxChecked;
        }
        else
        {
            if (PlayerPrefs.GetInt("WASDMode") == 1)
            {
                GetComponent<GameManager>().wasdMode = true;
                GetComponent<GameManager>().wasdModeButton.GetComponent<Image>().sprite = boxChecked;
                GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "Q";
            }
            else
            {
                GetComponent<GameManager>().wasdMode = false;
                GetComponent<GameManager>().wasdModeButton.GetComponent<Image>().sprite = boxNotChecked;
                GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "A";
            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) &&
            GetComponent<GameManager>().isInOptionsFromIntro == true)
        {
            GetComponent<GameManager>().hudPanelOptions.SetActive(false);
            GetComponent<GameManager>().panelIntro.SetActive(true);
            StartCoroutine(AnimationPanelIntro());
            GetComponent<GameManager>().isInOptionsFromIntro = false;
        }
    } 

    public void Resume ()
    {
        GetComponent<GameManager>().mapManager.GetComponent<MapManager>().Resume();
    }

    public void OptionsFromIntro()
    {
        GetComponent<GameManager>().panelIntro.SetActive(false);
        GetComponent<GameManager>().hudPanelOptions.SetActive(true);
        AnimationPanelOptions();
        GetComponent<GameManager>().isInOptionsFromIntro = true;
    }

    public void Options()
    {
        GetComponent<GameManager>().hudPanelMenu.SetActive(false);
        GetComponent<GameManager>().hudPanelOptions.SetActive(true);
        AnimationPanelOptions();
        GetComponent<GameManager>().isInOptions = true;
    }

    public void ShowCredits()
    {
        GetComponent<GameManager>().textCredits.SetActive(true);
    }

    public void HideCredits()
    {
        GetComponent<GameManager>().textCredits.SetActive(false);
    }

    void NewGame()
    {
        GetComponent<GameManager>().panelMissions.SetActive(false);
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
        AnimationPanelHUDMenu();
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
        GetComponent<GameManager>().PlayMusicMenu();
        StartCoroutine(AnimationPanelMenu());
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void SmartCast(GameObject obj)
    {
        if (GetComponent<GameManager>().smartcast == false)
        {
            PlayerPrefs.SetInt("Smartcast", 1);
            GetComponent<GameManager>().smartcast = true;
            obj.GetComponent<Image>().sprite = boxChecked;
        }
        else
        {
            PlayerPrefs.SetInt("Smartcast", 0);
            GetComponent<GameManager>().smartcast = false;
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
    }

    public void MusicMinus(GameObject obj)
    {
        GetComponent<GameManager>().volumeMusic -= 10;
        if (GetComponent<GameManager>().volumeMusic < 0)
            GetComponent<GameManager>().volumeMusic = 0;
        PlayerPrefs.SetInt("MusicVolumeSet", 1);
        PlayerPrefs.SetInt("MusicVolume", (int)GetComponent<GameManager>().volumeMusic);
        obj.GetComponent<Text>().text = "Music volume : " + GetComponent<GameManager>().volumeMusic + "%";
        if (GetComponent<GameManager>().isInGame == true)
            GetComponent<GameManager>().musicCombatObj.GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
        GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
    }

    public void MusicPlus(GameObject obj)
    {
        GetComponent<GameManager>().volumeMusic += 10;
        if (GetComponent<GameManager>().volumeMusic > 100)
            GetComponent<GameManager>().volumeMusic = 100;
        PlayerPrefs.SetInt("MusicVolumeSet", 1);
        PlayerPrefs.SetInt("MusicVolume", (int)GetComponent<GameManager>().volumeMusic);
        obj.GetComponent<Text>().text = "Music volume : " + GetComponent<GameManager>().volumeMusic + "%";
        if (GetComponent<GameManager>().isInGame == true)
            GetComponent<GameManager>().musicCombatObj.GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
        GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
    }

    public void SFXMinus(GameObject obj)
    {
        GetComponent<GameManager>().volumeSFX -= 10;
        if (GetComponent<GameManager>().volumeSFX < 0)
            GetComponent<GameManager>().volumeSFX = 0;
        PlayerPrefs.SetInt("SFXVolumeSet", 1);
        PlayerPrefs.SetInt("SFXVolume", (int)GetComponent<GameManager>().volumeSFX);
        obj.GetComponent<Text>().text = "SFX volume : " + GetComponent<GameManager>().volumeSFX + "%";
    }

    public void SFXPlus(GameObject obj)
    {
        GetComponent<GameManager>().volumeSFX += 10;
        if (GetComponent<GameManager>().volumeSFX > 100)
            GetComponent<GameManager>().volumeSFX = 100;
        PlayerPrefs.SetInt("SFXVolumeSet", 1);
        PlayerPrefs.SetInt("SFXVolume", (int)GetComponent<GameManager>().volumeSFX);
        obj.GetComponent<Text>().text = "SFX volume : " + GetComponent<GameManager>().volumeSFX + "%";
    }

    public void BloodTrigger(GameObject obj)
    {
        if (GetComponent<GameManager>().bloodless == true)
        {
            PlayerPrefs.SetInt("Bloodless", 0);
            GetComponent<GameManager>().ActivateBlood();
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
        else
        {
            PlayerPrefs.SetInt("Bloodless", 1);
            GetComponent<GameManager>().DesactivateBlood();
            obj.GetComponent<Image>().sprite = boxChecked;
        }
    }

    public void SpellInfosTrigger(GameObject obj)
    {
        if (GetComponent<GameManager>().showSpellsInfo == true)
        {
            PlayerPrefs.SetInt("SpellsInfoSet", 1);
            PlayerPrefs.SetInt("SpellsInfo", 0);
            GetComponent<GameManager>().showSpellsInfo = false;
            obj.GetComponent<Image>().sprite = boxNotChecked;
        }
        else
        {
            PlayerPrefs.SetInt("SpellsInfoSet", 1);
            PlayerPrefs.SetInt("SpellsInfo", 1);
            GetComponent<GameManager>().showSpellsInfo = true;
            obj.GetComponent<Image>().sprite = boxChecked;
        }
    }

    public void OpenGreenlightURL()
    {
        Application.OpenURL("http://steamcommunity.com/sharedfiles/filedetails/?id=917993010");
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
        StartCoroutine(AnimationPanelMenu());
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
        StartCoroutine(AnimationPanelMenu());
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
        StartCoroutine(AnimationPanelMenu());
    }

    public void ReturnToPanelSave()
    {
        GetComponent<GameManager>().panelIntro.SetActive(false);
        GetComponent<GameManager>().panelCharacterSelection.SetActive(false);
        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().panelSave.SetActive(true);
        StartCoroutine(AnimationPanelSave());
    }

    public void ValidateElementalMage()
    {
        if (GetComponent<GameManager>().currSave == 1)
        {
            PlayerPrefs.SetInt("Load1MageSet", 1);
            PlayerPrefs.SetString("Load1Mage", "Elemental");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            PlayerPrefs.SetInt("Load2MageSet", 1);
            PlayerPrefs.SetString("Load2Mage", "Elemental");
        }
        else if (GetComponent<GameManager>().currSave == 3)
        {
            PlayerPrefs.SetInt("Load3MageSet", 1);
            PlayerPrefs.SetString("Load3Mage", "Elemental");
        }

        GetComponent<GameManager>().panelCharacterSelection.SetActive(false);
        GetComponent<GameManager>().panelDifficulty.SetActive(true);
        StartCoroutine(AnimationPanelDifficulty());
    }

    public void ReturnToPanelCharacterSelection()
    {
        GetComponent<GameManager>().panelSave.SetActive(false);
        GetComponent<GameManager>().panelDifficulty.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel2.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel3.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel1.SetActive(true);
        GetComponent<GameManager>().panelCharacterSelection.SetActive(true);
        StartCoroutine(AnimationPanelCharacterSelection());
    }

    public void DisplayCharacterElemental()
    {
        GetComponent<GameManager>().scrollCharacterPanel2.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel3.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel1.SetActive(true);
    }

    public void DisplayCharacterDemonic()
    {
        GetComponent<GameManager>().scrollCharacterPanel3.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel1.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel2.SetActive(true);
    }

    public void DisplayCharacterRadiant()
    {
        GetComponent<GameManager>().scrollCharacterPanel2.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel1.SetActive(false);
        GetComponent<GameManager>().scrollCharacterPanel3.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        GetComponent<GameManager>().panelDifficulty.SetActive(false);
        GetComponent<GameManager>().panelMissions.SetActive(false);
        GetComponent<GameManager>().panelTavern.SetActive(false);
        GetComponent<GameManager>().panelTower.SetActive(false);
        GetComponent<GameManager>().panelMenu.SetActive(true);
        StartCoroutine(AnimationPanelMenu());
    }

    public void DisplayMissionsPanel()
    {
        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().panelMissions.SetActive(true);
        FillMissionsMainSheet(0);

        //Sheet1
        if (GetComponent<GameManager>().listMissions[0].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
            GetComponent<GameManager>().MissionsPanelSheet1Type.sprite = GetComponent<GameManager>().littlebossSprite;
        else if (GetComponent<GameManager>().listMissions[0].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
            GetComponent<GameManager>().MissionsPanelSheet1Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
        else
            GetComponent<GameManager>().MissionsPanelSheet1Type.sprite = GetComponent<GameManager>().littledefenseSprite;

        if (GetComponent<GameManager>().listMissions[0].GetComponent<MissionSheet>().difficulty > 1)
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty2.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty2.SetActive(false);

        if (GetComponent<GameManager>().listMissions[0].GetComponent<MissionSheet>().difficulty > 2)
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty3.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty3.SetActive(false);

        if (GetComponent<GameManager>().listMissions[0].GetComponent<MissionSheet>().difficulty > 3)
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty3.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty4.SetActive(false);

        //Sheet2
        if (GetComponent<GameManager>().listMissions.Count > 1)
        {
            GetComponent<GameManager>().MissionsPanelSheet2.SetActive(true);

            if (GetComponent<GameManager>().listMissions[1].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet2Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[1].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet2Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet2Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[1].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[1].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[1].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet2Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet2.SetActive(false);

        //Sheet3
        if (GetComponent<GameManager>().listMissions.Count > 2)
        {
            GetComponent<GameManager>().MissionsPanelSheet3.SetActive(true);

            if (GetComponent<GameManager>().listMissions[2].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet3Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[2].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet3Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet3Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[2].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[2].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[2].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet3Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet3.SetActive(false);
    }

    public void FillMissionsMainSheet(int id)
    {
        GetComponent<GameManager>().currMissionSelected = id;
        if (GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
            GetComponent<GameManager>().MissionsPanelType.sprite = GetComponent<GameManager>().bossSprite;
        else if (GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
            GetComponent<GameManager>().MissionsPanelType.sprite = GetComponent<GameManager>().captureSprite;
        else
            GetComponent<GameManager>().MissionsPanelType.sprite = GetComponent<GameManager>().defenseSprite;

        if (GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().difficulty > 1)
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty2.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty2.SetActive(false);

        if (GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().difficulty > 2)
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty3.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty3.SetActive(false);

        if (GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().difficulty > 3)
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty3.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty4.SetActive(false);

        GetComponent<GameManager>().MissionsPanelDescriptionText.text = GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().description.Replace("<br>", "\n");
        GetComponent<GameManager>().MissionsPanelDescriptionBisText.text = "Experience : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().experience +
                                                                           "\nReward : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().reward + " gold coins" +
                                                                           "\nPrestige : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().prestige;
    }

    public void EnterInMission()
    {
        NewGame();
        Application.LoadLevel(GetComponent<GameManager>().listMissions[GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().idMission);
        GetComponent<GameManager>().cam = GameObject.Find("Main Camera");
    }

    public void DisplayTavernPanel()
    {
        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().panelTavern.SetActive(true);
    }

    public void DisplayTowerPanel()
    {
        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().panelTower.SetActive(true);
    }

    public void ReturnToIntro()
    {
        GetComponent<GameManager>().panelSave.SetActive(false);
        GetComponent<GameManager>().panelIntro.SetActive(true);
        StartCoroutine(AnimationPanelIntro());
    }

    public void SwitchWASD()
    {
        if (GetComponent<GameManager>().wasdMode == false)
        {
            PlayerPrefs.SetInt("WASDMode", 1);
            PlayerPrefs.SetInt("WASDModeSet", 1);
            GetComponent<GameManager>().wasdMode = true;
            GetComponent<GameManager>().wasdModeButton.GetComponent<Image>().sprite = boxChecked;
            GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "Q";
        }
        else
        {
            PlayerPrefs.SetInt("WASDMode", 0);
            PlayerPrefs.SetInt("WASDModeSet", 1);
            GetComponent<GameManager>().wasdMode = false;
            GetComponent<GameManager>().wasdModeButton.GetComponent<Image>().sprite = boxNotChecked;
            GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "A";
        }
    }

    public void StartTutorial()
    {
        GetComponent<GameManager>().currentSlideTutorial = 0;

        for (int i = 0; i < GetComponent<GameManager>().tutorialSlides.Length; i++)
        {
            GetComponent<GameManager>().tutorialSlides[i].SetActive(false);
        }

        GetComponent<GameManager>().tutorialSlides[0].SetActive(true);
        GetComponent<GameManager>().panelTutorial.SetActive(true);
    }

    public void EndTutorial()
    {
        GetComponent<GameManager>().panelTutorial.SetActive(false);
    }

    public void TutorialNext()
    {
        GetComponent<GameManager>().tutorialSlides[GetComponent<GameManager>().currentSlideTutorial++].SetActive(false);
        if (GetComponent<GameManager>().currentSlideTutorial < GetComponent<GameManager>().tutorialSlides.Length)
            GetComponent<GameManager>().tutorialSlides[GetComponent<GameManager>().currentSlideTutorial].SetActive(true);
        else
            EndTutorial();
    }

    IEnumerator AnimationPanelIntro()
    {
        GameObject text1 = GetComponent<GameManager>().scrollIntro1.GetComponentInChildren<Text>().gameObject;
        GameObject text2 = GetComponent<GameManager>().scrollIntro2.GetComponentInChildren<Text>().gameObject;
        GameObject text3 = GetComponent<GameManager>().scrollIntro3.GetComponentInChildren<Text>().gameObject;
        GameObject text4 = GetComponent<GameManager>().scrollIntro4.GetComponentInChildren<Text>().gameObject;

        GetComponent<GameManager>().scrollIntro1.GetComponent<AnimOnStart>().StartAnimationByScript();
        text1.SetActive(false);
        GetComponent<GameManager>().scrollIntro2.GetComponent<AnimOnStart>().StartAnimationByScript();
        text2.SetActive(false);
        GetComponent<GameManager>().scrollIntro3.GetComponent<AnimOnStart>().StartAnimationByScript();
        text3.SetActive(false);
        GetComponent<GameManager>().scrollIntro4.GetComponent<AnimOnStart>().StartAnimationByScript();
        text4.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
        text4.SetActive(true);
    }

    IEnumerator AnimationPanelSave()
    {
        GameObject text4 = GetComponent<GameManager>().scrollSave4.GetComponentInChildren<Text>().gameObject;

        DeactivateButtonsDeleteSave1();
        DeactivateButtonsDeleteSave2();
        DeactivateButtonsDeleteSave3();

        GetComponent<GameManager>().scrollSave1.GetComponent<AnimOnStart>().StartAnimationByScript();
        GetComponent<GameManager>().load1Name.SetActive(false);
        GetComponent<GameManager>().buttonDeleteSave1.SetActive(false);
        GetComponent<GameManager>().scrollSave2.GetComponent<AnimOnStart>().StartAnimationByScript();
        GetComponent<GameManager>().load2Name.SetActive(false);
        GetComponent<GameManager>().buttonDeleteSave2.SetActive(false);
        GetComponent<GameManager>().scrollSave3.GetComponent<AnimOnStart>().StartAnimationByScript();
        GetComponent<GameManager>().load3Name.SetActive(false);
        GetComponent<GameManager>().buttonDeleteSave3.SetActive(false);
        GetComponent<GameManager>().scrollSave4.GetComponent<AnimOnStart>().StartAnimationByScript();
        text4.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        GetComponent<GameManager>().load1Name.SetActive(true);
        if (GetComponent<GameManager>().load1Created == true)
            GetComponent<GameManager>().buttonDeleteSave1.SetActive(true);

        GetComponent<GameManager>().load2Name.SetActive(true);
        if (GetComponent<GameManager>().load2Created == true)
            GetComponent<GameManager>().buttonDeleteSave2.SetActive(true);

        GetComponent<GameManager>().load3Name.SetActive(true);
        if (GetComponent<GameManager>().load3Created == true)
            GetComponent<GameManager>().buttonDeleteSave3.SetActive(true);

        text4.SetActive(true);
    }

    IEnumerator AnimationPanelCharacterSelection()
    {
        GameObject text1 = GetComponent<GameManager>().scrollCharacterValidate.GetComponentInChildren<Text>().gameObject;
        GameObject text2 = GetComponent<GameManager>().scrollCharacterReturn.GetComponentInChildren<Text>().gameObject;

        GetComponent<GameManager>().scrollCharacterValidate.GetComponent<AnimOnStart>().StartAnimationByScript();
        GetComponent<GameManager>().scrollCharacterReturn.GetComponent<AnimOnStart>().StartAnimationByScript();
        text1.SetActive(false);
        text2.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        text1.SetActive(true);
        text2.SetActive(true);
    }

    IEnumerator AnimationPanelDifficulty()
    {
        GameObject text1 = GetComponent<GameManager>().scrollDifficulty1.GetComponentInChildren<Text>().gameObject;
        GameObject text2 = GetComponent<GameManager>().scrollDifficulty2.GetComponentInChildren<Text>().gameObject;
        GameObject text3 = GetComponent<GameManager>().scrollDifficulty3.GetComponentInChildren<Text>().gameObject;
        GameObject text4 = GetComponent<GameManager>().scrollDifficulty4.GetComponentInChildren<Text>().gameObject;

        GetComponent<GameManager>().scrollDifficulty1.GetComponent<AnimOnStart>().StartAnimationByScript();
        text1.SetActive(false);
        GetComponent<GameManager>().scrollDifficulty2.GetComponent<AnimOnStart>().StartAnimationByScript();
        text2.SetActive(false);
        GetComponent<GameManager>().scrollDifficulty3.GetComponent<AnimOnStart>().StartAnimationByScript();
        text3.SetActive(false);
        GetComponent<GameManager>().scrollDifficulty4.GetComponent<AnimOnStart>().StartAnimationByScript();
        text4.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
        text4.SetActive(true);
    }

    public IEnumerator AnimationPanelMenu()
    {
        GameObject text1 = GetComponent<GameManager>().scrollMenu1.GetComponentInChildren<Text>().gameObject;
        GameObject text2 = GetComponent<GameManager>().scrollMenu2.GetComponentInChildren<Text>().gameObject;
        GameObject text3 = GetComponent<GameManager>().scrollMenu3.GetComponentInChildren<Text>().gameObject;
        GameObject text4 = GetComponent<GameManager>().scrollMenu4.GetComponentInChildren<Text>().gameObject;

        GetComponent<GameManager>().scrollMenu1.GetComponent<AnimOnStart>().StartAnimationByScript();
        text1.SetActive(false);
        GetComponent<GameManager>().scrollMenu2.GetComponent<AnimOnStart>().StartAnimationByScript();
        text2.SetActive(false);
        GetComponent<GameManager>().scrollMenu3.GetComponent<AnimOnStart>().StartAnimationByScript();
        text3.SetActive(false);
        GetComponent<GameManager>().scrollMenu4.GetComponent<AnimOnStart>().StartAnimationByScript();
        text4.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
        text4.SetActive(true);
    }

    public void AnimationPanelHUDMenu()
    {
        GetComponent<GameManager>().scrollHUDMenu1.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().buttonHUDMenu1.SetActive(false);
        GetComponent<GameManager>().scrollHUDMenu2.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().buttonHUDMenu2.SetActive(false);
        GetComponent<GameManager>().scrollHUDMenu3.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().buttonHUDMenu3.SetActive(false);
        GetComponent<GameManager>().scrollHUDMenu4.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().buttonHUDMenu4.SetActive(false);
    }

    public void EndAnimationPanelHUDMenu()
    {
        GetComponent<GameManager>().buttonHUDMenu1.SetActive(true);
        GetComponent<GameManager>().buttonHUDMenu2.SetActive(true);
        GetComponent<GameManager>().buttonHUDMenu3.SetActive(true);
        GetComponent<GameManager>().buttonHUDMenu4.SetActive(true);
    }

    public void AnimationPanelOptions()
    {
        GetComponent<GameManager>().scrollOptions1.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().smartCastIcon.SetActive(false);
        GetComponent<GameManager>().smartCastText.SetActive(false);
        GetComponent<GameManager>().scrollOptions2.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().bloodlessIcon.SetActive(false);
        GetComponent<GameManager>().bloodlessText.SetActive(false);
        GetComponent<GameManager>().scrollOptions3.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().showSpellsInfoIcon.SetActive(false);
        GetComponent<GameManager>().showSpellsInfoText.SetActive(false);
        GetComponent<GameManager>().scrollOptions4.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().volumeMusicPlus.SetActive(false);
        GetComponent<GameManager>().volumeMusicMinus.SetActive(false);
        GetComponent<GameManager>().volumeMusicText.SetActive(false);
        GetComponent<GameManager>().scrollOptions5.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().volumeSFXPlus.SetActive(false);
        GetComponent<GameManager>().volumeSFXMinus.SetActive(false);
        GetComponent<GameManager>().volumeSFXText.SetActive(false);
        GetComponent<GameManager>().scrollOptions6.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().wasdModeButton.SetActive(false);
        GetComponent<GameManager>().wasdModeText.SetActive(false);
    }

    public void EndAnimationPanelOptions()
    {
        GetComponent<GameManager>().smartCastIcon.SetActive(true);
        GetComponent<GameManager>().smartCastText.SetActive(true);
        GetComponent<GameManager>().bloodlessIcon.SetActive(true);
        GetComponent<GameManager>().bloodlessText.SetActive(true);
        GetComponent<GameManager>().showSpellsInfoIcon.SetActive(true);
        GetComponent<GameManager>().showSpellsInfoText.SetActive(true);
        GetComponent<GameManager>().volumeMusicPlus.SetActive(true);
        GetComponent<GameManager>().volumeMusicMinus.SetActive(true);
        GetComponent<GameManager>().volumeMusicText.SetActive(true);
        GetComponent<GameManager>().volumeSFXPlus.SetActive(true);
        GetComponent<GameManager>().volumeSFXMinus.SetActive(true);
        GetComponent<GameManager>().volumeSFXText.SetActive(true);
        GetComponent<GameManager>().wasdModeButton.SetActive(true);
        GetComponent<GameManager>().wasdModeText.SetActive(true);
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
                StartCoroutine(AnimationPanelMenu());
            }
            else
            {
                if (PlayerPrefs.GetInt("Load1MageSet") == 0)
                    ReturnToPanelCharacterSelection();
                else
                    ValidateElementalMage();
            }
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
            PlayerPrefs.SetInt("Load1Agent1StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load1Agent2StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load1Agent3StockHealthPotion", 3);
            GetComponent<GameManager>().load1DeleteIcon.SetActive(true);
            ReturnToPanelCharacterSelection();
        }
    }

    public void ActivateButtonsDeleteSave1()
    {
        GetComponent<GameManager>().load1Confirm.SetActive(true);
        GetComponent<GameManager>().load1Cancel.SetActive(true);
    }

    public void DeactivateButtonsDeleteSave1()
    {
        GetComponent<GameManager>().load1Confirm.SetActive(false);
        GetComponent<GameManager>().load1Cancel.SetActive(false);
    }

    public void DeleteSave1()
    {
        DeactivateButtonsDeleteSave1();
        GetComponent<GameManager>().load1DeleteIcon.SetActive(false);
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
        PlayerPrefs.SetInt("Load1Agent1StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load1Agent2StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load1Agent3StockHealthPotion", 3);

        PlayerPrefs.SetInt("Load1DifficultySet", 0);
        PlayerPrefs.SetInt("Load1MageSet", 0);
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
                StartCoroutine(AnimationPanelMenu());
            }
            else
            {
                if (PlayerPrefs.GetInt("Load2MageSet") == 0)
                    ReturnToPanelCharacterSelection();
                else
                    ValidateElementalMage();
            }
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
            PlayerPrefs.SetInt("Load2Agent1StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load2Agent2StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load2Agent3StockHealthPotion", 3);
            GetComponent<GameManager>().load2DeleteIcon.SetActive(true);
            ReturnToPanelCharacterSelection();
        }
    }

    public void ActivateButtonsDeleteSave2()
    {
        GetComponent<GameManager>().load2Confirm.SetActive(true);
        GetComponent<GameManager>().load2Cancel.SetActive(true);
    }

    public void DeactivateButtonsDeleteSave2()
    {
        GetComponent<GameManager>().load2Confirm.SetActive(false);
        GetComponent<GameManager>().load2Cancel.SetActive(false);
    }

    public void DeleteSave2()
    {
        DeactivateButtonsDeleteSave2();
        GetComponent<GameManager>().load2DeleteIcon.SetActive(false);
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
        PlayerPrefs.SetInt("Load2Agent1StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load2Agent2StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load2Agent3StockHealthPotion", 3);

        PlayerPrefs.SetInt("Load2DifficultySet", 0);
        PlayerPrefs.SetInt("Load2MageSet", 0);
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
                StartCoroutine(AnimationPanelMenu());
            }
            else
            {
                if (PlayerPrefs.GetInt("Load3MageSet") == 0)
                    ReturnToPanelCharacterSelection();
                else
                    ValidateElementalMage();
            }
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
            PlayerPrefs.SetInt("Load3Agent1StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load3Agent2StockHealthPotion", 3);
            PlayerPrefs.SetInt("Load3Agent3StockHealthPotion", 3);
            GetComponent<GameManager>().load3DeleteIcon.SetActive(true);
            ReturnToPanelCharacterSelection();
        }
    }

    public void ActivateButtonsDeleteSave3()
    {
        GetComponent<GameManager>().load3Confirm.SetActive(true);
        GetComponent<GameManager>().load3Cancel.SetActive(true);
    }

    public void DeactivateButtonsDeleteSave3()
    {
        GetComponent<GameManager>().load3Confirm.SetActive(false);
        GetComponent<GameManager>().load3Cancel.SetActive(false);
    }

    public void DeleteSave3()
    {
        DeactivateButtonsDeleteSave3();
        GetComponent<GameManager>().load3DeleteIcon.SetActive(false);
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
        PlayerPrefs.SetInt("Load3Agent1StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load3Agent2StockHealthPotion", 3);
        PlayerPrefs.SetInt("Load3Agent3StockHealthPotion", 3);

        PlayerPrefs.SetInt("Load3DifficultySet", 0);
        PlayerPrefs.SetInt("Load3MageSet", 0);
        GetComponent<GameManager>().load3Created = false;
        GetComponent<GameManager>().load3Name.GetComponent<Text>().text = "Empty save";
    }
}
