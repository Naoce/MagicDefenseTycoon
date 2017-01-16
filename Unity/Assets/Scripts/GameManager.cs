using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  GameObject      cam;
    public  GameObject      jingleDefaite;
    public  GameObject      jingleVictoire;
    public  GameObject      mapManager;
    public  GameObject      textNbEnemy;
    public  int[]           playerMaxHP = new int[15];
    public  int[]           playerMaxXP = new int[15];
    public  int[]           agentMaxHP = new int[10];
    public  int[]           agentMaxXP = new int[10];
    public  int             playerXP;
    public  int             playerLevel;
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
    public  GameObject      panelMenu;
    public  GameObject      hudPanelMenu;
    public  GameObject      hudPanelOptions;
    public  GameObject      levelUpAgent1;
    public  Slider          agenthealthBarGreenHUD;
    public  Slider          agentxpBarHUD;
    public  GameObject      agentLevel1;
    public  GameObject      agentLevel2;
    public  GameObject      agentLevel3;
    public  GameObject      agentLevel4;
    public  GameObject      agentLevel5;
    public  GameObject      agentLevel6;
    public  GameObject      agentLevel7;
    public  GameObject      agentLevel8;
    public  GameObject      agentLevel9;
    public  GameObject      agentLevel10;
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
    }

    public void SetNormalMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorNormal, pos, cursorMode);
    }

    public void SetActiveBulleInfoSpell1()
    {
        bulleInfoSpell1.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell1()
    {
        bulleInfoSpell1.SetActive(false);
    }

    public void SetActiveBulleInfoSpell2()
    {
        bulleInfoSpell2.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell2()
    {
        bulleInfoSpell2.SetActive(false);
    }

    public void SetActiveBulleInfoSpell3()
    {
        bulleInfoSpell3.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell3()
    {
        bulleInfoSpell3.SetActive(false);
    }

    public void SetActiveBulleInfoSpell4()
    {
        bulleInfoSpell4.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell4()
    {
        bulleInfoSpell4.SetActive(false);
    }

    public void SetActiveBulleInfoSpell5()
    {
        bulleInfoSpell5.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell5()
    {
        bulleInfoSpell5.SetActive(false);
    }

    public void SetActiveBulleInfoSpell6()
    {
        bulleInfoSpell6.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell6()
    {
        bulleInfoSpell6.SetActive(false);
    }

    public void SetActiveBulleInfoSpell7()
    {
        bulleInfoSpell7.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell7()
    {
        bulleInfoSpell7.SetActive(false);
    }

    public void SetActiveBulleInfoSpell8()
    {
        bulleInfoSpell8.SetActive(true);
    }

    public void SetInactiveBulleInfoSpell8()
    {
        bulleInfoSpell8.SetActive(false);
    }

    public void SetActiveBulleInfoObject1()
    {
        bulleInfoObject1.SetActive(true);
    }

    public void SetInactiveBulleInfoObject1()
    {
        bulleInfoObject1.SetActive(false);
    }

    public void SetActiveBulleInfoObject2()
    {
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
        yield return new WaitForSeconds(0.4f);

        hudStar1.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudStar2.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudStar3.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        //hudButtonTryAgain.SetActive(true);
        //yield return new WaitForSeconds(0.4f);

        hudButtonReturnToMenu.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

    IEnumerator DefeatAnimation()
    {
        hudDefeat.SetActive(true);
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
