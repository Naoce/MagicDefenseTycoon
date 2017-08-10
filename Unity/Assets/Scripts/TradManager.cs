using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradManager : MonoBehaviour
{
    private bool isInEnglish = false;

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

    // A Modifier lors d'un changement de langue - Debut
    public Text MenuTextIntroPlay;
    public Text MenuTextQuit;

    public Text MenuTextSave1;
    public Text MenuTextSave2;
    public Text MenuTextSave3;
    public Text MenuTextSaveDelete1;
    public Text MenuTextSaveDelete2;
    public Text MenuTextSaveDelete3;
    public Text MenuTextSaveCancel1;
    public Text MenuTextSaveCancel2;
    public Text MenuTextSaveCancel3;
    public Text MenuTextSaveReturn;

    public Text MenuTextCharacterElemental;
    public Text MenuTextCharacterDemonic;
    public Text MenuTextCharacterRadiant;
    public Text MenuTextCharacterRuneDamage;
    public Text MenuTextCharacterRuneCelerity;
    public Text MenuTextCharacterRuneHeal;
    public Text MenuTextCharacterConfirm;
    public Text MenuTextCharacterReturn;

    public Text MenuTextDifficultyEasy;
    public Text MenuTextDifficultyHard;
    public Text MenuTextDifficultyReturn;

    public Text MenuTextMainMenuTavern;
    public Text MenuTextMainMenuTower;
    public Text MenuTextMainMenuReturn;

    public Text MenuTextMissionsFight;
    public Text MenuTextMissionsReturn;

    public Text MenuTextTavernRecruit;
    public Text MenuTextTavernReturn;

    public Text MenuTextQGRoster;
    public Text MenuTextQGSkills;
    public Text MenuTextQGDeco;
    public Text MenuTextQGReturn;

    public Text MenuTextRosterDismiss;

    public Text MenuTextSkillsLevel;
    public Text MenuTextSkillsLearn;

    public Text MenuTextDecoBuy;

    public Text MenuTextInGameResume;
    public Text MenuTextInGameRestart;
    public Text MenuTextInGameForfeit;

    public Text MenuTextOptionsSmartcast;
    public Text MenuTextOptionsBloodless;
    public Text MenuTextOptionsPopUp;
    public Text MenuTextOptionsLanguage;
    public Text MenuTextOptionsWindowed;
    public Text MenuTextOptionsReturn;

    public Text HUDTextTryAgain;
    // A Modifier lors d'un changement de langue - Fin

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

    void Start()
    {
        EnglishRuneDamageTitle = "War rune";
        EnglishRuneCelerityTitle = "Celerity rune";
        EnglishRuneHealTitle = "Healing rune";

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
    }

    public void ResetTexts()
    {
        isInEnglish = GetComponent<GameManager>().englishLanguage;
        MenuTextIntroPlay.text = GetTextPlay();
        MenuTextQuit.text = GetTextQuit();

        MenuTextSave1.text = GetTextEmptySave();
        MenuTextSave2.text = GetTextEmptySave();
        MenuTextSave3.text = GetTextEmptySave();
        MenuTextSaveDelete1.text = GetTextDelete();
        MenuTextSaveDelete2.text = GetTextDelete();
        MenuTextSaveDelete3.text = GetTextDelete();
        MenuTextSaveCancel1.text = GetTextCancel();
        MenuTextSaveCancel2.text = GetTextCancel();
        MenuTextSaveCancel3.text = GetTextCancel();
        MenuTextSaveReturn.text = GetTextReturn();

        MenuTextCharacterElemental.text = GetTextElemental();
        MenuTextCharacterDemonic.text = GetTextDemonic();
        MenuTextCharacterRadiant.text = GetTextRadiant();
        MenuTextCharacterRuneDamage.text = GetTextRuneDamage();
        MenuTextCharacterRuneCelerity.text = GetTextRuneCelerity();
        MenuTextCharacterRuneHeal.text = GetTextRuneHeal();
        MenuTextCharacterConfirm.text = GetTextConfirm();
        MenuTextCharacterReturn.text = GetTextReturn();

        MenuTextDifficultyEasy.text = GetTextEasy();
        MenuTextDifficultyHard.text = GetTextHard();
        MenuTextDifficultyReturn.text = GetTextReturn();

        MenuTextMainMenuTavern.text = GetTextTavern();
        MenuTextMainMenuTower.text = GetTextTower();
        MenuTextMainMenuReturn.text = GetTextReturn();

        MenuTextMissionsFight.text = GetTextFight();
        MenuTextMissionsReturn.text = GetTextReturn();

        MenuTextTavernRecruit.text = GetTextRecruit();
        MenuTextTavernReturn.text = GetTextReturn();

        MenuTextQGRoster.text = GetTextRoster();
        MenuTextQGSkills.text = GetTextSkills();
        MenuTextQGDeco.text = GetTextDeco();
        MenuTextQGReturn.text = GetTextReturn();

        MenuTextRosterDismiss.text = GetTextDismiss();

        MenuTextSkillsLevel.text = GetTextLevel();
        MenuTextSkillsLearn.text = GetTextLearn();

        MenuTextDecoBuy.text = GetTextDecoBuy();

        MenuTextInGameResume.text = GetTextResume();
        MenuTextInGameRestart.text = GetTextRestart();
        MenuTextInGameForfeit.text = GetTextForfeit();

        MenuTextOptionsSmartcast.text = GetTextSmartcast();
        MenuTextOptionsBloodless.text = GetTextBloodless();
        MenuTextOptionsPopUp.text = GetTextPopUp();
        MenuTextOptionsLanguage.text = GetTextLanguage();
        MenuTextOptionsWindowed.text = GetTextWindowed();
        MenuTextOptionsReturn.text = GetTextReturn();

        HUDTextTryAgain.text = GetTextTryAgain();
    }

    public string GetTextPlay()
    {
        if (isInEnglish)
            return ("Play");
        else
            return ("Jouer");
    }

    public string GetTextQuit()
    {
        if (isInEnglish)
            return ("Quit");
        else
            return ("Quitter");
    }

    public string GetTextEmptySave()
    {
        if (isInEnglish)
            return ("Empty save");
        else
            return ("Sauvegarde vide");
    }

    public string GetTextDelete()
    {
        if (isInEnglish)
            return ("Delete save");
        else
            return ("Détruire");
    }

    public string GetTextCancel()
    {
        if (isInEnglish)
            return ("Cancel");
        else
            return ("Annuler");
    }

    public string GetTextReturn()
    {
        if (isInEnglish)
            return ("Return");
        else
            return ("Retour");
    }

    public string GetTextElemental()
    {
        if (isInEnglish)
            return ("The elemental mage makes use of elements as fire, electricity, ice and wind to fight his enemies.");
        else
            return ("Le mage élémentaire utilise le feu, la foudre, la glace et le vent pour combattre ses ennemis.");
    }

    public string GetTextDemonic()
    {
        if (isInEnglish)
            return ("The demonic mage makes use of fear - based spells in order to kill his enemies by heart failure.");
        else
            return ("Le mage démoniaque utilise des sorts liés à la peur pour tuer ses ennemis d'une crise cardiaque.");
    }

    public string GetTextRadiant()
    {
        if (isInEnglish)
            return ("The radiant mage makes use of light magic in order to heal and buff his allies.");
        else
            return ("Le mage lumineux utilise la magie de la lumière pour soigner et améliorer les statistiques de ses alliés.");
    }

    public string GetTextRuneDamage()
    {
        if (isInEnglish)
            return ("Every 10 seconds, the next spell cast will deal bonus damage, depending on the level of the mage.");
        else
            return ("Toutes les 10 secondes, le prochain sort lancé infligera des dégâts bonus en fonction du niveau du mage.");
    }

    public string GetTextRuneCelerity()
    {
        if (isInEnglish)
            return ("The mage runs faster, depending on his level.");
        else
            return ("Le mage court plus vite en fonction de son niveau.");
    }

    public string GetTextRuneHeal()
    {
        if (isInEnglish)
            return ("Every 15 seconds, the mage recovers some health points depending, on his level.");
        else
            return ("Toutes les 15 secondes, le mage se soigne en fonction de son niveau.");
    }

    public string GetTextConfirm()
    {
        if (isInEnglish)
            return ("Confirm");
        else
            return ("Confirmer");
    }

    public string GetTextEasy()
    {
        if (isInEnglish)
            return ("Easy");
        else
            return ("Facile");
    }

    public string GetTextHard()
    {
        if (isInEnglish)
            return ("Hard");
        else
            return ("Difficile");
    }

    public string GetTextTavern()
    {
        if (isInEnglish)
            return ("Tavern");
        else
            return ("Taverne");
    }

    public string GetTextTower()
    {
        if (isInEnglish)
            return ("Tower");
        else
            return ("Tour");
    }

    public string GetTextFight()
    {
        if (isInEnglish)
            return ("Fight");
        else
            return ("Combattre");
    }

    public string GetTextRecruit()
    {
        if (isInEnglish)
            return ("Recruit");
        else
            return ("Recruter");
    }

    public string GetTextRoster()
    {
        if (isInEnglish)
            return ("Roster");
        else
            return ("Équipe");
    }

    public string GetTextSkills()
    {
        if (isInEnglish)
            return ("Skills");
        else
            return ("Compétences");
    }

    public string GetTextDeco()
    {
        if (isInEnglish)
            return ("Decoration");
        else
            return ("Décoration");
    }

    public string GetTextDismiss()
    {
        if (isInEnglish)
            return ("Dismiss");
        else
            return ("Renvoyer");
    }

    public string GetTextLevel()
    {
        if (isInEnglish)
            return ("Level");
        else
            return ("Niveau");
    }

    public string GetTextLearn()
    {
        if (isInEnglish)
            return ("Learn");
        else
            return ("Apprendre");
    }

    public string GetTextDecoBuy()
    {
        if (isInEnglish)
            return ("Buy");
        else
            return ("Acheter");
    }

    public string GetTextResume()
    {
        if (isInEnglish)
            return ("Resume");
        else
            return ("Reprendre");
    }

    public string GetTextRestart()
    {
        if (isInEnglish)
            return ("Restart");
        else
            return ("Recommencer");
    }

    public string GetTextForfeit()
    {
        if (isInEnglish)
            return ("Forfeit");
        else
            return ("Abandonner");
    }

    public string GetTextSmartcast()
    {
        if (isInEnglish)
            return ("Smartcast");
        else
            return ("Sort facilité");
    }

    public string GetTextBloodless()
    {
        if (isInEnglish)
            return ("Bloodless");
        else
            return ("Sans sang");
    }

    public string GetTextPopUp()
    {
        if (isInEnglish)
            return ("Spells pop-up");
        else
            return ("Bulles infos");
    }

    public string GetTextLanguage()
    {
        if (isInEnglish)
            return ("English");
        else
            return ("Français");
    }

    public string GetTextWindowed()
    {
        if (isInEnglish)
            return ("Windowed");
        else
            return ("Fenêtré");
    }

    public string GetTextTryAgain()
    {
        if (isInEnglish)
            return ("Try again");
        else
            return ("Recommencer");
    }

    public string GetDecorationTitleChimney1()
    {
        if (isInEnglish)
            return ("Chimney, red flame");
        else
            return ("Cheminée à flamme rouge");
    }

    public string GetDecorationTitleChimney2()
    {
        if (isInEnglish)
            return ("Chimney, blue flame");
        else
            return ("Cheminée à flamme bleue");
    }

    public string GetDecorationTitleChimney3()
    {
        if (isInEnglish)
            return ("Chimney, yellow flame");
        else
            return ("Cheminée à flamme jaune");
    }

    public string GetDecorationTitleGod1()
    {
        if (isInEnglish)
            return ("God of War");
        else
            return ("Dieu de la Guerre");
    }

    public string GetDecorationTitleGod2()
    {
        if (isInEnglish)
            return ("God of Time");
        else
            return ("Dieu du Temps");
    }

    public string GetDecorationTitleGod3()
    {
        if (isInEnglish)
            return ("God of Life");
        else
            return ("Dieu de la Vie");
    }

    public string GetDecorationTitleBanner1()
    {
        if (isInEnglish)
            return ("Weapon banners");
        else
            return ("Bannières de guerre");
    }

    public string GetDecorationTitleBanner2()
    {
        if (isInEnglish)
            return ("Crown banners");
        else
            return ("Bannières somptueuses");
    }

    public string GetDecorationTitleEquipment1()
    {
        if (isInEnglish)
            return ("Weapon racks");
        else
            return ("Râtelier d'armes");
    }

    public string GetDecorationTitleEquipment2()
    {
        if (isInEnglish)
            return ("Shield racks");
        else
            return ("Râtelier de boucliers");
    }

    public string GetDecorationTitleCarpet1()
    {
        if (isInEnglish)
            return ("Bear carpet");
        else
            return ("Tapis en peau d'ours");
    }

    public string GetDecorationTitleCarpet2()
    {
        if (isInEnglish)
            return ("Crown carpet");
        else
            return ("Tapis somptueux");
    }

    public string GetDecorationDescriptionChimney1()
    {
        if (isInEnglish)
            return (GetDecorationTitleChimney1() + "\n\nEvery spell cast by the mage and attack from allies will do 1 additional point of damage.\n\nPrice : 20 gold coins");
        else
            return (GetDecorationTitleChimney1() + "\n\nChaque sort lancé par le mage et attaque des alliés fera 1 point de dégât supplémentaire.\n\nPrix : 20 pièces d'or.");
    }

    public string GetDecorationDescriptionChimney2()
    {
        if (isInEnglish)
            return (GetDecorationTitleChimney2() + "\n\nEvery attack against the mage or his allies will do 1 less point of damage.\n\nPrice : 20 gold coins");
        else
            return (GetDecorationTitleChimney2() + "\n\nChaque attaque lancée contre le mage ou ses alliés fera 1 point de dégât en moins.\n\nPrix : 20 pièces d'or");
    }

    public string GetDecorationDescriptionChimney3()
    {
        if (isInEnglish)
            return (GetDecorationTitleChimney3() + "\n\nPrestige +10.\n\nPrice : 20 gold coins");
        else
            return (GetDecorationTitleChimney3() + "\n\nPrestige +10.\n\nPrix : 20 pièces d'or");
    }

    public string GetDecorationDescriptionGod1()
    {
        if (isInEnglish)
            return (GetDecorationTitleGod1() + "\n\nEvery spell cast by the mage and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleGod1() + "\n\nChaque sort lancé par le mage et attaque des alliés fera 1 point de dégât supplémentaire.\n\nPrix : 30 pièces d'or");
    }

    public string GetDecorationDescriptionGod2()
    {
        if (isInEnglish)
            return (GetDecorationTitleGod2() + "\n\nIncrease the duration of the effects caused by the mage by 25%.\n\nPrice : 50 gold coins");
        else
            return (GetDecorationTitleGod2() + "\n\nAugmente la durée des effets provoqués par le mage de 25%.\n\nPrix : 50 pièces d'or");
    }

    public string GetDecorationDescriptionGod3()
    {
        if (isInEnglish)
            return (GetDecorationTitleGod3() + "\n\nIncrease the treatments received by the mage and his allies by an amount dependant on the level of the mage.\n\nPrice : 40 gold coins");
        else
            return (GetDecorationTitleGod3() + "\n\nAméliore les soins reçus par le mage et ses alliés pour un montant dépendant du niveau du mage.\n\nPrix : 40 pièces d'or");
    }

    public string GetDecorationDescriptionBanner1()
    {
        if (isInEnglish)
            return (GetDecorationTitleBanner1() + "\n\nEvery spell cast by the mage and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleBanner1() + "\n\nChaque sort lancé par le mage et attaque des alliés fera 1 point de dégât supplémentaire.\n\nPrix : 30 pièces d'or");
    }

    public string GetDecorationDescriptionBanner2()
    {
        if (isInEnglish)
            return (GetDecorationTitleBanner2() + "\n\nPrestige +10.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleBanner2() + "\n\nPrestige +10.\n\nPrix : 30 pièces d'or");
    }

    public string GetDecorationDescriptionEquipment1()
    {
        if (isInEnglish)
            return (GetDecorationTitleEquipment1() + "\n\nEvery spell cast by the mage and attack from allies will do 1 additional point of damage.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleEquipment1() + "\n\nChaque sort lancé par le mage et attaque des alliés fera 1 point de dégât supplémentaire.\n\nPrix : 30 pièces d'or");
    }

    public string GetDecorationDescriptionEquipment2()
    {
        if (isInEnglish)
            return (GetDecorationTitleEquipment2() + "\n\nEvery attack against the mage or his allies will do 1 less point of damage.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleEquipment2() + "\n\nChaque attaque lancée contre le mage ou ses alliés fera 1 point de dégât en moins.\n\nPrix : 30 pièces d'or");
    }

    public string GetDecorationDescriptionCarpet1()
    {
        if (isInEnglish)
            return (GetDecorationTitleCarpet1() + "\n\nEvery spell cast by the mage and attack from allies will do 1 additional point of damage.\n\nPrice : 20 gold coins");
        else
            return (GetDecorationTitleCarpet1() + "\n\nChaque sort lancé par le mage et attaque des alliés fera 1 point de dégât supplémentaire.\n\nPrix : 20 pièces d'or");
    }

    public string GetDecorationDescriptionCarpet2()
    {
        if (isInEnglish)
            return (GetDecorationTitleCarpet2() + "\n\nPrestige +10.\n\nPrice : 30 gold coins");
        else
            return (GetDecorationTitleCarpet2() + "\n\nPrestige +10.\n\nPrix : 30 pièces d'or");
    }
}
