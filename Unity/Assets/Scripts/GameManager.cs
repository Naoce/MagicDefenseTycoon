using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject      cam;
    private GameObject      player;
    public  GameObject      jingleDefaite;
    public  GameObject      EnemyGuerrier;
    public  GameObject      textNbEnemy;
    public  int[]           playerMaxHP = new int[15];
    public  int[]           playerMaxXP = new int[15];
    public  int             playerXP;
    public  int             playerLevel;
    public  int             playerDamage;
    public  Texture2D       cursorNormal;
    public  Texture2D       cursorRight;
    public  Texture2D       cursorWrong;
    public  CursorMode      cursorMode = CursorMode.Auto;
    public  Vector2         hotSpot = Vector2.zero;

    private float           timerSpawn = 0f;
    private float           timerMax = 5f;
    private bool            spawnLeft = true;
    private Quaternion      rot = new Quaternion(0, 0, 0, 0);
    public  Vector2         posLeft = new Vector2(0, 0);
    public  Vector2         posRight = new Vector2(0, 0);
    public List<GameObject> enemiesList = new List<GameObject>();
    private int             idGen = 0;
    private bool            canSpawn = true;
    private bool            cursorIsNormal = true;

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
    public  GameObject      hudMenuResume;
    public  GameObject      hudMenuOptions;
    public  GameObject      hudMenuRestart;
    public  GameObject      hudMenuAbandon;

    void Start ()
    {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        timerSpawn = timerMax;
        SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
    }

    void SetNormalMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorNormal, pos, cursorMode);
    }

    void SetRightMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorRight, pos, cursorMode);
    }

    void SetWrongMouse(Vector2 pos)
    {
        Cursor.SetCursor(cursorWrong, pos, cursorMode);
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
        if (enemiesList.Count > 0 || canSpawn == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                GetComponent<GameManager>().hudMenuResume.SetActive(true);
                GetComponent<GameManager>().hudMenuOptions.SetActive(true);
                GetComponent<GameManager>().hudMenuRestart.SetActive(true);
                GetComponent<GameManager>().hudMenuAbandon.SetActive(true);
            }
            if (player.GetComponent<Shoots>().spellSelected == 1)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f &&
                    cursorIsNormal == false)
                {
                    SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = true;
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 0.2f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 2)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
                {
                    RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "EnemyGuerrier" && cursorIsNormal == false)
                        {
                            SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                            cursorIsNormal = true;
                        }
                        else if (hit.collider.tag != "EnemyGuerrier" && cursorIsNormal == true)
                        {
                            SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                            cursorIsNormal = false;
                        }
                    }
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 3f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 3)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f &&
                    cursorIsNormal == false)
                {
                    SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = true;
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 0.2f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 4)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f &&
                    cursorIsNormal == false)
                {
                    SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = true;
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 3f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 5)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f &&
                    cursorIsNormal == false)
                {
                    SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = true;
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 3f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 6)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
                {
                    RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "EnemyGuerrier" && cursorIsNormal == false)
                        {
                            SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                            cursorIsNormal = true;
                        }
                        else if (hit.collider.tag != "EnemyGuerrier" && cursorIsNormal == true)
                        {
                            SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                            cursorIsNormal = false;
                        }
                    }
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 3f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
            else if (player.GetComponent<Shoots>().spellSelected == 8)
            {
                if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f &&
                    cursorIsNormal == false)
                {
                    SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = true;
                }
                else if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 0.2f &&
                        cursorIsNormal == true)
                {
                    SetWrongMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                    cursorIsNormal = false;
                }
            }
        }
	}

    public void StartVictory()
    {
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
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
        GameObject.Find("Slider Cooldown Spell 1").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 2").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 3").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 4").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 5").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 6").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 7").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 8").SetActive(false);
        StartCoroutine(VictoryAnimation());
    }

    public void StartDefeat()
    {
        Instantiate(jingleDefaite, transform.position, transform.rotation);
        SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
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
        GameObject.Find("Slider Cooldown Spell 1").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 2").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 3").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 4").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 5").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 6").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 7").SetActive(false);
        GameObject.Find("Slider Cooldown Spell 8").SetActive(false);
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
        foreach (GameObject go in enemiesList)
        {
            obj.GetComponent<Enemy>().IgnoreCollider(go);
        }

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
