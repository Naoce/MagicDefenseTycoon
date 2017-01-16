using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public  GameObject          player;
    public  GameObject          gm;
    public  GameObject          playerManager;
    private GameObject          cam;
    public  Vector2             playerStartPos;
    public Vector2              agentStartPos;
    public  float               LimitH;
    public  float               LimitD;
    public  float               LimitG;
    public  float               LimitB;
    public  GameObject          agentGuerrier;
    public  GameObject          EnemyGuerrier;
    public  List<GameObject>    alliesList = new List<GameObject>();
    public  List<GameObject>    enemiesList = new List<GameObject>();
    private int                 idGen = 0;
    private int                 idGenAgent = 0;
    private bool                canSpawn = true;
    private float               timerSpawn = 0f;
    public  float               timerMax;
    private bool                spawnLeft = true;
    private bool                cursorIsNormal = true;
    public  GameObject          blood;
    private GameObject          bloodObj;
    public Vector2              posLeft;
    public Vector2              posRight;


    void Start ()
    {
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().mapManager = gameObject;
        cam = GameObject.Find("Main Camera");
        gm.GetComponent<GameManager>().cam = cam;
        GameObject agentTmp = (GameObject)Instantiate(agentGuerrier, agentStartPos, transform.rotation);
        agentTmp.GetComponent<Agent>().id = idGenAgent++;
        alliesList.Add(agentTmp);
        timerSpawn = timerMax;
        if (gm.GetComponent<GameManager>().bloodless == false)
            bloodObj = (GameObject)Instantiate(blood, Vector2.zero, transform.rotation);
    }
	
	void Update ()
    {
        if (gm.GetComponent<GameManager>().gamePaused == false)
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
                    enemiesList.Count == 0 &&
                    gm.GetComponent<GameManager>().gamePaused == false)
            {
                print("goIN");
                print("goINidgen : " + idGen);
                print("goINcanSpawn : " + canSpawn);
                player.GetComponent<Deplacements>().isDead = true;
                gm.GetComponent<GameManager>().StartVictory();
            }
            if (enemiesList.Count > 0 || canSpawn == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape) &&
                    gm.GetComponent<GameManager>().gamePaused == false &&
                    gm.GetComponent<GameManager>().gameOver == false)
                {
                    OpenMenuInGame();
                }
                if (cursorIsNormal == false)
                    cursorIsNormal = true;
                else if (cursorIsNormal == true)
                    cursorIsNormal = false;
                playerManager.GetComponent<PlayerManager>().CheckMouse();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) &&
                gm.GetComponent<GameManager>().gamePaused == true &&
                gm.GetComponent<GameManager>().gameOver == false &&
                gm.GetComponent<GameManager>().isInMenu == true &&
                gm.GetComponent<GameManager>().isInOptions == false)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) &&
                gm.GetComponent<GameManager>().gamePaused == true &&
                gm.GetComponent<GameManager>().gameOver == false &&
                gm.GetComponent<GameManager>().isInMenu == true &&
                gm.GetComponent<GameManager>().isInOptions == true)
        {
            CloseOptions();
        }
    }

    public void OpenMenuInGame()
    {
        gm.GetComponent<GameManager>().DesactiveAllBulles();
        gm.GetComponent<GameManager>().isInMenu = true;
        gm.GetComponent<GameManager>().hudInGame.SetActive(false);
        gm.GetComponent<GameManager>().isInOptions = false;
        Time.timeScale = 0f;
        gm.GetComponent<GameManager>().gamePaused = true;
        gm.GetComponent<GameManager>().hudPanelMenu.SetActive(true);
        gm.GetComponent<GameManager>().hudPanelOptions.SetActive(false);
        gm.GetComponent<GameManager>().SetNormalMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
    }

    public void Resume()
    {
        gm.GetComponent<GameManager>().hudInGame.SetActive(true);
        gm.GetComponent<GameManager>().isInMenu = false;
        Time.timeScale = 1f;
        gm.GetComponent<GameManager>().gamePaused = false;
        gm.GetComponent<GameManager>().hudPanelMenu.SetActive(false);
        gm.GetComponent<GameManager>().hudPanelOptions.SetActive(false);
        playerManager.GetComponent<PlayerManager>().CheckMouse();
    }

    public void CloseOptions()
    {
        gm.GetComponent<GameManager>().isInOptions = false;
        gm.GetComponent<GameManager>().hudPanelMenu.SetActive(true);
        gm.GetComponent<GameManager>().hudPanelOptions.SetActive(false);
    }

    public void PopEnemy(int idToCheck)
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Enemy>().id == idToCheck)
                enemiesList.RemoveAt(i);
        }
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    public void PopAgent(int idToCheck)
    {
        for (int i = 0; i < alliesList.Count; i++)
        {
            if (alliesList[i].tag != "Player" &&
                alliesList[i].GetComponent<Agent>().id == idToCheck)
                alliesList.RemoveAt(i);
        }
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    void InstantiateGuerrier()
    {
        GameObject obj = null;
        if (spawnLeft == true)
        {
            spawnLeft = false;
            obj = (GameObject)Instantiate(EnemyGuerrier, posLeft, transform.rotation);
        }
        else
        {
            spawnLeft = true;
            obj = (GameObject)Instantiate(EnemyGuerrier, posRight, transform.rotation);
        }
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > 10)
            canSpawn = false;
    }

    public void ActivateBlood()
    {
        bloodObj = (GameObject)Instantiate(blood, transform.position, transform.rotation);
    }

    public void DesactivateBlood()
    {
        Destroy(bloodObj.gameObject);
    }
}
