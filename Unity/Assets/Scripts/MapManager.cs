using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public enum MapType
    {
        Capture,
        Defense,
        Boss
    };

    public GameObject player;
    public GameObject gm;
    public GameObject capture;
    public GameObject defense;
    public GameObject playerManager;
    private GameObject cam;
    public Vector2 playerStartPos;
    public Vector2 agentStartPos;
    public float LimitH;
    public float LimitD;
    public float LimitG;
    public float LimitB;
    public GameObject agentGuerrier;
    public GameObject EnemyGuerrierNormal;
    public GameObject EnemyGuerrierPlayer;
    public GameObject EnemyGuerrierCapture;
    public GameObject EnemyBossGuerrier;
    public List<GameObject> alliesList = new List<GameObject>();
    public List<GameObject> enemiesList = new List<GameObject>();
    private int idGen = 0;
    public int maxIdGen;
    private int idGenAgent = 0;
    private bool canSpawn = true;
    private float timerSpawn = 0f;
    public float timerMax;
    private bool spawnLeft = true;
    private bool cursorIsNormal = true;
    public GameObject blood;
    private GameObject bloodObj;
    public Vector2 posBoss;
    public Vector2 posLeft;
    public Vector2 posRight;
    public int mapID;
    public MapType type;


    void Start()
    {
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().mapManager = gameObject;
        cam = GameObject.Find("Main Camera");
        gm.GetComponent<GameManager>().cam = cam;
        if (type == MapType.Capture)
        {
            enemiesList.Add(capture);
            idGen = 1;
            gm.GetComponent<GameManager>().captureHealth.GetComponent<Slider>().value = 1f;
            gm.GetComponent<GameManager>().capturePanel.SetActive(true);
        }
        else if (type == MapType.Defense)
        {
            alliesList.Add(defense);
            idGenAgent = 1;
            gm.GetComponent<GameManager>().defenseHealth.GetComponent<Slider>().value = 1f;
            gm.GetComponent<GameManager>().defensePanel.SetActive(true);
        }
        GameObject agentTmp = (GameObject)Instantiate(agentGuerrier, agentStartPos, transform.rotation);
        agentTmp.GetComponent<Agent>().id = idGenAgent++;
        alliesList.Add(agentTmp);
        timerSpawn = timerMax;
        if (gm.GetComponent<GameManager>().bloodless == false)
            bloodObj = (GameObject)Instantiate(blood, Vector2.zero, transform.rotation);
        if (mapID == 1)
            StartMap1();
        else if (mapID == 2)
            StartMap2();
    }

    void StartMap1()
    {
        StartCoroutine(Map1());
    }

    void StartMap2()
    {
        StartCoroutine(Map2());
    }

    void Update()
    {
        if (gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (mapID == 0)
                UpdateMap0();
            else if (mapID == 1)
                UpdateMap1();
            else if (mapID == 2)
                UpdateMap2();
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

    void UpdateMap0()
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
                if (spawnLeft == true)
                {
                    spawnLeft = false;
                    InstantiateGuerrierNormal(posLeft);
                }
                else
                {
                    spawnLeft = true;
                    InstantiateGuerrierPlayer(posRight);
                }
            }
        }
        if (idGen > maxIdGen && canSpawn == true)
        {
            GameObject obj = null;
            gm.GetComponent<GameManager>().bossHealth.GetComponent<Slider>().value = 1;
            gm.GetComponent<GameManager>().bossPanel.SetActive(true);
            obj = (GameObject)Instantiate(EnemyBossGuerrier, posBoss, transform.rotation);
            obj.GetComponent<Enemy>().id = idGen++;
            obj.GetComponent<IAGuerrier>().player = player;
            enemiesList.Add(obj);
            gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
            canSpawn = false;
        }
        else if (canSpawn == false &&
                enemiesList.Count == 0 &&
                gm.GetComponent<GameManager>().gamePaused == false)
        {
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

    void UpdateMap1()
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
                if (spawnLeft == true)
                {
                    spawnLeft = false;
                    InstantiateGuerrierNormal(posLeft);
                }
                else
                {
                    spawnLeft = true;
                    InstantiateGuerrierPlayer(posRight);
                }
            }
        }
        if (canSpawn == true)
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

    void UpdateMap2()
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;
            if (timerSpawn > timerMax)
            {
                timerMax -= 0.2f;
                timerSpawn = 0f;
                if (timerMax < 1f)
                    timerMax = 1f;
                if (spawnLeft == true)
                {
                    spawnLeft = false;
                    InstantiateGuerrierNormal(posLeft);
                }
                else
                {
                    spawnLeft = true;
                    InstantiateGuerrierObjectif(posRight);
                }
            }
        }
        else if (canSpawn == false &&
                enemiesList.Count == 0 &&
                gm.GetComponent<GameManager>().gamePaused == false)
        {
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

    public void WinGame()
    {
        gm.GetComponent<GameManager>().defensePanel.SetActive(false);
        gm.GetComponent<GameManager>().capturePanel.SetActive(false);
        gm.GetComponent<GameManager>().bossPanel.SetActive(false);
        gm.GetComponent<GameManager>().playerLevel = player.GetComponent<StatsPlayer>().level;
        gm.GetComponent<GameManager>().playerXP = player.GetComponent<StatsPlayer>().currXP;
        player.GetComponent<Deplacements>().isDead = true;
        gm.GetComponent<GameManager>().StartVictory();
    }

    public void LoseGame()
    {
        gm.GetComponent<GameManager>().defensePanel.SetActive(false);
        gm.GetComponent<GameManager>().capturePanel.SetActive(false);
        gm.GetComponent<GameManager>().bossPanel.SetActive(false);
        player.GetComponent<Deplacements>().isDead = true;
        gm.GetComponent<GameManager>().StartDefeat();
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

    void InstantiateGuerrierNormal(Vector2 pos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyGuerrierNormal, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
            canSpawn = false;
    }

    void InstantiateGuerrierPlayer(Vector2 pos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyGuerrierPlayer, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
            canSpawn = false;
    }

    void InstantiateGuerrierObjectif(Vector2 pos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyGuerrierCapture, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
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

    IEnumerator Map1()
    {
        yield return new WaitForSeconds(0.1f);
        Vector2 vec1 = new Vector2(-1, 1.75f);
        Vector2 vec2 = new Vector2(1, 1.75f);
        GameObject obj1;
        obj1 = (GameObject)Instantiate(EnemyGuerrierNormal, vec1, transform.rotation);
        obj1.GetComponent<Enemy>().id = idGen++;
        obj1.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj1);
        GameObject obj2;
        obj2 = (GameObject)Instantiate(EnemyGuerrierPlayer, vec2, transform.rotation);
        obj2.GetComponent<Enemy>().id = idGen++;
        obj2.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj2);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    IEnumerator Map2()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject obj1;
        obj1 = (GameObject)Instantiate(EnemyGuerrierCapture, posLeft, transform.rotation);
        obj1.GetComponent<Enemy>().id = idGen++;
        obj1.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj1);
        GameObject obj2;
        obj2 = (GameObject)Instantiate(EnemyGuerrierCapture, posRight, transform.rotation);
        obj2.GetComponent<Enemy>().id = idGen++;
        obj2.GetComponent<IAGuerrier>().player = player;
        enemiesList.Add(obj2);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }
}
