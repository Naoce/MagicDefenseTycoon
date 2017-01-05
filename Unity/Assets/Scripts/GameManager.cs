using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  GameObject      EnemyGuerrier;
    public  GameObject      textNbEnemy;
    public  int[]           playerMaxHP = new int[15];
    public  int[]           playerMaxXP = new int[15];
    public  int             playerXP;
    public  int             playerLevel;
    public  int             playerDamage;
    //public Texture2D        cursorTexture;
    public CursorMode       cursorMode = CursorMode.Auto;
    public Vector2          hotSpot = Vector2.zero;

    private float           timerSpawn = 0f;
    private float           timerMax = 5f;
    private bool            spawnLeft = true;
    private Quaternion      rot = new Quaternion(0, 0, 0, 0);
    public  Vector2         posLeft = new Vector2(0, 0);
    public  Vector2         posRight = new Vector2(0, 0);
    public List<GameObject> enemiesList = new List<GameObject>();
    private int             idGen = 0;
    private bool            canSpawn = true;

    public  GameObject      hudPlayer;
    public  GameObject      hudHP;
    public  GameObject      hudHPText;
    public  GameObject      hudXP;
    public  GameObject      hudXPText;
    public  GameObject      hudFiole;
    public  GameObject      hudSpells;
    public  GameObject      hudObjects;
    public  GameObject      hudSpellIcon;
    public  GameObject      hudSpellUsing;
    public  GameObject      hudCounter;
    public  GameObject      hudCounterText;
    public  GameObject      hudLevel;
    public  GameObject      hudLevelText;
    public  GameObject      hudVictory;
    public  GameObject      hudDefeat;
    public  GameObject      hudStar1;
    public  GameObject      hudStar2;
    public  GameObject      hudStar3;
    public  GameObject      hudButtonTryAgain;
    public  GameObject      hudButtonQuit;


    void Start ()
    {
        timerSpawn = timerMax;
    }

    void OnMouseEnter()
    {
      //  Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
      //  Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    void Update ()
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;
            if (timerSpawn > timerMax)
            {
                timerMax -= 0.2f;
                timerSpawn = 0f;
                if (timerMax < 2f)
                    timerMax = 2f;
                InstantiateGuerrier();
            }
        }
        else if (canSpawn == false &&
                enemiesList.Count == 0)
        {
            GameObject.Find("Player").GetComponent<Deplacements>().isDead = true;
            StartVictory();
        }
	}

    public void StartVictory()
    {
        hudPlayer.SetActive(false);
        hudHP.SetActive(false);
        hudHPText.SetActive(false);
        hudXP.SetActive(false);
        hudXPText.SetActive(false);
        hudFiole.SetActive(false);
        hudSpells.SetActive(false);
        hudObjects.SetActive(false);
        hudSpellIcon.SetActive(false);
        hudSpellUsing.SetActive(false);
        hudCounter.SetActive(false);
        hudCounterText.SetActive(false);
        hudLevel.SetActive(false);
        hudLevelText.SetActive(false);
        StartCoroutine(VictoryAnimation());
    }

    public void StartDefeat()
    {
        hudPlayer.SetActive(false);
        hudHP.SetActive(false);
        hudHPText.SetActive(false);
        hudXP.SetActive(false);
        hudXPText.SetActive(false);
        hudFiole.SetActive(false);
        hudSpells.SetActive(false);
        hudObjects.SetActive(false);
        hudSpellIcon.SetActive(false);
        hudSpellUsing.SetActive(false);
        hudCounter.SetActive(false);
        hudCounterText.SetActive(false);
        hudLevel.SetActive(false);
        hudLevelText.SetActive(false);
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

        hudButtonTryAgain.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudButtonQuit.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

    IEnumerator DefeatAnimation()
    {
        hudDefeat.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudButtonTryAgain.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        hudButtonQuit.SetActive(true);
        yield return new WaitForSeconds(0.4f);
    }

    void InstantiateGuerrier()
    {
        GameObject obj = null;
        if (spawnLeft == true)
        {
            spawnLeft = false;
            obj = (GameObject)Instantiate(EnemyGuerrier, posLeft, rot);
        }
        else
        {
            spawnLeft = true;
            obj = (GameObject)Instantiate(EnemyGuerrier, posRight, rot);
        }
        obj.GetComponent<Enemy>().id = idGen++;
        enemiesList.Add(obj);
        textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > 10)
            canSpawn = false;
    }

    public void PopEnemy(int idToCheck)
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Enemy>().id == idToCheck)
                enemiesList.RemoveAt(i);
        }
        textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }
}
