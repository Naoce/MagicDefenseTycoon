using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shoots : MonoBehaviour 
{
    public enum Direction
    {
        TOP,
        TOPRIGHT,
        TOPLEFT,
        BOTTOM,
        BOTTOMRIGHT,
        BOTTOMLEFT,
        LEFT,
        RIGHT
    };

	private GameObject	cam;
    public  GameObject  rangeIndicator;
	public  GameObject	fireball;
    public  GameObject  fireballSFX;
    public  GameObject  thunderbolt;
    public  GameObject  thunderboltBase;
    public  GameObject  thunderboltSFX;
    public  GameObject  tornado;
    public  GameObject  tornadoBase;
    public  GameObject  tornadoSFX;
    public  GameObject  iceShard;
    public  GameObject  iceShardSFX;
    public  GameObject  meteor;
    public  GameObject  meteorSFX;
    public  GameObject  icePrison;
    public  GameObject  icePrisonSFX;
    public  GameObject  earthquake;
    public  GameObject  earthquakeSFX;
    public  GameObject  dragonG;
    public  GameObject  dragonD;
    public  GameObject  dragonSFX;
    public  GameObject  potionHealthSFX;
    public  GameObject  potionManaSFX;
    private GameObject  gm;
    private GameObject  mapManager;
    public  GameObject  usingSpell1Icon;
    public  GameObject  usingSpell2Icon;
    public  GameObject  usingSpell3Icon;
    public  GameObject  usingSpell4Icon;
    public  GameObject  usingSpell5Icon;
    public  GameObject  usingSpell6Icon;
    public  GameObject  usingSpell7Icon;
    public  GameObject  usingSpell8Icon;
    public  int         usingSpellInt;

    private Vector2 	newPos = new Vector2(0, 0);
	private Quaternion 	rot = new Quaternion (0, 0, 0, 0);
    private float       projectileRotation = 0f;

    private float       speedCD = 1f;
    public  bool        canShoot = true;
    private float       manaTimer = 0f;
    private bool        isUnderMana = false;
    private float       timerAttack = 0f;
    private float       timerSpell2 = 0f;
    private float       timerSpell3 = 0f;
    private float       timerSpell4 = 0f;
    private float       timerSpell5 = 0f;
    private float       timerSpell6 = 0f;
    private float       timerSpell7 = 0f;
    private float       timerSpell8 = 0f;
    private float       timerObject1 = 0f;
    private float       timerObject2 = 0f;
    private float       timerObject3 = 0f;

    public  float       cooldownAttack;
    public  float       cooldownSpell2;
    public  float       cooldownSpell3;
    public  float       cooldownSpell4;
    public  float       cooldownSpell5;
    public  float       cooldownSpell6;
    public  float       cooldownSpell7;
    public  float       cooldownSpell8;
    public  float       cooldownObject1;
    public  float       cooldownObject2;
    public  float       cooldownObject3;
    public  float       cooldownManaEffect;

    public  int         damageSpell1;
    public  int         damageSpell2;
    public  int         damageSpell3;
    public  int         damageSpell4;
    public  int         damageSpell5;
    public  int         damageSpell6;
    public  int         damageSpell7;
    public  int         damageSpell8;

    public  float       rangeSpell1;
    public  float       rangeSpell2;
    public  float       rangeSpell3;
    public  float       rangeSpell4;
    public  float       rangeSpell5;
    public  float       rangeSpell6;
    public  float       rangeSpell7;
    public  float       rangeSpell8;

    public  int         decorationBonusDamage;
    public  int         decorationBonusTanking;
    public  float       decorationBonusEffectDuration;
    public  int         decorationBonusHealing;

    public  int         numberShards;

    public  int         retaliateDamage;
    public  bool        canRetaliateShield;
    public  float       retaliateFreeze;
    public  bool        canFreezeShield;
    public  float       movementBonus;
    public  bool        canGainMovementSpeed;
    public  int         thunderboltStacksBonus;
    public  bool        canStackThunderbolt;

    private bool        spell1Ready = true;
    private bool        spell2Ready = true;
    private bool        spell3Ready = true;
    private bool        spell4Ready = true;
    private bool        spell5Ready = true;
    private bool        spell6Ready = true;
    private bool        spell7Ready = true;
    private bool        spell8Ready = true;
    private bool        object1Ready = true;
    private bool        object2Ready = true;

    public  int         spellSelected = 1;

    private GameObject  cdSpell1;
    private GameObject  cdSpell2;
    private GameObject  cdSpell3;
    private GameObject  cdSpell4;
    private GameObject  cdSpell5;
    private GameObject  cdSpell6;
    private GameObject  cdSpell7;
    private GameObject  cdSpell8;
    private GameObject  cdObject1;
    private GameObject  cdObject2;
    private GameObject  cdObject3;

    private bool        hasRuneCooldown;
    private bool        isRuneDamage;
    public  bool        isRuneCelerity;
    private bool        isRuneHeal;
    private bool        nextSpellDamageRune = false;
    private int         idSpell8 = 0;
    private int         idSpell5 = 0;


    void Start()
    {
        gm = GameObject.Find("GameManager");
        mapManager = GameObject.Find("MapManager");
        cam = GameObject.Find("Main Camera");

        usingSpell1Icon = gm.GetComponent<GameManager>().usingSpell1Icon;
        usingSpell2Icon = gm.GetComponent<GameManager>().usingSpell2Icon;
        usingSpell3Icon = gm.GetComponent<GameManager>().usingSpell3Icon;
        usingSpell4Icon = gm.GetComponent<GameManager>().usingSpell4Icon;
        usingSpell5Icon = gm.GetComponent<GameManager>().usingSpell5Icon;
        usingSpell6Icon = gm.GetComponent<GameManager>().usingSpell6Icon;
        usingSpell7Icon = gm.GetComponent<GameManager>().usingSpell7Icon;
        usingSpell8Icon = gm.GetComponent<GameManager>().usingSpell8Icon;

        usingSpell1Icon.SetActive(true);
        usingSpell1Icon.GetComponent<UsingSpell>().player = gameObject;

        cdSpell1 = gm.GetComponent<GameManager>().cdSpell1;
        cdSpell2 = gm.GetComponent<GameManager>().cdSpell2;
        cdSpell3 = gm.GetComponent<GameManager>().cdSpell3;
        cdSpell4 = gm.GetComponent<GameManager>().cdSpell4;
        cdSpell5 = gm.GetComponent<GameManager>().cdSpell5;
        cdSpell6 = gm.GetComponent<GameManager>().cdSpell6;
        cdSpell7 = gm.GetComponent<GameManager>().cdSpell7;
        cdSpell8 = gm.GetComponent<GameManager>().cdSpell8;
        cdObject1 = gm.GetComponent<GameManager>().cdObject1;
        cdObject2 = gm.GetComponent<GameManager>().cdObject2;
        cdObject3 = gm.GetComponent<GameManager>().cdObject3;

        cdSpell1.GetComponent<Slider>().value = 0;
        cdSpell2.GetComponent<Slider>().value = 0;
        cdSpell3.GetComponent<Slider>().value = 0;
        cdSpell4.GetComponent<Slider>().value = 0;
        cdSpell5.GetComponent<Slider>().value = 0;
        cdSpell6.GetComponent<Slider>().value = 0;
        cdSpell7.GetComponent<Slider>().value = 0;
        cdSpell8.GetComponent<Slider>().value = 0;
        cdObject1.GetComponent<Slider>().value = 0;
        cdObject2.GetComponent<Slider>().value = 0;
        cdObject3.GetComponent<Slider>().value = 0;

        if (gm.GetComponent<GameManager>().runeSelected == 0)
        {
            hasRuneCooldown = true;
            cooldownObject3 = 10;
            isRuneDamage = true;
            isRuneCelerity = false;
            isRuneHeal = false;
        }
        else if (gm.GetComponent<GameManager>().runeSelected == 1)
        {
            hasRuneCooldown = false;
            isRuneDamage = false;
            isRuneCelerity = true;
            isRuneHeal = false;
        }
        else
        {
            hasRuneCooldown = true;
            cooldownObject3 = 15;
            isRuneDamage = false;
            isRuneCelerity = false;
            isRuneHeal = true;
        }

        rangeSpell1 = 3f;
        rangeSpell3 = 3f;
        rangeSpell4 = 3f;

        decorationBonusEffectDuration = 1f;

        GetComponent<Deplacements>().movementBonus = 1f;
        movementBonus = 0f;

        if (gm.GetComponent<GameManager>().currSave == 1)
        {
            if (PlayerPrefs.GetInt("Load1Spell1_3") == 1)
            {
                damageSpell1 = 8;
                cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell1_2") == 1)
            {
                damageSpell1 = 6;
                cooldownAttack = 0.75f;
            }
            else
            {
                damageSpell1 = 5;
                cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load1Spell2_3") == 1)
            {
                damageSpell2 = 12;
                rangeSpell2 = 3f;
                cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell2_2") == 1)
            {
                damageSpell2 = 10;
                rangeSpell2 = 3f;
                cooldownSpell2 = 4f;
            }
            else
            {
                damageSpell2 = 8;
                rangeSpell2 = 2f;
                cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load1Spell3_3") == 1)
            {
                damageSpell3 = 3;
                cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load1Spell3_2") == 1)
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load1Spell4_3") == 1)
            {
                damageSpell4 = 10;
                cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell4_2") == 1)
            {
                damageSpell4 = 8;
                cooldownSpell4 = 7f;
            }
            else
            {
                damageSpell4 = 6;
                cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load1Spell5_3") == 1)
            {
                rangeSpell5 = 5f;
                cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell5_2") == 1)
            {
                rangeSpell5 = 4f;
                cooldownSpell5 = 8f;
            }
            else
            {
                rangeSpell5 = 3f;
                cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load1Spell6_3") == 1)
            {
                damageSpell6 = 6;
                rangeSpell6 = 3f;
                cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell6_2") == 1)
            {
                damageSpell6 = 5;
                rangeSpell6 = 3f;
                cooldownSpell6 = 8f;
            }
            else
            {
                damageSpell6 = 5;
                rangeSpell6 = 2f;
                cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load1Spell7_3") == 1)
            {
                damageSpell7 = 15;
                rangeSpell7 = 2f;
                cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell7_2") == 1)
            {
                damageSpell7 = 11;
                rangeSpell7 = 2f;
                cooldownSpell7 = 22.5f;
            }
            else
            {
                damageSpell7 = 7;
                rangeSpell7 = 2f;
                cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load1Spell8_3") == 1)
            {
                damageSpell8 = 25;
                cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell8_2") == 1)
            {
                damageSpell8 = 20;
                cooldownSpell8 = 27.5f;
            }
            else
            {
                damageSpell8 = 15;
                cooldownSpell8 = 30f;
            }


            if (PlayerPrefs.GetInt("Load1Passive1_3") == 1)
            {
                retaliateDamage = 5;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive1_2") == 1)
            {
                retaliateDamage = 3;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive1_1") == 1)
            {
                retaliateDamage = 1;
                canRetaliateShield = true;
            }
            else
                canRetaliateShield = false;


            if (PlayerPrefs.GetInt("Load1Passive2_3") == 1)
            {
                retaliateFreeze = 0.4f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive2_2") == 1)
            {
                retaliateFreeze = 0.6f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive2_1") == 1)
            {
                retaliateFreeze = 0.8f;
                canFreezeShield = true;
            }
            else
                canFreezeShield = false;


            if (PlayerPrefs.GetInt("Load1Passive3_3") == 1)
            {
                thunderboltStacksBonus = 3;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive3_2") == 1)
            {
                thunderboltStacksBonus = 2;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive3_1") == 1)
            {
                thunderboltStacksBonus = 1;
                canStackThunderbolt = true;
            }
            else
                canStackThunderbolt = false;


            if (PlayerPrefs.GetInt("Load1Passive4_3") == 1)
            {
                movementBonus += 0.4f;
                canGainMovementSpeed = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive4_2") == 1)
            {
                movementBonus += 0.3f;
                canGainMovementSpeed = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive4_1") == 1)
            {
                movementBonus += 0.2f;
                canGainMovementSpeed = true;
            }
            else
                canGainMovementSpeed = false;

            if (PlayerPrefs.GetInt("Load1Passive5_3") == 1)
            {
                damageSpell1 += 3;
                damageSpell4 += 3;
                damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load1Passive5_2") == 1)
            {
                damageSpell1 += 2;
                damageSpell4 += 2;
                damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load1Passive5_1") == 1)
            {
                damageSpell1 += 1;
                damageSpell4 += 1;
                damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load1Passive6_3") == 1)
            {
                damageSpell3 += 3;
                damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load1Passive6_2") == 1)
            {
                damageSpell3 += 2;
                damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load1Passive6_1") == 1)
            {
                damageSpell3 += 1;
                damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load1DecorationColor");

            if (chimney == 1)
                decorationBonusDamage++;
            else if (chimney == 3)
                decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load1DecorationGod");

            if (god == 1)
                decorationBonusDamage++;
            else if (god == 2)
                decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load1DecorationBanner") == 1)
                decorationBonusDamage++;


            int equipment = PlayerPrefs.GetInt("Load1DecorationWeapons");

            if (equipment == 1)
                decorationBonusDamage++;
            else if (equipment == 2)
                decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load1DecorationCarpet") == 1)
                decorationBonusDamage++;
        }
        else if (gm.GetComponent<GameManager>().currSave == 2)
        {
            if (PlayerPrefs.GetInt("Load2Spell1_3") == 1)
            {
                damageSpell1 = 8;
                cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell1_2") == 1)
            {
                damageSpell1 = 6;
                cooldownAttack = 0.75f;
            }
            else
            {
                damageSpell1 = 5;
                cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load2Spell2_3") == 1)
            {
                damageSpell2 = 12;
                rangeSpell2 = 3f;
                cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell2_2") == 1)
            {
                damageSpell2 = 10;
                rangeSpell2 = 3f;
                cooldownSpell2 = 4f;
            }
            else
            {
                damageSpell2 = 8;
                rangeSpell2 = 2f;
                cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load2Spell3_3") == 1)
            {
                damageSpell3 = 3;
                cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load2Spell3_2") == 1)
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load2Spell4_3") == 1)
            {
                damageSpell4 = 10;
                cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell4_2") == 1)
            {
                damageSpell4 = 8;
                cooldownSpell4 = 7f;
            }
            else
            {
                damageSpell4 = 6;
                cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load2Spell5_3") == 1)
            {
                rangeSpell5 = 5f;
                cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell5_2") == 1)
            {
                rangeSpell5 = 4f;
                cooldownSpell5 = 8f;
            }
            else
            {
                rangeSpell5 = 3f;
                cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load2Spell6_3") == 1)
            {
                damageSpell6 = 6;
                rangeSpell6 = 3f;
                cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell6_2") == 1)
            {
                damageSpell6 = 5;
                rangeSpell6 = 3f;
                cooldownSpell6 = 8f;
            }
            else
            {
                damageSpell6 = 5;
                rangeSpell6 = 2f;
                cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load2Spell7_3") == 1)
            {
                damageSpell7 = 15;
                rangeSpell7 = 2f;
                cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell7_2") == 1)
            {
                damageSpell7 = 11;
                rangeSpell7 = 2f;
                cooldownSpell7 = 22.5f;
            }
            else
            {
                damageSpell7 = 7;
                rangeSpell7 = 2f;
                cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load2Spell8_3") == 1)
            {
                damageSpell8 = 25;
                cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell8_2") == 1)
            {
                damageSpell8 = 20;
                cooldownSpell8 = 27.5f;
            }
            else
            {
                damageSpell8 = 15;
                cooldownSpell8 = 30f;
            }


            if (PlayerPrefs.GetInt("Load2Passive1_3") == 1)
            {
                retaliateDamage = 5;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive1_2") == 1)
            {
                retaliateDamage = 3;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive1_1") == 1)
            {
                retaliateDamage = 1;
                canRetaliateShield = true;
            }
            else
                canRetaliateShield = false;


            if (PlayerPrefs.GetInt("Load2Passive2_3") == 1)
            {
                retaliateFreeze = 0.4f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive2_2") == 1)
            {
                retaliateFreeze = 0.6f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive2_1") == 1)
            {
                retaliateFreeze = 0.8f;
                canFreezeShield = true;
            }
            else
                canFreezeShield = false;


            if (PlayerPrefs.GetInt("Load2Passive3_3") == 1)
            {
                thunderboltStacksBonus = 3;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive3_2") == 1)
            {
                thunderboltStacksBonus = 2;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load2Passive3_1") == 1)
            {
                thunderboltStacksBonus = 1;
                canStackThunderbolt = true;
            }
            else
                canStackThunderbolt = false;


            if (PlayerPrefs.GetInt("Load2Passive4_3") == 1)
            {
                movementBonus += 0.4f;
            }
            else if (PlayerPrefs.GetInt("Load2Passive4_2") == 1)
            {
                movementBonus += 0.3f;
            }
            else if (PlayerPrefs.GetInt("Load2Passive4_1") == 1)
            {
                movementBonus += 0.2f;
            }


            if (PlayerPrefs.GetInt("Load2Passive5_3") == 1)
            {
                damageSpell1 += 3;
                damageSpell4 += 3;
                damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load2Passive5_2") == 1)
            {
                damageSpell1 += 2;
                damageSpell4 += 2;
                damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load2Passive5_1") == 1)
            {
                damageSpell1 += 1;
                damageSpell4 += 1;
                damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load2Passive6_3") == 1)
            {
                damageSpell3 += 3;
                damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load2Passive6_2") == 1)
            {
                damageSpell3 += 2;
                damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load2Passive6_1") == 1)
            {
                damageSpell3 += 1;
                damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load2DecorationColor");

            if (chimney == 1)
                decorationBonusDamage++;
            else if (chimney == 3)
                decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load2DecorationGod");

            if (god == 1)
                decorationBonusDamage++;
            else if (god == 2)
                decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load2DecorationBanner") == 1)
                decorationBonusDamage++;


            int equipment = PlayerPrefs.GetInt("Load2DecorationWeapons");

            if (equipment == 1)
                decorationBonusDamage++;
            else if (equipment == 2)
                decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load2DecorationCarpet") == 1)
                decorationBonusDamage++;
        }
        else if (gm.GetComponent<GameManager>().currSave == 3)
        {
            if (PlayerPrefs.GetInt("Load3Spell1_3") == 1)
            {
                damageSpell1 = 8;
                cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell1_2") == 1)
            {
                damageSpell1 = 6;
                cooldownAttack = 0.75f;
            }
            else
            {
                damageSpell1 = 5;
                cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load3Spell2_3") == 1)
            {
                damageSpell2 = 12;
                rangeSpell2 = 3f;
                cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell2_2") == 1)
            {
                damageSpell2 = 10;
                rangeSpell2 = 3f;
                cooldownSpell2 = 4f;
            }
            else
            {
                damageSpell2 = 8;
                rangeSpell2 = 2f;
                cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load3Spell3_3") == 1)
            {
                damageSpell3 = 3;
                cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load3Spell3_2") == 1)
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                damageSpell3 = 2;
                cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load3Spell4_3") == 1)
            {
                damageSpell4 = 10;
                cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell4_2") == 1)
            {
                damageSpell4 = 8;
                cooldownSpell4 = 7f;
            }
            else
            {
                damageSpell4 = 6;
                cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load3Spell5_3") == 1)
            {
                rangeSpell5 = 5f;
                cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell5_2") == 1)
            {
                rangeSpell5 = 4f;
                cooldownSpell5 = 8f;
            }
            else
            {
                rangeSpell5 = 3f;
                cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load3Spell6_3") == 1)
            {
                damageSpell6 = 6;
                rangeSpell6 = 3f;
                cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell6_2") == 1)
            {
                damageSpell6 = 5;
                rangeSpell6 = 3f;
                cooldownSpell6 = 8f;
            }
            else
            {
                damageSpell6 = 5;
                rangeSpell6 = 2f;
                cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load3Spell7_3") == 1)
            {
                damageSpell7 = 15;
                rangeSpell7 = 2f;
                cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell7_2") == 1)
            {
                damageSpell7 = 11;
                rangeSpell7 = 2f;
                cooldownSpell7 = 22.5f;
            }
            else
            {
                damageSpell7 = 7;
                rangeSpell7 = 2f;
                cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load3Spell8_3") == 1)
            {
                damageSpell8 = 25;
                cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell8_2") == 1)
            {
                damageSpell8 = 20;
                cooldownSpell8 = 27.5f;
            }
            else
            {
                damageSpell8 = 15;
                cooldownSpell8 = 30f;
            }


            if (PlayerPrefs.GetInt("Load3Passive1_3") == 1)
            {
                retaliateDamage = 5;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive1_2") == 1)
            {
                retaliateDamage = 3;
                canRetaliateShield = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive1_1") == 1)
            {
                retaliateDamage = 1;
                canRetaliateShield = true;
            }
            else
                canRetaliateShield = false;


            if (PlayerPrefs.GetInt("Load3Passive2_3") == 1)
            {
                retaliateFreeze = 0.4f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive2_2") == 1)
            {
                retaliateFreeze = 0.6f;
                canFreezeShield = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive2_1") == 1)
            {
                retaliateFreeze = 0.8f;
                canFreezeShield = true;
            }
            else
                canFreezeShield = false;


            if (PlayerPrefs.GetInt("Load3Passive3_3") == 1)
            {
                thunderboltStacksBonus = 3;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive3_2") == 1)
            {
                thunderboltStacksBonus = 2;
                canStackThunderbolt = true;
            }
            else if (PlayerPrefs.GetInt("Load3Passive3_1") == 1)
            {
                thunderboltStacksBonus = 1;
                canStackThunderbolt = true;
            }
            else
                canStackThunderbolt = false;


            if (PlayerPrefs.GetInt("Load3Passive4_3") == 1)
            {
                movementBonus += 0.4f;
            }
            else if (PlayerPrefs.GetInt("Load3Passive4_2") == 1)
            {
                movementBonus += 0.3f;
            }
            else if (PlayerPrefs.GetInt("Load3Passive4_1") == 1)
            {
                movementBonus += 0.2f;
            }


            if (PlayerPrefs.GetInt("Load3Passive5_3") == 1)
            {
                damageSpell1 += 3;
                damageSpell4 += 3;
                damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load3Passive5_2") == 1)
            {
                damageSpell1 += 2;
                damageSpell4 += 2;
                damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load3Passive5_1") == 1)
            {
                damageSpell1 += 1;
                damageSpell4 += 1;
                damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load3Passive6_3") == 1)
            {
                damageSpell3 += 3;
                damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load3Passive6_2") == 1)
            {
                damageSpell3 += 2;
                damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load3Passive6_1") == 1)
            {
                damageSpell3 += 1;
                damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load3DecorationColor");

            if (chimney == 1)
                decorationBonusDamage++;
            else if (chimney == 3)
                decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load3DecorationGod");

            if (god == 1)
                decorationBonusDamage++;
            else if (god == 2)
                decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load3DecorationBanner") == 1)
                decorationBonusDamage++;


            int equipment = PlayerPrefs.GetInt("Load3DecorationWeapons");

            if (equipment == 1)
                decorationBonusDamage++;
            else if (equipment == 2)
                decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load3DecorationCarpet") == 1)
                decorationBonusDamage++;
        }

        print("damage spell 1 : " + damageSpell1);
        print("damage spell 3 : " + damageSpell3);
        print("damage spell 4 : " + damageSpell4);
        print("damage spell 6 : " + damageSpell6);
        print("damage spell 8 : " + damageSpell8);

        print("deco damage : " + decorationBonusDamage);
        print("deco tanking : " + decorationBonusTanking);
        print("deco effect : " + decorationBonusEffectDuration);
        print("deco healing : " + decorationBonusHealing);

        SelectSpell1(true);
    } 

    void Update ()
	{
        if (gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (isUnderMana == true)
            {
                manaTimer += Time.deltaTime;
                if (manaTimer > cooldownManaEffect)
                {
                    isUnderMana = false;
                    speedCD = 1f;
                    manaTimer = 0f;
                }
            }
            if (spell1Ready == false)
            {
                timerAttack += Time.deltaTime * speedCD;
                cdSpell1.GetComponent<Slider>().value = 1 - (float)timerAttack / (float)cooldownAttack;
                if (timerAttack > cooldownAttack)
                {
                    timerAttack = 0f;
                    cdSpell1.GetComponent<Slider>().value = 0;
                    spell1Ready = true;
                }
            }
            if (spell2Ready == false)
            {
                timerSpell2 += Time.deltaTime * speedCD;
                cdSpell2.GetComponent<Slider>().value = 1 - (float)timerSpell2 / (float)cooldownSpell2;
                if (timerSpell2 > cooldownSpell2)
                {
                    timerSpell2 = 0f;
                    cdSpell2.GetComponent<Slider>().value = 0;
                    spell2Ready = true;
                }
            }
            if (spell3Ready == false)
            {
                timerSpell3 += Time.deltaTime * speedCD;
                cdSpell3.GetComponent<Slider>().value = 1 - (float)timerSpell3 / (float)cooldownSpell3;
                if (timerSpell3 > cooldownSpell3)
                {
                    timerSpell3 = 0f;
                    cdSpell3.GetComponent<Slider>().value = 0;
                    spell3Ready = true;
                }
            }
            if (spell4Ready == false)
            {
                timerSpell4 += Time.deltaTime * speedCD;
                cdSpell4.GetComponent<Slider>().value = 1 - (float)timerSpell4 / (float)cooldownSpell4;
                if (timerSpell4 > cooldownSpell4)
                {
                    timerSpell4 = 0f;
                    cdSpell4.GetComponent<Slider>().value = 0;
                    spell4Ready = true;
                }
            }
            if (spell5Ready == false)
            {
                timerSpell5 += Time.deltaTime * speedCD;
                cdSpell5.GetComponent<Slider>().value = 1 - (float)timerSpell5 / (float)cooldownSpell5;
                if (timerSpell5 > cooldownSpell5)
                {
                    timerSpell5 = 0f;
                    cdSpell5.GetComponent<Slider>().value = 0;
                    spell5Ready = true;
                }
            }
            if (spell6Ready == false)
            {
                timerSpell6 += Time.deltaTime * speedCD;
                cdSpell6.GetComponent<Slider>().value = 1 - (float)timerSpell6 / (float)cooldownSpell6;
                if (timerSpell6 > cooldownSpell6)
                {
                    timerSpell6 = 0f;
                    cdSpell6.GetComponent<Slider>().value = 0;
                    spell6Ready = true;
                }
            }
            if (spell7Ready == false)
            {
                timerSpell7 += Time.deltaTime * speedCD;
                cdSpell7.GetComponent<Slider>().value = 1 - (float)timerSpell7 / (float)cooldownSpell7;
                if (timerSpell7 > cooldownSpell7)
                {
                    timerSpell7 = 0f;
                    cdSpell7.GetComponent<Slider>().value = 0;
                    spell7Ready = true;
                }
            }
            if (spell8Ready == false)
            {
                timerSpell8 += Time.deltaTime * speedCD;
                cdSpell8.GetComponent<Slider>().value = 1 - (float)timerSpell8 / (float)cooldownSpell8;
                if (timerSpell8 > cooldownSpell8)
                {
                    timerSpell8 = 0f;
                    cdSpell8.GetComponent<Slider>().value = 0;
                    spell8Ready = true;
                }
            }
            if (object1Ready == false)
            {
                timerObject1 += Time.deltaTime * speedCD;
                cdObject1.GetComponent<Slider>().value = 1 - (float)timerObject1 / (float)cooldownObject1;
                if (timerObject1 > cooldownObject1)
                {
                    timerObject1 = 0f;
                    cdObject1.GetComponent<Slider>().value = 0;
                    object1Ready = true;
                }
            }
            if (object2Ready == false)
            {
                timerObject2 += Time.deltaTime * speedCD;
                cdObject2.GetComponent<Slider>().value = 1 - (float)timerObject2 / (float)cooldownObject2;
                if (timerObject2 > cooldownObject2)
                {
                    timerObject2 = 0f;
                    cdObject2.GetComponent<Slider>().value = 0;
                    object2Ready = true;
                }
            }
            if (hasRuneCooldown == true)
            {
                if (isRuneDamage == true && nextSpellDamageRune == false)
                {
                    timerObject3 += Time.deltaTime * speedCD;
                    cdObject3.GetComponent<Slider>().value = 1 - (float)timerObject3 / (float)cooldownObject3;
                    if (timerObject3 > cooldownObject3)
                    {
                        timerObject3 = 0f;
                        cdObject3.GetComponent<Slider>().value = 0;
                        nextSpellDamageRune = true;
                    }
                }
                else if (isRuneHeal == true)
                {
                    if (timerObject3 > cooldownObject3)
                    {
                        if (GetComponent<StatsPlayer>().IsFullLife() == true)
                            cdObject3.GetComponent<Slider>().value = 0;
                        else
                        {
                            timerObject3 = 0f;
                            cdObject3.GetComponent<Slider>().value = 0;
                            GetComponent<StatsPlayer>().Heal(GetComponent<StatsPlayer>().level);
                        }
                    }
                    else
                    {
                        timerObject3 += Time.deltaTime * speedCD;
                        cdObject3.GetComponent<Slider>().value = 1 - (float)timerObject3 / (float)cooldownObject3;
                    }
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                if (spellSelected == 1)
                    SelectSpell8(true);
                else if (spellSelected == 2)
                    SelectSpell1(true);
                else if (spellSelected == 3)
                    SelectSpell2(true);
                else if (spellSelected == 4)
                    SelectSpell3(true);
                else if (spellSelected == 5)
                    SelectSpell4(true);
                else if (spellSelected == 6)
                    SelectSpell5(true);
                else if (spellSelected == 7)
                    SelectSpell6(true);
                else if (spellSelected == 8)
                    SelectSpell7(true);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            {
                if (spellSelected == 1)
                    SelectSpell2(true);
                else if (spellSelected == 2)
                    SelectSpell3(true);
                else if (spellSelected == 3)
                    SelectSpell4(true);
                else if (spellSelected == 4)
                    SelectSpell5(true);
                else if (spellSelected == 5)
                    SelectSpell6(true);
                else if (spellSelected == 6)
                    SelectSpell7(true);
                else if (spellSelected == 7)
                    SelectSpell8(true);
                else if (spellSelected == 8)
                    SelectSpell1(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectSpell1(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectSpell2(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectSpell3(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectSpell4(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectSpell5(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SelectSpell6(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SelectSpell7(false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SelectSpell8(false);
            }
            else if ((Input.GetKeyDown(KeyCode.A) &&
                    gm.GetComponent<GameManager>().englishLanguage == false) ||
                    (Input.GetKeyDown(KeyCode.Q) &&
                    gm.GetComponent<GameManager>().englishLanguage == true))
            {
                UseObject1();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                UseObject2();
            }
            if (spellSelected == 1 &&
                Input.GetMouseButton(0))
            {
                UseSpell1();
            }
            else if (spellSelected == 2 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell2();
            }
            else if (spellSelected == 3 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell3();
            }
            else if (spellSelected == 4 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell4();
            }
            else if (spellSelected == 5 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell5();
            }
            else if (spellSelected == 6 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell6();
            }
            else if (spellSelected == 7 &&
            Input.GetMouseButtonDown(0))
            {
                UseSpell7();
            }
            else if (spellSelected == 8 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell8();
            }
        }
    }

    public void SelectSpell1(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell1();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell1 * 2, rangeSpell1 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 1;
            usingSpell1Icon.SetActive(true);
            usingSpell1Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell2(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell2();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell2 * 2, rangeSpell2 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 2;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(true);
            usingSpell2Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell2Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell3(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell3();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell3 * 2, rangeSpell3 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 3;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(true);
            usingSpell3Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell3Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell4(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell4();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell4 * 2, rangeSpell4 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 4;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(true);
            usingSpell4Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell4Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell5(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell5();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell5 * 2, rangeSpell5 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 5;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(true);
            usingSpell5Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell5Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell6(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell6();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell6 * 2, rangeSpell6 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 6;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(true);
            usingSpell6Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell6Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell7(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell7();
        }
        else
        {
            if (gm.GetComponent<GameManager>().smartcast == false)
            {
                Vector3 newScale = new Vector3(rangeSpell7 * 2, rangeSpell7 * 2, 1);
                rangeIndicator.transform.localScale = newScale;
                rangeIndicator.SetActive(true);
                rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                rangeIndicator.SetActive(false);

            spellSelected = 7;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(true);
            usingSpell7Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell7Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
            usingSpell8Icon.SetActive(false);
        }
    }

    public void SelectSpell8(bool fromClick)
    {
        if (gm.GetComponent<GameManager>().smartcast == true &&
            fromClick == false)
        {
            UseSpell8();
        }
        else
        {
            rangeIndicator.GetComponent<SpriteAnimTimer>().isPlaying = false;
            rangeIndicator.SetActive(false);
            spellSelected = 8;
            usingSpell1Icon.SetActive(false);
            usingSpell2Icon.SetActive(false);
            usingSpell3Icon.SetActive(false);
            usingSpell4Icon.SetActive(false);
            usingSpell5Icon.SetActive(false);
            usingSpell6Icon.SetActive(false);
            usingSpell7Icon.SetActive(false);
            usingSpell8Icon.SetActive(true);
            usingSpell8Icon.GetComponent<UsingSpell>().player = gameObject;
            usingSpell8Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
        }
    }

    void FindShootDirection()
    {

        Vector2 newPosClick = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        Vector2 myPos = new Vector3(transform.position.x, transform.position.y);
        Vector3 dir = myPos - newPosClick;
        dir = transform.InverseTransformDirection(dir);

        projectileRotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Vector2 newPosTop = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 newPosTopRight = new Vector2(transform.position.x + 0.8f, transform.position.y + 0.8f);
        Vector2 newPosTopLeft = new Vector2(transform.position.x - 0.8f, transform.position.y + 0.8f);
        Vector2 newPosBot = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 newPosBotRight = new Vector2(transform.position.x + 0.8f, transform.position.y - 0.8f);
        Vector2 newPosBotLeft = new Vector2(transform.position.x - 0.8f, transform.position.y - 0.8f);
        Vector2 newPosRight = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 newPosLeft = new Vector2(transform.position.x - 1, transform.position.y);

        float distanceTop = Vector2.Distance(newPosTop, newPosClick);
        float distanceTopRight = Vector2.Distance(newPosTopRight, newPosClick);
        float distanceTopLeft = Vector2.Distance(newPosTopLeft, newPosClick);
        float distanceBot = Vector2.Distance(newPosBot, newPosClick);
        float distanceBotRight = Vector2.Distance(newPosBotRight, newPosClick);
        float distanceBotLeft = Vector2.Distance(newPosBotLeft, newPosClick);
        float distanceRight = Vector2.Distance(newPosRight, newPosClick);
        float distanceLeft = Vector2.Distance(newPosLeft, newPosClick);

        if (distanceRight < distanceTop &&
            distanceRight < distanceBot &&
            distanceRight < distanceLeft &&
            distanceRight < distanceTopRight &&
            distanceRight < distanceTopLeft &&
            distanceRight < distanceBotRight &&
            distanceRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.RIGHT;
        else if (distanceLeft < distanceTop &&
            distanceLeft < distanceBot &&
            distanceLeft < distanceRight &&
            distanceLeft < distanceTopRight &&
            distanceLeft < distanceTopLeft &&
            distanceLeft < distanceBotRight &&
            distanceLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.LEFT;
        else if (distanceBot < distanceTop &&
            distanceBot < distanceLeft &&
            distanceBot < distanceRight &&
            distanceBot < distanceTopRight &&
            distanceBot < distanceTopLeft &&
            distanceBot < distanceBotRight &&
            distanceBot < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOM;
        else if (distanceTop < distanceBot &&
            distanceTop < distanceLeft &&
            distanceTop < distanceRight &&
            distanceTop < distanceTopRight &&
            distanceTop < distanceTopLeft &&
            distanceTop < distanceBotRight &&
            distanceTop < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOP;
        else if (distanceTopRight < distanceBot &&
            distanceTopRight < distanceLeft &&
            distanceTopRight < distanceRight &&
            distanceTopRight < distanceTop &&
            distanceTopRight < distanceTopLeft &&
            distanceTopRight < distanceBotRight &&
            distanceTopRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOPRIGHT;
        else if (distanceTopLeft < distanceBot &&
            distanceTopLeft < distanceLeft &&
            distanceTopLeft < distanceRight &&
            distanceTopLeft < distanceTop &&
            distanceTopLeft < distanceTopRight &&
            distanceTopLeft < distanceBotRight &&
            distanceTopLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOPLEFT;
        else if (distanceBotRight < distanceBot &&
            distanceBotRight < distanceLeft &&
            distanceBotRight < distanceRight &&
            distanceBotRight < distanceTop &&
            distanceBotRight < distanceTopRight &&
            distanceBotRight < distanceTopLeft &&
            distanceBotRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOMRIGHT;
        else if (distanceBotLeft < distanceBot &&
            distanceBotLeft < distanceLeft &&
            distanceBotLeft < distanceRight &&
            distanceBotLeft < distanceTop &&
            distanceBotLeft < distanceTopRight &&
            distanceBotLeft < distanceTopLeft &&
            distanceBotLeft < distanceBotRight)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOMLEFT;
    }

    void UseSpell1()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true &&
            spell1Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            cdSpell1.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell1Ready = false;
            GameObject sfx = (GameObject)Instantiate(fireballSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(InstantiateProjectile(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    void UseSpell2()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true && 
            spell2Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= rangeSpell2)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier" || hit.collider.tag == "Capture")
                {
                    if (canGainMovementSpeed == true)
                        GetComponent<Deplacements>().SetMovementBonus();
                    cdSpell2.GetComponent<Slider>().value = 1;
                    StartCoroutine(SpellFoudre(hit.collider.gameObject));
                    GetComponent<Deplacements>().isAttacking = true;
                    GetComponent<Deplacements>().currentNumeroAnim = 1;
                    FindShootDirection();
                    spell2Ready = false;
                    GameObject sfx = (GameObject)Instantiate(thunderboltSFX, transform.position, transform.rotation);
                    sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
                    StartCoroutine(GoBackToAA());
                }
            }
        }
    }

    void UseSpell3()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true && 
            spell3Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            cdSpell3.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell3Ready = false;
            GameObject sfx = (GameObject)Instantiate(iceShardSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(InstantiateEclatsGlace(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
            StartCoroutine(GoBackToAA());
        }
    }

    void UseSpell4()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true && 
            spell4Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= rangeSpell4)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            cdSpell4.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell4Ready = false;
            GameObject sfx = (GameObject)Instantiate(meteorSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(SpellMeteore());
            StartCoroutine(GoBackToAA());
        }
    }

    void UseSpell5()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true &&
            spell5Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= rangeSpell5)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            cdSpell5.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell5Ready = false;
            GameObject sfx = (GameObject)Instantiate(tornadoSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(SpellTornade());
            StartCoroutine(GoBackToAA());
        }
    }

    void UseSpell6()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)

            rangeIndicator.SetActive(false);
        if (canShoot == true && 
            spell6Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= rangeSpell6)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier" || hit.collider.tag == "Capture")
                {
                    if (canGainMovementSpeed == true)
                        GetComponent<Deplacements>().SetMovementBonus();
                    if (canStackThunderbolt == true)
                        thunderboltStacksBonus++;

                    cdSpell6.GetComponent<Slider>().value = 1;
                    StartCoroutine(SpellPrisonGlace(hit.collider.gameObject));
                    GetComponent<Deplacements>().isAttacking = true;
                    GetComponent<Deplacements>().currentNumeroAnim = 1;
                    FindShootDirection();
                    spell6Ready = false;
                    GameObject sfx = (GameObject)Instantiate(icePrisonSFX, transform.position, transform.rotation);
                    sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
                    StartCoroutine(GoBackToAA());
                }
            }
        }
    }
    void UseSpell7()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)

            rangeIndicator.SetActive(false);
        if (spell7Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            cdSpell7.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            spell7Ready = false;
            StartCoroutine(SpellEarthquake());
            StartCoroutine(GoBackToAA());
        }
    }

    void UseSpell8()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            rangeIndicator.SetActive(false);

        if (canShoot == true && 
            spell8Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            cdSpell8.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell8Ready = false;
            GameObject sfx = (GameObject)Instantiate(dragonSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(SpellDragonFeu(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
            StartCoroutine(GoBackToAA());
        }
    }

    public void UseObject1()
    {
        if (object1Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            GetComponent<StatsPlayer>().stockHealthPotion > 0)
        {
            GetComponent<StatsPlayer>().stockHealthPotion--;
            gm.GetComponent<GameManager>().textStockHealthPotion.GetComponent<Text>().text = GetComponent<StatsPlayer>().stockHealthPotion.ToString();
            cdObject1.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            object1Ready = false;
            GameObject sfx = (GameObject)Instantiate(potionHealthSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            GetComponent<StatsPlayer>().Heal(10);
        }
    }

    public void UseObject2()
    {
        if (object2Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            GetComponent<StatsPlayer>().stockManaPotion > 0)
        {
            GetComponent<StatsPlayer>().stockManaPotion--;
            gm.GetComponent<GameManager>().textStockManaPotion.GetComponent<Text>().text = GetComponent<StatsPlayer>().stockManaPotion.ToString();
            cdObject2.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            object2Ready = false;
            isUnderMana = true;
            GameObject sfx = (GameObject)Instantiate(potionManaSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            speedCD = 2f;
        }
    }

    private void InflictDamage(GameObject obj, int damageToInflict, bool fromPlayer, Vector3 positionVector)
    {
        if (fromPlayer == true)
            obj.GetComponent<IAGuerrier>().TakeDamageFromPlayer(damageToInflict, positionVector);
        else
            obj.GetComponent<Capture>().TakeDamage(damageToInflict);
    }

    IEnumerator InstantiateProjectile(Vector2 directionPos)
	{
        yield return new WaitForSeconds(0.2f);
		GameObject obj = null;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Direction.RIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.LEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        int damageBonus = 0;
        if (nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            nextSpellDamageRune = false;
        }

        damageBonus += decorationBonusDamage;

        obj = (GameObject)Instantiate (fireball, newPos, rot);
		obj.GetComponent<Projectile>().GetPos(directionPos, damageSpell1 + damageBonus, projectileRotation, gameObject);
	}

    IEnumerator InstantiateEclatsGlace(Vector2 directionPos)
    {
        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Direction.RIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.LEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        int damageBonus = 0;
        if (nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            nextSpellDamageRune = false;
        }

        damageBonus += decorationBonusDamage;

        GameObject obj1 = null;
        obj1 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj1.GetComponent<IceShard>().GetPos(directionPos, damageSpell3 + damageBonus, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj2 = null;
        obj2 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj2.GetComponent<IceShard>().GetPos(directionPos, damageSpell3, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj3 = null;
        obj3 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj3.GetComponent<IceShard>().GetPos(directionPos, damageSpell3, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj4 = null;
        obj4 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj4.GetComponent<IceShard>().GetPos(directionPos, damageSpell3, projectileRotation, gameObject);
    }

    IEnumerator SpellFoudre(GameObject go)
    {
        Vector2 vectorTmp = go.transform.position;
        vectorTmp.y += 0.5f;
        GameObject obj = (GameObject)Instantiate(thunderbolt, vectorTmp, transform.rotation);
        obj.GetComponent<Thunderbolt>().enemy = go;
        yield return new WaitForSeconds(0.16f);

        if (go.gameObject != null)
        {
            int damageBonus = 0;
            if (nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                nextSpellDamageRune = false;
            }

            damageBonus += decorationBonusDamage;

            vectorTmp = go.transform.position;
            vectorTmp.y += 0.5f;
            GameObject obj2 = (GameObject)Instantiate(thunderboltBase, vectorTmp, transform.rotation);
            obj2.GetComponent<Thunderbolt>().enemy = go;
            if (go.tag != "Capture")
                InflictDamage(go.gameObject, damageSpell2 + damageBonus + thunderboltStacksBonus, true, transform.position);
            else if (go.tag == "Capture")
                InflictDamage(go.gameObject, damageSpell2 + damageBonus + thunderboltStacksBonus, false, transform.position);

            thunderboltStacksBonus = 0;
        }
    }

    IEnumerator GoBackToAA()
    {
        yield return new WaitForSeconds(0.1f);
        SelectSpell1(true);
        spellSelected = 1;
        usingSpell1Icon.SetActive(true);
        usingSpell1Icon.GetComponent<UsingSpell>().SetAnimNb(usingSpellInt);
        usingSpell2Icon.SetActive(false);
        usingSpell3Icon.SetActive(false);
        usingSpell4Icon.SetActive(false);
        usingSpell5Icon.SetActive(false);
        usingSpell6Icon.SetActive(false);
        usingSpell8Icon.SetActive(false);
    }

    IEnumerator SpellMeteore()
    {
        Vector2 mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector2 meteorPos = mousePos;
        meteorPos.y += 0.5f;
        Instantiate(meteor, meteorPos, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        foreach(GameObject go in mapManager.GetComponent<MapManager>().enemiesList)
        {
            int damageBonus = 0;
            if (nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                nextSpellDamageRune = false;
            }

            damageBonus += decorationBonusDamage;

            if (Vector2.Distance(go.transform.position, mousePos) < 1 &&
                go.tag != "Capture")
                InflictDamage(go.gameObject, damageSpell4 + damageBonus, true, mousePos);
            else if (Vector2.Distance(go.transform.position, mousePos) < 1 &&
                go.tag == "Capture")
                InflictDamage(go.gameObject, damageSpell4 + damageBonus, false, mousePos);
        }
    }

    IEnumerator SpellTornade()
    {
        Vector2 mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePos.y += 0.6f;
        yield return new WaitForSeconds(0.2f);
        Instantiate(tornadoBase, mousePos, transform.rotation);
        yield return new WaitForSeconds(0.16f);
        GameObject obj1 = (GameObject)Instantiate(tornado, mousePos, transform.rotation);
        obj1.GetComponent<SpriteAnimTimer>().StartAnim(2 * decorationBonusEffectDuration);
        obj1.GetComponent<Tornado>().id = idSpell5++;
        obj1.GetComponent<Tornado>().CCDuration = 2 * decorationBonusEffectDuration;
    }

    IEnumerator SpellPrisonGlace(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        if (go.gameObject != null)
        {
            int damageBonus = 0;
            if (nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                nextSpellDamageRune = false;
            }

            damageBonus += decorationBonusDamage;

            Vector2 vectorTmp = go.transform.position;
            vectorTmp.y -= 0.2f;
            GameObject tmp = (GameObject)Instantiate(icePrison, vectorTmp, go.transform.rotation);
            tmp.GetComponent<SpriteAnimTimer>().StartAnim(2 * decorationBonusEffectDuration);
            if (go.tag != "Capture")
            {
                InflictDamage(go.gameObject, damageSpell6 + damageBonus, true, transform.position);
                go.GetComponent<IAGuerrier>().ApplyCC(2 * decorationBonusEffectDuration);
            }
        }
    }

    IEnumerator SpellEarthquake()
    {
        Vector2 newVec = new Vector2(transform.position.x, transform.position.y + 0.3f);
        Instantiate(earthquake, newVec, transform.rotation);

        yield return new WaitForSeconds(0.35f);

        GameObject sfx = (GameObject)Instantiate(earthquakeSFX, transform.position, transform.rotation);
        sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;

        int damageBonus = 0;
        if (nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            nextSpellDamageRune = false;
        }

        damageBonus += decorationBonusDamage;

        foreach (GameObject go in mapManager.GetComponent<MapManager>().enemiesList)
        {
            if (Vector2.Distance(go.transform.position, transform.position) < 2 &&
                go.tag != "Capture")
            {
                InflictDamage(go.gameObject, damageSpell7 + damageBonus, true, transform.position);
                go.GetComponent<IAGuerrier>().ApplySlow(2f * decorationBonusEffectDuration, 0.5f);
            }
            else if (Vector2.Distance(go.transform.position, transform.position) < 2 &&
                go.tag == "Capture")
            {
                InflictDamage(go.gameObject, damageSpell7 + damageBonus, false, transform.position);
            }
        }
    }

    IEnumerator SpellDragonFeu(Vector2 directionPos)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = null;

        int damageBonus = 0;
        if (nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            nextSpellDamageRune = false;
        }

        damageBonus += decorationBonusDamage;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Direction.RIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOPRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOMRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.LEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOPLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOMLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOM)
        {
            newPos.y = transform.position.y - 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOP)
        {
            newPos.y = transform.position.y + 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
    }
}
