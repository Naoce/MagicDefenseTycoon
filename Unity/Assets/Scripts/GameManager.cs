using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  bool            load1Created;
    public  GameObject      inputFieldLoad1Name;
    public  GameObject      load1Name;

    public  bool            load2Created;
    public  GameObject      inputFieldLoad2Name;
    public  GameObject      load2Name;

    public  bool            load3Created;
    public  GameObject      inputFieldLoad3Name;
    public  GameObject      load3Name;

    public  GameObject      bulleInfoCreateSave;
    public  int             currSave;

    public  GameObject      cam;
    public  GameObject      jingleDefaite;
    public  GameObject      jingleVictoire;
    public  GameObject      mapManager;
    public  GameObject      textNbEnemy;
    public  int[]           playerMaxHP = new int[15];
    public  int[]           playerMaxXP = new int[15];
    public  int[]           agentType0MaxHP = new int[10];
    public  int[]           agentMaxXP = new int[10];
    public  GameObject[]    tabAgents = new GameObject[4];
    public  int             playerDamage;
    public  Texture2D       cursorNormal;
    public  CursorMode      cursorMode;

    public  bool            isInGame;
    public  bool            gamePaused;
    public  bool            gameOver;
    public  bool            smartcast;
    public  float           volumeMusic;
    public  bool            audioOn;
    public  bool            isInMenu;
    public  bool            isInOptions;
    public  bool            bloodless;
    public  bool            showSpellsInfo;

    public  GameObject      bossPanel;
    public  Slider          bossHealth;
    public  GameObject      capturePanel;
    public  Slider          captureHealth;
    public  GameObject      defensePanel;
    public  Slider          defenseHealth;
    public  Slider          healthBarGreen;
    public  Slider          xpBar;
    public  GameObject      textHP;
    public  GameObject      textXP;
    public  GameObject      textLevel;
    public  GameObject      fioleRed;
    public  GameObject      fioleOrange;
    public  GameObject      fioleYellow;
    public  GameObject      fioleGreen;
    public  GameObject      levelUpPlayer;
    public  GameObject      usingSpell1Icon;
    public  GameObject      usingSpell2Icon;
    public  GameObject      usingSpell3Icon;
    public  GameObject      usingSpell4Icon;
    public  GameObject      usingSpell5Icon;
    public  GameObject      usingSpell6Icon;
    public  GameObject      usingSpell7Icon;
    public  GameObject      usingSpell8Icon;
    public  GameObject      hudInGame;
    public  GameObject      hudCounterText;
    public  GameObject      hudVictory;
    public  GameObject      hudDefeat;
    public  GameObject      hudStar1;
    public  GameObject      hudStar2;
    public  GameObject      hudStar3;
    public  GameObject      hudButtonTryAgain;
    public  GameObject      hudButtonReturnToMenu;
    public  GameObject      panelSave;
    public  GameObject      panelMenu;
    public  GameObject      hudPanelMenu;
    public  GameObject      hudPanelOptions;
    public  GameObject      textStockHealthPotion;
    public  GameObject      textStockManaPotion;

    public  GameObject      agent1Panel;
    public  GameObject[]    agent1Levels = new GameObject[10];
    public  GameObject      levelUpAgent1;
    public  Slider          agent1healthBarGreenHUD;
    public  Slider          agent1xpBarHUD;

    public  GameObject      agent2Panel;
    public  GameObject[]    agent2Levels = new GameObject[10];
    public  GameObject      levelUpAgent2;
    public  Slider          agent2healthBarGreenHUD;
    public  Slider          agent2xpBarHUD;

    public GameObject       agent3Panel;
    public GameObject[]     agent3Levels = new GameObject[10];
    public GameObject       levelUpAgent3;
    public Slider           agent3healthBarGreenHUD;
    public Slider           agent3xpBarHUD;

    public GameObject       agent4Panel;
    public GameObject[]     agent4Levels = new GameObject[10];
    public GameObject       levelUpAgent4;
    public Slider           agent4healthBarGreenHUD;
    public Slider           agent4xpBarHUD;

    public  GameObject      bulleInfoSpell1;
    public  GameObject      bulleInfoSpell2;
    public  GameObject      bulleInfoSpell3;
    public  GameObject      bulleInfoSpell4;
    public  GameObject      bulleInfoSpell5;
    public  GameObject      bulleInfoSpell6;
    public  GameObject      bulleInfoSpell7;
    public  GameObject      bulleInfoSpell8;
    public  GameObject      bulleInfoObject1;
    public  GameObject      bulleInfoObject2;
    public  GameObject      cdSpell1;
    public  GameObject      cdSpell2;
    public  GameObject      cdSpell3;
    public  GameObject      cdSpell4;
    public  GameObject      cdSpell5;
    public  GameObject      cdSpell6;
    public  GameObject      cdSpell7;
    public  GameObject      cdSpell8;
    public  GameObject      cdObject1;
    public  GameObject      cdObject2;

    void Awake ()
    {
        cam = GameObject.Find("Main Camera");
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
        if (PlayerPrefs.GetInt("Load1Created") == 1)
        {
            load1Created = true;
            load1Name.GetComponent<Text>().text = PlayerPrefs.GetString("Load1Name");
        }
        if (PlayerPrefs.GetInt("Load2Created") == 1)
        {
            load2Created = true;
            load2Name.GetComponent<Text>().text = PlayerPrefs.GetString("Load2Name");
        }
        if (PlayerPrefs.GetInt("Load3Created") == 1)
        {
            load3Created = true;
            load3Name.GetComponent<Text>().text = PlayerPrefs.GetString("Load3Name");
        }
    }

    public void SetNormalMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorNormal, pos, cursorMode);
    }

    public void SetActiveBulleInfoSpell1()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell1.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell1()
    {
        bulleInfoSpell1.SetActive(false);
    }

    public void SetActiveBulleInfoSpell2()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell2.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell2()
    {
        bulleInfoSpell2.SetActive(false);
    }

    public void SetActiveBulleInfoSpell3()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell3.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell3()
    {
        bulleInfoSpell3.SetActive(false);
    }

    public void SetActiveBulleInfoSpell4()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell4.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell4()
    {
        bulleInfoSpell4.SetActive(false);
    }

    public void SetActiveBulleInfoSpell5()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell5.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell5()
    {
        bulleInfoSpell5.SetActive(false);
    }

    public void SetActiveBulleInfoSpell6()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell6.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell6()
    {
        bulleInfoSpell6.SetActive(false);
    }

    public void SetActiveBulleInfoSpell7()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell7.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell7()
    {
        bulleInfoSpell7.SetActive(false);
    }

    public void SetActiveBulleInfoSpell8()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell8.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell8()
    {
        if (showSpellsInfo == true)
            bulleInfoSpell8.SetActive(false);
    }

    public void SetActiveBulleInfoObject1()
    {
        if (showSpellsInfo == true)
            bulleInfoObject1.SetActive(true);
    }

    public void SetInactiveBulleInfoObject1()
    {
        bulleInfoObject1.SetActive(false);
    }

    public void SetActiveBulleInfoObject2()
    {
        if (showSpellsInfo == true)
            bulleInfoObject2.SetActive(true);
    }

    public void SetInactiveBulleInfoObject2()
    {
        bulleInfoObject2.SetActive(false);
    }

    public void DesactiveAllBulles()
    {
        bulleInfoSpell1.SetActive(false);
        bulleInfoSpell2.SetActive(false);
        bulleInfoSpell3.SetActive(false);
        bulleInfoSpell4.SetActive(false);
        bulleInfoSpell5.SetActive(false);
        bulleInfoSpell6.SetActive(false);
        bulleInfoSpell7.SetActive(false);
        bulleInfoSpell8.SetActive(false);
        bulleInfoObject1.SetActive(false);
        bulleInfoObject2.SetActive(false);
    }
    
    public void BossTakeDamage(int currHP, int maxHP)
    {
        bossHealth.value = (float)currHP / (float)maxHP;
    }

    public void CaptureTakeDamage(int currHP, int maxHP)
    {
        captureHealth.value = (float)currHP / (float)maxHP;
    }

    public void DefenseTakeDamage(int currHP, int maxHP)
    {
        defenseHealth.value = (float)currHP / (float)maxHP;
    }

    public void StartVictory()
    {
        gamePaused = true;
        gameOver = true;
        GameObject obj = (GameObject)Instantiate(jingleVictoire, transform.position, transform.rotation);
        obj.GetComponent<AudioSource>().volume = volumeMusic / 100;
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
        hudInGame.SetActive(false);
        StartCoroutine(VictoryAnimation());
    }

    public void StartDefeat()
    {
        gamePaused = true;
        gameOver = true;
        GameObject obj = (GameObject)Instantiate(jingleDefaite, transform.position, transform.rotation);
        obj.GetComponent<AudioSource>().volume = volumeMusic / 100;
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
        hudInGame.SetActive(false);
        StartCoroutine(DefeatAnimation());
    }

    IEnumerator VictoryAnimation()
    {
        hudVictory.SetActive(true);
        hudVictory.GetComponent<AnimOnStart>().StartAnimationByScript();
        yield return new WaitForSeconds(0.4f);

        hudStar1.SetActive(true);
        hudStar1.GetComponent<AnimOnStart>().StartAnimationByScript();
        yield return new WaitForSeconds(0.4f);

        hudStar2.SetActive(true);
        hudStar2.GetComponent<AnimOnStart>().StartAnimationByScript();
        yield return new WaitForSeconds(0.4f);

        hudStar3.SetActive(true);
        hudStar3.GetComponent<AnimOnStart>().StartAnimationByScript();
        yield return new WaitForSeconds(0.4f);

        hudButtonReturnToMenu.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

    IEnumerator DefeatAnimation()
    {
        hudDefeat.SetActive(true);
        hudDefeat.GetComponent<AnimOnStart>().StartAnimationByScript();
        yield return new WaitForSeconds(0.4f);

        hudButtonTryAgain.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudButtonReturnToMenu.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

    public void ActivateBlood()
    {
        bloodless = false;
        if (isInGame == true)
            mapManager.GetComponent<MapManager>().ActivateBlood();
    }

    public void DesactivateBlood()
    {
        bloodless = true;
        if (isInGame == true)
            mapManager.GetComponent<MapManager>().DesactivateBlood();
    }
}
