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

	public  GameObject	cam;
    public  GameObject  rangeIndicator;
    public  bool        canShoot = true;

    public  GameObject  potionHealthSFX;
    public  GameObject  potionManaSFX;
    public  GameObject  gm;
    public  GameObject  mapManager;
    public  GameObject  usingSpell1Icon;
    public  GameObject  usingSpell2Icon;
    public  GameObject  usingSpell3Icon;
    public  GameObject  usingSpell4Icon;
    public  GameObject  usingSpell5Icon;
    public  GameObject  usingSpell6Icon;
    public  GameObject  usingSpell7Icon;
    public  GameObject  usingSpell8Icon;
    public  int         usingSpellInt;

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

    public float        movementBonus;

    public  int         spellSelected = 1;

    public  GameObject  cdSpell1;
    public  GameObject  cdSpell2;
    public  GameObject  cdSpell3;
    public  GameObject  cdSpell4;
    public  GameObject  cdSpell5;
    public  GameObject  cdSpell6;
    public  GameObject  cdSpell7;
    public  GameObject  cdSpell8;
    public  GameObject  cdObject1;
    public  GameObject  cdObject2;
    public  GameObject  cdObject3;

    public  bool        hasRuneCooldown;
    public  bool        isRuneDamage;
    public  bool        isRuneCelerity;
    public  bool        isRuneHeal;
    public  bool        nextSpellDamageRune = false;

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
    }
}
