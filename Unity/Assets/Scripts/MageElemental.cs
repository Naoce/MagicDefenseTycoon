using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageElemental : MonoBehaviour
{
    public  GameObject  fireball;
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

    private GameObject  gm;
    private Vector2     newPos = new Vector2(0, 0);
    private Quaternion  rot = new Quaternion(0, 0, 0, 0);
    private float       projectileRotation = 0f;

    private float       speedCD = 1f;
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

    public  int         numberShards;
    public  int         retaliateDamage;
    public  bool        canRetaliateShield;
    public  float       retaliateFreeze;
    public  bool        canFreezeShield;
    public  bool        canGainMovementSpeed;
    public  int         thunderboltStacksBonus;
    public  bool        canStackThunderbolt;

    private int         idSpell8 = 0;
    private int         idSpell5 = 0;

    void Start ()
    {
        gm = GameObject.Find("GameManager");
        GetComponent<Shoots>().rangeSpell1 = 3f;
        GetComponent<Shoots>().rangeSpell3 = 3f;
        GetComponent<Shoots>().rangeSpell4 = 3f;

        GetComponent<Shoots>().decorationBonusEffectDuration = 1f;

        GetComponent<Deplacements>().movementBonus = 1f;
        GetComponent<Shoots>().movementBonus = 0f;

        GetComponent<Shoots>().usingSpell1Icon = gm.GetComponent<GameManager>().usingSpell1Icon;

        if (gm.GetComponent<GameManager>().currSave == 1)
        {
            if (PlayerPrefs.GetInt("Load1Spell1_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 8;
                GetComponent<Shoots>().cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell1_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 6;
                GetComponent<Shoots>().cooldownAttack = 0.75f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell1 = 5;
                GetComponent<Shoots>().cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load1Spell2_3") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 12;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell2_2") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 10;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell2 = 8;
                GetComponent<Shoots>().rangeSpell2 = 2f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load1Spell3_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 3;
                GetComponent<Shoots>().cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load1Spell3_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load1Spell4_3") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 10;
                GetComponent<Shoots>().cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell4_2") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 8;
                GetComponent<Shoots>().cooldownSpell4 = 7f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell4 = 6;
                GetComponent<Shoots>().cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load1Spell5_3") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 5f;
                GetComponent<Shoots>().cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell5_2") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 4f;
                GetComponent<Shoots>().cooldownSpell5 = 8f;
            }
            else
            {
                GetComponent<Shoots>().rangeSpell5 = 3f;
                GetComponent<Shoots>().cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load1Spell6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 6;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 8f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 2f;
                GetComponent<Shoots>().cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load1Spell7_3") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 15;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell7_2") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 11;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 22.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell7 = 7;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load1Spell8_3") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 25;
                GetComponent<Shoots>().cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load1Spell8_2") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 20;
                GetComponent<Shoots>().cooldownSpell8 = 27.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell8 = 15;
                GetComponent<Shoots>().cooldownSpell8 = 30f;
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
                GetComponent<Shoots>().movementBonus += 0.4f;
                canGainMovementSpeed = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive4_2") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.3f;
                canGainMovementSpeed = true;
            }
            else if (PlayerPrefs.GetInt("Load1Passive4_1") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.2f;
                canGainMovementSpeed = true;
            }
            else
                canGainMovementSpeed = false;

            if (PlayerPrefs.GetInt("Load1Passive5_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 3;
                GetComponent<Shoots>().damageSpell4 += 3;
                GetComponent<Shoots>().damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load1Passive5_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 2;
                GetComponent<Shoots>().damageSpell4 += 2;
                GetComponent<Shoots>().damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load1Passive5_1") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 1;
                GetComponent<Shoots>().damageSpell4 += 1;
                GetComponent<Shoots>().damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load1Passive6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 3;
                GetComponent<Shoots>().damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load1Passive6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 2;
                GetComponent<Shoots>().damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load1Passive6_1") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 1;
                GetComponent<Shoots>().damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load1DecorationColor");

            if (chimney == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (chimney == 3)
                GetComponent<Shoots>().decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load1DecorationGod");

            if (god == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (god == 2)
                GetComponent<Shoots>().decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                GetComponent<Shoots>().decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load1DecorationBanner") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;

            int equipment = PlayerPrefs.GetInt("Load1DecorationWeapons");

            if (equipment == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (equipment == 2)
                GetComponent<Shoots>().decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load1DecorationCarpet") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
        }
        else if (gm.GetComponent<GameManager>().currSave == 2)
        {
            if (PlayerPrefs.GetInt("Load2Spell1_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 8;
                GetComponent<Shoots>().cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell1_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 6;
                GetComponent<Shoots>().cooldownAttack = 0.75f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell1 = 5;
                GetComponent<Shoots>().cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load2Spell2_3") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 12;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell2_2") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 10;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell2 = 8;
                GetComponent<Shoots>().rangeSpell2 = 2f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load2Spell3_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 3;
                GetComponent<Shoots>().cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load2Spell3_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load2Spell4_3") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 10;
                GetComponent<Shoots>().cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell4_2") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 8;
                GetComponent<Shoots>().cooldownSpell4 = 7f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell4 = 6;
                GetComponent<Shoots>().cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load2Spell5_3") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 5f;
                GetComponent<Shoots>().cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell5_2") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 4f;
                GetComponent<Shoots>().cooldownSpell5 = 8f;
            }
            else
            {
                GetComponent<Shoots>().rangeSpell5 = 3f;
                GetComponent<Shoots>().cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load2Spell6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 6;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 8f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 2f;
                GetComponent<Shoots>().cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load2Spell7_3") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 15;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell7_2") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 11;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 22.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell7 = 7;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load2Spell8_3") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 25;
                GetComponent<Shoots>().cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load2Spell8_2") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 20;
                GetComponent<Shoots>().cooldownSpell8 = 27.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell8 = 15;
                GetComponent<Shoots>().cooldownSpell8 = 30f;
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
                GetComponent<Shoots>().movementBonus += 0.4f;
            }
            else if (PlayerPrefs.GetInt("Load2Passive4_2") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.3f;
            }
            else if (PlayerPrefs.GetInt("Load2Passive4_1") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.2f;
            }


            if (PlayerPrefs.GetInt("Load2Passive5_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 3;
                GetComponent<Shoots>().damageSpell4 += 3;
                GetComponent<Shoots>().damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load2Passive5_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 2;
                GetComponent<Shoots>().damageSpell4 += 2;
                GetComponent<Shoots>().damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load2Passive5_1") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 1;
                GetComponent<Shoots>().damageSpell4 += 1;
                GetComponent<Shoots>().damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load2Passive6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 3;
                GetComponent<Shoots>().damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load2Passive6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 2;
                GetComponent<Shoots>().damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load2Passive6_1") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 1;
                GetComponent<Shoots>().damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load2DecorationColor");

            if (chimney == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (chimney == 3)
                GetComponent<Shoots>().decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load2DecorationGod");

            if (god == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (god == 2)
                GetComponent<Shoots>().decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                GetComponent<Shoots>().decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load2DecorationBanner") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;


            int equipment = PlayerPrefs.GetInt("Load2DecorationWeapons");

            if (equipment == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (equipment == 2)
                GetComponent<Shoots>().decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load2DecorationCarpet") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
        }
        else if (gm.GetComponent<GameManager>().currSave == 3)
        {
            if (PlayerPrefs.GetInt("Load3Spell1_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 8;
                GetComponent<Shoots>().cooldownAttack = 0.5f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell1_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 = 6;
                GetComponent<Shoots>().cooldownAttack = 0.75f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell1 = 5;
                GetComponent<Shoots>().cooldownAttack = 1f;
            }


            if (PlayerPrefs.GetInt("Load3Spell2_3") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 12;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 3f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell2_2") == 1)
            {
                GetComponent<Shoots>().damageSpell2 = 10;
                GetComponent<Shoots>().rangeSpell2 = 3f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell2 = 8;
                GetComponent<Shoots>().rangeSpell2 = 2f;
                GetComponent<Shoots>().cooldownSpell2 = 4f;
            }


            if (PlayerPrefs.GetInt("Load3Spell3_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 3;
                GetComponent<Shoots>().cooldownSpell3 = 4f;
                numberShards = 6;
            }
            else if (PlayerPrefs.GetInt("Load3Spell3_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 5;
            }
            else
            {
                GetComponent<Shoots>().damageSpell3 = 2;
                GetComponent<Shoots>().cooldownSpell3 = 5f;
                numberShards = 4;
            }


            if (PlayerPrefs.GetInt("Load3Spell4_3") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 10;
                GetComponent<Shoots>().cooldownSpell4 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell4_2") == 1)
            {
                GetComponent<Shoots>().damageSpell4 = 8;
                GetComponent<Shoots>().cooldownSpell4 = 7f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell4 = 6;
                GetComponent<Shoots>().cooldownSpell4 = 8f;
            }


            if (PlayerPrefs.GetInt("Load3Spell5_3") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 5f;
                GetComponent<Shoots>().cooldownSpell5 = 6f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell5_2") == 1)
            {
                GetComponent<Shoots>().rangeSpell5 = 4f;
                GetComponent<Shoots>().cooldownSpell5 = 8f;
            }
            else
            {
                GetComponent<Shoots>().rangeSpell5 = 3f;
                GetComponent<Shoots>().cooldownSpell5 = 10f;
            }


            if (PlayerPrefs.GetInt("Load3Spell6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 6;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 7f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 3f;
                GetComponent<Shoots>().cooldownSpell6 = 8f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell6 = 5;
                GetComponent<Shoots>().rangeSpell6 = 2f;
                GetComponent<Shoots>().cooldownSpell6 = 9f;
            }


            if (PlayerPrefs.GetInt("Load3Spell7_3") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 15;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 20f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell7_2") == 1)
            {
                GetComponent<Shoots>().damageSpell7 = 11;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 22.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell7 = 7;
                GetComponent<Shoots>().rangeSpell7 = 2f;
                GetComponent<Shoots>().cooldownSpell7 = 25f;
            }


            if (PlayerPrefs.GetInt("Load3Spell8_3") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 25;
                GetComponent<Shoots>().cooldownSpell8 = 25f;
            }
            else if (PlayerPrefs.GetInt("Load3Spell8_2") == 1)
            {
                GetComponent<Shoots>().damageSpell8 = 20;
                GetComponent<Shoots>().cooldownSpell8 = 27.5f;
            }
            else
            {
                GetComponent<Shoots>().damageSpell8 = 15;
                GetComponent<Shoots>().cooldownSpell8 = 30f;
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
                GetComponent<Shoots>().movementBonus += 0.4f;
            }
            else if (PlayerPrefs.GetInt("Load3Passive4_2") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.3f;
            }
            else if (PlayerPrefs.GetInt("Load3Passive4_1") == 1)
            {
                GetComponent<Shoots>().movementBonus += 0.2f;
            }


            if (PlayerPrefs.GetInt("Load3Passive5_3") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 3;
                GetComponent<Shoots>().damageSpell4 += 3;
                GetComponent<Shoots>().damageSpell8 += 3;
            }
            else if (PlayerPrefs.GetInt("Load3Passive5_2") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 2;
                GetComponent<Shoots>().damageSpell4 += 2;
                GetComponent<Shoots>().damageSpell8 += 2;
            }
            else if (PlayerPrefs.GetInt("Load3Passive5_1") == 1)
            {
                GetComponent<Shoots>().damageSpell1 += 1;
                GetComponent<Shoots>().damageSpell4 += 1;
                GetComponent<Shoots>().damageSpell8 += 1;
            }


            if (PlayerPrefs.GetInt("Load3Passive6_3") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 3;
                GetComponent<Shoots>().damageSpell6 += 3;
            }
            else if (PlayerPrefs.GetInt("Load3Passive6_2") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 2;
                GetComponent<Shoots>().damageSpell6 += 2;
            }
            else if (PlayerPrefs.GetInt("Load3Passive6_1") == 1)
            {
                GetComponent<Shoots>().damageSpell3 += 1;
                GetComponent<Shoots>().damageSpell6 += 1;
            }


            int chimney = PlayerPrefs.GetInt("Load3DecorationColor");

            if (chimney == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (chimney == 3)
                GetComponent<Shoots>().decorationBonusTanking++;


            int god = PlayerPrefs.GetInt("Load3DecorationGod");

            if (god == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (god == 2)
                GetComponent<Shoots>().decorationBonusEffectDuration = 1.25f;
            else if (god == 3)
                GetComponent<Shoots>().decorationBonusHealing = GetComponent<StatsPlayer>().level;


            if (PlayerPrefs.GetInt("Load3DecorationBanner") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;


            int equipment = PlayerPrefs.GetInt("Load3DecorationWeapons");

            if (equipment == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
            else if (equipment == 2)
                GetComponent<Shoots>().decorationBonusTanking++;


            if (PlayerPrefs.GetInt("Load3DecorationCarpet") == 1)
                GetComponent<Shoots>().decorationBonusDamage++;
        }

        print("damage spell 1 : " + GetComponent<Shoots>().damageSpell1);
        print("damage spell 3 : " + GetComponent<Shoots>().damageSpell3);
        print("damage spell 4 : " + GetComponent<Shoots>().damageSpell4);
        print("damage spell 6 : " + GetComponent<Shoots>().damageSpell6);
        print("damage spell 8 : " + GetComponent<Shoots>().damageSpell8);

        print("deco damage : " + GetComponent<Shoots>().decorationBonusDamage);
        print("deco tanking : " + GetComponent<Shoots>().decorationBonusTanking);
        print("deco effect : " + GetComponent<Shoots>().decorationBonusEffectDuration);
        print("deco healing : " + GetComponent<Shoots>().decorationBonusHealing);

        SelectSpell1(true);
    }
	
	void Update ()
    {
        if (gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (isUnderMana == true)
            {
                manaTimer += Time.deltaTime;
                if (manaTimer >= GetComponent<Shoots>().cooldownManaEffect)
                {
                    isUnderMana = false;
                    speedCD = 1f;
                    manaTimer = 0f;
                }
            }
            if (spell1Ready == false)
            {
                timerAttack += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell1.GetComponent<Slider>().value = 1 - (float)timerAttack / (float)GetComponent<Shoots>().cooldownAttack;
                if (timerAttack >= GetComponent<Shoots>().cooldownAttack)
                {
                    timerAttack = 0f;
                    GetComponent<Shoots>().cdSpell1.GetComponent<Slider>().value = 0;
                    spell1Ready = true;
                }
            }
            if (spell2Ready == false)
            {
                timerSpell2 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell2.GetComponent<Slider>().value = 1 - (float)timerSpell2 / (float)GetComponent<Shoots>().cooldownSpell2;
                if (timerSpell2 >= GetComponent<Shoots>().cooldownSpell2)
                {
                    timerSpell2 = 0f;
                    GetComponent<Shoots>().cdSpell2.GetComponent<Slider>().value = 0;
                    spell2Ready = true;
                }
            }
            if (spell3Ready == false)
            {
                timerSpell3 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell3.GetComponent<Slider>().value = 1 - (float)timerSpell3 / (float)GetComponent<Shoots>().cooldownSpell3;
                if (timerSpell3 >= GetComponent<Shoots>().cooldownSpell3)
                {
                    timerSpell3 = 0f;
                    GetComponent<Shoots>().cdSpell3.GetComponent<Slider>().value = 0;
                    spell3Ready = true;
                }
            }
            if (spell4Ready == false)
            {
                timerSpell4 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell4.GetComponent<Slider>().value = 1 - (float)timerSpell4 / (float)GetComponent<Shoots>().cooldownSpell4;
                if (timerSpell4 >= GetComponent<Shoots>().cooldownSpell4)
                {
                    timerSpell4 = 0f;
                    GetComponent<Shoots>().cdSpell4.GetComponent<Slider>().value = 0;
                    spell4Ready = true;
                }
            }
            if (spell5Ready == false)
            {
                timerSpell5 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell5.GetComponent<Slider>().value = 1 - (float)timerSpell5 / (float)GetComponent<Shoots>().cooldownSpell5;
                if (timerSpell5 >= GetComponent<Shoots>().cooldownSpell5)
                {
                    timerSpell5 = 0f;
                    GetComponent<Shoots>().cdSpell5.GetComponent<Slider>().value = 0;
                    spell5Ready = true;
                }
            }
            if (spell6Ready == false)
            {
                timerSpell6 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell6.GetComponent<Slider>().value = 1 - (float)timerSpell6 / (float)GetComponent<Shoots>().cooldownSpell6;
                if (timerSpell6 >= GetComponent<Shoots>().cooldownSpell6)
                {
                    timerSpell6 = 0f;
                    GetComponent<Shoots>().cdSpell6.GetComponent<Slider>().value = 0;
                    spell6Ready = true;
                }
            }
            if (spell7Ready == false)
            {
                timerSpell7 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell7.GetComponent<Slider>().value = 1 - (float)timerSpell7 / (float)GetComponent<Shoots>().cooldownSpell7;
                if (timerSpell7 >= GetComponent<Shoots>().cooldownSpell7)
                {
                    timerSpell7 = 0f;
                    GetComponent<Shoots>().cdSpell7.GetComponent<Slider>().value = 0;
                    spell7Ready = true;
                }
            }
            if (spell8Ready == false)
            {
                timerSpell8 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdSpell8.GetComponent<Slider>().value = 1 - (float)timerSpell8 / (float)GetComponent<Shoots>().cooldownSpell8;
                if (timerSpell8 >= GetComponent<Shoots>().cooldownSpell8)
                {
                    timerSpell8 = 0f;
                    GetComponent<Shoots>().cdSpell8.GetComponent<Slider>().value = 0;
                    spell8Ready = true;
                }
            }
            if (object1Ready == false)
            {
                timerObject1 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdObject1.GetComponent<Slider>().value = 1 - (float)timerObject1 / (float)GetComponent<Shoots>().cooldownObject1;
                if (timerObject1 >= GetComponent<Shoots>().cooldownObject1)
                {
                    timerObject1 = 0f;
                    GetComponent<Shoots>().cdObject1.GetComponent<Slider>().value = 0;
                    object1Ready = true;
                }
            }
            if (object2Ready == false)
            {
                timerObject2 += Time.deltaTime * speedCD;
                GetComponent<Shoots>().cdObject2.GetComponent<Slider>().value = 1 - (float)timerObject2 / (float)GetComponent<Shoots>().cooldownObject2;
                if (timerObject2 >= GetComponent<Shoots>().cooldownObject2)
                {
                    timerObject2 = 0f;
                    GetComponent<Shoots>().cdObject2.GetComponent<Slider>().value = 0;
                    object2Ready = true;
                }
            }
            if (GetComponent<Shoots>().hasRuneCooldown == true)
            {
                if (GetComponent<Shoots>().isRuneDamage == true && GetComponent<Shoots>().nextSpellDamageRune == false)
                {
                    timerObject3 += Time.deltaTime * speedCD;
                    GetComponent<Shoots>().cdObject3.GetComponent<Slider>().value = 1 - (float)timerObject3 / (float)GetComponent<Shoots>().cooldownObject3;
                    if (timerObject3 >= GetComponent<Shoots>().cooldownObject3)
                    {
                        timerObject3 = 0f;
                        GetComponent<Shoots>().cdObject3.GetComponent<Slider>().value = 0;
                        GetComponent<Shoots>().nextSpellDamageRune = true;
                    }
                }
                else if (GetComponent<Shoots>().isRuneHeal == true)
                {
                    if (timerObject3 >= GetComponent<Shoots>().cooldownObject3)
                    {
                        if (GetComponent<StatsPlayer>().IsFullLife() == true)
                            GetComponent<Shoots>().cdObject3.GetComponent<Slider>().value = 0;
                        else
                        {
                            timerObject3 = 0f;
                            GetComponent<Shoots>().cdObject3.GetComponent<Slider>().value = 0;
                            GetComponent<StatsPlayer>().Heal(GetComponent<StatsPlayer>().level);
                        }
                    }
                    else
                    {
                        timerObject3 += Time.deltaTime * speedCD;
                        GetComponent<Shoots>().cdObject3.GetComponent<Slider>().value = 1 - (float)timerObject3 / (float)GetComponent<Shoots>().cooldownObject3;
                    }
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                if (GetComponent<Shoots>().spellSelected == 1)
                    SelectSpell8(true);
                else if (GetComponent<Shoots>().spellSelected == 2)
                    SelectSpell1(true);
                else if (GetComponent<Shoots>().spellSelected == 3)
                    SelectSpell2(true);
                else if (GetComponent<Shoots>().spellSelected == 4)
                    SelectSpell3(true);
                else if (GetComponent<Shoots>().spellSelected == 5)
                    SelectSpell4(true);
                else if (GetComponent<Shoots>().spellSelected == 6)
                    SelectSpell5(true);
                else if (GetComponent<Shoots>().spellSelected == 7)
                    SelectSpell6(true);
                else if (GetComponent<Shoots>().spellSelected == 8)
                    SelectSpell7(true);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            {
                if (GetComponent<Shoots>().spellSelected == 1)
                    SelectSpell2(true);
                else if (GetComponent<Shoots>().spellSelected == 2)
                    SelectSpell3(true);
                else if (GetComponent<Shoots>().spellSelected == 3)
                    SelectSpell4(true);
                else if (GetComponent<Shoots>().spellSelected == 4)
                    SelectSpell5(true);
                else if (GetComponent<Shoots>().spellSelected == 5)
                    SelectSpell6(true);
                else if (GetComponent<Shoots>().spellSelected == 6)
                    SelectSpell7(true);
                else if (GetComponent<Shoots>().spellSelected == 7)
                    SelectSpell8(true);
                else if (GetComponent<Shoots>().spellSelected == 8)
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
                    gm.GetComponent<GameManager>().zqsdMode == true) ||
                    (Input.GetKeyDown(KeyCode.Q) &&
                    gm.GetComponent<GameManager>().zqsdMode == false))
            {
                UseObject1();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                UseObject2();
            }
            if (GetComponent<Shoots>().spellSelected == 1 &&
                Input.GetMouseButton(0))
            {
                UseSpell1();
            }
            else if (GetComponent<Shoots>().spellSelected == 2 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell2();
            }
            else if (GetComponent<Shoots>().spellSelected == 3 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell3();
            }
            else if (GetComponent<Shoots>().spellSelected == 4 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell4();
            }
            else if (GetComponent<Shoots>().spellSelected == 5 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell5();
            }
            else if (GetComponent<Shoots>().spellSelected == 6 &&
                    Input.GetMouseButtonDown(0))
            {
                UseSpell6();
            }
            else if (GetComponent<Shoots>().spellSelected == 7 &&
            Input.GetMouseButtonDown(0))
            {
                UseSpell7();
            }
            else if (GetComponent<Shoots>().spellSelected == 8 &&
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell1 * 2, GetComponent<Shoots>().rangeSpell1 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 1;
            GetComponent<Shoots>().GetComponent<Shoots>().usingSpell1Icon.SetActive(true);
            GetComponent<Shoots>().GetComponent<Shoots>().usingSpell1Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell2 * 2, GetComponent<Shoots>().rangeSpell2 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 2;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell2Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell2Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell3 * 2, GetComponent<Shoots>().rangeSpell3 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 3;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell3Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell3Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell4 * 2, GetComponent<Shoots>().rangeSpell4 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 4;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell4Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell4Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell5 * 2, GetComponent<Shoots>().rangeSpell5 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 5;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell5Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell5Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell6 * 2, GetComponent<Shoots>().rangeSpell6 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 6;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell6Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell6Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
                Vector3 newScale = new Vector3(GetComponent<Shoots>().rangeSpell7 * 2, GetComponent<Shoots>().rangeSpell7 * 2, 1);
                GetComponent<Shoots>().rangeIndicator.transform.localScale = newScale;
                GetComponent<Shoots>().rangeIndicator.SetActive(true);
                GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().StartAnim(0);
            }
            else
                GetComponent<Shoots>().rangeIndicator.SetActive(false);

            GetComponent<Shoots>().spellSelected = 7;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell7Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell7Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
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
            GetComponent<Shoots>().rangeIndicator.GetComponent<SpriteAnimTimer>().isPlaying = false;
            GetComponent<Shoots>().rangeIndicator.SetActive(false);
            GetComponent<Shoots>().spellSelected = 8;
            GetComponent<Shoots>().usingSpell1Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell7Icon.SetActive(false);
            GetComponent<Shoots>().usingSpell8Icon.SetActive(true);
            GetComponent<Shoots>().usingSpell8Icon.GetComponent<UsingSpell>().player = gameObject;
            GetComponent<Shoots>().usingSpell8Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
        }
    }

    void FindShootDirection()
    {
        Vector2 newPosClick = GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

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
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.RIGHT;
        else if (distanceLeft < distanceTop &&
            distanceLeft < distanceBot &&
            distanceLeft < distanceRight &&
            distanceLeft < distanceTopRight &&
            distanceLeft < distanceTopLeft &&
            distanceLeft < distanceBotRight &&
            distanceLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.LEFT;
        else if (distanceBot < distanceTop &&
            distanceBot < distanceLeft &&
            distanceBot < distanceRight &&
            distanceBot < distanceTopRight &&
            distanceBot < distanceTopLeft &&
            distanceBot < distanceBotRight &&
            distanceBot < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.BOTTOM;
        else if (distanceTop < distanceBot &&
            distanceTop < distanceLeft &&
            distanceTop < distanceRight &&
            distanceTop < distanceTopRight &&
            distanceTop < distanceTopLeft &&
            distanceTop < distanceBotRight &&
            distanceTop < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.TOP;
        else if (distanceTopRight < distanceBot &&
            distanceTopRight < distanceLeft &&
            distanceTopRight < distanceRight &&
            distanceTopRight < distanceTop &&
            distanceTopRight < distanceTopLeft &&
            distanceTopRight < distanceBotRight &&
            distanceTopRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.TOPRIGHT;
        else if (distanceTopLeft < distanceBot &&
            distanceTopLeft < distanceLeft &&
            distanceTopLeft < distanceRight &&
            distanceTopLeft < distanceTop &&
            distanceTopLeft < distanceTopRight &&
            distanceTopLeft < distanceBotRight &&
            distanceTopLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.TOPLEFT;
        else if (distanceBotRight < distanceBot &&
            distanceBotRight < distanceLeft &&
            distanceBotRight < distanceRight &&
            distanceBotRight < distanceTop &&
            distanceBotRight < distanceTopRight &&
            distanceBotRight < distanceTopLeft &&
            distanceBotRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.BOTTOMRIGHT;
        else if (distanceBotLeft < distanceBot &&
            distanceBotLeft < distanceLeft &&
            distanceBotLeft < distanceRight &&
            distanceBotLeft < distanceTop &&
            distanceBotLeft < distanceTopRight &&
            distanceBotLeft < distanceTopLeft &&
            distanceBotLeft < distanceBotRight)
            GetComponent<Deplacements>().attackDirection = Shoots.Direction.BOTTOMLEFT;
    }

    void UseSpell1()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell1Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            GetComponent<Shoots>().cdSpell1.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell1Ready = false;
            GameObject sfx = (GameObject)Instantiate(fireballSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(InstantiateProjectile(GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    void UseSpell2()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell2Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= GetComponent<Shoots>().rangeSpell2)
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier" || hit.collider.tag == "Capture")
                {
                    if (canGainMovementSpeed == true)
                        GetComponent<Deplacements>().SetMovementBonus();
                    GetComponent<Shoots>().cdSpell2.GetComponent<Slider>().value = 1;
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
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell3Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            GetComponent<Shoots>().cdSpell3.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell3Ready = false;
            GameObject sfx = (GameObject)Instantiate(iceShardSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(InstantiateEclatsGlace(GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
            StartCoroutine(GoBackToAA());
        }
    }

    void UseSpell4()
    {
        if (gm.GetComponent<GameManager>().smartcast == true)
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell4Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= GetComponent<Shoots>().rangeSpell4)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            GetComponent<Shoots>().cdSpell4.GetComponent<Slider>().value = 1;
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
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell5Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= GetComponent<Shoots>().rangeSpell5)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            GetComponent<Shoots>().cdSpell5.GetComponent<Slider>().value = 1;
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

            GetComponent<Shoots>().rangeIndicator.SetActive(false);
        if (GetComponent<Shoots>().canShoot == true &&
            spell6Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) <= GetComponent<Shoots>().rangeSpell6)
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier" || hit.collider.tag == "Capture")
                {
                    if (canGainMovementSpeed == true)
                        GetComponent<Deplacements>().SetMovementBonus();
                    if (canStackThunderbolt == true)
                        thunderboltStacksBonus++;

                    GetComponent<Shoots>().cdSpell6.GetComponent<Slider>().value = 1;
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

            GetComponent<Shoots>().rangeIndicator.SetActive(false);
        if (spell7Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            GetComponent<Shoots>().cdSpell7.GetComponent<Slider>().value = 1;
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
            GetComponent<Shoots>().rangeIndicator.SetActive(false);

        if (GetComponent<Shoots>().canShoot == true &&
            spell8Ready == true &&
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            if (canGainMovementSpeed == true)
                GetComponent<Deplacements>().SetMovementBonus();
            if (canStackThunderbolt == true)
                thunderboltStacksBonus++;

            GetComponent<Shoots>().cdSpell8.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell8Ready = false;
            GameObject sfx = (GameObject)Instantiate(dragonSFX, transform.position, transform.rotation);
            sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
            StartCoroutine(SpellDragonFeu(GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
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
            GetComponent<Shoots>().cdObject1.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            object1Ready = false;
            GameObject sfx = (GameObject)Instantiate(GetComponent<Shoots>().potionHealthSFX, transform.position, transform.rotation);
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
            GetComponent<Shoots>().cdObject2.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            object2Ready = false;
            isUnderMana = true;
            GameObject sfx = (GameObject)Instantiate(GetComponent<Shoots>().potionManaSFX, transform.position, transform.rotation);
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
        if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.RIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.LEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        int damageBonus = 0;
        if (GetComponent<Shoots>().nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            GetComponent<Shoots>().nextSpellDamageRune = false;
        }

        damageBonus += GetComponent<Shoots>().decorationBonusDamage;

        obj = (GameObject)Instantiate(fireball, newPos, rot);
        obj.GetComponent<Projectile>().GetPos(directionPos, GetComponent<Shoots>().damageSpell1 + damageBonus, projectileRotation, gameObject);
    }

    IEnumerator InstantiateEclatsGlace(Vector2 directionPos)
    {
        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.RIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.LEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        int damageBonus = 0;
        if (GetComponent<Shoots>().nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            GetComponent<Shoots>().nextSpellDamageRune = false;
        }

        damageBonus += GetComponent<Shoots>().decorationBonusDamage;

        GameObject obj1 = null;
        obj1 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj1.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + damageBonus, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj2 = null;
        obj2 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj2.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + GetComponent<Shoots>().decorationBonusDamage, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj3 = null;
        obj3 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj3.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + GetComponent<Shoots>().decorationBonusDamage, projectileRotation, gameObject);
        yield return new WaitForSeconds(0.07f);

        GameObject obj4 = null;
        obj4 = (GameObject)Instantiate(iceShard, newPos, rot);
        obj4.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + GetComponent<Shoots>().decorationBonusDamage, projectileRotation, gameObject);

        if (numberShards > 4)
        {
            yield return new WaitForSeconds(0.07f);
            GameObject obj5 = null;
            obj5 = (GameObject)Instantiate(iceShard, newPos, rot);
            obj5.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + GetComponent<Shoots>().decorationBonusDamage, projectileRotation, gameObject);
        }

        if (numberShards > 5)
        {
            yield return new WaitForSeconds(0.07f);
            GameObject obj6 = null;
            obj6 = (GameObject)Instantiate(iceShard, newPos, rot);
            obj6.GetComponent<IceShard>().GetPos(directionPos, GetComponent<Shoots>().damageSpell3 + GetComponent<Shoots>().decorationBonusDamage, projectileRotation, gameObject);
        }
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
            if (GetComponent<Shoots>().nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                GetComponent<Shoots>().nextSpellDamageRune = false;
            }

            damageBonus += GetComponent<Shoots>().decorationBonusDamage;

            vectorTmp = go.transform.position;
            vectorTmp.y += 0.5f;
            GameObject obj2 = (GameObject)Instantiate(thunderboltBase, vectorTmp, transform.rotation);
            obj2.GetComponent<Thunderbolt>().enemy = go;
            if (go.tag != "Capture")
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell2 + damageBonus + thunderboltStacksBonus, true, transform.position);
            else if (go.tag == "Capture")
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell2 + damageBonus + thunderboltStacksBonus, false, transform.position);

            thunderboltStacksBonus = 0;
        }
    }

    IEnumerator GoBackToAA()
    {
        yield return new WaitForSeconds(0.1f);
        SelectSpell1(true);
        GetComponent<Shoots>().spellSelected = 1;
        GetComponent<Shoots>().usingSpell1Icon.SetActive(true);
        GetComponent<Shoots>().usingSpell1Icon.GetComponent<UsingSpell>().SetAnimNb(GetComponent<Shoots>().usingSpellInt);
        GetComponent<Shoots>().usingSpell2Icon.SetActive(false);
        GetComponent<Shoots>().usingSpell3Icon.SetActive(false);
        GetComponent<Shoots>().usingSpell4Icon.SetActive(false);
        GetComponent<Shoots>().usingSpell5Icon.SetActive(false);
        GetComponent<Shoots>().usingSpell6Icon.SetActive(false);
        GetComponent<Shoots>().usingSpell8Icon.SetActive(false);
    }

    IEnumerator SpellMeteore()
    {
        Vector2 mousePos = GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector2 meteorPos = mousePos;
        meteorPos.y += 0.5f;
        Instantiate(meteor, meteorPos, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject go in GetComponent<Shoots>().mapManager.GetComponent<MapManager>().enemiesList)
        {
            int damageBonus = 0;
            if (GetComponent<Shoots>().nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                GetComponent<Shoots>().nextSpellDamageRune = false;
            }

            damageBonus += GetComponent<Shoots>().decorationBonusDamage;

            if (Vector2.Distance(go.transform.position, mousePos) < 1 &&
                go.tag != "Capture")
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell4 + damageBonus, true, mousePos);
            else if (Vector2.Distance(go.transform.position, mousePos) < 1 &&
                go.tag == "Capture")
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell4 + damageBonus, false, mousePos);
        }
    }

    IEnumerator SpellTornade()
    {
        Vector2 mousePos = GetComponent<Shoots>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePos.y += 0.6f;
        yield return new WaitForSeconds(0.2f);
        Instantiate(tornadoBase, mousePos, transform.rotation);
        yield return new WaitForSeconds(0.16f);
        GameObject obj1 = (GameObject)Instantiate(tornado, mousePos, transform.rotation);
        obj1.GetComponent<SpriteAnimTimer>().StartAnim(2 * GetComponent<Shoots>().decorationBonusEffectDuration);
        obj1.GetComponent<Tornado>().id = idSpell5++;
        obj1.GetComponent<Tornado>().CCDuration = 2 * GetComponent<Shoots>().decorationBonusEffectDuration;
    }

    IEnumerator SpellPrisonGlace(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        if (go.gameObject != null)
        {
            int damageBonus = 0;
            if (GetComponent<Shoots>().nextSpellDamageRune == true)
            {
                damageBonus += GetComponent<StatsPlayer>().level;
                GetComponent<Shoots>().nextSpellDamageRune = false;
            }

            damageBonus += GetComponent<Shoots>().decorationBonusDamage;

            Vector2 vectorTmp = go.transform.position;
            vectorTmp.y -= 0.2f;
            GameObject tmp = (GameObject)Instantiate(icePrison, vectorTmp, go.transform.rotation);
            tmp.GetComponent<SpriteAnimTimer>().StartAnim(2 * GetComponent<Shoots>().decorationBonusEffectDuration);
            if (go.tag != "Capture")
            {
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell6 + damageBonus, true, transform.position);
                go.GetComponent<IAGuerrier>().ApplyCC(2 * GetComponent<Shoots>().decorationBonusEffectDuration);
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
        if (GetComponent<Shoots>().nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            GetComponent<Shoots>().nextSpellDamageRune = false;
        }

        damageBonus += GetComponent<Shoots>().decorationBonusDamage;

        foreach (GameObject go in GetComponent<Shoots>().mapManager.GetComponent<MapManager>().enemiesList)
        {
            if (Vector2.Distance(go.transform.position, transform.position) < 2 &&
                go.tag != "Capture")
            {
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell7 + damageBonus, true, transform.position);
                go.GetComponent<IAGuerrier>().ApplySlow(2f * GetComponent<Shoots>().decorationBonusEffectDuration, 0.5f);
            }
            else if (Vector2.Distance(go.transform.position, transform.position) < 2 &&
                go.tag == "Capture")
            {
                InflictDamage(go.gameObject, GetComponent<Shoots>().damageSpell7 + damageBonus, false, transform.position);
            }
        }
    }

    IEnumerator SpellDragonFeu(Vector2 directionPos)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = null;

        int damageBonus = 0;
        if (GetComponent<Shoots>().nextSpellDamageRune == true)
        {
            damageBonus += GetComponent<StatsPlayer>().level;
            GetComponent<Shoots>().nextSpellDamageRune = false;
        }

        damageBonus += GetComponent<Shoots>().decorationBonusDamage;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.RIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.LEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOM)
        {
            newPos.y = transform.position.y - 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation + 180f);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOP)
        {
            newPos.y = transform.position.y + 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, GetComponent<Shoots>().damageSpell8 + damageBonus, projectileRotation);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
    }
}
