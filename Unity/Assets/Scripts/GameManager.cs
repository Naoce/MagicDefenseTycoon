using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  bool            load1Created;
    public  GameObject      inputFieldLoad1Name;
    public  GameObject      load1Name;
    public  GameObject      load1DeleteIcon;
    public  GameObject      load1Confirm;
    public  GameObject      load1Cancel;

    public  bool            load2Created;
    public  GameObject      inputFieldLoad2Name;
    public  GameObject      load2Name;
    public  GameObject      load2DeleteIcon;
    public  GameObject      load2Confirm;
    public  GameObject      load2Cancel;

    public  bool            load3Created;
    public  GameObject      inputFieldLoad3Name;
    public  GameObject      load3Name;
    public  GameObject      load3DeleteIcon;
    public  GameObject      load3Confirm;
    public  GameObject      load3Cancel;

    public  GameObject      bulleInfoCreateSave;
    public  int             currSave;
    public  int             difficulty;

    public  GameObject      cam;
    public  GameObject      jingleDefaite;
    public  GameObject      jingleVictoire;
    public  GameObject      jingleIntroCombat;

    public  GameObject      musicCombatObj;
    public  GameObject      musicCombat;
    public  GameObject      musicMenu;

    public  GameObject      mapManager;

    public  GameObject      textNbEnemy;
    public  int[]           playerMaxHP = new int[15];
    public  int[]           playerMaxXP = new int[15];
    public  int[]           agentTypeKnightMaxHP = new int[10];
    public  int[]           agentTypeRogueMaxHP = new int[10];
    public  int[]           agentTypeSwordsmanMaxHP = new int[10];
    public  int[]           agentTypeKnightDamage = new int[10];
    public  int[]           agentTypeRogueDamage = new int[10];
    public  int[]           agentTypeSwordsmanDamage = new int[10];
    public  float[]         agentTypeKnightAS = new float[10];
    public  float[]         agentTypeRogueAS = new float[10];
    public  float[]         agentTypeSwordsmanAS = new float[10];
    public  int[]           agentMaxXP = new int[10];
    public  GameObject[]    tabAgents;

    public  List<GameObject> rosterAgents;
    public  List<GameObject> tabFreeAgents;
    public  int             currAgentSelected;

    public  int             playerDamage;
    public  Texture2D       cursorNormal;
    public  CursorMode      cursorMode;

    public  List<GameObject> listMissions;
    public  int             currMissionSelected;
    public  Sprite          bossSprite;
    public  Sprite          captureSprite;
    public  Sprite          defenseSprite;
    public  Sprite          littlebossSprite;
    public  Sprite          littlecaptureSprite;
    public  Sprite          littledefenseSprite;

    public  Text            MissionsPanelDescriptionText;
    public  Text            MissionsPanelDescriptionBisText;
    public  Image           MissionsPanelType;
    public  GameObject      MissionsPanelMainSheetDifficulty2;
    public  GameObject      MissionsPanelMainSheetDifficulty3;
    public  GameObject      MissionsPanelMainSheetDifficulty4;

    public  Image           MissionsPanelSheet1Type;
    public  GameObject      MissionsPanelSheet1Difficulty2;
    public  GameObject      MissionsPanelSheet1Difficulty3;
    public  GameObject      MissionsPanelSheet1Difficulty4;
    public  GameObject      MissionsPanelSheet2;
    public  Image           MissionsPanelSheet2Type;
    public  GameObject      MissionsPanelSheet2Difficulty2;
    public  GameObject      MissionsPanelSheet2Difficulty3;
    public  GameObject      MissionsPanelSheet2Difficulty4;
    public  GameObject      MissionsPanelSheet3;
    public  Image           MissionsPanelSheet3Type;
    public  GameObject      MissionsPanelSheet3Difficulty2;
    public  GameObject      MissionsPanelSheet3Difficulty3;
    public  GameObject      MissionsPanelSheet3Difficulty4;

    public  Sprite          tabOffSprite;
    public  Sprite          tabOnSprite;

    public  Sprite          swordsmanIcon;
    public  Sprite          knightIcon;
    public  Sprite          assassinIcon;

    public  GameObject[]    TavernAgentObj = new GameObject[4];
    public  GameObject      TavernAgent1;
    public  GameObject      TavernAgent2;
    public  GameObject      TavernAgent3;
    public  GameObject      TavernAgent4;
    public  GameObject      TavernTabAgent1;
    public  GameObject      TavernTabAgent2;
    public  GameObject      TavernTabAgent3;
    public  GameObject      TavernTabAgent4;
    public  bool            TavernAgent1Recruited;
    public  bool            TavernAgent2Recruited;
    public  bool            TavernAgent3Recruited;
    public  bool            TavernAgent4Recruited;
    public  Text            TavernRosterSizeText;
    public  Text            TavernPrestigeText;
    public  GameObject      TavernDescription;
    public  GameObject      TavernRecruitButton;

    public  GameObject      PanelRoster;
    public  GameObject      RosterTextDescription;
    public  Text            RosterTextNumberCount;
    public  GameObject      RosterButtonRecruit;
    public  GameObject      RosterButtonDismiss;
    public  GameObject      RosterAgent1;
    public  GameObject      RosterAgent2;
    public  GameObject      RosterAgent3;
    public  GameObject      RosterAgent4;
    public  GameObject      RosterAgent5;
    public  GameObject      RosterAgent6;
    public  GameObject      RosterTabAgent1;
    public  GameObject      RosterTabAgent2;
    public  GameObject      RosterTabAgent3;
    public  GameObject      RosterTabAgent4;
    public  GameObject      RosterTabAgent5;
    public  GameObject      RosterTabAgent6;
    public  GameObject      RosterSelected1;
    public  GameObject      RosterSelected2;
    public  GameObject      RosterSelected3;
    public  GameObject      RosterSelected4;
    public  GameObject      RosterSelected5;
    public  GameObject      RosterSelected6;

    public  GameObject      PanelSkillTree;
    public  int             SkillTreeSpellSelected;
    public  Text            SkillTreeLevelText;
    public  Text            SkillTreeActionPoints;
    public  Text            SkillTreeTitle;
    public  Text            SkillTreeDescription;
    public  GameObject      SkillTreeLearn;
    public  Image           SkillTreeSpellRect1_1;
    public  Image           SkillTreeSpellRect1_2;
    public  Image           SkillTreeSpellRect1_3;
    public  Image           SkillTreeSpellRect2_1;
    public  Image           SkillTreeSpellRect2_2;
    public  Image           SkillTreeSpellRect2_3;
    public  Image           SkillTreeSpellRect3_1;
    public  Image           SkillTreeSpellRect3_2;
    public  Image           SkillTreeSpellRect3_3;
    public  Image           SkillTreeSpellRect4_1;
    public  Image           SkillTreeSpellRect4_2;
    public  Image           SkillTreeSpellRect4_3;
    public  Image           SkillTreeSpellRect5_1;
    public  Image           SkillTreeSpellRect5_2;
    public  Image           SkillTreeSpellRect5_3;
    public  Image           SkillTreeSpellRect6_1;
    public  Image           SkillTreeSpellRect6_2;
    public  Image           SkillTreeSpellRect6_3;
    public  Image           SkillTreeSpellRect7_1;
    public  Image           SkillTreeSpellRect7_2;
    public  Image           SkillTreeSpellRect7_3;
    public  Image           SkillTreeSpellRect8_1;
    public  Image           SkillTreeSpellRect8_2;
    public  Image           SkillTreeSpellRect8_3;
    public  Image           SkillTreePassiveRect1_1;
    public  Image           SkillTreePassiveRect1_2;
    public  Image           SkillTreePassiveRect1_3;
    public  Image           SkillTreePassiveRect2_1;
    public  Image           SkillTreePassiveRect2_2;
    public  Image           SkillTreePassiveRect2_3;
    public  Image           SkillTreePassiveRect3_1;
    public  Image           SkillTreePassiveRect3_2;
    public  Image           SkillTreePassiveRect3_3;
    public  Image           SkillTreePassiveRect4_1;
    public  Image           SkillTreePassiveRect4_2;
    public  Image           SkillTreePassiveRect4_3;
    public  Image           SkillTreePassiveRect5_1;
    public  Image           SkillTreePassiveRect5_2;
    public  Image           SkillTreePassiveRect5_3;
    public  Image           SkillTreePassiveRect6_1;
    public  Image           SkillTreePassiveRect6_2;
    public  Image           SkillTreePassiveRect6_3;

    public  GameObject      PanelDecoration;
    public  Text            DecorationDescriptionText;
    public  Text            DecorationPrestigeText;
    public  Text            DecorationCoinsText;
    public  GameObject      DecorationScrollBuy;
    public  int             DecorationScrollSelected;

    public  GameObject      DecorationScrollChimney;
    public  int             DecorationCurrentChimneySelected;
    public  GameObject      DecorationNextChimney;
    public  GameObject      DecorationPrevChimney;
    public  Text            DecorationTextChimney;

    public  GameObject      DecorationScrollGod;
    public  int             DecorationCurrentGodSelected;
    public  GameObject      DecorationNextGod;
    public  GameObject      DecorationPrevGod;
    public  Text            DecorationTextGod;

    public  GameObject      DecorationScrollBanner;
    public  int             DecorationCurrentBannerSelected;
    public  GameObject      DecorationNextBanner;
    public  GameObject      DecorationPrevBanner;
    public  Text            DecorationTextBanner;

    public  GameObject      DecorationScrollWeapons;
    public  int             DecorationCurrentWeaponsSelected;
    public  GameObject      DecorationNextWeapons;
    public  GameObject      DecorationPrevWeapons;
    public  Text            DecorationTextWeapons;

    public  GameObject      DecorationScrollCarpet;
    public  int             DecorationCurrentCarpetSelected;
    public  GameObject      DecorationNextCarpet;
    public  GameObject      DecorationPrevCarpet;
    public  Text            DecorationTextCarpet;

    public  GameObject      PanelRedQG;
    public  GameObject      DecorationRedBannerWeapons;
    public  GameObject      DecorationRedBannerCrowns;
    public  GameObject      DecorationRedShields;
    public  GameObject      DecorationRedWeapons;
    public  GameObject      DecorationRedGodOfWar;
    public  GameObject      DecorationRedGodOfTime;
    public  GameObject      DecorationRedGodOfLife;
    public  GameObject      DecorationRedBear;
    public  GameObject      DecorationRedCarpet;
    
    public  GameObject      PanelBlueQG;
    public  GameObject      DecorationBlueBannerWeapons;
    public  GameObject      DecorationBlueBannerCrowns;
    public  GameObject      DecorationBlueShields;
    public  GameObject      DecorationBlueWeapons;
    public  GameObject      DecorationBlueGodOfWar;
    public  GameObject      DecorationBlueGodOfTime;
    public  GameObject      DecorationBlueGodOfLife;
    public  GameObject      DecorationBlueBear;
    public  GameObject      DecorationBlueCarpet;

    public  GameObject      PanelYellowQG;
    public  GameObject      DecorationYellowBannerWeapons;
    public  GameObject      DecorationYellowBannerCrowns;
    public  GameObject      DecorationYellowShields;
    public  GameObject      DecorationYellowWeapons;
    public  GameObject      DecorationYellowGodOfWar;
    public  GameObject      DecorationYellowGodOfTime;
    public  GameObject      DecorationYellowGodOfLife;
    public  GameObject      DecorationYellowBear;
    public  GameObject      DecorationYellowCarpet;

    public  bool            isInGame;
    public  bool            gamePaused;
    public  bool            gameOver;
    public  bool            smartcast;
    public  float           volumeMusic;
    public  float           volumeSFX;
    public  bool            audioOn;
    public  bool            isInMenu;
    public  bool            isInOptions;
    public  bool            isInOptionsFromIntro;
    public  bool            bloodless;
    public  bool            showSpellsInfo;
    public  bool            englishLanguage;
    public  bool            windowed;
    public  int             coins;
    public  int             prestige;

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

    public  GameObject      panelIntro;
    public  GameObject      textCredits;
    public  GameObject      scrollIntro1;
    public  GameObject      scrollIntro2;
    public  GameObject      scrollIntro3;
    public  GameObject      scrollIntro4;

    public  GameObject      panelSave;
    public  GameObject      scrollSave1;
    public  GameObject      buttonDeleteSave1;
    public  GameObject      scrollSave2;
    public  GameObject      buttonDeleteSave2;
    public  GameObject      scrollSave3;
    public  GameObject      buttonDeleteSave3;
    public  GameObject      scrollSave4;

    public  GameObject      panelCharacterSelection;
    public  GameObject      scrollCharacterPanel1;
    public  GameObject      scrollCharacterPanel2;
    public  GameObject      scrollCharacterPanel3;
    public  GameObject      scrollRunePanel1;
    public  GameObject      scrollRunePanel2;
    public  GameObject      scrollRunePanel3;
    public  int             runeSelected;
    public  Sprite          runeDamageSprite;
    public  Sprite          runeCeleritySprite;
    public  Sprite          runeHealSprite;
    public  Image           HUDRuneImage;
    public  GameObject      scrollCharacterValidate;
    public  GameObject      scrollCharacterReturn;

    public  GameObject      panelDifficulty;
    public  GameObject      textDifficulty;
    public  GameObject      scrollDifficulty1;
    public  GameObject      scrollDifficulty2;
    public  GameObject      scrollDifficulty3;
    public  GameObject      scrollDifficulty4;

    public  GameObject      panelMenu;
    public  GameObject      scrollMenu1;
    public  GameObject      scrollMenu2;
    public  GameObject      scrollMenu3;
    public  GameObject      scrollMenu4;

    public  GameObject      panelMissions;
    public  GameObject      panelTavern;
    public  GameObject      panelTower;

    public  GameObject      panelTutorial;
    public  int             currentSlideTutorial;
    public  GameObject[]    tutorialSlides;

    public  GameObject      hudPanelMenu;
    public  GameObject      scrollHUDMenu1;
    public  GameObject      buttonHUDMenu1;
    public  GameObject      scrollHUDMenu2;
    public  GameObject      buttonHUDMenu2;
    public  GameObject      scrollHUDMenu3;
    public  GameObject      buttonHUDMenu3;
    public  GameObject      scrollHUDMenu4;
    public  GameObject      buttonHUDMenu4;

    public  GameObject      hudPanelOptions;
    public  GameObject      scrollOptions1;
    public  GameObject      scrollOptions2;
    public  GameObject      scrollOptions3;
    public  GameObject      scrollOptions4;
    public  GameObject      scrollOptions5;
    public  GameObject      scrollOptions6;
    public  GameObject      scrollOptions7;
    public  GameObject      scrollOptions8;
    public  GameObject      smartCastIcon;
    public  GameObject      smartCastText;
    public  GameObject      bloodlessIcon;
    public  GameObject      bloodlessText;
    public  GameObject      showSpellsInfoIcon;
    public  GameObject      showSpellsInfoText;
    public  GameObject      volumeMusicMinus;
    public  GameObject      volumeMusicPlus;
    public  GameObject      volumeMusicText;
    public  GameObject      volumeSFXMinus;
    public  GameObject      volumeSFXPlus;
    public  GameObject      volumeSFXText;
    public  GameObject      wasdModeButton;
    public  GameObject      wasdModeText;
    public  GameObject      healthPotionHotkeyText;
    public  GameObject      windowedButton;
    public  GameObject      windowedText;
    public  GameObject      returnText;

    public  GameObject      textStockHealthPotion;
    public  GameObject      textStockManaPotion;

    public  GameObject      agent1Panel;
    public  GameObject      agent1Portrait;
    public  GameObject[]    agent1Levels = new GameObject[10];
    public  GameObject      levelUpAgent1;
    public  Slider          agent1healthBarGreenHUD;
    public  Slider          agent1xpBarHUD;
    public  GameObject      agent1Potion1;
    public  GameObject      agent1Potion2;
    public  GameObject      agent1Potion3;

    public  GameObject      agent2Panel;
    public  GameObject      agent2Portrait;
    public  GameObject[]    agent2Levels = new GameObject[10];
    public  GameObject      levelUpAgent2;
    public  Slider          agent2healthBarGreenHUD;
    public  Slider          agent2xpBarHUD;
    public  GameObject      agent2Potion1;
    public  GameObject      agent2Potion2;
    public  GameObject      agent2Potion3;

    public  GameObject      agent3Panel;
    public  GameObject      agent3Portrait;
    public  GameObject[]    agent3Levels = new GameObject[10];
    public  GameObject      levelUpAgent3;
    public  Slider          agent3healthBarGreenHUD;
    public  Slider          agent3xpBarHUD;
    public  GameObject      agent3Potion1;
    public  GameObject      agent3Potion2;
    public  GameObject      agent3Potion3;

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
    public  GameObject      bulleInfoObject3;
    public  GameObject      bulleInfoObject3Title;
    public  GameObject      bulleInfoObject3Text;

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
    public  GameObject      cdObject3;

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

        if (PlayerPrefs.GetInt("SFXVolumeSet") == 1)
            volumeSFX = PlayerPrefs.GetInt("SFXVolume");
        else
            volumeSFX = 50f;
        volumeSFXText.GetComponent<Text>().text = "SFX volume : " + GetComponent<GameManager>().volumeSFX + "%";

        if (PlayerPrefs.GetInt("MusicVolumeSet") == 1)
            volumeMusic = PlayerPrefs.GetInt("MusicVolume");
        else
            volumeMusic = 50f;
        volumeMusicText.GetComponent<Text>().text = "Music volume : " + volumeMusic + "%";
        GetComponent<AudioSource>().volume = volumeMusic / 100;

        if (PlayerPrefs.GetInt("Bloodless") == 0)
        {
            bloodless = false;
            bloodlessIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxNotChecked;
        }
        else
        {
            bloodless = true;
            bloodlessIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxChecked;
        }

        if (PlayerPrefs.GetInt("Smartcast") == 0)
        {
            smartcast = false;
            smartCastIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxNotChecked;
        }
        else
        {
            smartcast = true;
            smartCastIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxChecked;
        }

        if (PlayerPrefs.GetInt("SpellsInfoSet") == 1 &&
            PlayerPrefs.GetInt("SpellsInfo") == 0)
        {
            showSpellsInfo = false;
            showSpellsInfoIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxNotChecked;
        }
        else
        {
            showSpellsInfo = true;
            showSpellsInfoIcon.GetComponent<Image>().sprite = GetComponent<Buttons>().boxChecked;
        }

        if (PlayerPrefs.GetInt("Windowed") == 0)
        {
            GetComponent<GameManager>().windowed = false;
            windowedButton.GetComponent<Image>().sprite = GetComponent<Buttons>().boxNotChecked;
            Screen.fullScreen = true;
        }
        else
        {
            GetComponent<GameManager>().windowed = true;
            windowedButton.GetComponent<Image>().sprite = GetComponent<Buttons>().boxChecked;
            Screen.fullScreen = false;
        }

        if (PlayerPrefs.GetInt("Load1Created") == 1)
            load1Created = true;
        else
            load1Created = false;

        if (PlayerPrefs.GetInt("Load2Created") == 1)
            load2Created = true;
        else
            load2Created = false;

        if (PlayerPrefs.GetInt("Load3Created") == 1)
            load3Created = true;
        else
            load3Created = false;
    }

    public void SetNormalMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorNormal, pos, cursorMode);
    }

    public void SetActiveBulleInfoSpell1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;

        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell1 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            GetComponent<TradManager>().HUDTextDescriptionSpell1.text = GetComponent<TradManager>().GetElementalSpellInGame1_1() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame1_2();
            bulleInfoSpell1.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell1.SetActive(false);
    }

    public void SetActiveBulleInfoSpell2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell2 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().thunderboltStacksBonus;
            GetComponent<TradManager>().HUDTextDescriptionSpell2.text = GetComponent<TradManager>().GetElementalSpellInGame2_1() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame2_2();
            bulleInfoSpell2.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell2.SetActive(false);
    }

    public void SetActiveBulleInfoSpell3()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell3 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            GetComponent<TradManager>().HUDTextDescriptionSpell3.text = GetComponent<TradManager>().GetElementalSpellInGame3_1() + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().numberShards + GetComponent<TradManager>().GetElementalSpellInGame3_2() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame3_3();
            bulleInfoSpell3.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell3()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell3.SetActive(false);
    }

    public void SetActiveBulleInfoSpell4()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell4 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            GetComponent<TradManager>().HUDTextDescriptionSpell4.text = GetComponent<TradManager>().GetElementalSpellInGame4_1() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame4_2();
            bulleInfoSpell4.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell4()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell4.SetActive(false);
    }

    public void SetActiveBulleInfoSpell5()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            float duration = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusEffectDuration * 2;
            GetComponent<TradManager>().HUDTextDescriptionSpell5.text = GetComponent<TradManager>().GetElementalSpellInGame5_1() + duration + GetComponent<TradManager>().GetElementalSpellInGame5_2();
            bulleInfoSpell5.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell5()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell5.SetActive(false);
    }

    public void SetActiveBulleInfoSpell6()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell6 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            float duration = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusEffectDuration * 2;
            GetComponent<TradManager>().HUDTextDescriptionSpell6.text = GetComponent<TradManager>().GetElementalSpellInGame6_1() + duration + GetComponent<TradManager>().GetElementalSpellInGame6_2() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame6_3();
            bulleInfoSpell6.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell6()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell6.SetActive(false);
    }

    public void SetActiveBulleInfoSpell7()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell7 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            float duration = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusEffectDuration * 2;
            GetComponent<TradManager>().HUDTextDescriptionSpell7.text = GetComponent<TradManager>().GetElementalSpellInGame7_1() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame7_2() + duration + GetComponent<TradManager>().GetElementalSpellInGame7_3();
            bulleInfoSpell7.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell7()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoSpell7.SetActive(false);
    }

    public void SetActiveBulleInfoSpell8()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int damageCount = mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().damageSpell8 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusDamage;
            GetComponent<TradManager>().HUDTextDescriptionSpell8.text = GetComponent<TradManager>().GetElementalSpellInGame8_1() + damageCount + GetComponent<TradManager>().GetElementalSpellInGame8_2();
            bulleInfoSpell8.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoSpell8()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        if (showSpellsInfo == true)
            bulleInfoSpell8.SetActive(false);
    }

    public void SetActiveBulleInfoObject1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int healCount = 20 + mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().decorationBonusHealing;
            GetComponent<TradManager>().HUDTextDescriptionPotion1.text = GetComponent<TradManager>().GetDescriptionPotion1_1() + healCount + GetComponent<TradManager>().GetDescriptionPotion1_2();
            bulleInfoObject1.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoObject1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoObject1.SetActive(false);
    }

    public void SetActiveBulleInfoObject2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            GetComponent<TradManager>().HUDTextDescriptionPotion2.text = GetComponent<TradManager>().GetDescriptionPotion2();
            bulleInfoObject2.SetActive(true);
        }
    }

    public void SetInactiveBulleInfoObject2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoObject2.SetActive(false);
    }

    public void SetActiveBulleInfoObject3()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = false;
        if (showSpellsInfo == true)
        {
            int playerLevel = mapManager.GetComponent<MapManager>().player.GetComponent<StatsPlayer>().level;

            if (runeSelected == 0)
            {
                bulleInfoObject3Title.GetComponent<Text>().text = GetComponent<TradManager>().GetTitleRuneDamage();
                bulleInfoObject3Text.GetComponent<Text>().text = GetComponent<TradManager>().GetDescriptionRuneDamage_1() + playerLevel + GetComponent<TradManager>().GetDescriptionRuneDamage_2();
            }
            else if (runeSelected == 1)
            {
                bulleInfoObject3Title.GetComponent<Text>().text = GetComponent<TradManager>().GetTitleRuneCelerity();
                bulleInfoObject3Text.GetComponent<Text>().text = GetComponent<TradManager>().GetDescriptionRuneCelerity_1() + (playerLevel * 2) + GetComponent<TradManager>().GetDescriptionRuneCelerity_2();
            }
            else
            {
                bulleInfoObject3Title.GetComponent<Text>().text = GetComponent<TradManager>().GetTitleRuneHeal();
                bulleInfoObject3Text.GetComponent<Text>().text = GetComponent<TradManager>().GetDescriptionRuneHeal_1() + playerLevel + GetComponent<TradManager>().GetDescriptionRuneHeal_2();
            }

            bulleInfoObject3.SetActive(true);
        }

    }

    public void SetInactiveBulleInfoObject3()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().canShoot = true;
        bulleInfoObject3.SetActive(false);
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
        musicCombatObj.GetComponent<AudioSource>().Stop();
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
        musicCombatObj.GetComponent<AudioSource>().Stop();
        gamePaused = true;
        gameOver = true;
        GameObject obj = (GameObject)Instantiate(jingleDefaite, transform.position, transform.rotation);
        obj.GetComponent<AudioSource>().volume = volumeMusic / 100;
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
        hudInGame.SetActive(false);
        StartCoroutine(DefeatAnimation());
    }

    public void PauseMusic()
    {
        musicCombatObj.GetComponent<AudioSource>().Pause();
    }

    public void ResumeMusic()
    {
        musicCombatObj.GetComponent<AudioSource>().UnPause();
    }

    public void PlayMusicMenu()
    {
        GetComponent<AudioSource>().Play();
    }

    public void StopMusicMenu()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayMusicCombat()
    {
        StopMusicMenu();
        musicCombatObj = (GameObject)Instantiate(musicCombat, transform.position, transform.rotation);
        musicCombatObj.GetComponent<AudioSource>().volume = volumeMusic / 100;
    }

    public void SelectSpell1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell1(true);
    }

    public void SelectSpell2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell2(true);
    }

    public void SelectSpell3()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell3(true);
    }

    public void SelectSpell4()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell4(true);
    }

    public void SelectSpell5()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell5(true);
    }

    public void SelectSpell6()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell6(true);
    }

    public void SelectSpell7()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell7(true);
    }

    public void SelectSpell8()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().SelectSpell8(true);
    }

    public void SelectObject1()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().UseObject1();
    }

    public void SelectObject2()
    {
        mapManager.GetComponent<MapManager>().player.GetComponent<Shoots>().UseObject2();
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
