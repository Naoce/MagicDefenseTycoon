using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradManager : MonoBehaviour
{
    public Text HUDTextDescriptionSpell1;
    public Text HUDTextDescriptionSpell2;
    public Text HUDTextDescriptionSpell3;
    public Text HUDTextDescriptionSpell4;
    public Text HUDTextDescriptionSpell5;
    public Text HUDTextDescriptionSpell6;
    public Text HUDTextDescriptionSpell7;
    public Text HUDTextDescriptionSpell8;
    public Text HUDTextDescriptionPotion1;
    public Text HUDTextDescriptionPotion2;
    public Text HUDTextDescriptionRune;

    public string EnglishRuneDamageTitle;
    public string EnglishRuneCelerityTitle;
    public string EnglishRuneHealTitle;
    public string EnglishRuneDamageInfo;
    public string EnglishRuneCelerityInfo;
    public string EnglishRuneHealInfo;


    public string EnglishElementalSpellInGame1_1;
    public string EnglishElementalSpellInGame1_2;

    public string EnglishElementalSpellInGame2_1;
    public string EnglishElementalSpellInGame2_2;

    public string EnglishElementalSpellInGame3_1;
    public string EnglishElementalSpellInGame3_2;
    public string EnglishElementalSpellInGame3_3;

    public string EnglishElementalSpellInGame4_1;
    public string EnglishElementalSpellInGame4_2;

    public string EnglishElementalSpellInGame5_1;
    public string EnglishElementalSpellInGame5_2;

    public string EnglishElementalSpellInGame6_1;
    public string EnglishElementalSpellInGame6_2;
    public string EnglishElementalSpellInGame6_3;

    public string EnglishElementalSpellInGame7_1;
    public string EnglishElementalSpellInGame7_2;
    public string EnglishElementalSpellInGame7_3;

    public string EnglishElementalSpellInGame8_1;
    public string EnglishElementalSpellInGame8_2;


    public string EnglishPotionInGame1_1;
    public string EnglishPotionInGame1_2;

    public string EnglishPotionInGame2;

    public string EnglishRuneDamageInGame1_1;
    public string EnglishRuneDamageInGame1_2;

    public string EnglishRuneCelerityInGame1_1;
    public string EnglishRuneCelerityInGame1_2;

    public string EnglishRuneHealInGame1_1;
    public string EnglishRuneHealInGame1_2;


    public string EnglishElementalSpell1;
    public string EnglishElementalSpell1_1;
    public string EnglishElementalSpell1_2;
    public string EnglishElementalSpell1_3;

    public string EnglishElementalSpell2;
    public string EnglishElementalSpell2_1;
    public string EnglishElementalSpell2_2;
    public string EnglishElementalSpell2_3;

    public string EnglishElementalSpell3;
    public string EnglishElementalSpell3_1;
    public string EnglishElementalSpell3_2;
    public string EnglishElementalSpell3_3;

    public string EnglishElementalSpell4;
    public string EnglishElementalSpell4_1;
    public string EnglishElementalSpell4_2;
    public string EnglishElementalSpell4_3;

    public string EnglishElementalSpell5;
    public string EnglishElementalSpell5_1;
    public string EnglishElementalSpell5_2;
    public string EnglishElementalSpell5_3;

    public string EnglishElementalSpell6;
    public string EnglishElementalSpell6_1;
    public string EnglishElementalSpell6_2;
    public string EnglishElementalSpell6_3;

    public string EnglishElementalSpell7;
    public string EnglishElementalSpell7_1;
    public string EnglishElementalSpell7_2;
    public string EnglishElementalSpell7_3;

    public string EnglishElementalSpell8;
    public string EnglishElementalSpell8_1;
    public string EnglishElementalSpell8_2;
    public string EnglishElementalSpell8_3;


    public string EnglishElementalPassive1;
    public string EnglishElementalPassive1_1;
    public string EnglishElementalPassive1_2;
    public string EnglishElementalPassive1_3;

    public string EnglishElementalPassive2;
    public string EnglishElementalPassive2_1;
    public string EnglishElementalPassive2_2;
    public string EnglishElementalPassive2_3;

    public string EnglishElementalPassive3;
    public string EnglishElementalPassive3_1;
    public string EnglishElementalPassive3_2;
    public string EnglishElementalPassive3_3;

    public string EnglishElementalPassive4;
    public string EnglishElementalPassive4_1;
    public string EnglishElementalPassive4_2;
    public string EnglishElementalPassive4_3;

    public string EnglishElementalPassive5;
    public string EnglishElementalPassive5_1;
    public string EnglishElementalPassive5_2;
    public string EnglishElementalPassive5_3;

    public string EnglishElementalPassive6;
    public string EnglishElementalPassive6_1;
    public string EnglishElementalPassive6_2;
    public string EnglishElementalPassive6_3;


    public string EnglishDecorationTitleChimney1;
    public string EnglishDecorationTitleChimney2;
    public string EnglishDecorationTitleChimney3;

    public string EnglishDecorationTitleGod1;
    public string EnglishDecorationTitleGod2;
    public string EnglishDecorationTitleGod3;

    public string EnglishDecorationTitleBanner1;
    public string EnglishDecorationTitleBanner2;

    public string EnglishDecorationTitleEquipment1;
    public string EnglishDecorationTitleEquipment2;

    public string EnglishDecorationTitleCarpet1;
    public string EnglishDecorationTitleCarpet2;

    public string EnglishDecorationDescriptionChimney1;
    public string EnglishDecorationDescriptionChimney2;
    public string EnglishDecorationDescriptionChimney3;

    public string EnglishDecorationDescriptionGod1;
    public string EnglishDecorationDescriptionGod2;
    public string EnglishDecorationDescriptionGod3;

    public string EnglishDecorationDescriptionBanner1;
    public string EnglishDecorationDescriptionBanner2;

    public string EnglishDecorationDescriptionEquipment1;
    public string EnglishDecorationDescriptionEquipment2;

    public string EnglishDecorationDescriptionCarpet1;
    public string EnglishDecorationDescriptionCarpet2;

    void Start()
    {
        EnglishRuneDamageTitle = "War rune";
        EnglishRuneCelerityTitle = "Celerity rune";
        EnglishRuneHealTitle = "Healing rune";
        EnglishRuneDamageInfo = "Every 10 seconds, the next spell cast will deal bonus damage, depending on the level of the mage.";
        EnglishRuneCelerityInfo = "The mage runs faster, depending on his level.";
        EnglishRuneHealInfo = "Every 15 seconds, the mage recovers some health points depending, on his level.";


        EnglishElementalSpellInGame1_1 = "Shoots a fireball that deals ";
        EnglishElementalSpellInGame1_2 = " damage to the first enemy hit.";

        EnglishElementalSpellInGame2_1 = "A thunderbolt that deals ";
        EnglishElementalSpellInGame2_2 = " damage to the targeted enemy.";

        EnglishElementalSpellInGame3_1 = "Shoots ";
        EnglishElementalSpellInGame3_2 = " ice shards that deal ";
        EnglishElementalSpellInGame3_3 = " damage each to the first enemy hit.";

        EnglishElementalSpellInGame4_1 = "A meteor that deals ";
        EnglishElementalSpellInGame4_2 = " damage to all enemies around it.";

        EnglishElementalSpellInGame5_1 = "A tornado that sends all enemies around it flying for ";
        EnglishElementalSpellInGame5_2 = " seconds.";

        EnglishElementalSpellInGame6_1 = "Encase the selected enemy in ice for ";
        EnglishElementalSpellInGame6_2 = " seconds, dealing ";
        EnglishElementalSpellInGame6_3 = " damage.";

        EnglishElementalSpellInGame7_1 = "An earthquake deals ";
        EnglishElementalSpellInGame7_2 = " damage to the enemies near the player and slows them for 50% during ";
        EnglishElementalSpellInGame7_3 = " seconds.";

        EnglishElementalSpellInGame8_1 = "Shoots a fire dragon that deals ";
        EnglishElementalSpellInGame8_2 = " damage to all enemies in its path.";


        EnglishPotionInGame1_1 = "Heals the player for ";
        EnglishPotionInGame1_2 = " health points.";

        EnglishPotionInGame2 = "Accelerates the recuperation of the player skills for 5 seconds.";

        EnglishRuneDamageInGame1_1 = "Every 10 seconds, the next spell cast will deal ";
        EnglishRuneDamageInGame1_2 = " additional damage.";

        EnglishRuneCelerityInGame1_1 = "The mage runs ";
        EnglishRuneCelerityInGame1_2 = "% faster.";

        EnglishRuneHealInGame1_1 = "Every 15 seconds, the mage recovers ";
        EnglishRuneHealInGame1_2 = " health points.";


        EnglishElementalSpell1 = "Fireball";
        EnglishElementalSpell1_1 = "Level 1\nCooldown 1s\nRange 3\nShoots a fireball that deals 5 damage to the first enemy hit.";
        EnglishElementalSpell1_2 = "Level 2\nCooldown 0.75s\nRange 3\nShoots a fireball that deals 6 damage to the first enemy hit.";
        EnglishElementalSpell1_3 = "Level 3\nCooldown 0.5s\nRange 3\nShoots a fireball that deals 8 damage to the first enemy hit.";

        EnglishElementalSpell2 = "Thunderbolt";
        EnglishElementalSpell2_1 = "Level 1\nCooldown 4s\nRange 2\nA thunderbolt that deals 8 damage to the selected enemy.";
        EnglishElementalSpell2_2 = "Level 2\nCooldown 4s\nRange 3\nA thunderbolt that deals 10 damage to the selected enemy.";
        EnglishElementalSpell2_3 = "Level 3\nCooldown 3s\nRange 3\nA thunderbolt that deals 12 damage to the selected enemy.";

        EnglishElementalSpell3 = "Ice Shards";
        EnglishElementalSpell3_1 = "Level 1\nCooldown 5s\nRange 3\nShoots 4 ice shards that deal 2 damage each to the first enemy hit.";
        EnglishElementalSpell3_2 = "Level 2\nCooldown 4s\nRange 3\nShoots 5 ice shards that deal 2 damage each to the first enemy hit.";
        EnglishElementalSpell3_3 = "Level 3\nCooldown 4s\nRange 3\nShoots 6 ice shards that deal 3 damage each to the first enemy hit.";

        EnglishElementalSpell4 = "Meteor";
        EnglishElementalSpell4_1 = "Level 1\nCooldown 8s\nRange 3\nA meteor that deals 6 damage to all enemies around it.";
        EnglishElementalSpell4_2 = "Level 2\nCooldown 7s\nRange 3\nA meteor that deals 8 damage to all enemies around it.";
        EnglishElementalSpell4_3 = "Level 3\nCooldown 6s\nRange 3\nA meteor that deals 10 damage to all enemies around it.";

        EnglishElementalSpell5 = "Tornado";
        EnglishElementalSpell5_1 = "Level 1\nCooldown 10s\nRange 3\nA tornado that sends all enemies around it flying for 2 seconds.";
        EnglishElementalSpell5_2 = "Level 2\nCooldown 8s\nRange 4\nA tornado that sends all enemies around it flying for 2 seconds.";
        EnglishElementalSpell5_3 = "Level 3\nCooldown 6s\nRange 5\nA tornado that sends all enemies around it flying for 2 seconds.";

        EnglishElementalSpell6 = "Ice Prison";
        EnglishElementalSpell6_1 = "Level 1\nCooldown 9s\nRange 2\nEncase the selected enemy in ice for 2 seconds, dealing 5 damage.";
        EnglishElementalSpell6_2 = "Level 2\nCooldown 8s\nRange 3\nEncase the selected enemy in ice for 2 seconds, dealing 5 damage.";
        EnglishElementalSpell6_3 = "Level 3\nCooldown 7s\nRange 3\nEncase the selected enemy in ice for 2 seconds, dealing 6 damage.";

        EnglishElementalSpell7 = "Earthquake";
        EnglishElementalSpell7_1 = "Level 1\nCooldown 25s\nRange 2\nAn earthquake deals 7 damage to the enemies near the player and slows them for 50% during 2 seconds.";
        EnglishElementalSpell7_2 = "Level 2\nCooldown 22.5s\nRange 2\nAn earthquake deals 11 damage to the enemies near the player and slows them for 50% during 2 seconds.";
        EnglishElementalSpell7_3 = "Level 3\nCooldown 20s\nRange 2\nAn earthquake deals 15 damage to the enemies near the player and slows them for 50% during 2 seconds.";

        EnglishElementalSpell8 = "Fire Dragon";
        EnglishElementalSpell8_1 = "Level 1\nCooldown 30s\nRange infinite\nShoots a fire dragon that deals 15 damage to all enemies in its path.";
        EnglishElementalSpell8_2 = "Level 2\nCooldown 27.5s\nRange infinite\nShoots a fire dragon that deals 20 damage to all enemies in its path.";
        EnglishElementalSpell8_3 = "Level 3\nCooldown 25s\nRange infinite\nShoots a fire dragon that deals 25 damage to all enemies in its path.";


        EnglishElementalPassive1 = "Fire armor [Shield]";
        EnglishElementalPassive1_1 = "Level 1\nEnemies that attack you in melee take 1 damage.\nYou can only learn one shield skill.";
        EnglishElementalPassive1_2 = "Level 2\nEnemies that attack you in melee take 3 damage.\nYou can only learn one shield skill.";
        EnglishElementalPassive1_3 = "Level 3\nEnemies that attack you in melee take 5 damage.\nYou can only learn one shield skill.";

        EnglishElementalPassive2 = "Ice armor [Shield]";
        EnglishElementalPassive2_1 = "Level 1\nEnemies that attack you in melee are slowed by 20% for 2 sec.\nYou can only learn one shield skill.";
        EnglishElementalPassive2_2 = "Level 2\nEnemies that attack you in melee are slowed by 40% for 2 sec.\nYou can only learn one shield skill.";
        EnglishElementalPassive2_3 = "Level 3\nEnemies that attack you in melee are slowed by 60% for 2 sec.\nYou can only learn one shield skill.";

        EnglishElementalPassive3 = "Thunder overload";
        EnglishElementalPassive3_1 = "Level 1\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 1 additional point of damage. (Stacks)";
        EnglishElementalPassive3_2 = "Level 2\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 2 additional points of damage. (Stacks)";
        EnglishElementalPassive3_3 = "Level 3\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 3 additional points of damage. (Stacks)";

        EnglishElementalPassive4 = "Celerity";
        EnglishElementalPassive4_1 = "Level 1\nAfter using a spell (except the Fireball), your move speed increase by 20% for 1 second.";
        EnglishElementalPassive4_2 = "Level 2\nAfter using a spell (except the Fireball), your move speed increase by 30% for 1 second.";
        EnglishElementalPassive4_3 = "Level 3\nAfter using a spell (except the Fireball), your move speed increase by 40% for 1 second.";

        EnglishElementalPassive5 = "Fire mastery [Mastery]";
        EnglishElementalPassive5_1 = "Level 1\nFire spells deal 1 additional point of damage.\nYou can only learn one mastery skill.";
        EnglishElementalPassive5_2 = "Level 2\nFire spells deal 2 additional points of damage.\nYou can only learn one mastery skill.";
        EnglishElementalPassive5_3 = "Level 3\nFire spells deal 3 additional points of damage.\nYou can only learn one mastery skill.";

        EnglishElementalPassive6 = "Ice mastery [Mastery]";
        EnglishElementalPassive6_1 = "Level 1\nIce spells deal 1 additional point of damage.\nYou can only learn one mastery skill.";
        EnglishElementalPassive6_2 = "Level 2\nIce spells deal 2 additional points of damage.\nYou can only learn one mastery skill.";
        EnglishElementalPassive6_3 = "Level 3\nIce spells deal 3 additional points of damage.\nYou can only learn one mastery skill.";


        EnglishDecorationTitleChimney1 = "Chimney, red flame";
        EnglishDecorationTitleChimney2 = "Chimney, blue flame";
        EnglishDecorationTitleChimney3 = "Chimney, yellow flame";

        EnglishDecorationTitleGod1 = "God of War";
        EnglishDecorationTitleGod2 = "God of Time";
        EnglishDecorationTitleGod3 = "God of Life";

        EnglishDecorationTitleBanner1 = "Weapons banners";
        EnglishDecorationTitleBanner2 = "Crowns banners";

        EnglishDecorationTitleEquipment1 = "Weapon racks";
        EnglishDecorationTitleEquipment2 = "Shield racks";

        EnglishDecorationTitleCarpet1 = "Bear carpet";
        EnglishDecorationTitleCarpet2 = "Crowns carpet";

        EnglishDecorationDescriptionChimney1 = EnglishDecorationTitleChimney1 + "\n\nEvery spell cast by the player and attack from allies will do 1 additional point of damage.\n\nPrice : 20 gold coins";
        EnglishDecorationDescriptionChimney2 = EnglishDecorationTitleChimney2 + "\n\nEvery attack against the player or his allies will do 1 less point of damage.\n\nPrice : 20 gold coins";
        EnglishDecorationDescriptionChimney3 = EnglishDecorationTitleChimney3 + "\n\nPrestige +10.\n\nPrice : 20 gold coins";

        EnglishDecorationDescriptionGod1 = EnglishDecorationTitleGod1 + "\n\nEvery spell cast by the player and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins";
        EnglishDecorationDescriptionGod2 = EnglishDecorationTitleGod2 + "\n\nIncrease the duration of the effects caused by the player by 25%.\n\nPrice : 50 gold coins";
        EnglishDecorationDescriptionGod3 = EnglishDecorationTitleGod3 + "\n\nIncrease the treatments received by the player and his allies by an amount dependant on the level of the player.\n\nPrice : 40 gold coins";

        EnglishDecorationDescriptionBanner1 = EnglishDecorationTitleBanner1 + "\n\nEvery spell cast by the player and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins";
        EnglishDecorationDescriptionBanner2 = EnglishDecorationTitleBanner2 + "\n\nPrestige + 10.\n\nPrice: 30 gold coins";

        EnglishDecorationDescriptionEquipment1 = EnglishDecorationTitleEquipment1 + "\n\nEvery spell cast by the player and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins";
        EnglishDecorationDescriptionEquipment2 = EnglishDecorationTitleEquipment2 + "\n\nEvery attack against the player or his allies will do 1 less point of damage.\n\nPrice : 30 gold coins";

        EnglishDecorationDescriptionCarpet1 = EnglishDecorationTitleCarpet1 + "\n\nEvery spell cast by the player and attack from allies will do 1 additional point of damage.\n\nPrice : 20 gold coins";
        EnglishDecorationDescriptionCarpet2 = EnglishDecorationTitleCarpet2 + "\n\nPrestige + 10.\n\nPrice: 30 gold coins";
    }

    public string GetDecorationTitleChimney1()
    {
        return (EnglishDecorationTitleChimney1);
    }

    public string GetDecorationTitleChimney2()
    {
        return (EnglishDecorationTitleChimney2);
    }

    public string GetDecorationTitleChimney3()
    {
        return (EnglishDecorationTitleChimney3);
    }

    public string GetDecorationTitleGod1()
    {
        return (EnglishDecorationTitleGod1);
    }

    public string GetDecorationTitleGod2()
    {
        return (EnglishDecorationTitleGod2);
    }

    public string GetDecorationTitleGod3()
    {
        return (EnglishDecorationTitleGod3);
    }

    public string GetDecorationTitleBanner1()
    {
        return (EnglishDecorationTitleBanner1);
    }

    public string GetDecorationTitleBanner2()
    {
        return (EnglishDecorationTitleBanner2);
    }

    public string GetDecorationTitleEquipment1()
    {
        return (EnglishDecorationTitleEquipment1);
    }

    public string GetDecorationTitleEquipment2()
    {
        return (EnglishDecorationTitleEquipment2);
    }

    public string GetDecorationTitleCarpet1()
    {
        return (EnglishDecorationTitleCarpet1);
    }

    public string GetDecorationTitleCarpet2()
    {
        return (EnglishDecorationTitleCarpet2);
    }

    public string GetDecorationDescriptionChimney1()
    {
        return (EnglishDecorationDescriptionChimney1);
    }

    public string GetDecorationDescriptionChimney2()
    {
        return (EnglishDecorationDescriptionChimney2);
    }

    public string GetDecorationDescriptionChimney3()
    {
        return (EnglishDecorationDescriptionChimney3);
    }

    public string GetDecorationDescriptionGod1()
    {
        return (EnglishDecorationDescriptionGod1);
    }

    public string GetDecorationDescriptionGod2()
    {
        return (EnglishDecorationDescriptionGod2);
    }

    public string GetDecorationDescriptionGod3()
    {
        return (EnglishDecorationDescriptionGod3);
    }

    public string GetDecorationDescriptionBanner1()
    {
        return (EnglishDecorationDescriptionBanner1);
    }

    public string GetDecorationDescriptionBanner2()
    {
        return (EnglishDecorationDescriptionBanner2);
    }

    public string GetDecorationDescriptionEquipment1()
    {
        return (EnglishDecorationDescriptionEquipment1);
    }

    public string GetDecorationDescriptionEquipment2()
    {
        return (EnglishDecorationDescriptionEquipment2);
    }

    public string GetDecorationDescriptionCarpet1()
    {
        return (EnglishDecorationDescriptionCarpet1);
    }

    public string GetDecorationDescriptionCarpet2()
    {
        return (EnglishDecorationDescriptionCarpet2);
    }
}
