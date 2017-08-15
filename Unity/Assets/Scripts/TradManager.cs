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
    public Text MenuTextSaveInfo;
    public Text MenuTextSaveReturn;

    public Text MenuTextCharacterElemental;
    public Text MenuTextCharacterTitleElemental;
    public Text MenuTextCharacterDemonic;
    public Text MenuTextCharacterTitleDemonic;
    public Text MenuTextCharacterRadiant;
    public Text MenuTextCharacterTitleRadiant;
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

    public Text HUDTextTitleSpell1;
    public Text HUDTextTitleSpell2;
    public Text HUDTextTitleSpell3;
    public Text HUDTextTitleSpell4;
    public Text HUDTextTitleSpell5;
    public Text HUDTextTitleSpell6;
    public Text HUDTextTitleSpell7;
    public Text HUDTextTitleSpell8;
    public Text HUDTextTitlePotion1;
    public Text HUDTextTitlePotion2;
    public Text HUDTextTitleRune;

    public Text HUDTextTryAgain;
    // A Modifier lors d'un changement de langue - Fin

    public void ResetTexts()
    {
        isInEnglish = GetComponent<GameManager>().englishLanguage;

        MenuTextIntroPlay.text = GetTextPlay();
        MenuTextQuit.text = GetTextQuit();

        if (PlayerPrefs.GetInt("Load1Created") == 0)
            MenuTextSave1.text = GetTextEmptySave();
        if (PlayerPrefs.GetInt("Load2Created") == 0)
            MenuTextSave2.text = GetTextEmptySave();
        if (PlayerPrefs.GetInt("Load3Created") == 0)
            MenuTextSave3.text = GetTextEmptySave();
        MenuTextSaveDelete1.text = GetTextDelete();
        MenuTextSaveDelete2.text = GetTextDelete();
        MenuTextSaveDelete3.text = GetTextDelete();
        MenuTextSaveCancel1.text = GetTextCancel();
        MenuTextSaveCancel2.text = GetTextCancel();
        MenuTextSaveCancel3.text = GetTextCancel();
        MenuTextSaveInfo.text = GetTextSaveInfo();
        MenuTextSaveReturn.text = GetTextReturn();

        MenuTextCharacterElemental.text = GetTextElemental();
        MenuTextCharacterTitleElemental.text = GetTextTitleElemental();
        MenuTextCharacterDemonic.text = GetTextDemonic();
        MenuTextCharacterTitleDemonic.text = GetTextTitleDemonic();
        MenuTextCharacterRadiant.text = GetTextRadiant();
        MenuTextCharacterTitleRadiant.text = GetTextTitleRadiant();
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

        HUDTextTitleSpell1.text = GetTitleElementalSpell1();
        HUDTextTitleSpell2.text = GetTitleElementalSpell2();
        HUDTextTitleSpell3.text = GetTitleElementalSpell3();
        HUDTextTitleSpell4.text = GetTitleElementalSpell4();
        HUDTextTitleSpell5.text = GetTitleElementalSpell5();
        HUDTextTitleSpell6.text = GetTitleElementalSpell6();
        HUDTextTitleSpell7.text = GetTitleElementalSpell7();
        HUDTextTitleSpell8.text = GetTitleElementalSpell8();
        HUDTextTitlePotion1.text = GetTitlePotion1();
        HUDTextTitlePotion2.text = GetTitlePotion2();

        if (GetComponent<GameManager>().runeSelected == 0)
            HUDTextTitleRune.text = GetTitleRuneDamage();
        else if (GetComponent<GameManager>().runeSelected == 1)
            HUDTextTitleRune.text = GetTitleRuneCelerity();
        else
            HUDTextTitleRune.text = GetTitleRuneHeal();

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

    public string GetTextSaveInfo()
    {
        if (isInEnglish)
            return ("Choose your character name.");
        else
            return ("Choisissez le nom de votre personnage.");
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
            return ("The elemental mage makes use of elements such as fire, electricity, ice and wind to fight his enemies.");
        else
            return ("Le mage élémentaire utilise le feu, la foudre, la glace et le vent pour combattre ses ennemis.");
    }

    public string GetTextTitleElemental()
    {
        if (isInEnglish)
            return ("Elemental mage");
        else
            return ("Mage élémentaire");
    }

    public string GetTextDemonic()
    {
        if (isInEnglish)
            return ("The demonic mage makes use of fear - based spells in order to kill his enemies by heart failure.");
        else
            return ("Le mage démoniaque utilise des sorts liés à la peur pour tuer ses ennemis d'une crise cardiaque.");
    }

    public string GetTextTitleDemonic()
    {
        if (isInEnglish)
            return ("Demonic mage");
        else
            return ("Mage démoniaque");
    }

    public string GetTextRadiant()
    {
        if (isInEnglish)
            return ("The radiant mage makes use of light magic in order to heal and buff his allies.");
        else
            return ("Le mage lumineux utilise la magie de la lumière pour soigner et améliorer les statistiques de ses alliés.");
    }

    public string GetTextTitleRadiant()
    {
        if (isInEnglish)
            return ("Radiant mage");
        else
            return ("Mage lumineux");
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

    public string GetTitleRuneDamage()
    {
        if (isInEnglish)
            return ("War rune");
        else
            return ("Rune de bataille");
    }

    public string GetTitleRuneCelerity()
    {
        if (isInEnglish)
            return ("Celerity rune");
        else
            return ("Rune de célérité");
    }

    public string GetTitleRuneHeal()
    {
        if (isInEnglish)
            return ("Healing rune");
        else
            return ("Rune de guérison");
    }

    public string GetDescriptionRuneDamage_1()
    {
        if (isInEnglish)
            return ("Every 10 seconds, the next spell cast will deal ");
        else
            return ("Toutes les 10 secondes, le prochain sort infligera ");
    }

    public string GetDescriptionRuneDamage_2()
    {
        if (isInEnglish)
            return (" additional damage.");
        else
            return (" points de dégâts supplémentaires.");
    }

    public string GetDescriptionRuneCelerity_1()
    {
        if (isInEnglish)
            return ("The mage runs ");
        else
            return ("Le mage court ");
    }

    public string GetDescriptionRuneCelerity_2()
    {
        if (isInEnglish)
            return ("% faster.");
        else
            return ("% plus vite.");
    }

    public string GetDescriptionRuneHeal_1()
    {
        if (isInEnglish)
            return ("Every 15 seconds, the mage recovers ");
        else
            return ("Toutes les 15 secondes, le mage récupère ");
    }

    public string GetDescriptionRuneHeal_2()
    {
        if (isInEnglish)
            return (" health points.");
        else
            return (" points de vie.");
    }

    public string GetTitlePotion1()
    {
        if (isInEnglish)
            return ("Health potion");
        else
            return ("Potion de soins");
    }

    public string GetDescriptionPotion1_1()
    {
        if (isInEnglish)
            return ("Heals the mage for ");
        else
            return ("Soigne le mage de ");
    }

    public string GetDescriptionPotion1_2()
    {
        if (isInEnglish)
            return (" health points.");
        else
            return (" points de vie.");
    }

    public string GetTitlePotion2()
    {
        if (isInEnglish)
            return ("Mana potion");
        else
            return ("Potion de mana");
    }

    public string GetDescriptionPotion2()
    {
        if (isInEnglish)
            return ("Accelerates the recuperation of the mage skills for 5 seconds.");
        else
            return ("Accélère la récupération des sorts du mage pendant 5 secondes.");
    }

    public string GetElementalSpellInGame1_1()
    {
        if (isInEnglish)
            return ("Shoots a fireball that deals ");
        else
            return ("Tire une boule de feu qui inflige ");
    }

    public string GetElementalSpellInGame1_2()
    {
        if (isInEnglish)
            return (" damage to the first enemy hit.");
        else
            return (" points de dégâts au premier ennemi touché.");
    }

    public string GetElementalSpellInGame2_1()
    {
        if (isInEnglish)
            return ("A thunderbolt that deals ");
        else
            return ("Un éclair qui inflige ");
    }

    public string GetElementalSpellInGame2_2()
    {
        if (isInEnglish)
            return (" damage to the targeted enemy.");
        else
            return (" points de dégâts à l'ennemi visé.");
    }

    public string GetElementalSpellInGame3_1()
    {
        if (isInEnglish)
            return ("Shoots ");
        else
            return ("Tire ");
    }

    public string GetElementalSpellInGame3_2()
    {
        if (isInEnglish)
            return (" ice shards that deal ");
        else
            return (" éclats de glace qui infligent ");
    }

    public string GetElementalSpellInGame3_3()
    {
        if (isInEnglish)
            return (" damage each to the first enemy hit.");
        else
            return (" points de dégâts chacun au premier ennemi touché.");
    }

    public string GetElementalSpellInGame4_1()
    {
        if (isInEnglish)
            return ("A meteor that deals ");
        else
            return ("Un météore qui inflige ");
    }

    public string GetElementalSpellInGame4_2()
    {
        if (isInEnglish)
            return (" damage to all enemies around it.");
        else
            return (" points de dégâts à tous les ennemis à proximité.");
    }

    public string GetElementalSpellInGame5_1()
    {
        if (isInEnglish)
            return ("A tornado that sends all enemies around it flying for ");
        else
            return ("Une tornade qui projette dans les airs tous les ennemis à proximité pendant ");
    }

    public string GetElementalSpellInGame5_2()
    {
        if (isInEnglish)
            return (" seconds.");
        else
            return (" secondes.");
    }

    public string GetElementalSpellInGame6_1()
    {
        if (isInEnglish)
            return ("Encase the selected enemy in ice for ");
        else
            return ("Emprisonne l'ennemi sélectionné dans la glace pendant ");
    }

    public string GetElementalSpellInGame6_2()
    {
        if (isInEnglish)
            return (" seconds, dealing ");
        else
            return (" secondes, ce qui lui inflige ");
    }

    public string GetElementalSpellInGame6_3()
    {
        if (isInEnglish)
            return (" damage.");
        else
            return (" points de dégâts.");
    }

    public string GetElementalSpellInGame7_1()
    {
        if (isInEnglish)
            return ("An earthquake that deals ");
        else
            return ("Un tremblement de terre qui inflige ");
    }

    public string GetElementalSpellInGame7_2()
    {
        if (isInEnglish)
            return (" damage to the enemies near the mage and slows them for 50% during ");
        else
            return (" points de dégâts aux ennemis autour du mage et les ralentit de 50% pendant ");
    }

    public string GetElementalSpellInGame7_3()
    {
        if (isInEnglish)
            return (" seconds.");
        else
            return (" secondes.");
    }

    public string GetElementalSpellInGame8_1()
    {
        if (isInEnglish)
            return ("Shoots a fire dragon that deals ");
        else
            return ("Invoque un dragon de feu qui inflige ");
    }

    public string GetElementalSpellInGame8_2()
    {
        if (isInEnglish)
            return (" damage to all enemies in its path.");
        else
            return (" points de dégâts à tous les ennemis sur son passage.");
    }

    public string GetTitleElementalSpell1()
    {
        if (isInEnglish)
            return ("Fireball");
        else
            return ("Boule de feu");
    }

    public string GetDescriptionElementalSpell1_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 1s\nRange 3\nShoots a fireball that deals 5 damage to the first enemy hit.");
        else
            return ("Niveau 1\nTemps de récupération 1s\nPortée 3\nTire une boule de feu qui inflige 5 points de dégâts au premier ennemi touché.");
    }

    public string GetDescriptionElementalSpell1_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 0.75s\nRange 3\nShoots a fireball that deals 6 damage to the first enemy hit.");
        else
            return ("Niveau 2\nTemps de récupération 0.75s\nPortée 3\nTire une boule de feu qui inflige 6 points de dégâts au premier ennemi touché.");
    }

    public string GetDescriptionElementalSpell1_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 0.5s\nRange 3\nShoots a fireball that deals 8 damage to the first enemy hit.");
        else
            return ("Niveau 3\nTemps de récupération 0.5s\nPortée 3\nTire une boule de feu qui inflige 8 points de dégâts au premier ennemi touché.");
    }

    public string GetTitleElementalSpell2()
    {
        if (isInEnglish)
            return ("Thunderbolt");
        else
            return ("Éclair");
    }

    public string GetDescriptionElementalSpell2_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 4s\nRange 2\nA thunderbolt that deals 8 damage to the selected enemy.");
        else
            return ("Niveau 1\nTemps de récupération 4s\nPortée 2\nUn éclair qui inflige 8 points de dégâts à l'ennemi visé.");
    }

    public string GetDescriptionElementalSpell2_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 4s\nRange 3\nA thunderbolt that deals 10 damage to the selected enemy.");
        else
            return ("Niveau 2\nTemps de récupération 4s\nPortée 3\nUn éclair qui inflige 10 points de dégâts à l'ennemi visé.");
    }

    public string GetDescriptionElementalSpell2_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 3s\nRange 3\nA thunderbolt that deals 12 damage to the selected enemy.");
        else
            return ("Niveau 3\nTemps de récupération 3s\nPortée 3\nUn éclair qui inflige 12 points de dégâts à l'ennemi visé.");
    }

    public string GetTitleElementalSpell3()
    {
        if (isInEnglish)
            return ("Ice Shards");
        else
            return ("Éclats de glace");
    }

    public string GetDescriptionElementalSpell3_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 5s\nRange 3\nShoots 4 ice shards that deal 2 damage each to the first enemy hit.");
        else
            return ("Niveau 1\nTemps de récupération 5s\nPortée 3\nTire 4 éclats de glace qui infligent 2 points de dégâts chacun au premier ennemi touché.");
    }

    public string GetDescriptionElementalSpell3_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 4s\nRange 3\nShoots 5 ice shards that deal 2 damage each to the first enemy hit.");
        else
            return ("Niveau 2\nTemps de récupération 4s\nPortée 3\nTire 5 éclats de glace qui infligent 2 points de dégâts chacun au premier ennemi touché.");
    }

    public string GetDescriptionElementalSpell3_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 4s\nRange 3\nShoots 6 ice shards that deal 3 damage each to the first enemy hit.");
        else
            return ("Niveau 3\nTemps de récupération 4s\nPortée 3\nTire 6 éclats de glace qui infligent 3 points de dégâts chacun au premier ennemi touché.");
    }

    public string GetTitleElementalSpell4()
    {
        if (isInEnglish)
            return ("Meteor");
        else
            return ("Météore");
    }

    public string GetDescriptionElementalSpell4_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 8s\nRange 3\nA meteor that deals 6 damage to all enemies around it.");
        else
            return ("Niveau 1\nTemps de récupération 8s\nPortée 3\nUn météore qui inflige 6 points de dégâts à tous les ennemis à proximité.");
    }

    public string GetDescriptionElementalSpell4_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 7s\nRange 3\nA meteor that deals 8 damage to all enemies around it.");
        else
            return ("Niveau 2\nTemps de récupération 7s\nPortée 3\nUn météore qui inflige 8 points de dégâts à tous les ennemis à proximité.");
    }

    public string GetDescriptionElementalSpell4_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 6s\nRange 3\nA meteor that deals 10 damage to all enemies around it.");
        else
            return ("Niveau 3\nTemps de récupération 6s\nPortée 3\nUn météore qui inflige 10 points de dégâts à tous les ennemis à proximité.");
    }

    public string GetTitleElementalSpell5()
    {
        if (isInEnglish)
            return ("Tornado");
        else
            return ("Tornade");
    }

    public string GetDescriptionElementalSpell5_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 10s\nRange 3\nA tornado that sends all enemies around it flying for 2 seconds.");
        else
            return ("Niveau 1\nTemps de récupération 10s\nPortée 3\nUne tornade qui projette dans les airs tous les ennemis à proximité pendant 2 secondes.");
    }

    public string GetDescriptionElementalSpell5_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 8s\nRange 4\nA tornado that sends all enemies around it flying for 2 seconds.");
        else
            return ("Niveau 2\nTemps de récupération 8s\nPortée 4\nUne tornade qui projette dans les airs tous les ennemis à proximité pendant 2 secondes.");
    }

    public string GetDescriptionElementalSpell5_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 6s\nRange 5\nA tornado that sends all enemies around it flying for 2 seconds.");
        else
            return ("Niveau 3\nTemps de récupération 6s\nPortée 5\nUne tornade qui projette dans les airs tous les ennemis à proximité pendant 2 secondes.");
    }

    public string GetTitleElementalSpell6()
    {
        if (isInEnglish)
            return ("Ice Prison");
        else
            return ("Prison de glace");
    }

    public string GetDescriptionElementalSpell6_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 9s\nRange 2\nEncase the selected enemy in ice for 2 seconds, dealing 5 damage.");
        else
            return ("Niveau 1\nTemps de récupération 9s\nPortée 2\nEmprisonne l'ennemi sélectionné dans la glace pendant 2 secondes et lui inflige 5 points de dégâts.");
    }

    public string GetDescriptionElementalSpell6_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 8s\nRange 3\nEncase the selected enemy in ice for 2 seconds, dealing 5 damage.");
        else
            return ("Niveau 2\nTemps de récupération 8s\nPortée 3\nEmprisonne l'ennemi sélectionné dans la glace pendant 2 secondes et lui inflige 5 points de dégâts.");
    }

    public string GetDescriptionElementalSpell6_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 7s\nRange 3\nEncase the selected enemy in ice for 2 seconds, dealing 6 damage.");
        else
            return ("Niveau 3\nTemps de récupération 7s\nPortée 3\nEmprisonne l'ennemi sélectionné dans la glace pendant 2 secondes et lui inflige 6 points de dégâts.");
    }

    public string GetTitleElementalSpell7()
    {
        if (isInEnglish)
            return ("Earthquake");
        else
            return ("Tremblement de terre");
    }

    public string GetDescriptionElementalSpell7_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 25s\nRange 2\nAn earthquake deals 7 damage to the enemies near the mage and slows them for 50% during 2 seconds.");
        else
            return ("Niveau 1\nTemps de récupération 25s\nPortée 2\nUn tremblement de terre qui inflige 7 points de dégâts aux ennemis autour du mage et les ralentit de 50% pendant 2 secondes.");
    }

    public string GetDescriptionElementalSpell7_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 22.5s\nRange 2\nAn earthquake deals 11 damage to the enemies near the mage and slows them for 50% during 2 seconds.");
        else
            return ("Niveau 2\nTemps de récupération 22.5s\nPortée 2\nUn tremblement de terre qui inflige 11 points de dégâts aux ennemis autour du mage et les ralentit de 50% pendant 2 secondes.");
    }

    public string GetDescriptionElementalSpell7_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 20s\nRange 2\nAn earthquake deals 15 damage to the enemies near the mage and slows them for 50% during 2 seconds.");
        else
            return ("Niveau 3\nTemps de récupération 20s\nPortée 2\nUn tremblement de terre qui inflige 15 points de dégâts aux ennemis autour du mage et les ralentit de 50% pendant 2 secondes.");
    }

    public string GetTitleElementalSpell8()
    {
        if (isInEnglish)
            return ("Fire Dragon");
        else
            return ("Dragon de feu");
    }

    public string GetDescriptionElementalSpell8_1()
    {
        if (isInEnglish)
            return ("Level 1\nCooldown 30s\nRange infinite\nShoots a fire dragon that deals 15 damage to all enemies in its path.");
        else
            return ("Niveau 1\nTemps de récupération 30s\nPortée infinie\nInvoque un dragon de feu qui inflige 15 points de dégâts à tous les ennemis sur son passage.");
    }

    public string GetDescriptionElementalSpell8_2()
    {
        if (isInEnglish)
            return ("Level 2\nCooldown 27.5s\nRange infinite\nShoots a fire dragon that deals 20 damage to all enemies in its path.");
        else
            return ("Niveau 2\nTemps de récupération 27.5s\nPortée infinie\nInvoque un dragon de feu qui inflige 20 points de dégâts à tous les ennemis sur son passage.");
    }

    public string GetDescriptionElementalSpell8_3()
    {
        if (isInEnglish)
            return ("Level 3\nCooldown 25s\nRange infinite\nShoots a fire dragon that deals 25 damage to all enemies in its path.");
        else
            return ("Niveau 3\nTemps de récupération 25s\nPortée infinie\nInvoque un dragon de feu qui inflige 25 points de dégâts à tous les ennemis sur son passage.");
    }

    public string GetTitleElementalPassive1()
    {
        if (isInEnglish)
            return ("Fire armor [Shield]");
        else
            return ("Armure de feu [Bouclier]");
    }

    public string GetDescriptionElementalPassive1_1()
    {
        if (isInEnglish)
            return ("Level 1\nEnemies that attack you in melee take 1 damage.\nYou can only learn one shield skill.");
        else
            return ("Niveau 1\nLes ennemis qui vous attaquent en mêlée reçoivent 1 point de dégâts.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetDescriptionElementalPassive1_2()
    {
        if (isInEnglish)
            return ("Level 2\nEnemies that attack you in melee take 3 damage.\nYou can only learn one shield skill.");
        else
            return ("Niveau 2\nLes ennemis qui vous attaquent en mêlée reçoivent 3 points de dégâts.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetDescriptionElementalPassive1_3()
    {
        if (isInEnglish)
            return ("Level 3\nEnemies that attack you in melee take 5 damage.\nYou can only learn one shield skill.");
        else
            return ("Niveau 3\nLes ennemis qui vous attaquent en mêlée reçoivent 5 points de dégâts.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetTitleElementalPassive2()
    {
        if (isInEnglish)
            return ("Ice armor [Shield]");
        else
            return ("Armure de glace [Bouclier]");
    }

    public string GetDescriptionElementalPassive2_1()
    {
        if (isInEnglish)
            return ("Level 1\nEnemies that attack you in melee are slowed by 20% for 2 seconds.\nYou can only learn one shield skill.");
        else
            return ("Niveau 1\nLes ennemis qui vous attaquent en mêlée sont ralentis de 20% pendant 2 secondes.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetDescriptionElementalPassive2_2()
    {
        if (isInEnglish)
            return ("Level 2\nEnemies that attack you in melee are slowed by 40% for 2 sec.\nYou can only learn one shield skill.");
        else
            return ("Niveau 2\nLes ennemis qui vous attaquent en mêlée sont ralentis de 40% pendant 2 secondes.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetDescriptionElementalPassive2_3()
    {
        if (isInEnglish)
            return ("Level 3\nEnemies that attack you in melee are slowed by 60% for 2 sec.\nYou can only learn one shield skill.");
        else
            return ("Niveau 3\nLes ennemis qui vous attaquent en mêlée sont ralentis de 60% pendant 2 secondes.\nVous ne pouvez apprendre qu'une seule compétence de bouclier.");
    }

    public string GetTitleElementalPassive3()
    {
        if (isInEnglish)
            return ("Thunder overload");
        else
            return ("Surcharge de foudre");
    }

    public string GetDescriptionElementalPassive3_1()
    {
        if (isInEnglish)
            return ("Level 1\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 1 additional point of damage. (Stacks)");
        else
            return ("Niveau 1\nÀ chaque fois que vous utilisez un sort (sauf pour la boule de feu), votre prochaine utilisation du sort \"Éclair\" fera 1 point de dégâts supplémentaire. (Cumulable)");
    }

    public string GetDescriptionElementalPassive3_2()
    {
        if (isInEnglish)
            return ("Level 2\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 2 additional points of damage. (Stacks)");
        else
            return ("Niveau 2\nÀ chaque fois que vous utilisez un sort (sauf pour la boule de feu), votre prochaine utilisation du sort \"Éclair\" fera 2 points de dégâts supplémentaires. (Cumulable)");
    }

    public string GetDescriptionElementalPassive3_3()
    {
        if (isInEnglish)
            return ("Level 3\nWhenever you use a spell (except the Fireball), your next use of the \"Thunder\" skill will do 3 additional points of damage. (Stacks)");
        else
            return ("Niveau 3\nÀ chaque fois que vous utilisez un sort (sauf pour la boule de feu), votre prochaine utilisation du sort \"Éclair\" fera 3 points de dégâts supplémentaires. (Cumulable)");
    }

    public string GetTitleElementalPassive4()
    {
        if (isInEnglish)
            return ("Celerity");
        else
            return ("Célérité");
    }

    public string GetDescriptionElementalPassive4_1()
    {
        if (isInEnglish)
            return ("Level 1\nAfter using a spell (except the Fireball), your move speed increase by 20% for 1 second.");
        else
            return ("Niveau 1\nApres avoir utilisé un sort (sauf pour la boule de feu), votre vitesse de déplacement augmente de 20% pendant 1 seconde.");
    }

    public string GetDescriptionElementalPassive4_2()
    {
        if (isInEnglish)
            return ("Level 2\nAfter using a spell (except the Fireball), your move speed increase by 30% for 1 second.");
        else
            return ("Niveau 2\nApres avoir utilisé un sort (sauf pour la boule de feu), votre vitesse de déplacement augmente de 30% pendant 1 seconde.");
    }

    public string GetDescriptionElementalPassive4_3()
    {
        if (isInEnglish)
            return ("Level 3\nAfter using a spell (except the Fireball), your move speed increase by 40% for 1 second.");
        else
            return ("Niveau 3\nApres avoir utilisé un sort (sauf pour la boule de feu), votre vitesse de déplacement augmente de 40% pendant 1 seconde.");
    }

    public string GetTitleElementalPassive5()
    {
        if (isInEnglish)
            return ("Fire mastery [Mastery]");
        else
            return ("Maîtrise du feu [Maîtrise]");
    }

    public string GetDescriptionElementalPassive5_1()
    {
        if (isInEnglish)
            return ("Level 1\nFire spells deal 1 additional point of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 1\nLes sorts de feu infligent 1 point de dégâts supplémentaire.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetDescriptionElementalPassive5_2()
    {
        if (isInEnglish)
            return ("Level 2\nFire spells deal 2 additional points of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 2\nLes sorts de feu infligent 2 points de dégâts supplémentaires.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetDescriptionElementalPassive5_3()
    {
        if (isInEnglish)
            return ("Level 3\nFire spells deal 3 additional points of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 3\nLes sorts de feu infligent 3 points de dégâts supplémentaires.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetTitleElementalPassive6()
    {
        if (isInEnglish)
            return ("Ice mastery [Mastery]");
        else
            return ("Maîtrise de la glace [Maîtrise]");
    }

    public string GetDescriptionElementalPassive6_1()
    {
        if (isInEnglish)
            return ("Level 1\nIce spells deal 1 additional point of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 1\nLes sorts de glace infligent 1 point de dégâts supplémentaire.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetDescriptionElementalPassive6_2()
    {
        if (isInEnglish)
            return ("Level 2\nIce spells deal 2 additional points of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 2\nLes sorts de glace infligent 2 points de dégâts supplémentaires.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetDescriptionElementalPassive6_3()
    {
        if (isInEnglish)
            return ("Level 3\nIce spells deal 3 additional points of damage.\nYou can only learn one mastery skill.");
        else
            return ("Niveau 3\nLes sorts de glace infligent 3 points de dégâts supplémentaires.\nVous ne pouvez apprendre qu'une seule compétence de maîtrise.");
    }

    public string GetTitleClass(string className)
    {
        if (GetComponent<GameManager>().englishLanguage == true)
            return (className);
        else
        {
            if (className == "Swordsman")
                return ("Épéiste");
            else if (className == "Knight")
                return ("Chevalier");
            else
                return ("Assassin");
        }
    }
}
