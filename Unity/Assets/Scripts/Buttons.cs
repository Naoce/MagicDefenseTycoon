﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public  Sprite  boxChecked;
    public  Sprite  boxNotChecked;
    public  Sprite  englishSprite;
    public  Sprite  frenchSprite;
    private Color   colorBlack = new Color(0.19f, 0.19f, 0.19f, 1f);

    void Awake()
    {
        ReturnToIntro();
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("ZQSDModeSet") == 0)
        {
            PlayerPrefs.SetInt("ZQSDMode", 0);
            GetComponent<GameManager>().zqsdMode = false;
            GetComponent<GameManager>().zqsdModeButton.GetComponent<Image>().sprite = boxNotChecked;
            GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "Q";
        }
        else
        {
            if (PlayerPrefs.GetInt("ZQSDMode") == 1)
            {
                GetComponent<GameManager>().zqsdMode = true;
                GetComponent<GameManager>().zqsdModeButton.GetComponent<Image>().sprite = boxChecked;
                GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "A";
            }
            else
            {
                GetComponent<GameManager>().zqsdMode = false;
                GetComponent<GameManager>().zqsdModeButton.GetComponent<Image>().sprite = boxNotChecked;
                GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "Q";
            }
        }

        if (PlayerPrefs.GetInt("LanguageModeSet") == 0)
        {
            PlayerPrefs.SetInt("LanguageMode", 1);
            GetComponent<GameManager>().englishLanguage = true;
            GetComponent<GameManager>().LanguageButton.GetComponent<Image>().sprite = englishSprite;
        }
        else
        {
            if (PlayerPrefs.GetInt("LanguageMode") == 1)
            {
                GetComponent<GameManager>().englishLanguage = true;
                GetComponent<GameManager>().LanguageButton.GetComponent<Image>().sprite = englishSprite;
            }
            else
            {
                GetComponent<GameManager>().englishLanguage = false;
                GetComponent<GameManager>().LanguageButton.GetComponent<Image>().sprite = frenchSprite;
            }
        }

        GetComponent<TradManager>().ResetTexts();
    }

    public void CloseOptions()
    {
        if (Time.timeScale == 1)
        {
            GetComponent<GameManager>().hudPanelOptions.SetActive(false);
            GetComponent<GameManager>().isInOptionsFromIntro = false;
        }
        else
        {
            GetComponent<GameManager>().isInOptions = false;
            GetComponent<GameManager>().hudPanelMenu.SetActive(true);
            GetComponent<Buttons>().AnimationPanelHUDMenu();
            GetComponent<GameManager>().hudPanelOptions.SetActive(false);
        }
    }

    public void Resume ()
    {
        GetComponent<GameManager>().mapManager.GetComponent<MapManager>().Resume();
    }

    public void OptionsFromIntro()
    {
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

    public void OpenBestiary()
    {
        GetComponent<GameManager>().menuScrollOptions.SetActive(false);
        GetComponent<GameManager>().menuScrollTutorial.SetActive(false);
        GetComponent<GameManager>().menuScrollBestiary.SetActive(false);

        SelectEnemiesPanelBestiary();

        GetComponent<GameManager>().panelBestiary.SetActive(true);
    }

    public void SelectEnemiesPanelBestiary()
    {
        GetComponent<GameManager>().panelBestiaryHeroes.SetActive(false);
        GetComponent<GameManager>().panelBestiaryAllies.SetActive(false);
        GetComponent<GameManager>().panelBestiaryEnemies.SetActive(true);

        GetComponent<GameManager>().panelBestiaryIconEnemies.GetComponent<RectTransform>().localPosition = new Vector3(-425, 380, 0);
        GetComponent<GameManager>().panelBestiaryIconAllies.GetComponent<RectTransform>().localPosition = new Vector3(-300, 350, 0);
        GetComponent<GameManager>().panelBestiaryIconHeroes.GetComponent<RectTransform>().localPosition = new Vector3(-175, 350, 0);

        BestiarySelectCharacter(0);

    }
    public void SelectAlliesPanelBestiary()
    {
        GetComponent<GameManager>().panelBestiaryEnemies.SetActive(false);
        GetComponent<GameManager>().panelBestiaryHeroes.SetActive(false);
        GetComponent<GameManager>().panelBestiaryAllies.SetActive(true);

        GetComponent<GameManager>().panelBestiaryIconEnemies.GetComponent<RectTransform>().localPosition = new Vector3(-425, 350, 0);
        GetComponent<GameManager>().panelBestiaryIconAllies.GetComponent<RectTransform>().localPosition = new Vector3(-300, 380, 0);
        GetComponent<GameManager>().panelBestiaryIconHeroes.GetComponent<RectTransform>().localPosition = new Vector3(-175, 350, 0);

        BestiarySelectCharacter(9);
    }

    public void SelectHeroesPanelBestiary()
    {
        GetComponent<GameManager>().panelBestiaryEnemies.SetActive(false);
        GetComponent<GameManager>().panelBestiaryAllies.SetActive(false);
        GetComponent<GameManager>().panelBestiaryHeroes.SetActive(true);

        GetComponent<GameManager>().panelBestiaryIconEnemies.GetComponent<RectTransform>().localPosition = new Vector3(-425, 350, 0);
        GetComponent<GameManager>().panelBestiaryIconAllies.GetComponent<RectTransform>().localPosition = new Vector3(-300, 350, 0);
        GetComponent<GameManager>().panelBestiaryIconHeroes.GetComponent<RectTransform>().localPosition = new Vector3(-175, 380, 0);

        BestiarySelectCharacter(12);
    }

    public void CloseBestiary()
    {
        GetComponent<GameManager>().panelBestiary.SetActive(false);

        GetComponent<GameManager>().menuScrollOptions.SetActive(true);
        GetComponent<GameManager>().menuScrollTutorial.SetActive(true);
        GetComponent<GameManager>().menuScrollBestiary.SetActive(true);
    }

    public void BestiarySelectCharacter(int id)
    {
         if (id == 0)
        {
            float damage = GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty];
            float attackspeed = GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextBandit();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeWarrior();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterBandit.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 1)
        {
            float damage = GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty];
            float attackspeed = GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextBarbare();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeWarrior();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterBarbarian.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 2)
        {
            float damage = GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty];
            float attackspeed = GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextChaosWarrior();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeWarrior();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterChaosWarrior.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 3)
        {
            float damage = GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty];
            float attackspeed = GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextArcher();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeArcher();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterArcher.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 4)
        {
            float damage = GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty] * 2;
            float attackspeed = GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextRanger();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeArcher();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterRanger.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 5)
        {
            float damage = GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty] * 3;
            float attackspeed = GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextEliteArcher();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeArcher();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterEliteArcher.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 6)
        {
            float damage = GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty];
            float attackspeed = GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextRobber();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeThief();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterRobber.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextPlayer();
        }
        else if (id == 7)
        {
            float damage = GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty] * 2;
            float attackspeed = GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextHitman();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeThief();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterHitman.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextPlayer();
        }
        else if (id == 8)
        {
            float damage = GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().damage[GetComponent<GameManager>().difficulty] * 3;
            float attackspeed = GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().attackCooldown + GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().rightAttackSprites.Length * GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().animAttackCD;

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextNinja();
            GetComponent<GameManager>().panelBestiaryClassType.text = GetComponent<TradManager>().GetTextTypeThief();
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().maxHP[GetComponent<GameManager>().difficulty].ToString();
            GetComponent<GameManager>().panelBestiaryXPText.text = GetComponent<GameManager>().CharacterNinja.GetComponent<IAGuerrier>().valueXP.ToString();
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage / attackspeed), 2).ToString();
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextPlayer();
        }
        else if (id == 9)
        {
            float damage1 = GetComponent<GameManager>().agentTypeKnightDamage[0];
            float attackspeed1 = GetComponent<GameManager>().agentTypeKnightAS[0];

            float damage10 = GetComponent<GameManager>().agentTypeKnightDamage[9];
            float attackspeed10 = GetComponent<GameManager>().agentTypeKnightAS[9];

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().agentID0.GetComponent<IAGuerrierAgent>().SheetClass.ToString());
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().agentTypeKnightMaxHP[0] + " - " + GetComponent<GameManager>().agentTypeKnightMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage1 / attackspeed1), 2) + " - " + System.Math.Round((damage10 / attackspeed10), 2);
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 10)
        {
            float damage1 = GetComponent<GameManager>().agentTypeRogueDamage[0];
            float attackspeed1 = GetComponent<GameManager>().agentTypeRogueAS[0];

            float damage10 = GetComponent<GameManager>().agentTypeRogueDamage[9];
            float attackspeed10 = GetComponent<GameManager>().agentTypeRogueAS[9];

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().agentID1.GetComponent<IAGuerrierAgent>().SheetClass.ToString());
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().agentTypeRogueMaxHP[0] + " - " + GetComponent<GameManager>().agentTypeRogueMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage1 / attackspeed1), 2) + " - " + System.Math.Round((damage10 / attackspeed10), 2);
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 11)
        {
            float damage1 = GetComponent<GameManager>().agentTypeSwordsmanDamage[0];
            float attackspeed1 = GetComponent<GameManager>().agentTypeSwordsmanAS[0];

            float damage10 = GetComponent<GameManager>().agentTypeSwordsmanDamage[9];
            float attackspeed10 = GetComponent<GameManager>().agentTypeSwordsmanAS[9];

            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().agentID2.GetComponent<IAGuerrierAgent>().SheetClass.ToString());
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().agentTypeSwordsmanMaxHP[0] + " - " + GetComponent<GameManager>().agentTypeSwordsmanMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = System.Math.Round((damage1 / attackspeed1), 2) + " - " + System.Math.Round((damage10 / attackspeed10), 2);
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextClosest();
        }
        else if (id == 12)
        {
            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextTitleElemental();
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().playerMaxHP[0] + " - " + GetComponent<GameManager>().playerMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = "> 9000";
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextFree();
        }
        else if (id == 13)
        {
            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextTitleDemonic();
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().playerMaxHP[0] + " - " + GetComponent<GameManager>().playerMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = "> 9000";
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextFree();
        }
        else if (id == 14)
        {
            GetComponent<GameManager>().panelBestiaryClassName.text = GetComponent<TradManager>().GetTextTitleRadiant();
            GetComponent<GameManager>().panelBestiaryClassType.text = "";
            GetComponent<GameManager>().panelBestiaryHPText.text = GetComponent<GameManager>().playerMaxHP[0] + " - " + GetComponent<GameManager>().playerMaxHP[9];
            GetComponent<GameManager>().panelBestiaryXPText.text = "0";
            GetComponent<GameManager>().panelBestiaryDPSText.text = "> 9000";
            GetComponent<GameManager>().panelBestiaryTargetText.text = GetComponent<TradManager>().GetTextFree();
        }
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
        GetComponent<GameManager>().menuScrollOptions.SetActive(false);
        GetComponent<GameManager>().menuScrollTutorial.SetActive(false);
        GetComponent<GameManager>().menuScrollBestiary.SetActive(false);
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
        GetComponent<GameManager>().hudVictoryCoinsScroll.SetActive(false);
        GetComponent<GameManager>().hudVictoryCoin.SetActive(false);
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
        GetComponent<GameManager>().menuScrollOptions.SetActive(true);
        GetComponent<GameManager>().menuScrollTutorial.SetActive(true);
        //GetComponent<GameManager>().menuScrollBestiary.SetActive(true);
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

    public void MusicVolumeChange()
    {
        GetComponent<GameManager>().volumeMusic = GetComponent<GameManager>().volumeMusicSlider.GetComponent<Slider>().value * 100f;
        PlayerPrefs.SetInt("MusicVolumeSet", 1);
        PlayerPrefs.SetInt("MusicVolume", (int)GetComponent<GameManager>().volumeMusic);
        GetComponent<GameManager>().volumeMusicText.GetComponent<Text>().text = ((int)GetComponent<GameManager>().volumeMusic).ToString() + "%";

        if (GetComponent<GameManager>().isInGame == true)
            GetComponent<GameManager>().musicCombatObj.GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
        GetComponent<AudioSource>().volume = GetComponent<GameManager>().volumeMusic / 100;
    }

    public void DisplayInfoMusic()
    {
        GetComponent<GameManager>().bulleInfoMusic.SetActive(true);
    }

    public void HideInfoMusic()
    {
        GetComponent<GameManager>().bulleInfoMusic.SetActive(false);
    }

    public void SFXVolumeChange()
    {
        GetComponent<GameManager>().volumeSFX = GetComponent<GameManager>().volumeSFXSlider.GetComponent<Slider>().value * 100f;
        PlayerPrefs.SetInt("SFXVolumeSet", 1);
        PlayerPrefs.SetInt("SFXVolume", (int)GetComponent<GameManager>().volumeSFX);
        GetComponent<GameManager>().volumeSFXText.GetComponent<Text>().text = ((int)GetComponent<GameManager>().volumeSFX).ToString() + "%";
    }

    public void DisplayInfoSFX()
    {
        GetComponent<GameManager>().bulleInfoSFX.SetActive(true);
    }

    public void HideInfoSFX()
    {
        GetComponent<GameManager>().bulleInfoSFX.SetActive(false);
    }

    public void BloodTrigger(GameObject obj)
    {
        if (GetComponent<GameManager>().bloodless == true)
        {
            PlayerPrefs.SetInt("Bloodless", 0);
            obj.GetComponent<Image>().sprite = boxNotChecked;
            GetComponent<GameManager>().bloodless = false;
        }
        else
        {
            PlayerPrefs.SetInt("Bloodless", 1);
            obj.GetComponent<Image>().sprite = boxChecked;
            GetComponent<GameManager>().bloodless = true;
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
        {
            if (GetComponent<GameManager>().englishLanguage == true)
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "For players searching for a more relaxed experience.";
            else
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "Pour les joueurs qui recherchent une expérience de jeu plus relaxante.";
        }
        else if (difficulty == 1)
        {
            if (GetComponent<GameManager>().englishLanguage == true)
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "For players that search for a normal experience.";
            else
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "Pour les joueurs qui recherchent une expérience de jeu normale.";
        }   
        else if (difficulty == 2)
        {
            if (GetComponent<GameManager>().englishLanguage == true)
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "Only play this if you enjoy dying.\nA lot.";
            else
                GetComponent<GameManager>().textDifficulty.GetComponentInChildren<Text>().text = "Sélectionnez ce mode de jeu uniquement si vous aimez mourir.\nBeaucoup.";
        }
           
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

    public void SaveRuneSelected()
    {
        if (GetComponent<GameManager>().currSave == 1)
        {
            if (GetComponent<GameManager>().runeSelected == 0)
                PlayerPrefs.SetString("Load1Rune", "Damage");
            else if (GetComponent<GameManager>().runeSelected == 1)
                PlayerPrefs.SetString("Load1Rune", "Celerity");
            else
                PlayerPrefs.SetString("Load1Rune", "Heal");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            if (GetComponent<GameManager>().runeSelected == 0)
                PlayerPrefs.SetString("Load2Rune", "Damage");
            else if (GetComponent<GameManager>().runeSelected == 1)
                PlayerPrefs.SetString("Load2Rune", "Celerity");
            else
                PlayerPrefs.SetString("Load2Rune", "Heal");
        }
        else if (GetComponent<GameManager>().currSave == 3)
        {
            if (GetComponent<GameManager>().runeSelected == 0)
                PlayerPrefs.SetString("Load3Rune", "Damage");
            else if (GetComponent<GameManager>().runeSelected == 1)
                PlayerPrefs.SetString("Load3Rune", "Celerity");
            else
                PlayerPrefs.SetString("Load3Rune", "Heal");
        }
    }

    public void ReturnToPanelCharacterSelection()
    {
        DisplayRuneDamage();
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

    public void DisplayRuneDamage()
    {
        GetComponent<GameManager>().runeSelected = 0;
        SaveRuneSelected();
        GetComponent<GameManager>().scrollRunePanel1.SetActive(true);
        GetComponent<GameManager>().scrollRunePanel2.SetActive(false);
        GetComponent<GameManager>().scrollRunePanel3.SetActive(false);
    }

    public void DisplayRuneCelerity()
    {
        GetComponent<GameManager>().runeSelected = 1;
        SaveRuneSelected();
        GetComponent<GameManager>().scrollRunePanel1.SetActive(false);
        GetComponent<GameManager>().scrollRunePanel2.SetActive(true);
        GetComponent<GameManager>().scrollRunePanel3.SetActive(false);
    }

    public void DisplayRuneHeal()
    {
        GetComponent<GameManager>().runeSelected = 2;
        SaveRuneSelected();
        GetComponent<GameManager>().scrollRunePanel1.SetActive(false);
        GetComponent<GameManager>().scrollRunePanel2.SetActive(false);
        GetComponent<GameManager>().scrollRunePanel3.SetActive(true);
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
            GetComponent<GameManager>().MissionsPanelSheet1Difficulty4.SetActive(true);
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

        //Sheet4
        if (GetComponent<GameManager>().listMissions.Count > 3)
        {
            GetComponent<GameManager>().MissionsPanelSheet4.SetActive(true);

            if (GetComponent<GameManager>().listMissions[3].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet4Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[3].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet4Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet4Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[3].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[3].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[3].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet4Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet4.SetActive(false);

        //Sheet5
        if (GetComponent<GameManager>().listMissions.Count > 4)
        {
            GetComponent<GameManager>().MissionsPanelSheet5.SetActive(true);

            if (GetComponent<GameManager>().listMissions[4].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet5Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[4].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet5Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet5Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[4].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[4].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[4].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet5Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet5.SetActive(false);

        //Sheet6
        if (GetComponent<GameManager>().listMissions.Count > 5)
        {
            GetComponent<GameManager>().MissionsPanelSheet6.SetActive(true);

            if (GetComponent<GameManager>().listMissions[5].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet6Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[5].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet6Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet6Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[5].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[5].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[5].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet6Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet6.SetActive(false);

        //Sheet7
        if (GetComponent<GameManager>().listMissions.Count > 6)
        {
            GetComponent<GameManager>().MissionsPanelSheet7.SetActive(true);

            if (GetComponent<GameManager>().listMissions[6].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet7Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[6].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet7Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet7Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[6].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[6].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[6].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet7Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet7.SetActive(false);

        //Sheet8
        if (GetComponent<GameManager>().listMissions.Count > 7)
        {
            GetComponent<GameManager>().MissionsPanelSheet8.SetActive(true);

            if (GetComponent<GameManager>().listMissions[7].GetComponent<MissionSheet>().type == MapManager.MapType.Boss)
                GetComponent<GameManager>().MissionsPanelSheet8Type.sprite = GetComponent<GameManager>().littlebossSprite;
            else if (GetComponent<GameManager>().listMissions[7].GetComponent<MissionSheet>().type == MapManager.MapType.Capture)
                GetComponent<GameManager>().MissionsPanelSheet8Type.sprite = GetComponent<GameManager>().littlecaptureSprite;
            else
                GetComponent<GameManager>().MissionsPanelSheet8Type.sprite = GetComponent<GameManager>().littledefenseSprite;

            if (GetComponent<GameManager>().listMissions[7].GetComponent<MissionSheet>().difficulty > 1)
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty2.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty2.SetActive(false);

            if (GetComponent<GameManager>().listMissions[7].GetComponent<MissionSheet>().difficulty > 2)
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty3.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty3.SetActive(false);

            if (GetComponent<GameManager>().listMissions[7].GetComponent<MissionSheet>().difficulty > 3)
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty4.SetActive(true);
            else
                GetComponent<GameManager>().MissionsPanelSheet8Difficulty4.SetActive(false);
        }
        else
            GetComponent<GameManager>().MissionsPanelSheet8.SetActive(false);
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
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty4.SetActive(true);
        else
            GetComponent<GameManager>().MissionsPanelMainSheetDifficulty4.SetActive(false);
        if (GetComponent<GameManager>().englishLanguage == true)
        {
            GetComponent<GameManager>().MissionsPanelDescriptionText.text = GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().descriptionEnglish.Replace("<br>", "\n");
            GetComponent<GameManager>().MissionsPanelDescriptionBisText.text = "Experience : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().experience +
                                                                               "\nReward : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().reward + " gold coins";

        }
        else
        {
            GetComponent<GameManager>().MissionsPanelDescriptionText.text = GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().descriptionFrench.Replace("<br>", "\n");
            GetComponent<GameManager>().MissionsPanelDescriptionBisText.text = "Expérience : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().experience +
                                                                               "\nRécompense : " + GetComponent<GameManager>().listMissions[id].GetComponent<MissionSheet>().reward + " pièces d'or";

        }
    }

    public void EnterInMission()
    {
        if (GetComponent<GameManager>().runeSelected == 0)
            GetComponent<GameManager>().HUDRuneImage.sprite = GetComponent<GameManager>().runeDamageSprite;
        else if (GetComponent<GameManager>().runeSelected == 1)
            GetComponent<GameManager>().HUDRuneImage.sprite = GetComponent<GameManager>().runeCeleritySprite;
        else
            GetComponent<GameManager>().HUDRuneImage.sprite = GetComponent<GameManager>().runeHealSprite;

        NewGame();
        Application.LoadLevel(GetComponent<GameManager>().listMissions[GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().idMission);
        GetComponent<GameManager>().cam = GameObject.Find("Main Camera");
    }

    public void HighlightTavernTab(int id)
    {
        GetComponent<GameManager>().TavernTabAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().TavernTabAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().TavernTabAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().TavernTabAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;

        if (id == 0)
            GetComponent<GameManager>().TavernTabAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 1)
            GetComponent<GameManager>().TavernTabAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 2)
            GetComponent<GameManager>().TavernTabAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else
            GetComponent<GameManager>().TavernTabAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
    }

    public void DisplayTavernPanel()
    {
        GetComponent<GameManager>().TavernRosterSizeText.text = GetComponent<GameManager>().rosterAgents.Count.ToString() + " / 6";
        GetComponent<GameManager>().TavernRosterSizeText.color = colorBlack;

        GetComponent<GameManager>().TavernPrestigeText.text = GetComponent<GameManager>().prestige.ToString();
        GetComponent<GameManager>().TavernPrestigeText.color = colorBlack;

        GetComponent<GameManager>().currAgentSelected = 0;
        GetComponent<GameManager>().TavernAgent1Recruited = false;
        GetComponent<GameManager>().TavernAgent2Recruited = false;
        GetComponent<GameManager>().TavernAgent3Recruited = false;
        GetComponent<GameManager>().TavernAgent4Recruited = false;

        if (GetComponent<GameManager>().tabFreeAgents.Count > 0)
        {
            GetComponent<GameManager>().TavernDescription.SetActive(true);
            GetComponent<GameManager>().TavernRecruitButton.SetActive(true);
            GetComponent<GameManager>().TavernAgentObj[0] = GetComponent<GameManager>().tabFreeAgents[0];
            FillTavernMainSheet(0);
            GetComponent<GameManager>().TavernAgent1.SetActive(true);
            GetComponent<GameManager>().TavernTabAgent1.SetActive(true);

            GetComponent<GameManager>().TavernAgentObj[1] = null;
            GetComponent<GameManager>().TavernAgentObj[2] = null;
            GetComponent<GameManager>().TavernAgentObj[3] = null;

            HighlightTavernTab(0);

            if (GetComponent<GameManager>().tabFreeAgents[0].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().TavernAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().tabFreeAgents[0].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().TavernAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().TavernAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;
        }
        else
        {
            GetComponent<GameManager>().TavernDescription.SetActive(false);
            GetComponent<GameManager>().TavernRecruitButton.SetActive(false);
            GetComponent<GameManager>().TavernAgent1.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent1.SetActive(false);
        }

        if (GetComponent<GameManager>().tabFreeAgents.Count > 1)
        {
            GetComponent<GameManager>().TavernAgentObj[1] = GetComponent<GameManager>().tabFreeAgents[1];
            GetComponent<GameManager>().TavernAgent2.SetActive(true);
            GetComponent<GameManager>().TavernTabAgent2.SetActive(true);

            if (GetComponent<GameManager>().tabFreeAgents[1].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().TavernAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().tabFreeAgents[1].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().TavernAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().TavernAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;
        }
        else
        {
            GetComponent<GameManager>().TavernAgent2.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent2.SetActive(false);
        }

        if (GetComponent<GameManager>().tabFreeAgents.Count > 2)
        {
            GetComponent<GameManager>().TavernAgentObj[2] = GetComponent<GameManager>().tabFreeAgents[2];
            GetComponent<GameManager>().TavernAgent3.SetActive(true);
            GetComponent<GameManager>().TavernTabAgent3.SetActive(true);

            if (GetComponent<GameManager>().tabFreeAgents[2].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().TavernAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().tabFreeAgents[2].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().TavernAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().TavernAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;
        }
        else
        {
            GetComponent<GameManager>().TavernAgent3.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent3.SetActive(false);
        }

        if (GetComponent<GameManager>().tabFreeAgents.Count > 3)
        {
            GetComponent<GameManager>().TavernAgentObj[3] = GetComponent<GameManager>().tabFreeAgents[3];
            GetComponent<GameManager>().TavernAgent4.SetActive(true);
            GetComponent<GameManager>().TavernTabAgent4.SetActive(true);

            if (GetComponent<GameManager>().tabFreeAgents[3].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().TavernAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().tabFreeAgents[3].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().TavernAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().TavernAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;
        }
        else
        {
            GetComponent<GameManager>().TavernAgent4.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent4.SetActive(false);
        }

        GetComponent<GameManager>().panelMenu.SetActive(false);
        GetComponent<GameManager>().panelTavern.SetActive(true);
    }

    public void FillTavernMainSheet(int id)
    {
        GetComponent<GameManager>().TavernRosterSizeText.color = colorBlack;
        GetComponent<GameManager>().TavernPrestigeText.color = colorBlack;

        HighlightTavernTab(id);
        GetComponent<GameManager>().currAgentSelected = id;

        GetComponent<GameManager>().TavernPrestigeText.text = GetComponent<GameManager>().prestige.ToString();

        int hp = 0;
        int damage = 0;
        float attackspeed = 0;

        int levelAgent = 0;

        if (GetComponent<GameManager>().currSave == 1)
        {
            if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load1Agent1Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load1Agent2Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load1Agent3Level");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load2Agent1Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load2Agent2Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load2Agent3Level");
        }
        else
        {
            if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load3Agent1Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load3Agent2Level");
            else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load3Agent3Level");
        }

        if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
        {
            hp = GetComponent<GameManager>().agentTypeKnightMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeKnightDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeKnightAS[levelAgent];
        }

        else if (GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Rogue)
        {
            hp = GetComponent<GameManager>().agentTypeRogueMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeRogueDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeRogueAS[levelAgent];
        }
        else
        {
            hp = GetComponent<GameManager>().agentTypeSwordsmanMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeSwordsmanDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeSwordsmanAS[levelAgent];
        }

        if (GetComponent<GameManager>().englishLanguage == true)
        {
            GetComponent<GameManager>().TavernDescription.GetComponent<Text>().text = GetComponent<TradManager>().GetNameAlly(GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID) +
                                                            "\nClass : " + GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetClass.ToString()) +
                                                            "\nLevel : " + levelAgent +
                                                            "\n\nHealth points : " + hp +
                                                            "\nDamage per second : " + System.Math.Round((damage / attackspeed), 2) +
                                                            "\n\nPrestige needed : " + GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetPrestige;

        }
        else
        {
            GetComponent<GameManager>().TavernDescription.GetComponent<Text>().text = GetComponent<TradManager>().GetNameAlly(GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetID) +
                                                            "\nClasse : " + GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetClass.ToString()) +
                                                            "\nNiveau : " + levelAgent +
                                                            "\n\nPoints de vie : " + hp +
                                                            "\nDégâts par seconde : " + System.Math.Round((damage / attackspeed), 2) +
                                                            "\n\nPrestige nécessaire : " + GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetPrestige;

        }

        if (GetComponent<GameManager>().prestige >= GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetPrestige &&
            GetComponent<GameManager>().rosterAgents.Count < 6)
        {
            GetComponent<GameManager>().TavernRosterSizeText.color = colorBlack;
            GetComponent<GameManager>().TavernPrestigeText.color = colorBlack;
            GetComponent<GameManager>().TavernRecruitButton.SetActive(true);
        }
        else
        {
            if (GetComponent<GameManager>().rosterAgents.Count < 6)
                GetComponent<GameManager>().TavernRosterSizeText.color = colorBlack;
            else
                GetComponent<GameManager>().TavernRosterSizeText.color = Color.red;

            if (GetComponent<GameManager>().prestige >= GetComponent<GameManager>().TavernAgentObj[id].GetComponent<IAGuerrierAgent>().SheetPrestige)
                GetComponent<GameManager>().TavernPrestigeText.color = colorBlack;
            else
                GetComponent<GameManager>().TavernPrestigeText.color = Color.red;

            GetComponent<GameManager>().TavernRecruitButton.SetActive(false);
        }

    }

    public void AddAgentToRoster()
    {
        GetComponent<GameManager>().rosterAgents.Add(GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected]);
        GetComponent<GameManager>().TavernRosterSizeText.text = GetComponent<GameManager>().rosterAgents.Count.ToString() + " / 6";

        if (CountTabAgentsLength() < 3)
        {
            if (GetComponent<GameManager>().tabAgents[0] == null)
                GetComponent<GameManager>().tabAgents[0] = GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected];
            else if (GetComponent<GameManager>().tabAgents[1] == null)
                GetComponent<GameManager>().tabAgents[1] = GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected];
            else
                GetComponent<GameManager>().tabAgents[2] = GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected];

            SaveAgentAddedToTeam(GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
        }

        SaveAgentAddedToRoster(GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);

        GetComponent<GameManager>().tabFreeAgents.Remove(GetComponent<GameManager>().TavernAgentObj[GetComponent<GameManager>().currAgentSelected]);

        if (GetComponent<GameManager>().currAgentSelected == 0)
        {
            GetComponent<GameManager>().TavernAgent1Recruited = true;
            GetComponent<GameManager>().TavernAgent1.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent1.SetActive(false);
            GetComponent<GameManager>().TavernAgentObj[0] = null;
        }
        else if (GetComponent<GameManager>().currAgentSelected == 1)
        {
            GetComponent<GameManager>().TavernAgent2Recruited = true;
            GetComponent<GameManager>().TavernAgent2.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent2.SetActive(false);
            GetComponent<GameManager>().TavernAgentObj[1] = null;
        }
        else if (GetComponent<GameManager>().currAgentSelected == 2)
        {
            GetComponent<GameManager>().TavernAgent3Recruited = true;
            GetComponent<GameManager>().TavernAgent3.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent3.SetActive(false);
            GetComponent<GameManager>().TavernAgentObj[2] = null;
        }
        else
        {
            GetComponent<GameManager>().TavernAgent4Recruited = true;
            GetComponent<GameManager>().TavernAgent4.SetActive(false);
            GetComponent<GameManager>().TavernTabAgent4.SetActive(false);
            GetComponent<GameManager>().TavernAgentObj[3] = null;
        }

        if (GetComponent<GameManager>().TavernAgent1Recruited == false &&
            GetComponent<GameManager>().TavernAgentObj[0] != null)
        {
            FillTavernMainSheet(0);
        }
        else if (GetComponent<GameManager>().TavernAgent2Recruited == false &&
            GetComponent<GameManager>().TavernAgentObj[1] != null)
        {
            FillTavernMainSheet(1);
        }
        else if (GetComponent<GameManager>().TavernAgent3Recruited == false &&
            GetComponent<GameManager>().TavernAgentObj[2] != null)
        {
            FillTavernMainSheet(2);
        }
        else if (GetComponent<GameManager>().TavernAgent4Recruited == false &&
            GetComponent<GameManager>().TavernAgentObj[3] != null)
        {
            FillTavernMainSheet(3);
        }
        else
        {
            GetComponent<GameManager>().TavernDescription.SetActive(false);
            GetComponent<GameManager>().TavernRecruitButton.SetActive(false);
        }
    }

    public void SaveAgentAddedToRoster(int id)
    {
        if (id == 0)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent1Roster", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent1Roster", 1);
            else
                PlayerPrefs.SetInt("Load3Agent1Roster", 1);
        }
        else if (id == 1)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent2Roster", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent2Roster", 1);
            else
                PlayerPrefs.SetInt("Load3Agent2Roster", 1);
        }
        else if (id == 2)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent3Roster", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent3Roster", 1);
            else
                PlayerPrefs.SetInt("Load3Agent3Roster", 1);
        }
    }

    public void SaveAgentRemovedFromRoster(int id)
    {
        if (id == 0)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent1Roster", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent1Roster", 0);
            else
                PlayerPrefs.SetInt("Load3Agent1Roster", 0);
        }
        else if (id == 1)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent2Roster", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent2Roster", 0);
            else
                PlayerPrefs.SetInt("Load3Agent2Roster", 0);
        }
        else if (id == 2)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent3Roster", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent3Roster", 0);
            else
                PlayerPrefs.SetInt("Load3Agent3Roster", 0);
        }
    }

    public void SaveAgentAddedToTeam(int id)
    {
        if (id == 0)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent1Team", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent1Team", 1);
            else
                PlayerPrefs.SetInt("Load3Agent1Team", 1);
        }
        else if (id == 1)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent2Team", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent2Team", 1);
            else
                PlayerPrefs.SetInt("Load3Agent2Team", 1);
        }
        else if (id == 2)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent3Team", 1);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent3Team", 1);
            else
                PlayerPrefs.SetInt("Load3Agent3Team", 1);
        }
    }

    public void SaveAgentRemovedFromTeam(int id)
    {
        if (id == 0)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent1Team", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent1Team", 0);
            else
                PlayerPrefs.SetInt("Load3Agent1Team", 0);
        }
        else if (id == 1)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent2Team", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent2Team", 0);
            else
                PlayerPrefs.SetInt("Load3Agent2Team", 0);
        }
        else if (id == 2)
        {
            if (GetComponent<GameManager>().currSave == 1)
                PlayerPrefs.SetInt("Load1Agent3Team", 0);
            else if (GetComponent<GameManager>().currSave == 2)
                PlayerPrefs.SetInt("Load2Agent3Team", 0);
            else
                PlayerPrefs.SetInt("Load3Agent3Team", 0);
        }
    }

    public void HighlightTowerTab(int id)
    {
        GetComponent<GameManager>().RosterTabAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().RosterTabAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().RosterTabAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().RosterTabAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().RosterTabAgent5.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;
        GetComponent<GameManager>().RosterTabAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOffSprite;

        if (id == 0)
            GetComponent<GameManager>().RosterTabAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 1)
            GetComponent<GameManager>().RosterTabAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 2)
            GetComponent<GameManager>().RosterTabAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 3)
            GetComponent<GameManager>().RosterTabAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else if (id == 4)
            GetComponent<GameManager>().RosterTabAgent5.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
        else
            GetComponent<GameManager>().RosterTabAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().tabOnSprite;
    }

    public void CheckRosterPotions()
    {
       // bool agent1InTeam = false;

      
            GetComponent<GameManager>().RosterSelected1.SetActive(false);

            GetComponent<GameManager>().RosterSelected2.SetActive(false);

            GetComponent<GameManager>().RosterSelected3.SetActive(false);

            GetComponent<GameManager>().RosterSelected4.SetActive(false);

            GetComponent<GameManager>().RosterSelected5.SetActive(false);

            GetComponent<GameManager>().RosterSelected6.SetActive(false);
    }

    public void DisplayTowerPanel()
    {
        GetComponent<GameManager>().panelMenu.SetActive(false);
        UpdateDecoration(false);
        CheckRosterPotions();
        GetComponent<GameManager>().currAgentSelected = 0;
        GetComponent<GameManager>().RosterTextNumberCount.color = colorBlack;
        GetComponent<GameManager>().RosterTextNumberCount.text = CountTabAgentsLength().ToString() + " / 3";

        if (GetComponent<GameManager>().rosterAgents.Count > 0)
        {
            GetComponent<GameManager>().RosterAgent1.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent1.SetActive(true);
            GetComponent<GameManager>().RosterButtonRecruit.SetActive(true);
            GetComponent<GameManager>().RosterButtonDismiss.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[0].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[0].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent1.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            HighlightTowerTab(0);
            UpdateRosterText(0);

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[0]) == true)
                GetComponent<GameManager>().RosterSelected1.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent1.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent1.SetActive(false);
            GetComponent<GameManager>().RosterTextDescription.SetActive(false);
            GetComponent<GameManager>().RosterButtonRecruit.SetActive(false);
            GetComponent<GameManager>().RosterButtonDismiss.SetActive(false);
            GetComponent<GameManager>().RosterSelected1.SetActive(false);
        }

        if (GetComponent<GameManager>().rosterAgents.Count > 1)
        {
            GetComponent<GameManager>().RosterAgent2.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent2.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[1].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[1].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent2.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[1]) == true)
                GetComponent<GameManager>().RosterSelected2.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent2.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent2.SetActive(false);
            GetComponent<GameManager>().RosterSelected2.SetActive(false);
        }

        if (GetComponent<GameManager>().rosterAgents.Count > 2)
        {
            GetComponent<GameManager>().RosterAgent3.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent3.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[2].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[2].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent3.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[2]) == true)
                GetComponent<GameManager>().RosterSelected3.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent3.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent3.SetActive(false);
            GetComponent<GameManager>().RosterSelected3.SetActive(false);
        }

        if (GetComponent<GameManager>().rosterAgents.Count > 3)
        {
            GetComponent<GameManager>().RosterAgent4.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent4.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[3].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[3].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent4.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[3]) == true)
                GetComponent<GameManager>().RosterSelected4.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent4.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent4.SetActive(false);
            GetComponent<GameManager>().RosterSelected4.SetActive(false);
        }

        if (GetComponent<GameManager>().rosterAgents.Count > 4)
        {
            GetComponent<GameManager>().RosterAgent5.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent5.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[4].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent5.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[4].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent5.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[4]) == true)
                GetComponent<GameManager>().RosterSelected5.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent5.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent5.SetActive(false);
            GetComponent<GameManager>().RosterSelected5.SetActive(false);
        }

        if (GetComponent<GameManager>().rosterAgents.Count > 5)
        {
            GetComponent<GameManager>().RosterAgent6.SetActive(true);
            GetComponent<GameManager>().RosterTabAgent6.SetActive(true);

            if (GetComponent<GameManager>().rosterAgents[5].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Swordsman)
                GetComponent<GameManager>().RosterAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().swordsmanIcon;
            else if (GetComponent<GameManager>().rosterAgents[5].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                GetComponent<GameManager>().RosterAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().knightIcon;
            else
                GetComponent<GameManager>().RosterAgent6.GetComponent<Image>().sprite = GetComponent<GameManager>().assassinIcon;

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[5]) == true)
                GetComponent<GameManager>().RosterSelected6.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().RosterAgent6.SetActive(false);
            GetComponent<GameManager>().RosterTabAgent6.SetActive(false);
            GetComponent<GameManager>().RosterSelected6.SetActive(false);
        }

        GetComponent<GameManager>().RosterTextNumberCount.text = CountTabAgentsLength().ToString() + " / 3";

        GetComponent<GameManager>().PanelRoster.SetActive(true);
        GetComponent<GameManager>().PanelSkillTree.SetActive(false);
        GetComponent<GameManager>().PanelDecoration.SetActive(false);
        GetComponent<GameManager>().panelTower.SetActive(true);
    }

    public void UpdateRosterText(int id)
    {
        HighlightTowerTab(id);
        GetComponent<GameManager>().RosterTextNumberCount.color = colorBlack;
        GetComponent<GameManager>().RosterButtonDismiss.SetActive(true);
        GetComponent<GameManager>().RosterButtonRecruit.SetActive(true);
        GetComponent<GameManager>().currAgentSelected = id;
        GetComponent<GameManager>().RosterTextDescription.SetActive(true);

        int hp = 0;
        int damage = 0;
        float attackspeed = 0;

        int levelAgent = 0;

        if (GetComponent<GameManager>().currSave == 1)
        {
            if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load1Agent1Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load1Agent2Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load1Agent3Level");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load2Agent1Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load2Agent2Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load2Agent3Level");
        }
        else
        {
            if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 0)
                levelAgent = PlayerPrefs.GetInt("Load3Agent1Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 1)
                levelAgent = PlayerPrefs.GetInt("Load3Agent2Level");
            else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID == 2)
                levelAgent = PlayerPrefs.GetInt("Load3Agent3Level");
        }

        if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
        {
            hp = GetComponent<GameManager>().agentTypeKnightMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeKnightDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeKnightAS[levelAgent];
        }
        else if (GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Rogue)
        {
            hp = GetComponent<GameManager>().agentTypeRogueMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeRogueDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeRogueAS[levelAgent];
        }
        else
        {
            hp = GetComponent<GameManager>().agentTypeSwordsmanMaxHP[levelAgent];
            damage = GetComponent<GameManager>().agentTypeSwordsmanDamage[levelAgent];
            attackspeed = GetComponent<GameManager>().agentTypeSwordsmanAS[levelAgent];
        }

        if (GetComponent<GameManager>().englishLanguage == true)
        {
            GetComponent<GameManager>().RosterTextDescription.GetComponent<Text>().text = GetComponent<TradManager>().GetNameAlly(GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID) +
                                    "\nClass : " + GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetClass.ToString()) +
                                    "\nLevel : " + levelAgent +
                                    "\n\nHealth points : " + hp +
                                    "\nDamage per second : " + System.Math.Round((damage / attackspeed), 2);

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[id]) == true)
                GetComponent<GameManager>().RosterButtonRecruit.GetComponentInChildren<Text>().text = "Remove from\nthe team";
            else
                GetComponent<GameManager>().RosterButtonRecruit.GetComponentInChildren<Text>().text = "Add to\nthe team";
        }
        else
        {
            GetComponent<GameManager>().RosterTextDescription.GetComponent<Text>().text = GetComponent<TradManager>().GetNameAlly(GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetID) +
                                    "\nClasse : " + GetComponent<TradManager>().GetTitleClass(GetComponent<GameManager>().rosterAgents[id].GetComponent<IAGuerrierAgent>().SheetClass.ToString()) +
                                    "\nNiveau : " + levelAgent +
                                    "\n\nPoints de vie : " + hp +
                                    "\nDégâts par seconde : " + System.Math.Round((damage / attackspeed), 2);

            if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[id]) == true)
                GetComponent<GameManager>().RosterButtonRecruit.GetComponentInChildren<Text>().text = "Retirer de\nl'équipe";
            else
                GetComponent<GameManager>().RosterButtonRecruit.GetComponentInChildren<Text>().text = "Ajouter à\nl'équipe";
        }

    }

    public void AddAgentToTeam()
    {
        if (IsAgentAlreadyInTeam(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected]) == false)
        {
            if (CountTabAgentsLength() < 3)
            {
                if (GetComponent<GameManager>().tabAgents[0] == null)
                    GetComponent<GameManager>().tabAgents[0] = GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected];
                else if (GetComponent<GameManager>().tabAgents[1] == null)
                    GetComponent<GameManager>().tabAgents[1] = GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected];
                else
                    GetComponent<GameManager>().tabAgents[2] = GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected];

                if (GetComponent<GameManager>().currAgentSelected == 0)
                    GetComponent<GameManager>().RosterSelected1.SetActive(true);
                else if (GetComponent<GameManager>().currAgentSelected == 1)
                    GetComponent<GameManager>().RosterSelected2.SetActive(true);
                else if (GetComponent<GameManager>().currAgentSelected == 2)
                    GetComponent<GameManager>().RosterSelected3.SetActive(true);
                else if (GetComponent<GameManager>().currAgentSelected == 3)
                    GetComponent<GameManager>().RosterSelected4.SetActive(true);
                else if (GetComponent<GameManager>().currAgentSelected == 4)
                    GetComponent<GameManager>().RosterSelected5.SetActive(true);
                else
                    GetComponent<GameManager>().RosterSelected6.SetActive(true);

                GetComponent<GameManager>().RosterTextNumberCount.text = CountTabAgentsLength().ToString() + " / 3";
                UpdateRosterText(GetComponent<GameManager>().currAgentSelected);

                SaveAgentAddedToTeam(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
            }
            else
                GetComponent<GameManager>().RosterTextNumberCount.color = Color.red;
        }
        else
        {
            if (GetComponent<GameManager>().tabAgents[0] == GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected])
                GetComponent<GameManager>().tabAgents[0] = null;
            if (GetComponent<GameManager>().tabAgents[1] == GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected])
                GetComponent<GameManager>().tabAgents[1] = null;
            if (GetComponent<GameManager>().tabAgents[2] == GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected])
                GetComponent<GameManager>().tabAgents[2] = null;

            if (GetComponent<GameManager>().currAgentSelected == 0)
                GetComponent<GameManager>().RosterSelected1.SetActive(false);
            else if (GetComponent<GameManager>().currAgentSelected == 1)
                GetComponent<GameManager>().RosterSelected2.SetActive(false);
            else if (GetComponent<GameManager>().currAgentSelected == 2)
                GetComponent<GameManager>().RosterSelected3.SetActive(false);
            else if (GetComponent<GameManager>().currAgentSelected == 3)
                GetComponent<GameManager>().RosterSelected4.SetActive(false);
            else if (GetComponent<GameManager>().currAgentSelected == 4)
                GetComponent<GameManager>().RosterSelected5.SetActive(false);
            else
                GetComponent<GameManager>().RosterSelected6.SetActive(false);

            SaveAgentRemovedFromTeam(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);

            GetComponent<GameManager>().RosterTextNumberCount.text = CountTabAgentsLength().ToString() + " / 3";

            UpdateRosterText(GetComponent<GameManager>().currAgentSelected);
        }
    }

    public void DismissAgentTower()
    {
        RemoveAgentFromTeam();

        GetComponent<GameManager>().tabFreeAgents.Add(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected]);

        SaveAgentRemovedFromRoster(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
        GetComponent<GameManager>().rosterAgents.Remove(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected]);
        DisplayTowerPanel();
    }

    public void RemoveAgentFromTeam()
    {
        if (GetComponent<GameManager>().tabAgents[0] == GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected])
        {
            SaveAgentRemovedFromRoster(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
            GetComponent<GameManager>().tabAgents[0] = null;
        }
        else if (GetComponent<GameManager>().tabAgents[1] == GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected])
        {
            SaveAgentRemovedFromRoster(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
            GetComponent<GameManager>().tabAgents[1] = null;
        }
        else
        {
            SaveAgentRemovedFromRoster(GetComponent<GameManager>().rosterAgents[GetComponent<GameManager>().currAgentSelected].GetComponent<IAGuerrierAgent>().SheetID);
            GetComponent<GameManager>().tabAgents[2] = null;
        }
    }

    public bool IsAgentAlreadyInTeam(GameObject agent)
    {
        if (GetComponent<GameManager>().tabAgents[0] == agent)
            return (true);
        if (GetComponent<GameManager>().tabAgents[1] == agent)
            return (true);
        if (GetComponent<GameManager>().tabAgents[2] == agent)
            return (true);

        return (false);
    }

    public int CountTabAgentsLength()
    {
        int i = 0;

        if (GetComponent<GameManager>().tabAgents[0] != null)
            i++;
        if (GetComponent<GameManager>().tabAgents[1] != null)
            i++;
        if (GetComponent<GameManager>().tabAgents[2] != null)
            i++;

        return (i);
    }

    public void DisplaySkillTreePanel()
    {
        int actionPoints = 0;
        int level = 0;

        if (GetComponent<GameManager>().currSave == 1)
        {
            actionPoints = PlayerPrefs.GetInt("Load1PlayerActionPoints");
            level = PlayerPrefs.GetInt("Load1PlayerLevel");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            actionPoints = PlayerPrefs.GetInt("Load2PlayerActionPoints");
            level = PlayerPrefs.GetInt("Load2PlayerLevel");
        }
        else
        {
            actionPoints = PlayerPrefs.GetInt("Load3PlayerActionPoints");
            level = PlayerPrefs.GetInt("Load3PlayerLevel");
        }

        if (GetComponent<GameManager>().englishLanguage == true)
            GetComponent<GameManager>().SkillTreeLevelText.text = "Level " + level.ToString();
        else
            GetComponent<GameManager>().SkillTreeLevelText.text = "Niveau " + level.ToString();

        GetComponent<GameManager>().SkillTreeActionPoints.text = "Points : " + actionPoints.ToString();

        UpdateSkillText(0);
        UpdateSkillTreeSkillRect();

        GetComponent<GameManager>().PanelRoster.SetActive(false);
        GetComponent<GameManager>().PanelDecoration.SetActive(false);
        UpdateDecoration(false);
        GetComponent<GameManager>().PanelSkillTree.SetActive(true);
    }

    public void UpdateSkillText(int id)
    {
        GetComponent<GameManager>().SkillTreeSpellSelected = id;
        int level = 0;
        int actionPoints = 0;
        if (GetComponent<GameManager>().currSave == 1)
        {
            level = PlayerPrefs.GetInt("Load1PlayerLevel");
            actionPoints = PlayerPrefs.GetInt("Load1PlayerActionPoints");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            level = PlayerPrefs.GetInt("Load2PlayerLevel");
            actionPoints = PlayerPrefs.GetInt("Load2PlayerActionPoints");
        }
        else
        {
            level = PlayerPrefs.GetInt("Load3PlayerLevel");
            actionPoints = PlayerPrefs.GetInt("Load3PlayerActionPoints");
        }

        switch (id)
        {
            case 0:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell1_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 1:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell1_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell1_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell1_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell1_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                }
                break;
            case 2:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell1_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell1_2") == 1 && PlayerPrefs.GetInt("Load1Spell1_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell1_2") == 1 && PlayerPrefs.GetInt("Load2Spell1_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell1_2") == 1 && PlayerPrefs.GetInt("Load3Spell1_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 3:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell2_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 3)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 4:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell2_2();
                if (actionPoints > 0 && level > 2 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell2_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell2_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell2_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 2)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 5:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell2_3();
                if (actionPoints > 0 && level > 2 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell2_2") == 1 && PlayerPrefs.GetInt("Load1Spell2_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell2_2") == 1 && PlayerPrefs.GetInt("Load2Spell2_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell2_2") == 1 && PlayerPrefs.GetInt("Load3Spell2_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 2)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 6:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell3_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 5)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 7:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell3_2();
                if (actionPoints > 0 && level > 4 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell3_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell3_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell3_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 4)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 8:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell3_3();
                if (actionPoints > 0 && level > 4 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell3_2") == 1 && PlayerPrefs.GetInt("Load1Spell3_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell3_2") == 1 && PlayerPrefs.GetInt("Load2Spell3_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell3_2") == 1 && PlayerPrefs.GetInt("Load3Spell3_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 4)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 9:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell4_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 7)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 10:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell4_2();
                if (actionPoints > 0 && level > 6 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell4_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell4_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell4_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 6)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 11:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell4_3();
                if (actionPoints > 0 && level > 6 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell4_2") == 1 && PlayerPrefs.GetInt("Load1Spell4_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell4_2") == 1 && PlayerPrefs.GetInt("Load2Spell4_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell4_2") == 1 && PlayerPrefs.GetInt("Load3Spell4_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 6)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 12:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell5_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 9)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 13:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell5_2();
                if (actionPoints > 0 && level > 8 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell5_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell5_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell5_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 8)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 14:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell5_3();
                if (actionPoints > 0 && level > 8 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell5_2") == 1 && PlayerPrefs.GetInt("Load1Spell5_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell5_2") == 1 && PlayerPrefs.GetInt("Load2Spell5_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell5_2") == 1 && PlayerPrefs.GetInt("Load3Spell5_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 8)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;

    
            case 15:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell6_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 11)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 16:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell6_2();
                if (actionPoints > 0 && level > 10 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell6_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell6_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell6_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 10)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 17:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell6_3();
                if (actionPoints > 0 && level > 10 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell6_2") == 1 && PlayerPrefs.GetInt("Load1Spell6_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell6_2") == 1 && PlayerPrefs.GetInt("Load2Spell6_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell6_2") == 1 && PlayerPrefs.GetInt("Load3Spell6_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 10)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 18:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell7();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell7_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 13)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 19:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell7();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell7_2();
                if (actionPoints > 0 && level > 12 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell7_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell7_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell7_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 12)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 20:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell7();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell7_3();
                if (actionPoints > 0 && level > 12 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell7_2") == 1 && PlayerPrefs.GetInt("Load1Spell7_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell7_2") == 1 && PlayerPrefs.GetInt("Load2Spell7_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell7_2") == 1 && PlayerPrefs.GetInt("Load3Spell7_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 12)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 21:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell8();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell8_1();
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    if (level < 15)
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 22:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell8();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell8_2();
                if (actionPoints > 0 && level > 14 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell8_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell8_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell8_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 14)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 23:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalSpell8();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalSpell8_3();
                if (actionPoints > 0 && level > 14 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell8_2") == 1 && PlayerPrefs.GetInt("Load1Spell8_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell8_2") == 1 && PlayerPrefs.GetInt("Load2Spell8_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell8_2") == 1 && PlayerPrefs.GetInt("Load3Spell8_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

                    if (level > 14)
                        GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    else
                        GetComponent<GameManager>().SkillTreeLevelText.color = Color.red;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 24:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive1_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 0 && PlayerPrefs.GetInt("Load1Passive2_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 0 && PlayerPrefs.GetInt("Load2Passive2_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 0 && PlayerPrefs.GetInt("Load3Passive2_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                } 
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 25:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive1_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 1 && PlayerPrefs.GetInt("Load1Passive1_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 1 && PlayerPrefs.GetInt("Load2Passive1_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 1 && PlayerPrefs.GetInt("Load3Passive1_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 26:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive1();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive1_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_2") == 1 && PlayerPrefs.GetInt("Load1Passive1_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_2") == 1 && PlayerPrefs.GetInt("Load2Passive1_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_2") == 1 && PlayerPrefs.GetInt("Load3Passive1_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 27:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive2_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 0 && PlayerPrefs.GetInt("Load1Passive2_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 0 && PlayerPrefs.GetInt("Load2Passive2_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 0 && PlayerPrefs.GetInt("Load3Passive2_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 28:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive2_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_1") == 1 && PlayerPrefs.GetInt("Load1Passive2_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_1") == 1 && PlayerPrefs.GetInt("Load2Passive2_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_1") == 1 && PlayerPrefs.GetInt("Load3Passive2_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 29:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive2();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive2_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_2") == 1 && PlayerPrefs.GetInt("Load1Passive2_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_2") == 1 && PlayerPrefs.GetInt("Load2Passive2_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_2") == 1 && PlayerPrefs.GetInt("Load3Passive2_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 30:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive3_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 31:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive3_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_1") == 1 && PlayerPrefs.GetInt("Load1Passive3_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_1") == 1 && PlayerPrefs.GetInt("Load2Passive3_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_1") == 1 && PlayerPrefs.GetInt("Load3Passive3_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 32:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive3();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive3_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_2") == 1 && PlayerPrefs.GetInt("Load1Passive3_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_2") == 1 && PlayerPrefs.GetInt("Load2Passive3_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_2") == 1 && PlayerPrefs.GetInt("Load3Passive3_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 33:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive4_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 34:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive4_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_1") == 1 && PlayerPrefs.GetInt("Load1Passive4_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_1") == 1 && PlayerPrefs.GetInt("Load2Passive4_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_1") == 1 && PlayerPrefs.GetInt("Load3Passive4_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 35:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive4();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive4_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_2") == 1 && PlayerPrefs.GetInt("Load1Passive4_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_2") == 1 && PlayerPrefs.GetInt("Load2Passive4_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_2") == 1 && PlayerPrefs.GetInt("Load3Passive4_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 36:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive5_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 0 && PlayerPrefs.GetInt("Load1Passive6_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 0 && PlayerPrefs.GetInt("Load2Passive6_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 0 && PlayerPrefs.GetInt("Load3Passive6_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 37:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive5_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 1 && PlayerPrefs.GetInt("Load1Passive5_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 1 && PlayerPrefs.GetInt("Load2Passive5_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 1 && PlayerPrefs.GetInt("Load3Passive5_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 38:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive5();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive5_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_2") == 1 && PlayerPrefs.GetInt("Load1Passive5_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_2") == 1 && PlayerPrefs.GetInt("Load2Passive5_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_2") == 1 && PlayerPrefs.GetInt("Load3Passive5_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;


            case 39:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive6_1();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 0 && PlayerPrefs.GetInt("Load1Passive6_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 0 && PlayerPrefs.GetInt("Load2Passive6_1") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 0 && PlayerPrefs.GetInt("Load3Passive6_1") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 40:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive6_2();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_1") == 1 && PlayerPrefs.GetInt("Load1Passive6_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_1") == 1 && PlayerPrefs.GetInt("Load2Passive6_2") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_1") == 1 && PlayerPrefs.GetInt("Load3Passive6_2") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
            case 41:
                GetComponent<GameManager>().SkillTreeTitle.text = GetComponent<TradManager>().GetTitleElementalPassive6();
                GetComponent<GameManager>().SkillTreeDescription.text = GetComponent<TradManager>().GetDescriptionElementalPassive6_3();
                if (actionPoints > 0 &&
                    ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_2") == 1 && PlayerPrefs.GetInt("Load1Passive6_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_2") == 1 && PlayerPrefs.GetInt("Load2Passive6_3") == 0) ||
                    (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_2") == 1 && PlayerPrefs.GetInt("Load3Passive6_3") == 0)))
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(true);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;
                    GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                else
                {
                    GetComponent<GameManager>().SkillTreeLearn.SetActive(false);
                    GetComponent<GameManager>().SkillTreeLevelText.color = colorBlack;

                    if (actionPoints == 0)
                        GetComponent<GameManager>().SkillTreeActionPoints.color = Color.red;
                    else
                        GetComponent<GameManager>().SkillTreeActionPoints.color = colorBlack;
                }
                break;
        }
    }

    public void ResetSkillRectAvailable()
    {
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable1_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable1_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable2_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable2_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable3_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable3_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable4_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable4_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable5_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable5_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable6_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable6_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable7_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable7_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable8_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable8_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable1_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable2_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable3_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable3_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable3_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable4_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable4_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable4_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable5_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.GetComponent<AnimOnStart>().StartAnimationByScript();

        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable6_1.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_1.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.activeSelf == true)
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.GetComponent<AnimOnStart>().StartAnimationByScript();
    }

    public void LearnSkillBySkillTree()
    {
        GetComponent<GameManager>().SkillTreeLearn.SetActive(false);

        switch (GetComponent<GameManager>().SkillTreeSpellSelected)
        {
            case 1:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell1_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell1_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell1_2", 1);
                break;
            case 2:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell1_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell1_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell1_3", 1);
                break;


            case 4:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell2_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell2_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell2_2", 1);
                break;
            case 5:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell2_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell2_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell2_3", 1);
                break;


            case 7:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell3_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell3_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell3_2", 1);
                break;
            case 8:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell3_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell3_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell3_3", 1);
                break;


            case 10:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell4_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell4_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell4_2", 1);
                break;
            case 11:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell4_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell4_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell4_3", 1);
                break;


            case 13:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell5_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell5_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell5_2", 1);
                break;
            case 14:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell5_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell5_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell5_3", 1);
                break;


            case 16:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell6_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell6_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell6_2", 1);
                break;
            case 17:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell6_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell6_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell6_3", 1);
                break;


            case 19:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell7_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell7_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell7_2", 1);
                break;
            case 20:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell7_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell7_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell7_3", 1);
                break;


            case 22:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell8_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell8_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell8_2", 1);
                break;
            case 23:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Spell8_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Spell8_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Spell8_3", 1);
                break;


            case 24:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive1_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive1_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive1_1", 1);
                break;
            case 25:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive1_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive1_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive1_2", 1);
                break;
            case 26:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive1_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive1_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive1_3", 1);
                break;


            case 27:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive2_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive2_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive2_1", 1);
                break;
            case 28:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive2_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive2_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive2_2", 1);
                break;
            case 29:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive2_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive2_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive2_3", 1);
                break;


            case 30:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive3_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive3_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive3_1", 1);
                break;
            case 31:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive3_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive3_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive3_2", 1);
                break;
            case 32:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive3_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive3_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive3_3", 1);
                break;


            case 33:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive4_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive4_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive4_1", 1);
                break;
            case 34:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive4_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive4_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive4_2", 1);
                break;
            case 35:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive4_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive4_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive4_3", 1);
                break;


            case 36:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive5_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive5_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive5_1", 1);
                break;
            case 37:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive5_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive5_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive5_2", 1);
                break;
            case 38:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive5_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive5_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive5_3", 1);
                break;


            case 39:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive6_1", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive6_1", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive6_1", 1);
                break;
            case 40:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive6_2", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive6_2", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive6_2", 1);
                break;
            case 41:
                if (GetComponent<GameManager>().currSave == 1)
                    PlayerPrefs.SetInt("Load1Passive6_3", 1);
                else if (GetComponent<GameManager>().currSave == 2)
                    PlayerPrefs.SetInt("Load2Passive6_3", 1);
                else
                    PlayerPrefs.SetInt("Load3Passive6_3", 1);
                break;
        }

        if (GetComponent<GameManager>().currSave == 1)
        {
            int actionPoints = PlayerPrefs.GetInt("Load1PlayerActionPoints") - 1;
            PlayerPrefs.SetInt("Load1PlayerActionPoints", actionPoints);
            GetComponent<GameManager>().SkillTreeActionPoints.text = "Points : " + actionPoints.ToString();
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            int actionPoints = PlayerPrefs.GetInt("Load2PlayerActionPoints") - 1;
            PlayerPrefs.SetInt("Load2PlayerActionPoints", actionPoints);
            GetComponent<GameManager>().SkillTreeActionPoints.text = "Points : " + actionPoints.ToString();
        }
        else
        {
            int actionPoints = PlayerPrefs.GetInt("Load3PlayerActionPoints") - 1;
            PlayerPrefs.SetInt("Load3PlayerActionPoints", actionPoints);
            GetComponent<GameManager>().SkillTreeActionPoints.text = "Points : " + actionPoints.ToString();
        }

        UpdateSkillTreeSkillRect();
        ResetSkillRectAvailable();
    }

    public void UpdateSkillTreeSkillRect()
    {
        int level = 0;

        if (GetComponent<GameManager>().currSave == 1)
            level = PlayerPrefs.GetInt("Load1PlayerLevel");
        else if (GetComponent<GameManager>().currSave == 2)
            level = PlayerPrefs.GetInt("Load2PlayerLevel");
        else
            level = PlayerPrefs.GetInt("Load3PlayerLevel");

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell1_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell1_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell1_2") == 1))
        {
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable1_2.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable1_2.SetActive(false);
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell1_3") == 1) ||
           (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell1_3") == 1) ||
           (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell1_3") == 1))
        {
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable1_3.SetActive(false);
        }
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell1_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell1_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell1_2") == 1))
        {
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_3.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable1_3.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectAvailable1_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable1_3.SetActive(true);
        }


        if (level > 2)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell2_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable2_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable2_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell2_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell2_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell2_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell2_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable2_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable2_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable2_3.SetActive(true);
        }


        if (level > 4)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell3_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell3_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell3_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable3_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable3_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell3_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell3_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell3_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell3_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell3_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell3_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable3_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable3_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable3_3.SetActive(true);
        }


        if (level > 6)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell4_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell4_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell4_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable4_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable4_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell4_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell4_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell4_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell4_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell4_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell4_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable4_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable4_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable4_3.SetActive(true);
        }


        if (level > 8)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell5_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable5_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable5_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell5_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell5_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell5_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell5_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable5_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable5_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable5_3.SetActive(true);
        }


        if (level > 10)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell6_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable6_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable6_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell6_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell6_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell6_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell6_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable6_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable6_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable6_3.SetActive(true);
        }


        if (level > 12)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell7_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell7_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell7_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable7_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable7_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell7_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell7_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell7_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell7_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell7_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell7_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable7_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable7_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable7_3.SetActive(true);
        }


        if (level > 14)
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_1.SetActive(false);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell8_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell8_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell8_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable8_2.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable8_2.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_2.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell8_3") == 1) ||
               (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell8_3") == 1) ||
               (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell8_3") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Spell8_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Spell8_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Spell8_2") == 1))
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.SetActive(true);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.SetActive(false);
                GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_3.SetActive(true);
            }
        }
        else
        {
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_1.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable8_2.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_2.SetActive(true);
            GetComponent<GameManager>().SkillTreeSpellRectAvailable8_3.SetActive(false);
            GetComponent<GameManager>().SkillTreeSpellRectNotAvailable8_3.SetActive(true);
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_3.SetActive(true);
        }
        else
        {
            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_1.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_1.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_1.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_1.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_2.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_2.SetActive(true);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_3") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_3") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_3") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable1_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect1_3.SetActive(true);
            }
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive1_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive1_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive1_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_3.SetActive(true);
        }
        else
        {
            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_1.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_1.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_1.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_1.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_2.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_2.SetActive(true);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_3") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_3") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_3") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive2_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive2_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable2_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect2_3.SetActive(true);
            }
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_1.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_1.SetActive(false);
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_2") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_2.SetActive(false);
        }
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_2.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_2.SetActive(true);
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_3") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_3") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_3") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_3.SetActive(false);
        }
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive3_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive3_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive3_2") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_3.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_3.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable3_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect3_3.SetActive(true);
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_1.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_1.SetActive(false);
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_2") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_2.SetActive(false);
        }
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_2.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_2.SetActive(true);
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_3") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_3") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_3") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_3.SetActive(false);
        }
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive4_2") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive4_2") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive4_2") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_3.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_3.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable4_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect4_3.SetActive(true);
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_3.SetActive(true);
        }
        else
        {
            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_1.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_1.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_1.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_1.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_2.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_2.SetActive(true);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_3") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_3") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_3") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable5_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect5_3.SetActive(true);
            }
        }


        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive5_1") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive5_1") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive5_1") == 1))
        {
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_1.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_1.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_2.SetActive(true);
            GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.SetActive(false);
            GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_3.SetActive(true);
        }
        else
        {
            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_1.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_1.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_1.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_1.SetActive(false);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_2.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_1") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_1") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_1") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_2.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_2.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_2.SetActive(true);
            }

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_3") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_3") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_3") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_3.SetActive(false);
            }
            else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Passive6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Passive6_2") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Passive6_2") == 1))
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.SetActive(true);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_3.SetActive(false);
            }
            else
            {
                GetComponent<GameManager>().SkillTreePassiveRectAvailable6_3.SetActive(false);
                GetComponent<GameManager>().SkillTreePassiveNotAvailableRect6_3.SetActive(true);
            }
        }
    }

    public void DisplayPanelDecoration()
    {
        DecorationSelectScroll(0);
        DecorationSelectScroll(1);
        DecorationSelectScroll(2);
        DecorationSelectScroll(3);
        DecorationSelectScroll(4);
        DecorationSelectScroll(5);

        GetComponent<GameManager>().PanelRoster.SetActive(false);
        GetComponent<GameManager>().PanelSkillTree.SetActive(false);
        GetComponent<GameManager>().PanelDecoration.SetActive(true);

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1DecorationColor") == 0) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2DecorationColor") == 0) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3DecorationColor") == 0))
            DecorationSelectScroll(0);
        else
            DecorationSelectScroll(1);

        UpdateDecoration(true);
    }

    public void DecorationNextChimney()
    {
        if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected++;
            GetComponent<GameManager>().PanelRedQG.SetActive(false);
            GetComponent<GameManager>().PanelBlueQG.SetActive(true);
        }
        else if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 1)
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected++;
            GetComponent<GameManager>().PanelBlueQG.SetActive(false);
            GetComponent<GameManager>().PanelYellowQG.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected = 0;
            GetComponent<GameManager>().PanelYellowQG.SetActive(false);
            GetComponent<GameManager>().PanelRedQG.SetActive(true);
        }

        DecorationSelectScroll(0);
    }

    public void DecorationPrevChimney()
    {
        if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected = 2;
            GetComponent<GameManager>().PanelRedQG.SetActive(false);
            GetComponent<GameManager>().PanelYellowQG.SetActive(true);
        }
        else if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 1)
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected--;
            GetComponent<GameManager>().PanelBlueQG.SetActive(false);
            GetComponent<GameManager>().PanelRedQG.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentChimneySelected--;
            GetComponent<GameManager>().PanelYellowQG.SetActive(false);
            GetComponent<GameManager>().PanelBlueQG.SetActive(true);
        }

        DecorationSelectScroll(0);
    }

    public void DecorationNextGod()
    {
        if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected++;

            GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(true);
        }
        else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected++;

            GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected = 0;

            GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(true);
        }

        DecorationSelectScroll(1);
    }

    public void DecorationPrevGod()
    {
        if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected = 2;

            GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(true);
        }
        else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected--;

            GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentGodSelected--;

            GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(false);
            GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(false);
            GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(false);

            GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(true);
            GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(true);
            GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(true);
        }

        DecorationSelectScroll(1);
    }

    public void DecorationSwitchBanner()
    {
        if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentBannerSelected++;

            GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(false);
            GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(false);
            GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(false);

            GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(true);
            GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(true);
            GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentBannerSelected = 0;

            GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(false);
            GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(false);
            GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(false);

            GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(true);
            GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(true);
            GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(true);
        }

        DecorationSelectScroll(2);
    }

    public void DecorationSwitchEquipment()
    {
        if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentWeaponsSelected++;

            GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(true);
            GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(true);
            GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(true);

            GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(false);
            GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(false);
            GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentWeaponsSelected = 0;

            GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(false);
            GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(false);
            GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(false);

            GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(true);
            GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(true);
            GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(true);
        }

        DecorationSelectScroll(3);
    }

    public void DecorationSwitchCarpet()
    {
        if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentCarpetSelected++;

            GetComponent<GameManager>().DecorationRedBear.SetActive(false);
            GetComponent<GameManager>().DecorationBlueBear.SetActive(false);
            GetComponent<GameManager>().DecorationYellowBear.SetActive(false);

            GetComponent<GameManager>().DecorationRedCarpet.SetActive(true);
            GetComponent<GameManager>().DecorationBlueCarpet.SetActive(true);
            GetComponent<GameManager>().DecorationYellowCarpet.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentCarpetSelected = 0;

            GetComponent<GameManager>().DecorationRedCarpet.SetActive(false);
            GetComponent<GameManager>().DecorationBlueCarpet.SetActive(false);
            GetComponent<GameManager>().DecorationYellowCarpet.SetActive(false);

            GetComponent<GameManager>().DecorationRedBear.SetActive(true);
            GetComponent<GameManager>().DecorationBlueBear.SetActive(true);
            GetComponent<GameManager>().DecorationYellowBear.SetActive(true);
        }

        DecorationSelectScroll(4);
    }

    public void DecorationSwitchShields()
    {
        if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 0)
        {
            GetComponent<GameManager>().DecorationCurrentShieldsSelected++;

            GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(true);
            GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(true);
            GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(true);

            GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(false);
            GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(false);
            GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(false);
        }
        else
        {
            GetComponent<GameManager>().DecorationCurrentShieldsSelected = 0;

            GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(false);
            GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(false);
            GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(false);

            GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(true);
            GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(true);
            GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(true);
        }

        DecorationSelectScroll(5);
    }

    public void DecorationBuy()
    {
        if (GetComponent<GameManager>().DecorationScrollSelected == 0)
        {
            GetComponent<GameManager>().coins -= 20;
            if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 2)
                GetComponent<GameManager>().prestige += 10;

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationColor", GetComponent<GameManager>().DecorationCurrentChimneySelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load1Prestige", GetComponent<GameManager>().prestige); 
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationColor", GetComponent<GameManager>().DecorationCurrentChimneySelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load2Prestige", GetComponent<GameManager>().prestige);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationColor", GetComponent<GameManager>().DecorationCurrentChimneySelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load3Prestige", GetComponent<GameManager>().prestige);
            }

            DecorationSelectScroll(1);
        }
        else if (GetComponent<GameManager>().DecorationScrollSelected == 1)
        {
            if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
                GetComponent<GameManager>().coins -= 30;
            else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
                GetComponent<GameManager>().coins -= 50;
            else
                GetComponent<GameManager>().coins -= 40;

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationGod", GetComponent<GameManager>().DecorationCurrentGodSelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationGod", GetComponent<GameManager>().DecorationCurrentGodSelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationGod", GetComponent<GameManager>().DecorationCurrentGodSelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
            }
        }
        else if (GetComponent<GameManager>().DecorationScrollSelected == 2)
        {
            GetComponent<GameManager>().coins -= 30;
            if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 1)
                GetComponent<GameManager>().prestige += 10;

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationBanner", GetComponent<GameManager>().DecorationCurrentBannerSelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load1Prestige", GetComponent<GameManager>().prestige);
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationBanner", GetComponent<GameManager>().DecorationCurrentBannerSelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load2Prestige", GetComponent<GameManager>().prestige);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationBanner", GetComponent<GameManager>().DecorationCurrentBannerSelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load3Prestige", GetComponent<GameManager>().prestige);
            }
        }
        else if (GetComponent<GameManager>().DecorationScrollSelected == 3)
        {
            GetComponent<GameManager>().coins -= 30;

            if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 1)
                GetComponent<GameManager>().prestige += 10;

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationWeapons", GetComponent<GameManager>().DecorationCurrentWeaponsSelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load1Prestige", GetComponent<GameManager>().prestige);
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationWeapons", GetComponent<GameManager>().DecorationCurrentWeaponsSelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load2Prestige", GetComponent<GameManager>().prestige);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationWeapons", GetComponent<GameManager>().DecorationCurrentWeaponsSelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load3Prestige", GetComponent<GameManager>().prestige);
            }
        }
        else if (GetComponent<GameManager>().DecorationScrollSelected == 4)
        {
            if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
                GetComponent<GameManager>().coins -= 20;
            else
            {
                GetComponent<GameManager>().coins -= 30;
                GetComponent<GameManager>().prestige += 10;
            }

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationCarpet", GetComponent<GameManager>().DecorationCurrentCarpetSelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load1Prestige", GetComponent<GameManager>().prestige);
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationCarpet", GetComponent<GameManager>().DecorationCurrentCarpetSelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load2Prestige", GetComponent<GameManager>().prestige);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationCarpet", GetComponent<GameManager>().DecorationCurrentCarpetSelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load3Prestige", GetComponent<GameManager>().prestige);
            }
        }
        else if (GetComponent<GameManager>().DecorationScrollSelected == 5)
        {
            GetComponent<GameManager>().coins -= 30;

            if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 1)
                GetComponent<GameManager>().prestige += 10;

            if (GetComponent<GameManager>().currSave == 1)
            {
                PlayerPrefs.SetInt("Load1DecorationShields", GetComponent<GameManager>().DecorationCurrentShieldsSelected + 1);
                PlayerPrefs.SetInt("Load1Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load1Prestige", GetComponent<GameManager>().prestige);
            }
            else if (GetComponent<GameManager>().currSave == 2)
            {
                PlayerPrefs.SetInt("Load2DecorationShields", GetComponent<GameManager>().DecorationCurrentShieldsSelected + 1);
                PlayerPrefs.SetInt("Load2Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load2Prestige", GetComponent<GameManager>().prestige);
            }
            else
            {
                PlayerPrefs.SetInt("Load3DecorationShields", GetComponent<GameManager>().DecorationCurrentShieldsSelected + 1);
                PlayerPrefs.SetInt("Load3Coins", GetComponent<GameManager>().coins);
                PlayerPrefs.SetInt("Load3Prestige", GetComponent<GameManager>().prestige);
            }
        }

        DecorationSelectScroll(GetComponent<GameManager>().DecorationScrollSelected);
        UpdateDecoration(true);
    }

    public void UpdateDecoration(bool isInDecorationPanel)
    {
        GetComponent<GameManager>().DecorationPrestigeText.text = GetComponent<GameManager>().prestige.ToString();
        GetComponent<GameManager>().DecorationCoinsText.text = GetComponent<GameManager>().coins.ToString();

        int decorationColor = 0;
        int decorationGod = 0;
        int decorationBanner = 0;
        int decorationWeapons = 0;
        int decorationCarpet = 0;
        int decorationShields = 0;

        if (GetComponent<GameManager>().currSave == 1)
        {
            decorationColor = PlayerPrefs.GetInt("Load1DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load1DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load1DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load1DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load1DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load1DecorationShields");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            decorationColor = PlayerPrefs.GetInt("Load2DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load2DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load2DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load2DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load2DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load2DecorationShields");
        }
        else
        {
            decorationColor = PlayerPrefs.GetInt("Load3DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load3DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load3DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load3DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load3DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load3DecorationShields");
        }

        if (decorationColor == 0)
        {
            GetComponent<GameManager>().PanelRedQG.SetActive(false);
            GetComponent<GameManager>().PanelBlueQG.SetActive(false);
            GetComponent<GameManager>().PanelYellowQG.SetActive(false);

            GetComponent<GameManager>().DecorationScrollChimney.SetActive(true);
            GetComponent<GameManager>().DecorationScrollGod.SetActive(false);
            GetComponent<GameManager>().DecorationScrollBanner.SetActive(false);
            GetComponent<GameManager>().DecorationScrollWeapons.SetActive(false);
            GetComponent<GameManager>().DecorationScrollCarpet.SetActive(false);
            GetComponent<GameManager>().DecorationScrollShields.SetActive(false);

            if (isInDecorationPanel == true)
            {
                if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 0)
                    GetComponent<GameManager>().PanelRedQG.SetActive(true);
                else if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 1)
                    GetComponent<GameManager>().PanelBlueQG.SetActive(true);
                else
                    GetComponent<GameManager>().PanelYellowQG.SetActive(true);
            }
        }
        else
        {
            switch (decorationGod)
            {
                case 0:
                    GetComponent<GameManager>().DecorationNextGod.SetActive(true);
                    GetComponent<GameManager>().DecorationPrevGod.SetActive(true);
                    break;

                case 1:
                    GetComponent<GameManager>().DecorationNextGod.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevGod.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationNextGod.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevGod.SetActive(false);
                    break;

                case 3:
                    GetComponent<GameManager>().DecorationNextGod.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevGod.SetActive(false);
                    break;
            }

            switch (decorationBanner)
            {
                case 0:
                    GetComponent<GameManager>().DecorationNextBanner.SetActive(true);
                    GetComponent<GameManager>().DecorationPrevBanner.SetActive(true);
                    break;

                case 1:
                    GetComponent<GameManager>().DecorationNextBanner.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevBanner.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationNextBanner.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevBanner.SetActive(false);
                    break;
            }

            switch (decorationWeapons)
            {
                case 0:
                    GetComponent<GameManager>().DecorationNextWeapons.SetActive(true);
                    GetComponent<GameManager>().DecorationPrevWeapons.SetActive(true);
                    break;

                case 1:
                    GetComponent<GameManager>().DecorationNextWeapons.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevWeapons.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationNextWeapons.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevWeapons.SetActive(false);
                    break;
            }

            switch (decorationCarpet)
            {
                case 0:
                    GetComponent<GameManager>().DecorationNextCarpet.SetActive(true);
                    GetComponent<GameManager>().DecorationPrevCarpet.SetActive(true);
                    break;

                case 1:
                    GetComponent<GameManager>().DecorationNextCarpet.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevCarpet.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationNextCarpet.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevCarpet.SetActive(false);
                    break;
            }

            switch (decorationShields)
            {
                case 0:
                    GetComponent<GameManager>().DecorationNextShields.SetActive(true);
                    GetComponent<GameManager>().DecorationPrevShields.SetActive(true);
                    break;

                case 1:
                    GetComponent<GameManager>().DecorationNextShields.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevShields.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationNextShields.SetActive(false);
                    GetComponent<GameManager>().DecorationPrevShields.SetActive(false);
                    break;
            }
        }


        if (decorationColor == 1)
        {
            GetComponent<GameManager>().PanelRedQG.SetActive(true);
            GetComponent<GameManager>().PanelBlueQG.SetActive(false);
            GetComponent<GameManager>().PanelYellowQG.SetActive(false);

            GetComponent<GameManager>().DecorationScrollChimney.SetActive(false);
            GetComponent<GameManager>().DecorationScrollGod.SetActive(true);
            GetComponent<GameManager>().DecorationScrollBanner.SetActive(true);
            GetComponent<GameManager>().DecorationScrollWeapons.SetActive(true);
            GetComponent<GameManager>().DecorationScrollCarpet.SetActive(true);
            GetComponent<GameManager>().DecorationScrollShields.SetActive(true);

            switch (decorationGod)
            {
                case 0:
                    GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
                            GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(true);
                        else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
                            GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(true);
                    GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(true);
                    GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(false);
                    break;

                case 3:
                    GetComponent<GameManager>().DecorationRedGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationRedGodOfLife.SetActive(true);
                    break;
            }

            switch (decorationBanner)
            {
                case 0:
                    GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 0)
                            GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(true);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationRedBannerCrowns.SetActive(true);
                    GetComponent<GameManager>().DecorationRedBannerWeapons.SetActive(false);
                    break;
            }

            switch (decorationWeapons)
            {
                case 0:
                    GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 0)
                            GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(true);
                    GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationRedWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationRedWeaponsPrestige.SetActive(true);
                    break;
            }

            switch (decorationCarpet)
            {
                case 0:
                    GetComponent<GameManager>().DecorationRedBear.SetActive(false);
                    GetComponent<GameManager>().DecorationRedCarpet.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
                            GetComponent<GameManager>().DecorationRedBear.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationRedCarpet.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationRedBear.SetActive(true);
                    GetComponent<GameManager>().DecorationRedCarpet.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationRedBear.SetActive(false);
                    GetComponent<GameManager>().DecorationRedCarpet.SetActive(true);
                    break;
            }

            switch (decorationShields)
            {
                case 0:
                    GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 0)
                            GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(true);
                    GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationRedShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationRedShieldsPrestige.SetActive(true);
                    break;
            }
        }
        else if (decorationColor == 2)
        {
            GetComponent<GameManager>().PanelRedQG.SetActive(false);
            GetComponent<GameManager>().PanelBlueQG.SetActive(true);
            GetComponent<GameManager>().PanelYellowQG.SetActive(false);

            GetComponent<GameManager>().DecorationScrollChimney.SetActive(false);
            GetComponent<GameManager>().DecorationScrollGod.SetActive(true);
            GetComponent<GameManager>().DecorationScrollBanner.SetActive(true);
            GetComponent<GameManager>().DecorationScrollWeapons.SetActive(true);
            GetComponent<GameManager>().DecorationScrollCarpet.SetActive(true);
            GetComponent<GameManager>().DecorationScrollShields.SetActive(true);

            switch (decorationGod)
            {
                case 0:
                    GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
                            GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(true);
                        else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
                            GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(true);
                    GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(true);
                    GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(false);
                    break;

                case 3:
                    GetComponent<GameManager>().DecorationBlueGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueGodOfLife.SetActive(true);
                    break;
            }

            switch (decorationBanner)
            {
                case 0:
                    GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 0)
                            GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(true);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationBlueBannerCrowns.SetActive(true);
                    GetComponent<GameManager>().DecorationBlueBannerWeapons.SetActive(false);
                    break;
            }

            switch (decorationWeapons)
            {
                case 0:
                    GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 0)
                            GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(true);
                    GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationBlueWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueWeaponsPrestige.SetActive(true);
                    break;
            }

            switch (decorationCarpet)
            {
                case 0:
                    GetComponent<GameManager>().DecorationBlueBear.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueCarpet.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
                            GetComponent<GameManager>().DecorationBlueBear.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationBlueCarpet.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationBlueBear.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueCarpet.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationBlueBear.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueCarpet.SetActive(false);
                    break;
            }

            switch (decorationShields)
            {
                case 0:
                    GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 0)
                            GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(true);
                    GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationBlueShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationBlueShieldsPrestige.SetActive(true);
                    break;
            }
        }
        else if (decorationColor == 3)
        {
            GetComponent<GameManager>().PanelRedQG.SetActive(false);
            GetComponent<GameManager>().PanelBlueQG.SetActive(false);
            GetComponent<GameManager>().PanelYellowQG.SetActive(true);

            GetComponent<GameManager>().DecorationScrollChimney.SetActive(false);
            GetComponent<GameManager>().DecorationScrollGod.SetActive(true);
            GetComponent<GameManager>().DecorationScrollBanner.SetActive(true);
            GetComponent<GameManager>().DecorationScrollWeapons.SetActive(true);
            GetComponent<GameManager>().DecorationScrollCarpet.SetActive(true);
            GetComponent<GameManager>().DecorationScrollShields.SetActive(true);

            switch (decorationGod)
            {
                case 0:
                    GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
                            GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(true);
                        else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
                            GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(true);
                    GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(true);
                    GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(false);
                    break;

                case 3:
                    GetComponent<GameManager>().DecorationYellowGodOfWar.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfTime.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowGodOfLife.SetActive(true);
                    break;
            }

            switch (decorationBanner)
            {
                case 0:
                    GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 0)
                            GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(true);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationYellowBannerCrowns.SetActive(true);
                    GetComponent<GameManager>().DecorationYellowBannerWeapons.SetActive(false);
                    break;
            }

            switch (decorationWeapons)
            {
                case 0:
                    GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 0)
                            GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(true);
                    GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationYellowWeaponsDamage.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowWeaponsPrestige.SetActive(true);
                    break;
            }

            switch (decorationCarpet)
            {
                case 0:
                    GetComponent<GameManager>().DecorationYellowBear.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowCarpet.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
                            GetComponent<GameManager>().DecorationYellowBear.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationYellowCarpet.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationYellowBear.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowCarpet.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationYellowBear.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowCarpet.SetActive(false);
                    break;
            }

            switch (decorationShields)
            {
                case 0:
                    GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(false);

                    if (isInDecorationPanel == true)
                    {
                        if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 0)
                            GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(true);
                        else
                            GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(true);
                    }

                    break;

                case 1:
                    GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(true);
                    GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(false);
                    break;

                case 2:
                    GetComponent<GameManager>().DecorationYellowShieldsDefense.SetActive(false);
                    GetComponent<GameManager>().DecorationYellowShieldsPrestige.SetActive(true);
                    break;
            }
        }
    }

    public void DecorationCheckScrollBuy(int price)
    {
        if (GetComponent<GameManager>().coins >= price)
        {
            GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
            GetComponent<GameManager>().DecorationScrollBuy.SetActive(true);
        }
        else
        {
            GetComponent<GameManager>().DecorationCoinsText.color = Color.red;
            GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
        }
    }

    public void DecorationSelectScroll(int scroll)
    {
        GetComponent<GameManager>().DecorationScrollSelected = scroll;

        int decorationColor = 0;
        int decorationGod = 0;
        int decorationBanner = 0;
        int decorationWeapons = 0;
        int decorationCarpet = 0;
        int decorationShields = 0;

        if (GetComponent<GameManager>().currSave == 1)
        {
            decorationColor = PlayerPrefs.GetInt("Load1DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load1DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load1DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load1DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load1DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load1DecorationShields");
        }
        else if (GetComponent<GameManager>().currSave == 2)
        {
            decorationColor = PlayerPrefs.GetInt("Load2DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load2DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load2DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load2DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load2DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load2DecorationShields");
        }
        else
        {
            decorationColor = PlayerPrefs.GetInt("Load3DecorationColor");
            decorationGod = PlayerPrefs.GetInt("Load3DecorationGod");
            decorationBanner = PlayerPrefs.GetInt("Load3DecorationBanner");
            decorationWeapons = PlayerPrefs.GetInt("Load3DecorationWeapons");
            decorationCarpet = PlayerPrefs.GetInt("Load3DecorationCarpet");
            decorationShields = PlayerPrefs.GetInt("Load3DecorationShields");
        }

        if (scroll == 0)
        {
            DecorationCheckScrollBuy(20);

            if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 0)
            {
                GetComponent<GameManager>().DecorationTextChimney.text = GetComponent<TradManager>().GetDecorationTitleChimney1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionChimney1();
            }
            else if (GetComponent<GameManager>().DecorationCurrentChimneySelected == 1)
            {
                GetComponent<GameManager>().DecorationTextChimney.text = GetComponent<TradManager>().GetDecorationTitleChimney2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionChimney2();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextChimney.text = GetComponent<TradManager>().GetDecorationTitleChimney3();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionChimney3();
            }
        }
        else if (scroll == 1)
        {
            if (decorationGod != 0)
            {
                GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
                GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
            }

            if (decorationGod == 0)
            {
                if (GetComponent<GameManager>().DecorationCurrentGodSelected == 0)
                {
                    DecorationCheckScrollBuy(30);
                    GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod1();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod1();
                }
                else if (GetComponent<GameManager>().DecorationCurrentGodSelected == 1)
                {
                    DecorationCheckScrollBuy(50);
                    GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod2();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod2();
                }
                else
                {
                    DecorationCheckScrollBuy(40);
                    GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod3();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod3();
                }
            }
            else if (decorationGod == 1)
            {
                GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod1();
            }
            else if (decorationGod == 2)
            {
                GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod2();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextGod.text = GetComponent<TradManager>().GetDecorationTitleGod3();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionGod3();
            }
        }
        else if (scroll == 2)
        {
            if (decorationBanner != 0)
            {
                GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
                GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
            }

            if (decorationBanner == 0)
            {
                DecorationCheckScrollBuy(30);

                if (GetComponent<GameManager>().DecorationCurrentBannerSelected == 0)
                {
                    GetComponent<GameManager>().DecorationTextBanner.text = GetComponent<TradManager>().GetDecorationTitleBanner1();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionBanner1();
                }
                else
                {
                    GetComponent<GameManager>().DecorationTextBanner.text = GetComponent<TradManager>().GetDecorationTitleBanner2();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionBanner2();
                }
            }
            else if (decorationBanner == 1)
            {
                GetComponent<GameManager>().DecorationTextBanner.text = GetComponent<TradManager>().GetDecorationTitleBanner1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionBanner1();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextBanner.text = GetComponent<TradManager>().GetDecorationTitleBanner2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionBanner2();
            }
        }
        else if (scroll == 3)
        {
            if (decorationWeapons != 0)
            {
                GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
                GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
            }

            if (decorationWeapons == 0)
            {
                DecorationCheckScrollBuy(30);

                if (GetComponent<GameManager>().DecorationCurrentWeaponsSelected == 0)
                {
                    GetComponent<GameManager>().DecorationTextWeapons.text = GetComponent<TradManager>().GetDecorationTitleEquipment1();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionEquipment1();
                }
                else
                {
                    GetComponent<GameManager>().DecorationTextWeapons.text = GetComponent<TradManager>().GetDecorationTitleEquipment2();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionEquipment2();
                }
            }
            else if (decorationWeapons == 1)
            {
                GetComponent<GameManager>().DecorationTextWeapons.text = GetComponent<TradManager>().GetDecorationTitleEquipment1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionEquipment1();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextWeapons.text = GetComponent<TradManager>().GetDecorationTitleEquipment2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionEquipment2();
            }
        }
        else if (scroll == 4)
        {
            if (decorationCarpet != 0)
            {
                GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
                GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
            }

            if (decorationCarpet == 0)
            {
                if (GetComponent<GameManager>().DecorationCurrentCarpetSelected == 0)
                {
                    DecorationCheckScrollBuy(20);
                    GetComponent<GameManager>().DecorationTextCarpet.text = GetComponent<TradManager>().GetDecorationTitleCarpet1();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionCarpet1();
                }
                else
                {
                    DecorationCheckScrollBuy(30);
                    GetComponent<GameManager>().DecorationTextCarpet.text = GetComponent<TradManager>().GetDecorationTitleCarpet2();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionCarpet2();
                }
            }
            else if (decorationCarpet == 1)
            {
                GetComponent<GameManager>().DecorationTextCarpet.text = GetComponent<TradManager>().GetDecorationTitleCarpet1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionCarpet1();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextCarpet.text = GetComponent<TradManager>().GetDecorationTitleCarpet2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionCarpet2();
            }
        }
        else if (scroll == 5)
        {
            if (decorationShields != 0)
            {
                GetComponent<GameManager>().DecorationCoinsText.color = colorBlack;
                GetComponent<GameManager>().DecorationScrollBuy.SetActive(false);
            }

            if (decorationShields == 0)
            {
                DecorationCheckScrollBuy(30);

                if (GetComponent<GameManager>().DecorationCurrentShieldsSelected == 0)
                {
                    GetComponent<GameManager>().DecorationTextShields.text = GetComponent<TradManager>().GetDecorationTitleShields1();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionShields1();
                }
                else
                {
                    GetComponent<GameManager>().DecorationTextShields.text = GetComponent<TradManager>().GetDecorationTitleShields2();
                    GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionShields2();
                }
            }
            else if (decorationShields == 1)
            {
                GetComponent<GameManager>().DecorationTextShields.text = GetComponent<TradManager>().GetDecorationTitleShields1();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionShields1();
            }
            else
            {
                GetComponent<GameManager>().DecorationTextShields.text = GetComponent<TradManager>().GetDecorationTitleShields2();
                GetComponent<GameManager>().DecorationDescriptionText.text = GetComponent<TradManager>().GetDecorationDescriptionShields2();
            }
        }
    }

    public void ReturnToIntro()
    {
        GetComponent<GameManager>().panelSave.SetActive(false);
        GetComponent<GameManager>().panelIntro.SetActive(true);
        StartCoroutine(AnimationPanelIntro());
    }

    public void SwitchWASD()
    {
        if (GetComponent<GameManager>().zqsdMode == false)
        {
            PlayerPrefs.SetInt("ZQSDMode", 1);
            PlayerPrefs.SetInt("ZQSDModeSet", 1);
            GetComponent<GameManager>().zqsdMode = true;
            GetComponent<GameManager>().zqsdModeButton.GetComponent<Image>().sprite = boxChecked;
            GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "A";
        }
        else
        {
            PlayerPrefs.SetInt("ZQSDMode", 0);
            PlayerPrefs.SetInt("ZQSDModeSet", 1);
            GetComponent<GameManager>().zqsdMode = false;
            GetComponent<GameManager>().zqsdModeButton.GetComponent<Image>().sprite = boxNotChecked;
            GetComponent<GameManager>().healthPotionHotkeyText.GetComponent<Text>().text = "Q";
        }
    }

    public void SwitchLanguage()
    {
        if (GetComponent<GameManager>().englishLanguage == false)
        {
            PlayerPrefs.SetInt("LanguageMode", 1);
            PlayerPrefs.SetInt("LanguageModeSet", 1);
            GetComponent<GameManager>().englishLanguage = true;
            GetComponent<GameManager>().LanguageButton.GetComponent<Image>().sprite = englishSprite;
            GetComponent<TradManager>().ResetTexts();
        }
        else
        {
            PlayerPrefs.SetInt("LanguageMode", 0);
            PlayerPrefs.SetInt("LanguageModeSet", 1);
            GetComponent<GameManager>().englishLanguage = false;
            GetComponent<GameManager>().LanguageButton.GetComponent<Image>().sprite = frenchSprite;
            GetComponent<TradManager>().ResetTexts();
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
        LoadAgentsInRoster();

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetString("Load1Mage") == "Elemental") ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetString("Load2Mage") == "Elemental") ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetString("Load3Mage") == "Elemental"))
            GetComponent<GameManager>().currMageType = 1;
        else if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetString("Load1Mage") == "Demonic") ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetString("Load2Mage") == "Demonic") ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetString("Load3Mage") == "Demonic"))
            GetComponent<GameManager>().currMageType = 2;
        else
            GetComponent<GameManager>().currMageType = 3;

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
        GetComponent<GameManager>().volumeMusicSlider.SetActive(false);
        GetComponent<GameManager>().volumeMusicText.SetActive(false);
        GetComponent<GameManager>().scrollOptions5.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().volumeSFXSlider.SetActive(false);
        GetComponent<GameManager>().volumeSFXText.SetActive(false);
        GetComponent<GameManager>().scrollOptions6.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().zqsdModeButton.SetActive(false);
        GetComponent<GameManager>().zqsdModeText.SetActive(false);
        GetComponent<GameManager>().scrollOptions7.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().optionsReturnText.SetActive(false);
        GetComponent<GameManager>().scrollOptions8.GetComponent<Animator>().SetBool("StartAnim", true);
        GetComponent<GameManager>().LanguageButton.SetActive(false);
        GetComponent<GameManager>().LanguageText.SetActive(false);
    }

    public void EndAnimationPanelOptions()
    {
        GetComponent<GameManager>().smartCastIcon.SetActive(true);
        GetComponent<GameManager>().smartCastText.SetActive(true);
        GetComponent<GameManager>().bloodlessIcon.SetActive(true);
        GetComponent<GameManager>().bloodlessText.SetActive(true);
        GetComponent<GameManager>().showSpellsInfoIcon.SetActive(true);
        GetComponent<GameManager>().showSpellsInfoText.SetActive(true);
        GetComponent<GameManager>().volumeMusicSlider.SetActive(true);
        GetComponent<GameManager>().volumeMusicText.SetActive(true);
        GetComponent<GameManager>().volumeSFXSlider.SetActive(true);
        GetComponent<GameManager>().volumeSFXText.SetActive(true);
        GetComponent<GameManager>().zqsdModeButton.SetActive(true);
        GetComponent<GameManager>().zqsdModeText.SetActive(true);
        GetComponent<GameManager>().optionsReturnText.SetActive(true);
        GetComponent<GameManager>().LanguageButton.SetActive(true);
        GetComponent<GameManager>().LanguageText.SetActive(true);
    }

    public void LoadAgentsInRoster()
    {
        GetComponent<GameManager>().tabFreeAgents.Clear();
        GetComponent<GameManager>().rosterAgents.Clear();
        GetComponent<GameManager>().tabAgents[0] = null;
        GetComponent<GameManager>().tabAgents[1] = null;
        GetComponent<GameManager>().tabAgents[2] = null;

        GetComponent<GameManager>().tabFreeAgents.Add(GetComponent<GameManager>().agentID0);
        GetComponent<GameManager>().tabFreeAgents.Add(GetComponent<GameManager>().agentID1);
        GetComponent<GameManager>().tabFreeAgents.Add(GetComponent<GameManager>().agentID2);

        int counter = 0;

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent1Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent1Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent1Roster") == 1))
        {
            GetComponent<GameManager>().rosterAgents.Add(GetComponent<GameManager>().tabFreeAgents[0 - counter]);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent1Team") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent1Team") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent1Team") == 1))
            {
                if (GetComponent<GameManager>().tabAgents[0] == null)
                    GetComponent<GameManager>().tabAgents[0] = GetComponent<GameManager>().tabFreeAgents[0 - counter];
                else if (GetComponent<GameManager>().tabAgents[1] == null)
                    GetComponent<GameManager>().tabAgents[1] = GetComponent<GameManager>().tabFreeAgents[0 - counter];
                else
                    GetComponent<GameManager>().tabAgents[2] = GetComponent<GameManager>().tabFreeAgents[0 - counter];
            }

            GetComponent<GameManager>().tabFreeAgents.Remove(GetComponent<GameManager>().tabFreeAgents[0 - counter]);

            counter++;
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent2Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent2Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent2Roster") == 1))
        {
            GetComponent<GameManager>().rosterAgents.Add(GetComponent<GameManager>().tabFreeAgents[1 - counter]);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent2Team") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent2Team") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent2Team") == 1))
            {
                if (GetComponent<GameManager>().tabAgents[0] == null)
                    GetComponent<GameManager>().tabAgents[0] = GetComponent<GameManager>().tabFreeAgents[1 - counter];
                else if (GetComponent<GameManager>().tabAgents[1] == null)
                    GetComponent<GameManager>().tabAgents[1] = GetComponent<GameManager>().tabFreeAgents[1 - counter];
                else
                    GetComponent<GameManager>().tabAgents[2] = GetComponent<GameManager>().tabFreeAgents[1 - counter];
            }

            GetComponent<GameManager>().tabFreeAgents.Remove(GetComponent<GameManager>().tabFreeAgents[1 - counter]);

            counter++;
        }

        if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent3Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent3Roster") == 1) ||
            (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent3Roster") == 1))
        {
            GetComponent<GameManager>().rosterAgents.Add(GetComponent<GameManager>().tabFreeAgents[2 - counter]);

            if ((GetComponent<GameManager>().currSave == 1 && PlayerPrefs.GetInt("Load1Agent3Team") == 1) ||
                (GetComponent<GameManager>().currSave == 2 && PlayerPrefs.GetInt("Load2Agent3Team") == 1) ||
                (GetComponent<GameManager>().currSave == 3 && PlayerPrefs.GetInt("Load3Agent3Team") == 1))
            {
                if (GetComponent<GameManager>().tabAgents[0] == null)
                    GetComponent<GameManager>().tabAgents[0] = GetComponent<GameManager>().tabFreeAgents[2 - counter];
                else if (GetComponent<GameManager>().tabAgents[1] == null)
                    GetComponent<GameManager>().tabAgents[1] = GetComponent<GameManager>().tabFreeAgents[2 - counter];
                else
                    GetComponent<GameManager>().tabAgents[2] = GetComponent<GameManager>().tabFreeAgents[2 - counter];
            }

            GetComponent<GameManager>().tabFreeAgents.Remove(GetComponent<GameManager>().tabFreeAgents[2 - counter]);

            counter++;
        }
    }

    public void OpenNews()
    {
        Application.OpenURL("https://www.facebook.com/HeroicMercenaries/");
    }

    public void OpenCredits()
    {
        GetComponent<GameManager>().PanelCredits.SetActive(true);
    }

    public void CloseCredits()
    {
        GetComponent<GameManager>().PanelCredits.SetActive(false);
        ReturnToIntro();
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
                GetComponent<GameManager>().coins = PlayerPrefs.GetInt("Load1Coins");
                GetComponent<GameManager>().prestige = PlayerPrefs.GetInt("Load1Prestige");

                if (PlayerPrefs.GetString("Load1Rune") == "Damage")
                    GetComponent<GameManager>().runeSelected = 0;
                else if (PlayerPrefs.GetString("Load1Rune") == "Celerity")
                    GetComponent<GameManager>().runeSelected = 1;
                else
                    GetComponent<GameManager>().runeSelected = 2;

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
            PlayerPrefs.SetInt("Load1Coins", 0);
            PlayerPrefs.SetInt("Load1Prestige", 0);
            PlayerPrefs.SetInt("Load1PlayerLevel", 1);
            PlayerPrefs.SetInt("Load1PlayerActionPoints", 0);
            GetComponent<GameManager>().coins = 0;
            GetComponent<GameManager>().prestige = 0;

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
        PlayerPrefs.SetInt("Load1Coins", 0);
        PlayerPrefs.SetInt("Load1Prestige", 0);
        GetComponent<GameManager>().coins = 0;
        GetComponent<GameManager>().prestige = 0;

        PlayerPrefs.SetInt("Load1Agent1Level", 0);
        PlayerPrefs.SetInt("Load1Agent1XP", 0);
        PlayerPrefs.SetInt("Load1Agent1Roster", 0);
        PlayerPrefs.SetInt("Load1Agent1Team", 0);
        PlayerPrefs.SetInt("Load1Agent2Level", 0);
        PlayerPrefs.SetInt("Load1Agent2XP", 0);
        PlayerPrefs.SetInt("Load1Agent2Roster", 0);
        PlayerPrefs.SetInt("Load1Agent2Team", 0);
        PlayerPrefs.SetInt("Load1Agent3Level", 0);
        PlayerPrefs.SetInt("Load1Agent3XP", 0);
        PlayerPrefs.SetInt("Load1Agent3Roster", 0);
        PlayerPrefs.SetInt("Load1Agent3Team", 0);

        PlayerPrefs.SetInt("Load1DifficultySet", 0);
        PlayerPrefs.SetInt("Load1MageSet", 0);

        PlayerPrefs.SetInt("Load1Spell1_2", 0);
        PlayerPrefs.SetInt("Load1Spell1_3", 0);

        PlayerPrefs.SetInt("Load1Spell2_2", 0);
        PlayerPrefs.SetInt("Load1Spell2_3", 0);

        PlayerPrefs.SetInt("Load1Spell3_2", 0);
        PlayerPrefs.SetInt("Load1Spell3_3", 0);

        PlayerPrefs.SetInt("Load1Spell4_2", 0);
        PlayerPrefs.SetInt("Load1Spell4_3", 0);

        PlayerPrefs.SetInt("Load1Spell5_2", 0);
        PlayerPrefs.SetInt("Load1Spell5_3", 0);

        PlayerPrefs.SetInt("Load1Spell6_2", 0);
        PlayerPrefs.SetInt("Load1Spell6_3", 0);

        PlayerPrefs.SetInt("Load1Passive1_1", 0);
        PlayerPrefs.SetInt("Load1Passive1_2", 0);
        PlayerPrefs.SetInt("Load1Passive1_3", 0);

        PlayerPrefs.SetInt("Load1Passive2_1", 0);
        PlayerPrefs.SetInt("Load1Passive2_2", 0);
        PlayerPrefs.SetInt("Load1Passive2_3", 0);

        PlayerPrefs.SetInt("Load1Passive3_1", 0);
        PlayerPrefs.SetInt("Load1Passive3_2", 0);
        PlayerPrefs.SetInt("Load1Passive3_3", 0);

        PlayerPrefs.SetInt("Load1Passive4_1", 0);
        PlayerPrefs.SetInt("Load1Passive4_2", 0);
        PlayerPrefs.SetInt("Load1Passive4_3", 0);

        PlayerPrefs.SetInt("Load1Passive5_1", 0);
        PlayerPrefs.SetInt("Load1Passive5_2", 0);
        PlayerPrefs.SetInt("Load1Passive5_3", 0);

        PlayerPrefs.SetInt("Load1Passive6_1", 0);
        PlayerPrefs.SetInt("Load1Passive6_2", 0);
        PlayerPrefs.SetInt("Load1Passive6_3", 0);

        PlayerPrefs.SetInt("Load1DecorationColor", 0);
        PlayerPrefs.SetInt("Load1DecorationGod", 0);
        PlayerPrefs.SetInt("Load1DecorationBanner", 0);
        PlayerPrefs.SetInt("Load1DecorationWeapons", 0);
        PlayerPrefs.SetInt("Load1DecorationCarpet", 0);
        PlayerPrefs.SetInt("Load1DecorationShields", 0);

        GetComponent<GameManager>().load1Created = false;
        GetComponent<GameManager>().load1Name.GetComponent<Text>().text = GetComponent<TradManager>().GetTextEmptySave();
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
                GetComponent<GameManager>().coins = PlayerPrefs.GetInt("Load2Coins");
                GetComponent<GameManager>().prestige = PlayerPrefs.GetInt("Load2Prestige");

                if (PlayerPrefs.GetString("Load2Rune") == "Damage")
                    GetComponent<GameManager>().runeSelected = 0;
                else if (PlayerPrefs.GetString("Load2Rune") == "Celerity")
                    GetComponent<GameManager>().runeSelected = 1;
                else
                    GetComponent<GameManager>().runeSelected = 2;

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
            PlayerPrefs.SetInt("Load2Coins", 0);
            PlayerPrefs.SetInt("Load2Prestige", 0);
            PlayerPrefs.SetInt("Load2PlayerLevel", 1);
            PlayerPrefs.SetInt("Load2PlayerActionPoints", 0);
            GetComponent<GameManager>().coins = 0;
            GetComponent<GameManager>().prestige = 0;

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
        PlayerPrefs.SetInt("Load2Coins", 0);
        PlayerPrefs.SetInt("Load2Prestige", 0);
        GetComponent<GameManager>().coins = 0;
        GetComponent<GameManager>().prestige = 0;

        PlayerPrefs.SetInt("Load2Agent1Level", 0);
        PlayerPrefs.SetInt("Load2Agent1XP", 0);
        PlayerPrefs.SetInt("Load2Agent1Roster", 0);
        PlayerPrefs.SetInt("Load2Agent1Team", 0);
        PlayerPrefs.SetInt("Load2Agent2Level", 0);
        PlayerPrefs.SetInt("Load2Agent2XP", 0);
        PlayerPrefs.SetInt("Load2Agent2Roster", 0);
        PlayerPrefs.SetInt("Load2Agent2Team", 0);
        PlayerPrefs.SetInt("Load2Agent3Level", 0);
        PlayerPrefs.SetInt("Load2Agent3XP", 0);
        PlayerPrefs.SetInt("Load2Agent3Roster", 0);
        PlayerPrefs.SetInt("Load2Agent3Team", 0);

        PlayerPrefs.SetInt("Load2DifficultySet", 0);
        PlayerPrefs.SetInt("Load2MageSet", 0);

        PlayerPrefs.SetInt("Load2Spell1_2", 0);
        PlayerPrefs.SetInt("Load2Spell1_3", 0);

        PlayerPrefs.SetInt("Load2Spell2_2", 0);
        PlayerPrefs.SetInt("Load2Spell2_3", 0);

        PlayerPrefs.SetInt("Load2Spell3_2", 0);
        PlayerPrefs.SetInt("Load2Spell3_3", 0);

        PlayerPrefs.SetInt("Load2Spell4_2", 0);
        PlayerPrefs.SetInt("Load2Spell4_3", 0);

        PlayerPrefs.SetInt("Load2Spell5_2", 0);
        PlayerPrefs.SetInt("Load2Spell5_3", 0);

        PlayerPrefs.SetInt("Load2Spell6_2", 0);
        PlayerPrefs.SetInt("Load2Spell6_3", 0);

        PlayerPrefs.SetInt("Load2Passive1_1", 0);
        PlayerPrefs.SetInt("Load2Passive1_2", 0);
        PlayerPrefs.SetInt("Load2Passive1_3", 0);

        PlayerPrefs.SetInt("Load2Passive2_1", 0);
        PlayerPrefs.SetInt("Load2Passive2_2", 0);
        PlayerPrefs.SetInt("Load2Passive2_3", 0);

        PlayerPrefs.SetInt("Load2Passive3_1", 0);
        PlayerPrefs.SetInt("Load2Passive3_2", 0);
        PlayerPrefs.SetInt("Load2Passive3_3", 0);

        PlayerPrefs.SetInt("Load2Passive4_1", 0);
        PlayerPrefs.SetInt("Load2Passive4_2", 0);
        PlayerPrefs.SetInt("Load2Passive4_3", 0);

        PlayerPrefs.SetInt("Load2Passive5_1", 0);
        PlayerPrefs.SetInt("Load2Passive5_2", 0);
        PlayerPrefs.SetInt("Load2Passive5_3", 0);

        PlayerPrefs.SetInt("Load2Passive6_1", 0);
        PlayerPrefs.SetInt("Load2Passive6_2", 0);
        PlayerPrefs.SetInt("Load2Passive6_3", 0);

        PlayerPrefs.SetInt("Load2DecorationColor", 0);
        PlayerPrefs.SetInt("Load2DecorationGod", 0);
        PlayerPrefs.SetInt("Load2DecorationBanner", 0);
        PlayerPrefs.SetInt("Load2DecorationWeapons", 0);
        PlayerPrefs.SetInt("Load2DecorationCarpet", 0);
        PlayerPrefs.SetInt("Load2DecorationShields", 0);

        GetComponent<GameManager>().load2Created = false;
        GetComponent<GameManager>().load2Name.GetComponent<Text>().text = GetComponent<TradManager>().GetTextEmptySave();
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
                GetComponent<GameManager>().coins = PlayerPrefs.GetInt("Load3Coins");
                GetComponent<GameManager>().prestige = PlayerPrefs.GetInt("Load3Prestige");

                if (PlayerPrefs.GetString("Load3Rune") == "Damage")
                    GetComponent<GameManager>().runeSelected = 0;
                else if (PlayerPrefs.GetString("Load3Rune") == "Celerity")
                    GetComponent<GameManager>().runeSelected = 1;
                else
                    GetComponent<GameManager>().runeSelected = 2;

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
            PlayerPrefs.SetInt("Load3Coins", 0);
            PlayerPrefs.SetInt("Load3Prestige", 0);
            PlayerPrefs.SetInt("Load3PlayerLevel", 1);
            PlayerPrefs.SetInt("Load3PlayerActionPoints", 0);
            GetComponent<GameManager>().coins = 0;
            GetComponent<GameManager>().prestige = 0;

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
        PlayerPrefs.SetInt("Load3Coins", 0);
        PlayerPrefs.SetInt("Load3Prestige", 0);
        GetComponent<GameManager>().coins = 0;
        GetComponent<GameManager>().prestige = 0;

        PlayerPrefs.SetInt("Load3Agent1Level", 0);
        PlayerPrefs.SetInt("Load3Agent1XP", 0);
        PlayerPrefs.SetInt("Load3Agent1Roster", 0);
        PlayerPrefs.SetInt("Load3Agent1Team", 0);
        PlayerPrefs.SetInt("Load3Agent2Level", 0);
        PlayerPrefs.SetInt("Load3Agent2XP", 0);
        PlayerPrefs.SetInt("Load3Agent2Roster", 0);
        PlayerPrefs.SetInt("Load3Agent2Team", 0);
        PlayerPrefs.SetInt("Load3Agent3Level", 0);
        PlayerPrefs.SetInt("Load3Agent3XP", 0);
        PlayerPrefs.SetInt("Load3Agent3Roster", 0);
        PlayerPrefs.SetInt("Load3Agent3Team", 0);

        PlayerPrefs.SetInt("Load3DifficultySet", 0);
        PlayerPrefs.SetInt("Load3MageSet", 0);

        PlayerPrefs.SetInt("Load3Spell1_2", 0);
        PlayerPrefs.SetInt("Load3Spell1_3", 0);

        PlayerPrefs.SetInt("Load3Spell2_2", 0);
        PlayerPrefs.SetInt("Load3Spell2_3", 0);

        PlayerPrefs.SetInt("Load3Spell3_2", 0);
        PlayerPrefs.SetInt("Load3Spell3_3", 0);

        PlayerPrefs.SetInt("Load3Spell4_2", 0);
        PlayerPrefs.SetInt("Load3Spell4_3", 0);

        PlayerPrefs.SetInt("Load3Spell5_2", 0);
        PlayerPrefs.SetInt("Load3Spell5_3", 0);

        PlayerPrefs.SetInt("Load3Spell6_2", 0);
        PlayerPrefs.SetInt("Load3Spell6_3", 0);

        PlayerPrefs.SetInt("Load3Passive1_1", 0);
        PlayerPrefs.SetInt("Load3Passive1_2", 0);
        PlayerPrefs.SetInt("Load3Passive1_3", 0);

        PlayerPrefs.SetInt("Load3Passive2_1", 0);
        PlayerPrefs.SetInt("Load3Passive2_2", 0);
        PlayerPrefs.SetInt("Load3Passive2_3", 0);

        PlayerPrefs.SetInt("Load3Passive3_1", 0);
        PlayerPrefs.SetInt("Load3Passive3_2", 0);
        PlayerPrefs.SetInt("Load3Passive3_3", 0);

        PlayerPrefs.SetInt("Load3Passive4_1", 0);
        PlayerPrefs.SetInt("Load3Passive4_2", 0);
        PlayerPrefs.SetInt("Load3Passive4_3", 0);

        PlayerPrefs.SetInt("Load3Passive5_1", 0);
        PlayerPrefs.SetInt("Load3Passive5_2", 0);
        PlayerPrefs.SetInt("Load3Passive5_3", 0);

        PlayerPrefs.SetInt("Load3Passive6_1", 0);
        PlayerPrefs.SetInt("Load3Passive6_2", 0);
        PlayerPrefs.SetInt("Load3Passive6_3", 0);

        PlayerPrefs.SetInt("Load3DecorationColor", 0);
        PlayerPrefs.SetInt("Load3DecorationGod", 0);
        PlayerPrefs.SetInt("Load3DecorationBanner", 0);
        PlayerPrefs.SetInt("Load3DecorationWeapons", 0);
        PlayerPrefs.SetInt("Load3DecorationCarpet", 0);
        PlayerPrefs.SetInt("Load3DecorationShields", 0);

        GetComponent<GameManager>().load3Created = false;
        GetComponent<GameManager>().load3Name.GetComponent<Text>().text = GetComponent<TradManager>().GetTextEmptySave();
    }
}
