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

    public  GameObject          player;
    public  GameObject          gm;
    public  GameObject          capture;
    public  GameObject          defense;
    public  GameObject          playerManager;
    private GameObject[][]      tabNodes;
    public  int                 tabNodesMaxX;
    public  int                 tabNodesMaxY;
    private GameObject          cam;
    public  Vector2             playerStartPos;
    public  Vector2[]           agentStartPos;
    public  float               LimitH;
    public  float               LimitD;
    public  float               LimitG;
    public  float               LimitB;

    public  GameObject          EnemyMagician;
    public  GameObject          EnemyGuerrierBrigand;
    public  GameObject          EnemyGuerrierBarbare;
    public  GameObject          EnemyGuerrierBoss;

    public  List<GameObject>    alliesList = new List<GameObject>();
    public  List<GameObject>    enemiesList = new List<GameObject>();
    public  List<int>           enemiesDeadList = new List<int>();
    private int                 idGen = 0;
    public  int                 maxIdGen;
    private int                 idGenAgent = 0;
    private bool                canSpawn = true;
    private float               timerSpawn = 0f;
    public  float               timerMax;
    private bool                cursorIsNormal = true;
    public  GameObject          blood;
    private GameObject          bloodObj;
    public  Vector2             posBoss;
    public  Vector2[]           posEnemies;
    public  int                 mapID;
    public  MapType             type;
    public  bool                agent1Died;
    public  bool                agent2Died;
    public  bool                agent3Died;


    void Start()
    {
        gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().mapManager = gameObject;
        cam = GameObject.Find("Main Camera");
        gm.GetComponent<GameManager>().cam = cam;

        Time.timeScale = 0f;

        FillTabNodes();
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


        GameObject agentTmp = null;
        if (gm.GetComponent<GameManager>().tabAgents[0] != null)
        {
            agentTmp = (GameObject)Instantiate(gm.GetComponent<GameManager>().tabAgents[0], agentStartPos[0], transform.rotation);
            agentTmp.GetComponent<Agent>().id = idGenAgent++;
            agentTmp.GetComponent<Agent>().idAgent = 0;
            agentTmp.GetComponent<IAGuerrierAgent>().newPos = agentStartPos[0];
            alliesList.Add(agentTmp);

            if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                gm.GetComponent<GameManager>().agent1Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().knightIcon;
            else if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Rogue)
                gm.GetComponent<GameManager>().agent1Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().assassinIcon;
            else
                gm.GetComponent<GameManager>().agent1Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().swordsmanIcon;
            gm.GetComponent<GameManager>().agent1Panel.SetActive(true);
        }
        else
        {
            gm.GetComponent<GameManager>().agent1Panel.SetActive(false);
        }
            

        if (gm.GetComponent<GameManager>().tabAgents[1] != null)
        {
            agentTmp = (GameObject)Instantiate(gm.GetComponent<GameManager>().tabAgents[1], agentStartPos[1], transform.rotation);
            agentTmp.GetComponent<Agent>().id = idGenAgent++;
            agentTmp.GetComponent<Agent>().idAgent = 1;
            agentTmp.GetComponent<IAGuerrierAgent>().newPos = agentStartPos[1];
            alliesList.Add(agentTmp);

            if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                gm.GetComponent<GameManager>().agent2Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().knightIcon;
            else if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Rogue)
                gm.GetComponent<GameManager>().agent2Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().assassinIcon;
            else
                gm.GetComponent<GameManager>().agent2Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().swordsmanIcon;
            gm.GetComponent<GameManager>().agent2Panel.SetActive(true);
        }
        else
        {
            gm.GetComponent<GameManager>().agent2Panel.SetActive(false);
        }
            

        if (gm.GetComponent<GameManager>().tabAgents[2] != null)
        {
            agentTmp = (GameObject)Instantiate(gm.GetComponent<GameManager>().tabAgents[2], agentStartPos[2], transform.rotation);
            agentTmp.GetComponent<Agent>().id = idGenAgent++;
            agentTmp.GetComponent<Agent>().idAgent = 2;
            agentTmp.GetComponent<IAGuerrierAgent>().newPos = agentStartPos[2];
            alliesList.Add(agentTmp);

            if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Knight)
                gm.GetComponent<GameManager>().agent3Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().knightIcon;
            else if (agentTmp.GetComponent<IAGuerrierAgent>().SheetClass == IAGuerrierAgent.AgentClass.Rogue)
                gm.GetComponent<GameManager>().agent3Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().assassinIcon;
            else
                gm.GetComponent<GameManager>().agent3Portrait.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().swordsmanIcon;
            gm.GetComponent<GameManager>().agent3Panel.SetActive(true);
        }
        else
        {
            gm.GetComponent<GameManager>().agent3Panel.SetActive(false);
        }
            
        timerSpawn = timerMax;

        if (mapID == 1)
            StartMap1();
        else if (mapID == 2)
            StartMap2();

        Time.timeScale = 1f;

        gm.GetComponent<GameManager>().PlayMusicCombat();
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
            else if (mapID == 3)
                UpdateMap3();
            else if (mapID == 4)
                UpdateMap4();
            else if (mapID == 5)
                UpdateMap5();
        }
    }

    void UpdateMap0()
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;
            if (timerSpawn > timerMax)
            {
                timerSpawn = 0f;
            //    InstantiateGuerrierNormal(posLeft, new Vector2(posLeft.x, posLeft.y - 0.5f));
             //   InstantiateGuerrierPlayer(posRight, new Vector2(posRight.x, posRight.y - 0.5f));
            }
        }
        if (idGen == maxIdGen && canSpawn == true)
        {
            GameObject obj = null;
            gm.GetComponent<GameManager>().bossHealth.GetComponent<Slider>().value = 1;
            gm.GetComponent<GameManager>().bossPanel.SetActive(true);
            obj = (GameObject)Instantiate(EnemyGuerrierBoss, posBoss, transform.rotation);
            obj.GetComponent<Enemy>().id = idGen++;
            obj.GetComponent<IAGuerrier>().player = player;
            obj.GetComponent<IAGuerrier>().newPos = new Vector2(posBoss.x, posBoss.y);

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
                timerSpawn = 0f;
             //   InstantiateGuerrierNormal(posLeft, new Vector2(posLeft.x, posLeft.y - 0.5f));
             //   InstantiateGuerrierPlayer(posRight, new Vector2(posRight.x, posRight.y - 0.5f));
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
                timerSpawn = 0f;
           //     InstantiateGuerrierNormal(posLeft, new Vector2(posLeft.x, posLeft.y + 0.5f));
           //     InstantiateGuerrierPlayer(posRight, new Vector2(posRight.x, posRight.y + 0.5f));
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

    void UpdateMap3() // capture
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;

            if (timerSpawn > timerMax)
            {
                timerSpawn = 0f;
                InstantiateGuerrierBrigand(posEnemies[0], new Vector2(posEnemies[0].x, posEnemies[0].y - 0.5f));
                InstantiateGuerrierBarbare(posEnemies[1], new Vector2(posEnemies[1].x, posEnemies[1].y - 0.5f));
            }

            if (Input.GetKeyDown(KeyCode.Escape) &&
                gm.GetComponent<GameManager>().gamePaused == false &&
                gm.GetComponent<GameManager>().gameOver == false)
                OpenMenuInGame();

            if (cursorIsNormal == false)
                cursorIsNormal = true;
            else if (cursorIsNormal == true)
                cursorIsNormal = false;

            playerManager.GetComponent<PlayerManager>().CheckMouse();
        }
    }

    void UpdateMap4() // defense
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;
            if (timerSpawn > timerMax)
            {
                timerSpawn = 0f;
                InstantiateGuerrierBrigand(posEnemies[0], new Vector2(posEnemies[0].x, posEnemies[0].y - 0.5f));
                InstantiateGuerrierBarbare(posEnemies[1], new Vector2(posEnemies[1].x, posEnemies[1].y - 0.5f));
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
                OpenMenuInGame();

            if (cursorIsNormal == false)
                cursorIsNormal = true;
            else if (cursorIsNormal == true)
                cursorIsNormal = false;

            playerManager.GetComponent<PlayerManager>().CheckMouse();
        }
    }

    void UpdateMap5() // boss
    {
        if (canSpawn == true)
        {
            timerSpawn += Time.deltaTime;
            if (timerSpawn > timerMax)
            {
                timerSpawn = 0f;
                InstantiateGuerrierBrigand(posEnemies[0], new Vector2(posEnemies[0].x, posEnemies[0].y - 0.5f));
                InstantiateGuerrierBarbare(posEnemies[1], new Vector2(posEnemies[1].x, posEnemies[1].y - 0.5f));
            }
        }
        if (idGen == maxIdGen && canSpawn == true)
        {
            GameObject obj = null;
            gm.GetComponent<GameManager>().bossHealth.GetComponent<Slider>().value = 1;
            gm.GetComponent<GameManager>().bossPanel.SetActive(true);
            obj = (GameObject)Instantiate(EnemyGuerrierBoss, posBoss, transform.rotation);
            obj.GetComponent<Enemy>().id = idGen++;
            obj.GetComponent<IAGuerrier>().player = player;
            obj.GetComponent<IAGuerrier>().newPos = new Vector2(posBoss.x, posBoss.y);

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

    public void WinGame()
    {
        gm.GetComponent<GameManager>().defensePanel.SetActive(false);
        gm.GetComponent<GameManager>().capturePanel.SetActive(false);
        gm.GetComponent<GameManager>().bossPanel.SetActive(false);

        gm.GetComponent<GameManager>().coins += gm.GetComponent<GameManager>().listMissions[gm.GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().reward;

        player.GetComponent<StatsPlayer>().EarnXP(gm.GetComponent<GameManager>().listMissions[gm.GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().experience);

        if (gm.GetComponent<GameManager>().currSave == 1)
        {
            PlayerPrefs.SetInt("Load1PlayerLevel", player.GetComponent<StatsPlayer>().level);
            PlayerPrefs.SetInt("Load1PlayerXP", player.GetComponent<StatsPlayer>().currXP);
            PlayerPrefs.SetInt("Load1Coins", gm.GetComponent<GameManager>().coins);
            PlayerPrefs.SetInt("Load1Prestige", gm.GetComponent<GameManager>().prestige);

            int actionPoints = PlayerPrefs.GetInt("Load1PlayerActionPoints") + (player.GetComponent<StatsPlayer>().levelsWon);
            PlayerPrefs.SetInt("Load1PlayerActionPoints", actionPoints);

            for (int i = 0; i < alliesList.Count; i++)
            {
                if (alliesList[i].tag == "AgentGuerrier")
                {
                    alliesList[i].GetComponent<IAGuerrierAgent>().EarnXP(gm.GetComponent<GameManager>().listMissions[gm.GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().experience);

                    if (alliesList[i].GetComponent<Agent>().idAgent == 0)
                    {
                        PlayerPrefs.SetInt("Load1Agent1Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load1Agent1XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 1)
                    {
                        PlayerPrefs.SetInt("Load1Agent2Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load1Agent2XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 2)
                    {
                        PlayerPrefs.SetInt("Load1Agent3Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load1Agent3XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                }
            }
        }
        else if (gm.GetComponent<GameManager>().currSave == 2)
        {
            PlayerPrefs.SetInt("Load2PlayerLevel", player.GetComponent<StatsPlayer>().level);
            PlayerPrefs.SetInt("Load2PlayerXP", player.GetComponent<StatsPlayer>().currXP);
            PlayerPrefs.SetInt("Load2Coins", gm.GetComponent<GameManager>().coins);
            PlayerPrefs.SetInt("Load2Prestige", gm.GetComponent<GameManager>().prestige);

            int actionPoints = PlayerPrefs.GetInt("Load2PlayerActionPoints") + (player.GetComponent<StatsPlayer>().levelsWon);
            PlayerPrefs.SetInt("Load2PlayerActionPoints", actionPoints);

            for (int i = 0; i < alliesList.Count; i++)
            {
                if (alliesList[i].tag == "AgentGuerrier")
                {
                    alliesList[i].GetComponent<IAGuerrierAgent>().EarnXP(gm.GetComponent<GameManager>().listMissions[gm.GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().experience);

                    if (alliesList[i].GetComponent<Agent>().idAgent == 0)
                    {
                        PlayerPrefs.SetInt("Load2Agent1Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load2Agent1XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 1)
                    {
                        PlayerPrefs.SetInt("Load2Agent2Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load2Agent2XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 2)
                    {
                        PlayerPrefs.SetInt("Load2Agent3Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load2Agent3XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                }
            }
        }
        else if (gm.GetComponent<GameManager>().currSave == 3)
        {
            PlayerPrefs.SetInt("Load3PlayerLevel", player.GetComponent<StatsPlayer>().level);
            PlayerPrefs.SetInt("Load3PlayerXP", player.GetComponent<StatsPlayer>().currXP);
            PlayerPrefs.SetInt("Load3Coins", gm.GetComponent<GameManager>().coins);
            PlayerPrefs.SetInt("Load3Prestige", gm.GetComponent<GameManager>().prestige);

            int actionPoints = PlayerPrefs.GetInt("Load3PlayerActionPoints") + (player.GetComponent<StatsPlayer>().levelsWon);
            PlayerPrefs.SetInt("Load3PlayerActionPoints", actionPoints);

            for (int i = 0; i < alliesList.Count; i++)
            {
                if (alliesList[i].tag == "AgentGuerrier")
                {
                    alliesList[i].GetComponent<IAGuerrierAgent>().EarnXP(gm.GetComponent<GameManager>().listMissions[gm.GetComponent<GameManager>().currMissionSelected].GetComponent<MissionSheet>().experience);

                    if (alliesList[i].GetComponent<Agent>().idAgent == 0)
                    {
                        PlayerPrefs.SetInt("Load3Agent1Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load3Agent1XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 1)
                    {
                        PlayerPrefs.SetInt("Load3Agent2Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load3Agent2XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                    else if (alliesList[i].GetComponent<Agent>().idAgent == 2)
                    {
                        PlayerPrefs.SetInt("Load3Agent3Level", alliesList[i].GetComponent<IAGuerrierAgent>().level);
                        PlayerPrefs.SetInt("Load3Agent3XP", alliesList[i].GetComponent<IAGuerrierAgent>().currXP);
                    }
                }
            }
        }

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
        gm.GetComponent<Buttons>().AnimationPanelHUDMenu();
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

    public void PopEnemy(int idToCheck)
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if (enemiesList[i].GetComponent<Enemy>().id == idToCheck)
                enemiesList.RemoveAt(i);
        }
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    public void FillDeadList(int idToFill)
    {
        enemiesDeadList.Add(idToFill);
    }

    public bool IsEnemyAlreadyDead(int idToCheck)
    {
        for (int i = 0; i < enemiesDeadList.Count; i++)
        {
            if (enemiesDeadList[i] == idToCheck)
                return (true);
        }
        return (false);
    }

    public void PopAgent(int idToCheck)
    {
        for (int i = 0; i < alliesList.Count; i++)
        {
            if (alliesList[i].tag != "Player" &&
                alliesList[i].GetComponent<Agent>().id == idToCheck)
            {
                if (alliesList[i].GetComponent<Agent>().idAgent == 0)
                {
                    agent1Died = true;
                }
                else if (alliesList[i].GetComponent<Agent>().idAgent == 1)
                {
                    agent2Died = true;
                }
                else if (alliesList[i].GetComponent<Agent>().idAgent == 2)
                {
                    agent3Died = true;
                }
                alliesList.RemoveAt(i);
            }
                
        }
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    void InstantiateGuerrierBrigand(Vector2 pos, Vector2 targetPos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyGuerrierBrigand, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        obj.GetComponent<IAGuerrier>().newPos = pos;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
            canSpawn = false;
    }

    void InstantiateMagicianEnemy(Vector2 pos, Vector2 targetPos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyMagician, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        obj.GetComponent<IAGuerrier>().newPos = pos;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
            canSpawn = false;
    }

    void InstantiateGuerrierBarbare(Vector2 pos, Vector2 targetPos)
    {
        GameObject obj = null;

        obj = (GameObject)Instantiate(EnemyGuerrierBarbare, pos, transform.rotation);
        obj.GetComponent<Enemy>().id = idGen++;
        obj.GetComponent<IAGuerrier>().player = player;
        obj.GetComponent<IAGuerrier>().newPos = pos;
        enemiesList.Add(obj);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
        if (idGen > maxIdGen && type == MapType.Defense)
            canSpawn = false;
    }

    public void ActivateBlood()
    {
        //bloodObj = (GameObject)Instantiate(blood, transform.position, transform.rotation);
    }

    public void DesactivateBlood()
    {
        //Destroy(bloodObj.gameObject);
    }

    IEnumerator Map1()
    {
        yield return new WaitForSeconds(0.25f);
        Vector2 vec1 = new Vector2(-1, 1.75f);
        Vector2 vec2 = new Vector2(1, 1.75f);
        GameObject obj1;
        obj1 = (GameObject)Instantiate(EnemyGuerrierBrigand, vec1, transform.rotation);
        obj1.GetComponent<Enemy>().id = idGen++;
        obj1.GetComponent<IAGuerrier>().player = player;
        obj1.GetComponent<IAGuerrier>().newPos = vec1;
        enemiesList.Add(obj1);
        GameObject obj2;
        obj2 = (GameObject)Instantiate(EnemyGuerrierBarbare, vec2, transform.rotation);
        obj2.GetComponent<Enemy>().id = idGen++;
        obj2.GetComponent<IAGuerrier>().player = player;
        obj2.GetComponent<IAGuerrier>().newPos = vec2;
        enemiesList.Add(obj2);
        gm.GetComponent<GameManager>().textNbEnemy.GetComponent<Text>().text = enemiesList.Count.ToString();
    }

    IEnumerator Map2()
    {
        yield return new WaitForSeconds(0.25f);
    }

    public GameObject[][] GetTabNodes()
    {
        return (tabNodes);
    }

    private void FillTabNodes()
    {
        if (mapID == 0 ||
            mapID == 1 ||
            mapID == 2)
        {
            tabNodes = new GameObject[19][];
            tabNodes[0] = new GameObject[35];
            tabNodes[1] = new GameObject[35];
            tabNodes[2] = new GameObject[35];
            tabNodes[3] = new GameObject[35];
            tabNodes[4] = new GameObject[35];
            tabNodes[5] = new GameObject[35];
            tabNodes[6] = new GameObject[35];
            tabNodes[7] = new GameObject[35];
            tabNodes[8] = new GameObject[35];
            tabNodes[9] = new GameObject[35];
            tabNodes[10] = new GameObject[35];
            tabNodes[11] = new GameObject[35];
            tabNodes[12] = new GameObject[35];
            tabNodes[13] = new GameObject[35];
            tabNodes[14] = new GameObject[35];
            tabNodes[15] = new GameObject[35];
            tabNodes[16] = new GameObject[35];
            tabNodes[17] = new GameObject[35];
            tabNodes[18] = new GameObject[35];

            tabNodes[0][0] = GameObject.Find("Nodes/Node 0 (0)");
            tabNodes[0][1] = GameObject.Find("Nodes/Node 1 (0)");
            tabNodes[0][2] = GameObject.Find("Nodes/Node 2 (0)");
            tabNodes[0][3] = GameObject.Find("Nodes/Node 3 (0)");
            tabNodes[0][4] = GameObject.Find("Nodes/Node 4 (0)");
            tabNodes[0][5] = GameObject.Find("Nodes/Node 5 (0)");
            tabNodes[0][6] = GameObject.Find("Nodes/Node 6 (0)");
            tabNodes[0][7] = GameObject.Find("Nodes/Node 7 (0)");
            tabNodes[0][8] = GameObject.Find("Nodes/Node 8 (0)");
            tabNodes[0][9] = GameObject.Find("Nodes/Node 9 (0)");
            tabNodes[0][10] = GameObject.Find("Nodes/Node 10 (0)");
            tabNodes[0][11] = GameObject.Find("Nodes/Node 11 (0)");
            tabNodes[0][12] = GameObject.Find("Nodes/Node 12 (0)");
            tabNodes[0][13] = GameObject.Find("Nodes/Node 13 (0)");
            tabNodes[0][14] = GameObject.Find("Nodes/Node 14 (0)");
            tabNodes[0][15] = GameObject.Find("Nodes/Node 15 (0)");
            tabNodes[0][16] = GameObject.Find("Nodes/Node 16 (0)");
            tabNodes[0][17] = GameObject.Find("Nodes/Node 17 (0)");
            tabNodes[0][18] = GameObject.Find("Nodes/Node 18 (0)");
            tabNodes[0][19] = GameObject.Find("Nodes/Node 19 (0)");
            tabNodes[0][20] = GameObject.Find("Nodes/Node 20 (0)");
            tabNodes[0][21] = GameObject.Find("Nodes/Node 21 (0)");
            tabNodes[0][22] = GameObject.Find("Nodes/Node 22 (0)");
            tabNodes[0][23] = GameObject.Find("Nodes/Node 23 (0)");
            tabNodes[0][24] = GameObject.Find("Nodes/Node 24 (0)");
            tabNodes[0][25] = GameObject.Find("Nodes/Node 25 (0)");
            tabNodes[0][26] = GameObject.Find("Nodes/Node 26 (0)");
            tabNodes[0][27] = GameObject.Find("Nodes/Node 27 (0)");
            tabNodes[0][28] = GameObject.Find("Nodes/Node 28 (0)");
            tabNodes[0][29] = GameObject.Find("Nodes/Node 29 (0)");
            tabNodes[0][30] = GameObject.Find("Nodes/Node 30 (0)");
            tabNodes[0][31] = GameObject.Find("Nodes/Node 31 (0)");
            tabNodes[0][32] = GameObject.Find("Nodes/Node 32 (0)");
            tabNodes[0][33] = GameObject.Find("Nodes/Node 33 (0)");
            tabNodes[0][34] = GameObject.Find("Nodes/Node 34 (0)");

            tabNodes[1][0] = GameObject.Find("Nodes/Node 0 (1)");
            tabNodes[1][1] = GameObject.Find("Nodes/Node 1 (1)");
            tabNodes[1][2] = GameObject.Find("Nodes/Node 2 (1)");
            tabNodes[1][3] = GameObject.Find("Nodes/Node 3 (1)");
            tabNodes[1][4] = GameObject.Find("Nodes/Node 4 (1)");
            tabNodes[1][5] = GameObject.Find("Nodes/Node 5 (1)");
            tabNodes[1][6] = GameObject.Find("Nodes/Node 6 (1)");
            tabNodes[1][7] = GameObject.Find("Nodes/Node 7 (1)");
            tabNodes[1][8] = GameObject.Find("Nodes/Node 8 (1)");
            tabNodes[1][9] = GameObject.Find("Nodes/Node 9 (1)");
            tabNodes[1][10] = GameObject.Find("Nodes/Node 10 (1)");
            tabNodes[1][11] = GameObject.Find("Nodes/Node 11 (1)");
            tabNodes[1][12] = GameObject.Find("Nodes/Node 12 (1)");
            tabNodes[1][13] = GameObject.Find("Nodes/Node 13 (1)");
            tabNodes[1][14] = GameObject.Find("Nodes/Node 14 (1)");
            tabNodes[1][15] = GameObject.Find("Nodes/Node 15 (1)");
            tabNodes[1][16] = GameObject.Find("Nodes/Node 16 (1)");
            tabNodes[1][17] = GameObject.Find("Nodes/Node 17 (1)");
            tabNodes[1][18] = GameObject.Find("Nodes/Node 18 (1)");
            tabNodes[1][19] = GameObject.Find("Nodes/Node 19 (1)");
            tabNodes[1][20] = GameObject.Find("Nodes/Node 20 (1)");
            tabNodes[1][21] = GameObject.Find("Nodes/Node 21 (1)");
            tabNodes[1][22] = GameObject.Find("Nodes/Node 22 (1)");
            tabNodes[1][23] = GameObject.Find("Nodes/Node 23 (1)");
            tabNodes[1][24] = GameObject.Find("Nodes/Node 24 (1)");
            tabNodes[1][25] = GameObject.Find("Nodes/Node 25 (1)");
            tabNodes[1][26] = GameObject.Find("Nodes/Node 26 (1)");
            tabNodes[1][27] = GameObject.Find("Nodes/Node 27 (1)");
            tabNodes[1][28] = GameObject.Find("Nodes/Node 28 (1)");
            tabNodes[1][29] = GameObject.Find("Nodes/Node 29 (1)");
            tabNodes[1][30] = GameObject.Find("Nodes/Node 30 (1)");
            tabNodes[1][31] = GameObject.Find("Nodes/Node 31 (1)");
            tabNodes[1][32] = GameObject.Find("Nodes/Node 32 (1)");
            tabNodes[1][33] = GameObject.Find("Nodes/Node 33 (1)");
            tabNodes[1][34] = GameObject.Find("Nodes/Node 34 (1)");

            tabNodes[2][0] = GameObject.Find("Nodes/Node 0 (2)");
            tabNodes[2][1] = GameObject.Find("Nodes/Node 1 (2)");
            tabNodes[2][2] = GameObject.Find("Nodes/Node 2 (2)");
            tabNodes[2][3] = GameObject.Find("Nodes/Node 3 (2)");
            tabNodes[2][4] = GameObject.Find("Nodes/Node 4 (2)");
            tabNodes[2][5] = GameObject.Find("Nodes/Node 5 (2)");
            tabNodes[2][6] = GameObject.Find("Nodes/Node 6 (2)");
            tabNodes[2][7] = GameObject.Find("Nodes/Node 7 (2)");
            tabNodes[2][8] = GameObject.Find("Nodes/Node 8 (2)");
            tabNodes[2][9] = GameObject.Find("Nodes/Node 9 (2)");
            tabNodes[2][10] = GameObject.Find("Nodes/Node 10 (2)");
            tabNodes[2][11] = GameObject.Find("Nodes/Node 11 (2)");
            tabNodes[2][12] = GameObject.Find("Nodes/Node 12 (2)");
            tabNodes[2][13] = GameObject.Find("Nodes/Node 13 (2)");
            tabNodes[2][14] = GameObject.Find("Nodes/Node 14 (2)");
            tabNodes[2][15] = GameObject.Find("Nodes/Node 15 (2)");
            tabNodes[2][16] = GameObject.Find("Nodes/Node 16 (2)");
            tabNodes[2][17] = GameObject.Find("Nodes/Node 17 (2)");
            tabNodes[2][18] = GameObject.Find("Nodes/Node 18 (2)");
            tabNodes[2][19] = GameObject.Find("Nodes/Node 19 (2)");
            tabNodes[2][20] = GameObject.Find("Nodes/Node 20 (2)");
            tabNodes[2][21] = GameObject.Find("Nodes/Node 21 (2)");
            tabNodes[2][22] = GameObject.Find("Nodes/Node 22 (2)");
            tabNodes[2][23] = GameObject.Find("Nodes/Node 23 (2)");
            tabNodes[2][24] = GameObject.Find("Nodes/Node 24 (2)");
            tabNodes[2][25] = GameObject.Find("Nodes/Node 25 (2)");
            tabNodes[2][26] = GameObject.Find("Nodes/Node 26 (2)");
            tabNodes[2][27] = GameObject.Find("Nodes/Node 27 (2)");
            tabNodes[2][28] = GameObject.Find("Nodes/Node 28 (2)");
            tabNodes[2][29] = GameObject.Find("Nodes/Node 29 (2)");
            tabNodes[2][30] = GameObject.Find("Nodes/Node 30 (2)");
            tabNodes[2][31] = GameObject.Find("Nodes/Node 31 (2)");
            tabNodes[2][32] = GameObject.Find("Nodes/Node 32 (2)");
            tabNodes[2][33] = GameObject.Find("Nodes/Node 33 (2)");
            tabNodes[2][34] = GameObject.Find("Nodes/Node 34 (2)");

            tabNodes[3][0] = GameObject.Find("Nodes/Node 0 (3)");
            tabNodes[3][1] = GameObject.Find("Nodes/Node 1 (3)");
            tabNodes[3][2] = GameObject.Find("Nodes/Node 2 (3)");
            tabNodes[3][3] = GameObject.Find("Nodes/Node 3 (3)");
            tabNodes[3][4] = GameObject.Find("Nodes/Node 4 (3)");
            tabNodes[3][5] = GameObject.Find("Nodes/Node 5 (3)");
            tabNodes[3][6] = GameObject.Find("Nodes/Node 6 (3)");
            tabNodes[3][7] = GameObject.Find("Nodes/Node 7 (3)");
            tabNodes[3][8] = GameObject.Find("Nodes/Node 8 (3)");
            tabNodes[3][9] = GameObject.Find("Nodes/Node 9 (3)");
            tabNodes[3][10] = GameObject.Find("Nodes/Node 10 (3)");
            tabNodes[3][11] = GameObject.Find("Nodes/Node 11 (3)");
            tabNodes[3][12] = GameObject.Find("Nodes/Node 12 (3)");
            tabNodes[3][13] = GameObject.Find("Nodes/Node 13 (3)");
            tabNodes[3][14] = GameObject.Find("Nodes/Node 14 (3)");
            tabNodes[3][15] = GameObject.Find("Nodes/Node 15 (3)");
            tabNodes[3][16] = GameObject.Find("Nodes/Node 16 (3)");
            tabNodes[3][17] = GameObject.Find("Nodes/Node 17 (3)");
            tabNodes[3][18] = GameObject.Find("Nodes/Node 18 (3)");
            tabNodes[3][19] = GameObject.Find("Nodes/Node 19 (3)");
            tabNodes[3][20] = GameObject.Find("Nodes/Node 20 (3)");
            tabNodes[3][21] = GameObject.Find("Nodes/Node 21 (3)");
            tabNodes[3][22] = GameObject.Find("Nodes/Node 22 (3)");
            tabNodes[3][23] = GameObject.Find("Nodes/Node 23 (3)");
            tabNodes[3][24] = GameObject.Find("Nodes/Node 24 (3)");
            tabNodes[3][25] = GameObject.Find("Nodes/Node 25 (3)");
            tabNodes[3][26] = GameObject.Find("Nodes/Node 26 (3)");
            tabNodes[3][27] = GameObject.Find("Nodes/Node 27 (3)");
            tabNodes[3][28] = GameObject.Find("Nodes/Node 28 (3)");
            tabNodes[3][29] = GameObject.Find("Nodes/Node 29 (3)");
            tabNodes[3][30] = GameObject.Find("Nodes/Node 30 (3)");
            tabNodes[3][31] = GameObject.Find("Nodes/Node 31 (3)");
            tabNodes[3][32] = GameObject.Find("Nodes/Node 32 (3)");
            tabNodes[3][33] = GameObject.Find("Nodes/Node 33 (3)");
            tabNodes[3][34] = GameObject.Find("Nodes/Node 34 (3)");

            tabNodes[4][0] = GameObject.Find("Nodes/Node 0 (4)");
            tabNodes[4][1] = GameObject.Find("Nodes/Node 1 (4)");
            tabNodes[4][2] = GameObject.Find("Nodes/Node 2 (4)");
            tabNodes[4][3] = GameObject.Find("Nodes/Node 3 (4)");
            tabNodes[4][4] = GameObject.Find("Nodes/Node 4 (4)");
            tabNodes[4][5] = GameObject.Find("Nodes/Node 5 (4)");
            tabNodes[4][6] = GameObject.Find("Nodes/Node 6 (4)");
            tabNodes[4][7] = GameObject.Find("Nodes/Node 7 (4)");
            tabNodes[4][8] = GameObject.Find("Nodes/Node 8 (4)");
            tabNodes[4][9] = GameObject.Find("Nodes/Node 9 (4)");
            tabNodes[4][10] = GameObject.Find("Nodes/Node 10 (4)");
            tabNodes[4][11] = GameObject.Find("Nodes/Node 11 (4)");
            tabNodes[4][12] = GameObject.Find("Nodes/Node 12 (4)");
            tabNodes[4][13] = GameObject.Find("Nodes/Node 13 (4)");
            tabNodes[4][14] = GameObject.Find("Nodes/Node 14 (4)");
            tabNodes[4][15] = GameObject.Find("Nodes/Node 15 (4)");
            tabNodes[4][16] = GameObject.Find("Nodes/Node 16 (4)");
            tabNodes[4][17] = GameObject.Find("Nodes/Node 17 (4)");
            tabNodes[4][18] = GameObject.Find("Nodes/Node 18 (4)");
            tabNodes[4][19] = GameObject.Find("Nodes/Node 19 (4)");
            tabNodes[4][20] = GameObject.Find("Nodes/Node 20 (4)");
            tabNodes[4][21] = GameObject.Find("Nodes/Node 21 (4)");
            tabNodes[4][22] = GameObject.Find("Nodes/Node 22 (4)");
            tabNodes[4][23] = GameObject.Find("Nodes/Node 23 (4)");
            tabNodes[4][24] = GameObject.Find("Nodes/Node 24 (4)");
            tabNodes[4][25] = GameObject.Find("Nodes/Node 25 (4)");
            tabNodes[4][26] = GameObject.Find("Nodes/Node 26 (4)");
            tabNodes[4][27] = GameObject.Find("Nodes/Node 27 (4)");
            tabNodes[4][28] = GameObject.Find("Nodes/Node 28 (4)");
            tabNodes[4][29] = GameObject.Find("Nodes/Node 29 (4)");
            tabNodes[4][30] = GameObject.Find("Nodes/Node 30 (4)");
            tabNodes[4][31] = GameObject.Find("Nodes/Node 31 (4)");
            tabNodes[4][32] = GameObject.Find("Nodes/Node 32 (4)");
            tabNodes[4][33] = GameObject.Find("Nodes/Node 33 (4)");
            tabNodes[4][34] = GameObject.Find("Nodes/Node 34 (4)");

            tabNodes[5][0] = GameObject.Find("Nodes/Node 0 (5)");
            tabNodes[5][1] = GameObject.Find("Nodes/Node 1 (5)");
            tabNodes[5][2] = GameObject.Find("Nodes/Node 2 (5)");
            tabNodes[5][3] = GameObject.Find("Nodes/Node 3 (5)");
            tabNodes[5][4] = GameObject.Find("Nodes/Node 4 (5)");
            tabNodes[5][5] = GameObject.Find("Nodes/Node 5 (5)");
            tabNodes[5][6] = GameObject.Find("Nodes/Node 6 (5)");
            tabNodes[5][7] = GameObject.Find("Nodes/Node 7 (5)");
            tabNodes[5][8] = GameObject.Find("Nodes/Node 8 (5)");
            tabNodes[5][9] = GameObject.Find("Nodes/Node 9 (5)");
            tabNodes[5][10] = GameObject.Find("Nodes/Node 10 (5)");
            tabNodes[5][11] = GameObject.Find("Nodes/Node 11 (5)");
            tabNodes[5][12] = GameObject.Find("Nodes/Node 12 (5)");
            tabNodes[5][13] = GameObject.Find("Nodes/Node 13 (5)");
            tabNodes[5][14] = GameObject.Find("Nodes/Node 14 (5)");
            tabNodes[5][15] = GameObject.Find("Nodes/Node 15 (5)");
            tabNodes[5][16] = GameObject.Find("Nodes/Node 16 (5)");
            tabNodes[5][17] = GameObject.Find("Nodes/Node 17 (5)");
            tabNodes[5][18] = GameObject.Find("Nodes/Node 18 (5)");
            tabNodes[5][19] = GameObject.Find("Nodes/Node 19 (5)");
            tabNodes[5][20] = GameObject.Find("Nodes/Node 20 (5)");
            tabNodes[5][21] = GameObject.Find("Nodes/Node 21 (5)");
            tabNodes[5][22] = GameObject.Find("Nodes/Node 22 (5)");
            tabNodes[5][23] = GameObject.Find("Nodes/Node 23 (5)");
            tabNodes[5][24] = GameObject.Find("Nodes/Node 24 (5)");
            tabNodes[5][25] = GameObject.Find("Nodes/Node 25 (5)");
            tabNodes[5][26] = GameObject.Find("Nodes/Node 26 (5)");
            tabNodes[5][27] = GameObject.Find("Nodes/Node 27 (5)");
            tabNodes[5][28] = GameObject.Find("Nodes/Node 28 (5)");
            tabNodes[5][29] = GameObject.Find("Nodes/Node 29 (5)");
            tabNodes[5][30] = GameObject.Find("Nodes/Node 30 (5)");
            tabNodes[5][31] = GameObject.Find("Nodes/Node 31 (5)");
            tabNodes[5][32] = GameObject.Find("Nodes/Node 32 (5)");
            tabNodes[5][33] = GameObject.Find("Nodes/Node 33 (5)");
            tabNodes[5][34] = GameObject.Find("Nodes/Node 34 (5)");

            tabNodes[6][0] = GameObject.Find("Nodes/Node 0 (6)");
            tabNodes[6][1] = GameObject.Find("Nodes/Node 1 (6)");
            tabNodes[6][2] = GameObject.Find("Nodes/Node 2 (6)");
            tabNodes[6][3] = GameObject.Find("Nodes/Node 3 (6)");
            tabNodes[6][4] = GameObject.Find("Nodes/Node 4 (6)");
            tabNodes[6][5] = GameObject.Find("Nodes/Node 5 (6)");
            tabNodes[6][6] = GameObject.Find("Nodes/Node 6 (6)");
            tabNodes[6][7] = GameObject.Find("Nodes/Node 7 (6)");
            tabNodes[6][8] = GameObject.Find("Nodes/Node 8 (6)");
            tabNodes[6][9] = GameObject.Find("Nodes/Node 9 (6)");
            tabNodes[6][10] = GameObject.Find("Nodes/Node 10 (6)");
            tabNodes[6][11] = GameObject.Find("Nodes/Node 11 (6)");
            tabNodes[6][12] = GameObject.Find("Nodes/Node 12 (6)");
            tabNodes[6][13] = GameObject.Find("Nodes/Node 13 (6)");
            tabNodes[6][14] = GameObject.Find("Nodes/Node 14 (6)");
            tabNodes[6][15] = GameObject.Find("Nodes/Node 15 (6)");
            tabNodes[6][16] = GameObject.Find("Nodes/Node 16 (6)");
            tabNodes[6][17] = GameObject.Find("Nodes/Node 17 (6)");
            tabNodes[6][18] = GameObject.Find("Nodes/Node 18 (6)");
            tabNodes[6][19] = GameObject.Find("Nodes/Node 19 (6)");
            tabNodes[6][20] = GameObject.Find("Nodes/Node 20 (6)");
            tabNodes[6][21] = GameObject.Find("Nodes/Node 21 (6)");
            tabNodes[6][22] = GameObject.Find("Nodes/Node 22 (6)");
            tabNodes[6][23] = GameObject.Find("Nodes/Node 23 (6)");
            tabNodes[6][24] = GameObject.Find("Nodes/Node 24 (6)");
            tabNodes[6][25] = GameObject.Find("Nodes/Node 25 (6)");
            tabNodes[6][26] = GameObject.Find("Nodes/Node 26 (6)");
            tabNodes[6][27] = GameObject.Find("Nodes/Node 27 (6)");
            tabNodes[6][28] = GameObject.Find("Nodes/Node 28 (6)");
            tabNodes[6][29] = GameObject.Find("Nodes/Node 29 (6)");
            tabNodes[6][30] = GameObject.Find("Nodes/Node 30 (6)");
            tabNodes[6][31] = GameObject.Find("Nodes/Node 31 (6)");
            tabNodes[6][32] = GameObject.Find("Nodes/Node 32 (6)");
            tabNodes[6][33] = GameObject.Find("Nodes/Node 33 (6)");
            tabNodes[6][34] = GameObject.Find("Nodes/Node 34 (6)");

            tabNodes[7][0] = GameObject.Find("Nodes/Node 0 (7)");
            tabNodes[7][1] = GameObject.Find("Nodes/Node 1 (7)");
            tabNodes[7][2] = GameObject.Find("Nodes/Node 2 (7)");
            tabNodes[7][3] = GameObject.Find("Nodes/Node 3 (7)");
            tabNodes[7][4] = GameObject.Find("Nodes/Node 4 (7)");
            tabNodes[7][5] = GameObject.Find("Nodes/Node 5 (7)");
            tabNodes[7][6] = GameObject.Find("Nodes/Node 6 (7)");
            tabNodes[7][7] = GameObject.Find("Nodes/Node 7 (7)");
            tabNodes[7][8] = GameObject.Find("Nodes/Node 8 (7)");
            tabNodes[7][9] = GameObject.Find("Nodes/Node 9 (7)");
            tabNodes[7][10] = GameObject.Find("Nodes/Node 10 (7)");
            tabNodes[7][11] = GameObject.Find("Nodes/Node 11 (7)");
            tabNodes[7][12] = GameObject.Find("Nodes/Node 12 (7)");
            tabNodes[7][13] = GameObject.Find("Nodes/Node 13 (7)");
            tabNodes[7][14] = GameObject.Find("Nodes/Node 14 (7)");
            tabNodes[7][15] = GameObject.Find("Nodes/Node 15 (7)");
            tabNodes[7][16] = GameObject.Find("Nodes/Node 16 (7)");
            tabNodes[7][17] = GameObject.Find("Nodes/Node 17 (7)");
            tabNodes[7][18] = GameObject.Find("Nodes/Node 18 (7)");
            tabNodes[7][19] = GameObject.Find("Nodes/Node 19 (7)");
            tabNodes[7][20] = GameObject.Find("Nodes/Node 20 (7)");
            tabNodes[7][21] = GameObject.Find("Nodes/Node 21 (7)");
            tabNodes[7][22] = GameObject.Find("Nodes/Node 22 (7)");
            tabNodes[7][23] = GameObject.Find("Nodes/Node 23 (7)");
            tabNodes[7][24] = GameObject.Find("Nodes/Node 24 (7)");
            tabNodes[7][25] = GameObject.Find("Nodes/Node 25 (7)");
            tabNodes[7][26] = GameObject.Find("Nodes/Node 26 (7)");
            tabNodes[7][27] = GameObject.Find("Nodes/Node 27 (7)");
            tabNodes[7][28] = GameObject.Find("Nodes/Node 28 (7)");
            tabNodes[7][29] = GameObject.Find("Nodes/Node 29 (7)");
            tabNodes[7][30] = GameObject.Find("Nodes/Node 30 (7)");
            tabNodes[7][31] = GameObject.Find("Nodes/Node 31 (7)");
            tabNodes[7][32] = GameObject.Find("Nodes/Node 32 (7)");
            tabNodes[7][33] = GameObject.Find("Nodes/Node 33 (7)");
            tabNodes[7][34] = GameObject.Find("Nodes/Node 34 (7)");

            tabNodes[8][0] = GameObject.Find("Nodes/Node 0 (8)");
            tabNodes[8][1] = GameObject.Find("Nodes/Node 1 (8)");
            tabNodes[8][2] = GameObject.Find("Nodes/Node 2 (8)");
            tabNodes[8][3] = GameObject.Find("Nodes/Node 3 (8)");
            tabNodes[8][4] = GameObject.Find("Nodes/Node 4 (8)");
            tabNodes[8][5] = GameObject.Find("Nodes/Node 5 (8)");
            tabNodes[8][6] = GameObject.Find("Nodes/Node 6 (8)");
            tabNodes[8][7] = GameObject.Find("Nodes/Node 7 (8)");
            tabNodes[8][8] = GameObject.Find("Nodes/Node 8 (8)");
            tabNodes[8][9] = GameObject.Find("Nodes/Node 9 (8)");
            tabNodes[8][10] = GameObject.Find("Nodes/Node 10 (8)");
            tabNodes[8][11] = GameObject.Find("Nodes/Node 11 (8)");
            tabNodes[8][12] = GameObject.Find("Nodes/Node 12 (8)");
            tabNodes[8][13] = GameObject.Find("Nodes/Node 13 (8)");
            tabNodes[8][14] = GameObject.Find("Nodes/Node 14 (8)");
            tabNodes[8][15] = GameObject.Find("Nodes/Node 15 (8)");
            tabNodes[8][16] = GameObject.Find("Nodes/Node 16 (8)");
            tabNodes[8][17] = GameObject.Find("Nodes/Node 17 (8)");
            tabNodes[8][18] = GameObject.Find("Nodes/Node 18 (8)");
            tabNodes[8][19] = GameObject.Find("Nodes/Node 19 (8)");
            tabNodes[8][20] = GameObject.Find("Nodes/Node 20 (8)");
            tabNodes[8][21] = GameObject.Find("Nodes/Node 21 (8)");
            tabNodes[8][22] = GameObject.Find("Nodes/Node 22 (8)");
            tabNodes[8][23] = GameObject.Find("Nodes/Node 23 (8)");
            tabNodes[8][24] = GameObject.Find("Nodes/Node 24 (8)");
            tabNodes[8][25] = GameObject.Find("Nodes/Node 25 (8)");
            tabNodes[8][26] = GameObject.Find("Nodes/Node 26 (8)");
            tabNodes[8][27] = GameObject.Find("Nodes/Node 27 (8)");
            tabNodes[8][28] = GameObject.Find("Nodes/Node 28 (8)");
            tabNodes[8][29] = GameObject.Find("Nodes/Node 29 (8)");
            tabNodes[8][30] = GameObject.Find("Nodes/Node 30 (8)");
            tabNodes[8][31] = GameObject.Find("Nodes/Node 31 (8)");
            tabNodes[8][32] = GameObject.Find("Nodes/Node 32 (8)");
            tabNodes[8][33] = GameObject.Find("Nodes/Node 33 (8)");
            tabNodes[8][34] = GameObject.Find("Nodes/Node 34 (8)");

            tabNodes[9][0] = GameObject.Find("Nodes/Node 0 (9)");
            tabNodes[9][1] = GameObject.Find("Nodes/Node 1 (9)");
            tabNodes[9][2] = GameObject.Find("Nodes/Node 2 (9)");
            tabNodes[9][3] = GameObject.Find("Nodes/Node 3 (9)");
            tabNodes[9][4] = GameObject.Find("Nodes/Node 4 (9)");
            tabNodes[9][5] = GameObject.Find("Nodes/Node 5 (9)");
            tabNodes[9][6] = GameObject.Find("Nodes/Node 6 (9)");
            tabNodes[9][7] = GameObject.Find("Nodes/Node 7 (9)");
            tabNodes[9][8] = GameObject.Find("Nodes/Node 8 (9)");
            tabNodes[9][9] = GameObject.Find("Nodes/Node 9 (9)");
            tabNodes[9][10] = GameObject.Find("Nodes/Node 10 (9)");
            tabNodes[9][11] = GameObject.Find("Nodes/Node 11 (9)");
            tabNodes[9][12] = GameObject.Find("Nodes/Node 12 (9)");
            tabNodes[9][13] = GameObject.Find("Nodes/Node 13 (9)");
            tabNodes[9][14] = GameObject.Find("Nodes/Node 14 (9)");
            tabNodes[9][15] = GameObject.Find("Nodes/Node 15 (9)");
            tabNodes[9][16] = GameObject.Find("Nodes/Node 16 (9)");
            tabNodes[9][17] = GameObject.Find("Nodes/Node 17 (9)");
            tabNodes[9][18] = GameObject.Find("Nodes/Node 18 (9)");
            tabNodes[9][19] = GameObject.Find("Nodes/Node 19 (9)");
            tabNodes[9][20] = GameObject.Find("Nodes/Node 20 (9)");
            tabNodes[9][21] = GameObject.Find("Nodes/Node 21 (9)");
            tabNodes[9][22] = GameObject.Find("Nodes/Node 22 (9)");
            tabNodes[9][23] = GameObject.Find("Nodes/Node 23 (9)");
            tabNodes[9][24] = GameObject.Find("Nodes/Node 24 (9)");
            tabNodes[9][25] = GameObject.Find("Nodes/Node 25 (9)");
            tabNodes[9][26] = GameObject.Find("Nodes/Node 26 (9)");
            tabNodes[9][27] = GameObject.Find("Nodes/Node 27 (9)");
            tabNodes[9][28] = GameObject.Find("Nodes/Node 28 (9)");
            tabNodes[9][29] = GameObject.Find("Nodes/Node 29 (9)");
            tabNodes[9][30] = GameObject.Find("Nodes/Node 30 (9)");
            tabNodes[9][31] = GameObject.Find("Nodes/Node 31 (9)");
            tabNodes[9][32] = GameObject.Find("Nodes/Node 32 (9)");
            tabNodes[9][33] = GameObject.Find("Nodes/Node 33 (9)");
            tabNodes[9][34] = GameObject.Find("Nodes/Node 34 (9)");

            tabNodes[10][0] = GameObject.Find("Nodes/Node 0 (10)");
            tabNodes[10][1] = GameObject.Find("Nodes/Node 1 (10)");
            tabNodes[10][2] = GameObject.Find("Nodes/Node 2 (10)");
            tabNodes[10][3] = GameObject.Find("Nodes/Node 3 (10)");
            tabNodes[10][4] = GameObject.Find("Nodes/Node 4 (10)");
            tabNodes[10][5] = GameObject.Find("Nodes/Node 5 (10)");
            tabNodes[10][6] = GameObject.Find("Nodes/Node 6 (10)");
            tabNodes[10][7] = GameObject.Find("Nodes/Node 7 (10)");
            tabNodes[10][8] = GameObject.Find("Nodes/Node 8 (10)");
            tabNodes[10][9] = GameObject.Find("Nodes/Node 9 (10)");
            tabNodes[10][10] = GameObject.Find("Nodes/Node 10 (10)");
            tabNodes[10][11] = GameObject.Find("Nodes/Node 11 (10)");
            tabNodes[10][12] = GameObject.Find("Nodes/Node 12 (10)");
            tabNodes[10][13] = GameObject.Find("Nodes/Node 13 (10)");
            tabNodes[10][14] = GameObject.Find("Nodes/Node 14 (10)");
            tabNodes[10][15] = GameObject.Find("Nodes/Node 15 (10)");
            tabNodes[10][16] = GameObject.Find("Nodes/Node 16 (10)");
            tabNodes[10][17] = GameObject.Find("Nodes/Node 17 (10)");
            tabNodes[10][18] = GameObject.Find("Nodes/Node 18 (10)");
            tabNodes[10][19] = GameObject.Find("Nodes/Node 19 (10)");
            tabNodes[10][20] = GameObject.Find("Nodes/Node 20 (10)");
            tabNodes[10][21] = GameObject.Find("Nodes/Node 21 (10)");
            tabNodes[10][22] = GameObject.Find("Nodes/Node 22 (10)");
            tabNodes[10][23] = GameObject.Find("Nodes/Node 23 (10)");
            tabNodes[10][24] = GameObject.Find("Nodes/Node 24 (10)");
            tabNodes[10][25] = GameObject.Find("Nodes/Node 25 (10)");
            tabNodes[10][26] = GameObject.Find("Nodes/Node 26 (10)");
            tabNodes[10][27] = GameObject.Find("Nodes/Node 27 (10)");
            tabNodes[10][28] = GameObject.Find("Nodes/Node 28 (10)");
            tabNodes[10][29] = GameObject.Find("Nodes/Node 29 (10)");
            tabNodes[10][30] = GameObject.Find("Nodes/Node 30 (10)");
            tabNodes[10][31] = GameObject.Find("Nodes/Node 31 (10)");
            tabNodes[10][32] = GameObject.Find("Nodes/Node 32 (10)");
            tabNodes[10][33] = GameObject.Find("Nodes/Node 33 (10)");
            tabNodes[10][34] = GameObject.Find("Nodes/Node 34 (10)");

            tabNodes[11][0] = GameObject.Find("Nodes/Node 0 (11)");
            tabNodes[11][1] = GameObject.Find("Nodes/Node 1 (11)");
            tabNodes[11][2] = GameObject.Find("Nodes/Node 2 (11)");
            tabNodes[11][3] = GameObject.Find("Nodes/Node 3 (11)");
            tabNodes[11][4] = GameObject.Find("Nodes/Node 4 (11)");
            tabNodes[11][5] = GameObject.Find("Nodes/Node 5 (11)");
            tabNodes[11][6] = GameObject.Find("Nodes/Node 6 (11)");
            tabNodes[11][7] = GameObject.Find("Nodes/Node 7 (11)");
            tabNodes[11][8] = GameObject.Find("Nodes/Node 8 (11)");
            tabNodes[11][9] = GameObject.Find("Nodes/Node 9 (11)");
            tabNodes[11][10] = GameObject.Find("Nodes/Node 10 (11)");
            tabNodes[11][11] = GameObject.Find("Nodes/Node 11 (11)");
            tabNodes[11][12] = GameObject.Find("Nodes/Node 12 (11)");
            tabNodes[11][13] = GameObject.Find("Nodes/Node 13 (11)");
            tabNodes[11][14] = GameObject.Find("Nodes/Node 14 (11)");
            tabNodes[11][15] = GameObject.Find("Nodes/Node 15 (11)");
            tabNodes[11][16] = GameObject.Find("Nodes/Node 16 (11)");
            tabNodes[11][17] = GameObject.Find("Nodes/Node 17 (11)");
            tabNodes[11][18] = GameObject.Find("Nodes/Node 18 (11)");
            tabNodes[11][19] = GameObject.Find("Nodes/Node 19 (11)");
            tabNodes[11][20] = GameObject.Find("Nodes/Node 20 (11)");
            tabNodes[11][21] = GameObject.Find("Nodes/Node 21 (11)");
            tabNodes[11][22] = GameObject.Find("Nodes/Node 22 (11)");
            tabNodes[11][23] = GameObject.Find("Nodes/Node 23 (11)");
            tabNodes[11][24] = GameObject.Find("Nodes/Node 24 (11)");
            tabNodes[11][25] = GameObject.Find("Nodes/Node 25 (11)");
            tabNodes[11][26] = GameObject.Find("Nodes/Node 26 (11)");
            tabNodes[11][27] = GameObject.Find("Nodes/Node 27 (11)");
            tabNodes[11][28] = GameObject.Find("Nodes/Node 28 (11)");
            tabNodes[11][29] = GameObject.Find("Nodes/Node 29 (11)");
            tabNodes[11][30] = GameObject.Find("Nodes/Node 30 (11)");
            tabNodes[11][31] = GameObject.Find("Nodes/Node 31 (11)");
            tabNodes[11][32] = GameObject.Find("Nodes/Node 32 (11)");
            tabNodes[11][33] = GameObject.Find("Nodes/Node 33 (11)");
            tabNodes[11][34] = GameObject.Find("Nodes/Node 34 (11)");

            tabNodes[12][0] = GameObject.Find("Nodes/Node 0 (12)");
            tabNodes[12][1] = GameObject.Find("Nodes/Node 1 (12)");
            tabNodes[12][2] = GameObject.Find("Nodes/Node 2 (12)");
            tabNodes[12][3] = GameObject.Find("Nodes/Node 3 (12)");
            tabNodes[12][4] = GameObject.Find("Nodes/Node 4 (12)");
            tabNodes[12][5] = GameObject.Find("Nodes/Node 5 (12)");
            tabNodes[12][6] = GameObject.Find("Nodes/Node 6 (12)");
            tabNodes[12][7] = GameObject.Find("Nodes/Node 7 (12)");
            tabNodes[12][8] = GameObject.Find("Nodes/Node 8 (12)");
            tabNodes[12][9] = GameObject.Find("Nodes/Node 9 (12)");
            tabNodes[12][10] = GameObject.Find("Nodes/Node 10 (12)");
            tabNodes[12][11] = GameObject.Find("Nodes/Node 11 (12)");
            tabNodes[12][12] = GameObject.Find("Nodes/Node 12 (12)");
            tabNodes[12][13] = GameObject.Find("Nodes/Node 13 (12)");
            tabNodes[12][14] = GameObject.Find("Nodes/Node 14 (12)");
            tabNodes[12][15] = GameObject.Find("Nodes/Node 15 (12)");
            tabNodes[12][16] = GameObject.Find("Nodes/Node 16 (12)");
            tabNodes[12][17] = GameObject.Find("Nodes/Node 17 (12)");
            tabNodes[12][18] = GameObject.Find("Nodes/Node 18 (12)");
            tabNodes[12][19] = GameObject.Find("Nodes/Node 19 (12)");
            tabNodes[12][20] = GameObject.Find("Nodes/Node 20 (12)");
            tabNodes[12][21] = GameObject.Find("Nodes/Node 21 (12)");
            tabNodes[12][22] = GameObject.Find("Nodes/Node 22 (12)");
            tabNodes[12][23] = GameObject.Find("Nodes/Node 23 (12)");
            tabNodes[12][24] = GameObject.Find("Nodes/Node 24 (12)");
            tabNodes[12][25] = GameObject.Find("Nodes/Node 25 (12)");
            tabNodes[12][26] = GameObject.Find("Nodes/Node 26 (12)");
            tabNodes[12][27] = GameObject.Find("Nodes/Node 27 (12)");
            tabNodes[12][28] = GameObject.Find("Nodes/Node 28 (12)");
            tabNodes[12][29] = GameObject.Find("Nodes/Node 29 (12)");
            tabNodes[12][30] = GameObject.Find("Nodes/Node 30 (12)");
            tabNodes[12][31] = GameObject.Find("Nodes/Node 31 (12)");
            tabNodes[12][32] = GameObject.Find("Nodes/Node 32 (12)");
            tabNodes[12][33] = GameObject.Find("Nodes/Node 33 (12)");
            tabNodes[12][34] = GameObject.Find("Nodes/Node 34 (12)");

            tabNodes[13][0] = GameObject.Find("Nodes/Node 0 (13)");
            tabNodes[13][1] = GameObject.Find("Nodes/Node 1 (13)");
            tabNodes[13][2] = GameObject.Find("Nodes/Node 2 (13)");
            tabNodes[13][3] = GameObject.Find("Nodes/Node 3 (13)");
            tabNodes[13][4] = GameObject.Find("Nodes/Node 4 (13)");
            tabNodes[13][5] = GameObject.Find("Nodes/Node 5 (13)");
            tabNodes[13][6] = GameObject.Find("Nodes/Node 6 (13)");
            tabNodes[13][7] = GameObject.Find("Nodes/Node 7 (13)");
            tabNodes[13][8] = GameObject.Find("Nodes/Node 8 (13)");
            tabNodes[13][9] = GameObject.Find("Nodes/Node 9 (13)");
            tabNodes[13][10] = GameObject.Find("Nodes/Node 10 (13)");
            tabNodes[13][11] = GameObject.Find("Nodes/Node 11 (13)");
            tabNodes[13][12] = GameObject.Find("Nodes/Node 12 (13)");
            tabNodes[13][13] = GameObject.Find("Nodes/Node 13 (13)");
            tabNodes[13][14] = GameObject.Find("Nodes/Node 14 (13)");
            tabNodes[13][15] = GameObject.Find("Nodes/Node 15 (13)");
            tabNodes[13][16] = GameObject.Find("Nodes/Node 16 (13)");
            tabNodes[13][17] = GameObject.Find("Nodes/Node 17 (13)");
            tabNodes[13][18] = GameObject.Find("Nodes/Node 18 (13)");
            tabNodes[13][19] = GameObject.Find("Nodes/Node 19 (13)");
            tabNodes[13][20] = GameObject.Find("Nodes/Node 20 (13)");
            tabNodes[13][21] = GameObject.Find("Nodes/Node 21 (13)");
            tabNodes[13][22] = GameObject.Find("Nodes/Node 22 (13)");
            tabNodes[13][23] = GameObject.Find("Nodes/Node 23 (13)");
            tabNodes[13][24] = GameObject.Find("Nodes/Node 24 (13)");
            tabNodes[13][25] = GameObject.Find("Nodes/Node 25 (13)");
            tabNodes[13][26] = GameObject.Find("Nodes/Node 26 (13)");
            tabNodes[13][27] = GameObject.Find("Nodes/Node 27 (13)");
            tabNodes[13][28] = GameObject.Find("Nodes/Node 28 (13)");
            tabNodes[13][29] = GameObject.Find("Nodes/Node 29 (13)");
            tabNodes[13][30] = GameObject.Find("Nodes/Node 30 (13)");
            tabNodes[13][31] = GameObject.Find("Nodes/Node 31 (13)");
            tabNodes[13][32] = GameObject.Find("Nodes/Node 32 (13)");
            tabNodes[13][33] = GameObject.Find("Nodes/Node 33 (13)");
            tabNodes[13][34] = GameObject.Find("Nodes/Node 34 (13)");

            tabNodes[14][0] = GameObject.Find("Nodes/Node 0 (14)");
            tabNodes[14][1] = GameObject.Find("Nodes/Node 1 (14)");
            tabNodes[14][2] = GameObject.Find("Nodes/Node 2 (14)");
            tabNodes[14][3] = GameObject.Find("Nodes/Node 3 (14)");
            tabNodes[14][4] = GameObject.Find("Nodes/Node 4 (14)");
            tabNodes[14][5] = GameObject.Find("Nodes/Node 5 (14)");
            tabNodes[14][6] = GameObject.Find("Nodes/Node 6 (14)");
            tabNodes[14][7] = GameObject.Find("Nodes/Node 7 (14)");
            tabNodes[14][8] = GameObject.Find("Nodes/Node 8 (14)");
            tabNodes[14][9] = GameObject.Find("Nodes/Node 9 (14)");
            tabNodes[14][10] = GameObject.Find("Nodes/Node 10 (14)");
            tabNodes[14][11] = GameObject.Find("Nodes/Node 11 (14)");
            tabNodes[14][12] = GameObject.Find("Nodes/Node 12 (14)");
            tabNodes[14][13] = GameObject.Find("Nodes/Node 13 (14)");
            tabNodes[14][14] = GameObject.Find("Nodes/Node 14 (14)");
            tabNodes[14][15] = GameObject.Find("Nodes/Node 15 (14)");
            tabNodes[14][16] = GameObject.Find("Nodes/Node 16 (14)");
            tabNodes[14][17] = GameObject.Find("Nodes/Node 17 (14)");
            tabNodes[14][18] = GameObject.Find("Nodes/Node 18 (14)");
            tabNodes[14][19] = GameObject.Find("Nodes/Node 19 (14)");
            tabNodes[14][20] = GameObject.Find("Nodes/Node 20 (14)");
            tabNodes[14][21] = GameObject.Find("Nodes/Node 21 (14)");
            tabNodes[14][22] = GameObject.Find("Nodes/Node 22 (14)");
            tabNodes[14][23] = GameObject.Find("Nodes/Node 23 (14)");
            tabNodes[14][24] = GameObject.Find("Nodes/Node 24 (14)");
            tabNodes[14][25] = GameObject.Find("Nodes/Node 25 (14)");
            tabNodes[14][26] = GameObject.Find("Nodes/Node 26 (14)");
            tabNodes[14][27] = GameObject.Find("Nodes/Node 27 (14)");
            tabNodes[14][28] = GameObject.Find("Nodes/Node 28 (14)");
            tabNodes[14][29] = GameObject.Find("Nodes/Node 29 (14)");
            tabNodes[14][30] = GameObject.Find("Nodes/Node 30 (14)");
            tabNodes[14][31] = GameObject.Find("Nodes/Node 31 (14)");
            tabNodes[14][32] = GameObject.Find("Nodes/Node 32 (14)");
            tabNodes[14][33] = GameObject.Find("Nodes/Node 33 (14)");
            tabNodes[14][34] = GameObject.Find("Nodes/Node 34 (14)");

            tabNodes[15][0] = GameObject.Find("Nodes/Node 0 (15)");
            tabNodes[15][1] = GameObject.Find("Nodes/Node 1 (15)");
            tabNodes[15][2] = GameObject.Find("Nodes/Node 2 (15)");
            tabNodes[15][3] = GameObject.Find("Nodes/Node 3 (15)");
            tabNodes[15][4] = GameObject.Find("Nodes/Node 4 (15)");
            tabNodes[15][5] = GameObject.Find("Nodes/Node 5 (15)");
            tabNodes[15][6] = GameObject.Find("Nodes/Node 6 (15)");
            tabNodes[15][7] = GameObject.Find("Nodes/Node 7 (15)");
            tabNodes[15][8] = GameObject.Find("Nodes/Node 8 (15)");
            tabNodes[15][9] = GameObject.Find("Nodes/Node 9 (15)");
            tabNodes[15][10] = GameObject.Find("Nodes/Node 10 (15)");
            tabNodes[15][11] = GameObject.Find("Nodes/Node 11 (15)");
            tabNodes[15][12] = GameObject.Find("Nodes/Node 12 (15)");
            tabNodes[15][13] = GameObject.Find("Nodes/Node 13 (15)");
            tabNodes[15][14] = GameObject.Find("Nodes/Node 14 (15)");
            tabNodes[15][15] = GameObject.Find("Nodes/Node 15 (15)");
            tabNodes[15][16] = GameObject.Find("Nodes/Node 16 (15)");
            tabNodes[15][17] = GameObject.Find("Nodes/Node 17 (15)");
            tabNodes[15][18] = GameObject.Find("Nodes/Node 18 (15)");
            tabNodes[15][19] = GameObject.Find("Nodes/Node 19 (15)");
            tabNodes[15][20] = GameObject.Find("Nodes/Node 20 (15)");
            tabNodes[15][21] = GameObject.Find("Nodes/Node 21 (15)");
            tabNodes[15][22] = GameObject.Find("Nodes/Node 22 (15)");
            tabNodes[15][23] = GameObject.Find("Nodes/Node 23 (15)");
            tabNodes[15][24] = GameObject.Find("Nodes/Node 24 (15)");
            tabNodes[15][25] = GameObject.Find("Nodes/Node 25 (15)");
            tabNodes[15][26] = GameObject.Find("Nodes/Node 26 (15)");
            tabNodes[15][27] = GameObject.Find("Nodes/Node 27 (15)");
            tabNodes[15][28] = GameObject.Find("Nodes/Node 28 (15)");
            tabNodes[15][29] = GameObject.Find("Nodes/Node 29 (15)");
            tabNodes[15][30] = GameObject.Find("Nodes/Node 30 (15)");
            tabNodes[15][31] = GameObject.Find("Nodes/Node 31 (15)");
            tabNodes[15][32] = GameObject.Find("Nodes/Node 32 (15)");
            tabNodes[15][33] = GameObject.Find("Nodes/Node 33 (15)");
            tabNodes[15][34] = GameObject.Find("Nodes/Node 34 (15)");

            tabNodes[16][0] = GameObject.Find("Nodes/Node 0 (16)");
            tabNodes[16][1] = GameObject.Find("Nodes/Node 1 (16)");
            tabNodes[16][2] = GameObject.Find("Nodes/Node 2 (16)");
            tabNodes[16][3] = GameObject.Find("Nodes/Node 3 (16)");
            tabNodes[16][4] = GameObject.Find("Nodes/Node 4 (16)");
            tabNodes[16][5] = GameObject.Find("Nodes/Node 5 (16)");
            tabNodes[16][6] = GameObject.Find("Nodes/Node 6 (16)");
            tabNodes[16][7] = GameObject.Find("Nodes/Node 7 (16)");
            tabNodes[16][8] = GameObject.Find("Nodes/Node 8 (16)");
            tabNodes[16][9] = GameObject.Find("Nodes/Node 9 (16)");
            tabNodes[16][10] = GameObject.Find("Nodes/Node 10 (16)");
            tabNodes[16][11] = GameObject.Find("Nodes/Node 11 (16)");
            tabNodes[16][12] = GameObject.Find("Nodes/Node 12 (16)");
            tabNodes[16][13] = GameObject.Find("Nodes/Node 13 (16)");
            tabNodes[16][14] = GameObject.Find("Nodes/Node 14 (16)");
            tabNodes[16][15] = GameObject.Find("Nodes/Node 15 (16)");
            tabNodes[16][16] = GameObject.Find("Nodes/Node 16 (16)");
            tabNodes[16][17] = GameObject.Find("Nodes/Node 17 (16)");
            tabNodes[16][18] = GameObject.Find("Nodes/Node 18 (16)");
            tabNodes[16][19] = GameObject.Find("Nodes/Node 19 (16)");
            tabNodes[16][20] = GameObject.Find("Nodes/Node 20 (16)");
            tabNodes[16][21] = GameObject.Find("Nodes/Node 21 (16)");
            tabNodes[16][22] = GameObject.Find("Nodes/Node 22 (16)");
            tabNodes[16][23] = GameObject.Find("Nodes/Node 23 (16)");
            tabNodes[16][24] = GameObject.Find("Nodes/Node 24 (16)");
            tabNodes[16][25] = GameObject.Find("Nodes/Node 25 (16)");
            tabNodes[16][26] = GameObject.Find("Nodes/Node 26 (16)");
            tabNodes[16][27] = GameObject.Find("Nodes/Node 27 (16)");
            tabNodes[16][28] = GameObject.Find("Nodes/Node 28 (16)");
            tabNodes[16][29] = GameObject.Find("Nodes/Node 29 (16)");
            tabNodes[16][30] = GameObject.Find("Nodes/Node 30 (16)");
            tabNodes[16][31] = GameObject.Find("Nodes/Node 31 (16)");
            tabNodes[16][32] = GameObject.Find("Nodes/Node 32 (16)");
            tabNodes[16][33] = GameObject.Find("Nodes/Node 33 (16)");
            tabNodes[16][34] = GameObject.Find("Nodes/Node 34 (16)");

            tabNodes[17][0] = GameObject.Find("Nodes/Node 0 (17)");
            tabNodes[17][1] = GameObject.Find("Nodes/Node 1 (17)");
            tabNodes[17][2] = GameObject.Find("Nodes/Node 2 (17)");
            tabNodes[17][3] = GameObject.Find("Nodes/Node 3 (17)");
            tabNodes[17][4] = GameObject.Find("Nodes/Node 4 (17)");
            tabNodes[17][5] = GameObject.Find("Nodes/Node 5 (17)");
            tabNodes[17][6] = GameObject.Find("Nodes/Node 6 (17)");
            tabNodes[17][7] = GameObject.Find("Nodes/Node 7 (17)");
            tabNodes[17][8] = GameObject.Find("Nodes/Node 8 (17)");
            tabNodes[17][9] = GameObject.Find("Nodes/Node 9 (17)");
            tabNodes[17][10] = GameObject.Find("Nodes/Node 10 (17)");
            tabNodes[17][11] = GameObject.Find("Nodes/Node 11 (17)");
            tabNodes[17][12] = GameObject.Find("Nodes/Node 12 (17)");
            tabNodes[17][13] = GameObject.Find("Nodes/Node 13 (17)");
            tabNodes[17][14] = GameObject.Find("Nodes/Node 14 (17)");
            tabNodes[17][15] = GameObject.Find("Nodes/Node 15 (17)");
            tabNodes[17][16] = GameObject.Find("Nodes/Node 16 (17)");
            tabNodes[17][17] = GameObject.Find("Nodes/Node 17 (17)");
            tabNodes[17][18] = GameObject.Find("Nodes/Node 18 (17)");
            tabNodes[17][19] = GameObject.Find("Nodes/Node 19 (17)");
            tabNodes[17][20] = GameObject.Find("Nodes/Node 20 (17)");
            tabNodes[17][21] = GameObject.Find("Nodes/Node 21 (17)");
            tabNodes[17][22] = GameObject.Find("Nodes/Node 22 (17)");
            tabNodes[17][23] = GameObject.Find("Nodes/Node 23 (17)");
            tabNodes[17][24] = GameObject.Find("Nodes/Node 24 (17)");
            tabNodes[17][25] = GameObject.Find("Nodes/Node 25 (17)");
            tabNodes[17][26] = GameObject.Find("Nodes/Node 26 (17)");
            tabNodes[17][27] = GameObject.Find("Nodes/Node 27 (17)");
            tabNodes[17][28] = GameObject.Find("Nodes/Node 28 (17)");
            tabNodes[17][29] = GameObject.Find("Nodes/Node 29 (17)");
            tabNodes[17][30] = GameObject.Find("Nodes/Node 30 (17)");
            tabNodes[17][31] = GameObject.Find("Nodes/Node 31 (17)");
            tabNodes[17][32] = GameObject.Find("Nodes/Node 32 (17)");
            tabNodes[17][33] = GameObject.Find("Nodes/Node 33 (17)");
            tabNodes[17][34] = GameObject.Find("Nodes/Node 34 (17)");

            tabNodes[18][0] = GameObject.Find("Nodes/Node 0 (18)");
            tabNodes[18][1] = GameObject.Find("Nodes/Node 1 (18)");
            tabNodes[18][2] = GameObject.Find("Nodes/Node 2 (18)");
            tabNodes[18][3] = GameObject.Find("Nodes/Node 3 (18)");
            tabNodes[18][4] = GameObject.Find("Nodes/Node 4 (18)");
            tabNodes[18][5] = GameObject.Find("Nodes/Node 5 (18)");
            tabNodes[18][6] = GameObject.Find("Nodes/Node 6 (18)");
            tabNodes[18][7] = GameObject.Find("Nodes/Node 7 (18)");
            tabNodes[18][8] = GameObject.Find("Nodes/Node 8 (18)");
            tabNodes[18][9] = GameObject.Find("Nodes/Node 9 (18)");
            tabNodes[18][10] = GameObject.Find("Nodes/Node 10 (18)");
            tabNodes[18][11] = GameObject.Find("Nodes/Node 11 (18)");
            tabNodes[18][12] = GameObject.Find("Nodes/Node 12 (18)");
            tabNodes[18][13] = GameObject.Find("Nodes/Node 13 (18)");
            tabNodes[18][14] = GameObject.Find("Nodes/Node 14 (18)");
            tabNodes[18][15] = GameObject.Find("Nodes/Node 15 (18)");
            tabNodes[18][16] = GameObject.Find("Nodes/Node 16 (18)");
            tabNodes[18][17] = GameObject.Find("Nodes/Node 17 (18)");
            tabNodes[18][18] = GameObject.Find("Nodes/Node 18 (18)");
            tabNodes[18][19] = GameObject.Find("Nodes/Node 19 (18)");
            tabNodes[18][20] = GameObject.Find("Nodes/Node 20 (18)");
            tabNodes[18][21] = GameObject.Find("Nodes/Node 21 (18)");
            tabNodes[18][22] = GameObject.Find("Nodes/Node 22 (18)");
            tabNodes[18][23] = GameObject.Find("Nodes/Node 23 (18)");
            tabNodes[18][24] = GameObject.Find("Nodes/Node 24 (18)");
            tabNodes[18][25] = GameObject.Find("Nodes/Node 25 (18)");
            tabNodes[18][26] = GameObject.Find("Nodes/Node 26 (18)");
            tabNodes[18][27] = GameObject.Find("Nodes/Node 27 (18)");
            tabNodes[18][28] = GameObject.Find("Nodes/Node 28 (18)");
            tabNodes[18][29] = GameObject.Find("Nodes/Node 29 (18)");
            tabNodes[18][30] = GameObject.Find("Nodes/Node 30 (18)");
            tabNodes[18][31] = GameObject.Find("Nodes/Node 31 (18)");
            tabNodes[18][32] = GameObject.Find("Nodes/Node 32 (18)");
            tabNodes[18][33] = GameObject.Find("Nodes/Node 33 (18)");
            tabNodes[18][34] = GameObject.Find("Nodes/Node 34 (18)");
        }


        if (mapID == 3 ||
            mapID == 4 ||
            mapID == 5)
        {
            tabNodes = new GameObject[21][];
            tabNodes[0] = new GameObject[22];
            tabNodes[1] = new GameObject[22];
            tabNodes[2] = new GameObject[22];
            tabNodes[3] = new GameObject[22];
            tabNodes[4] = new GameObject[22];
            tabNodes[5] = new GameObject[22];
            tabNodes[6] = new GameObject[22];
            tabNodes[7] = new GameObject[22];
            tabNodes[8] = new GameObject[22];
            tabNodes[9] = new GameObject[22];
            tabNodes[10] = new GameObject[22];
            tabNodes[11] = new GameObject[22];
            tabNodes[12] = new GameObject[22];
            tabNodes[13] = new GameObject[22];
            tabNodes[14] = new GameObject[22];
            tabNodes[15] = new GameObject[22];
            tabNodes[16] = new GameObject[22];
            tabNodes[17] = new GameObject[22];
            tabNodes[18] = new GameObject[22];
            tabNodes[19] = new GameObject[22];
            tabNodes[20] = new GameObject[22];

            tabNodes[0][0] = GameObject.Find("Nodes/Node 0 (0)");
            tabNodes[0][1] = GameObject.Find("Nodes/Node 1 (0)");
            tabNodes[0][2] = GameObject.Find("Nodes/Node 2 (0)");
            tabNodes[0][3] = GameObject.Find("Nodes/Node 3 (0)");
            tabNodes[0][4] = GameObject.Find("Nodes/Node 4 (0)");
            tabNodes[0][5] = GameObject.Find("Nodes/Node 5 (0)");
            tabNodes[0][6] = GameObject.Find("Nodes/Node 6 (0)");
            tabNodes[0][7] = GameObject.Find("Nodes/Node 7 (0)");
            tabNodes[0][8] = GameObject.Find("Nodes/Node 8 (0)");
            tabNodes[0][9] = GameObject.Find("Nodes/Node 9 (0)");
            tabNodes[0][10] = GameObject.Find("Nodes/Node 10 (0)");
            tabNodes[0][11] = GameObject.Find("Nodes/Node 11 (0)");
            tabNodes[0][12] = GameObject.Find("Nodes/Node 12 (0)");
            tabNodes[0][13] = GameObject.Find("Nodes/Node 13 (0)");
            tabNodes[0][14] = GameObject.Find("Nodes/Node 14 (0)");
            tabNodes[0][15] = GameObject.Find("Nodes/Node 15 (0)");
            tabNodes[0][16] = GameObject.Find("Nodes/Node 16 (0)");
            tabNodes[0][17] = GameObject.Find("Nodes/Node 17 (0)");
            tabNodes[0][18] = GameObject.Find("Nodes/Node 18 (0)");
            tabNodes[0][19] = GameObject.Find("Nodes/Node 19 (0)");
            tabNodes[0][20] = GameObject.Find("Nodes/Node 20 (0)");
            tabNodes[0][21] = GameObject.Find("Nodes/Node 21 (0)");

            tabNodes[1][0] = GameObject.Find("Nodes/Node 0 (1)");
            tabNodes[1][1] = GameObject.Find("Nodes/Node 1 (1)");
            tabNodes[1][2] = GameObject.Find("Nodes/Node 2 (1)");
            tabNodes[1][3] = GameObject.Find("Nodes/Node 3 (1)");
            tabNodes[1][4] = GameObject.Find("Nodes/Node 4 (1)");
            tabNodes[1][5] = GameObject.Find("Nodes/Node 5 (1)");
            tabNodes[1][6] = GameObject.Find("Nodes/Node 6 (1)");
            tabNodes[1][7] = GameObject.Find("Nodes/Node 7 (1)");
            tabNodes[1][8] = GameObject.Find("Nodes/Node 8 (1)");
            tabNodes[1][9] = GameObject.Find("Nodes/Node 9 (1)");
            tabNodes[1][10] = GameObject.Find("Nodes/Node 10 (1)");
            tabNodes[1][11] = GameObject.Find("Nodes/Node 11 (1)");
            tabNodes[1][12] = GameObject.Find("Nodes/Node 12 (1)");
            tabNodes[1][13] = GameObject.Find("Nodes/Node 13 (1)");
            tabNodes[1][14] = GameObject.Find("Nodes/Node 14 (1)");
            tabNodes[1][15] = GameObject.Find("Nodes/Node 15 (1)");
            tabNodes[1][16] = GameObject.Find("Nodes/Node 16 (1)");
            tabNodes[1][17] = GameObject.Find("Nodes/Node 17 (1)");
            tabNodes[1][18] = GameObject.Find("Nodes/Node 18 (1)");
            tabNodes[1][19] = GameObject.Find("Nodes/Node 19 (1)");
            tabNodes[1][20] = GameObject.Find("Nodes/Node 20 (1)");
            tabNodes[1][21] = GameObject.Find("Nodes/Node 21 (1)");

            tabNodes[2][0] = GameObject.Find("Nodes/Node 0 (2)");
            tabNodes[2][1] = GameObject.Find("Nodes/Node 1 (2)");
            tabNodes[2][2] = GameObject.Find("Nodes/Node 2 (2)");
            tabNodes[2][3] = GameObject.Find("Nodes/Node 3 (2)");
            tabNodes[2][4] = GameObject.Find("Nodes/Node 4 (2)");
            tabNodes[2][5] = GameObject.Find("Nodes/Node 5 (2)");
            tabNodes[2][6] = GameObject.Find("Nodes/Node 6 (2)");
            tabNodes[2][7] = GameObject.Find("Nodes/Node 7 (2)");
            tabNodes[2][8] = GameObject.Find("Nodes/Node 8 (2)");
            tabNodes[2][9] = GameObject.Find("Nodes/Node 9 (2)");
            tabNodes[2][10] = GameObject.Find("Nodes/Node 10 (2)");
            tabNodes[2][11] = GameObject.Find("Nodes/Node 11 (2)");
            tabNodes[2][12] = GameObject.Find("Nodes/Node 12 (2)");
            tabNodes[2][13] = GameObject.Find("Nodes/Node 13 (2)");
            tabNodes[2][14] = GameObject.Find("Nodes/Node 14 (2)");
            tabNodes[2][15] = GameObject.Find("Nodes/Node 15 (2)");
            tabNodes[2][16] = GameObject.Find("Nodes/Node 16 (2)");
            tabNodes[2][17] = GameObject.Find("Nodes/Node 17 (2)");
            tabNodes[2][18] = GameObject.Find("Nodes/Node 18 (2)");
            tabNodes[2][19] = GameObject.Find("Nodes/Node 19 (2)");
            tabNodes[2][20] = GameObject.Find("Nodes/Node 20 (2)");
            tabNodes[2][21] = GameObject.Find("Nodes/Node 21 (2)");

            tabNodes[3][0] = GameObject.Find("Nodes/Node 0 (3)");
            tabNodes[3][1] = GameObject.Find("Nodes/Node 1 (3)");
            tabNodes[3][2] = GameObject.Find("Nodes/Node 2 (3)");
            tabNodes[3][3] = GameObject.Find("Nodes/Node 3 (3)");
            tabNodes[3][4] = GameObject.Find("Nodes/Node 4 (3)");
            tabNodes[3][5] = GameObject.Find("Nodes/Node 5 (3)");
            tabNodes[3][6] = GameObject.Find("Nodes/Node 6 (3)");
            tabNodes[3][7] = GameObject.Find("Nodes/Node 7 (3)");
            tabNodes[3][8] = GameObject.Find("Nodes/Node 8 (3)");
            tabNodes[3][9] = GameObject.Find("Nodes/Node 9 (3)");
            tabNodes[3][10] = GameObject.Find("Nodes/Node 10 (3)");
            tabNodes[3][11] = GameObject.Find("Nodes/Node 11 (3)");
            tabNodes[3][12] = GameObject.Find("Nodes/Node 12 (3)");
            tabNodes[3][13] = GameObject.Find("Nodes/Node 13 (3)");
            tabNodes[3][14] = GameObject.Find("Nodes/Node 14 (3)");
            tabNodes[3][15] = GameObject.Find("Nodes/Node 15 (3)");
            tabNodes[3][16] = GameObject.Find("Nodes/Node 16 (3)");
            tabNodes[3][17] = GameObject.Find("Nodes/Node 17 (3)");
            tabNodes[3][18] = GameObject.Find("Nodes/Node 18 (3)");
            tabNodes[3][19] = GameObject.Find("Nodes/Node 19 (3)");
            tabNodes[3][20] = GameObject.Find("Nodes/Node 20 (3)");
            tabNodes[3][21] = GameObject.Find("Nodes/Node 21 (3)");

            tabNodes[4][0] = GameObject.Find("Nodes/Node 0 (4)");
            tabNodes[4][1] = GameObject.Find("Nodes/Node 1 (4)");
            tabNodes[4][2] = GameObject.Find("Nodes/Node 2 (4)");
            tabNodes[4][3] = GameObject.Find("Nodes/Node 3 (4)");
            tabNodes[4][4] = GameObject.Find("Nodes/Node 4 (4)");
            tabNodes[4][5] = GameObject.Find("Nodes/Node 5 (4)");
            tabNodes[4][6] = GameObject.Find("Nodes/Node 6 (4)");
            tabNodes[4][7] = GameObject.Find("Nodes/Node 7 (4)");
            tabNodes[4][8] = GameObject.Find("Nodes/Node 8 (4)");
            tabNodes[4][9] = GameObject.Find("Nodes/Node 9 (4)");
            tabNodes[4][10] = GameObject.Find("Nodes/Node 10 (4)");
            tabNodes[4][11] = GameObject.Find("Nodes/Node 11 (4)");
            tabNodes[4][12] = GameObject.Find("Nodes/Node 12 (4)");
            tabNodes[4][13] = GameObject.Find("Nodes/Node 13 (4)");
            tabNodes[4][14] = GameObject.Find("Nodes/Node 14 (4)");
            tabNodes[4][15] = GameObject.Find("Nodes/Node 15 (4)");
            tabNodes[4][16] = GameObject.Find("Nodes/Node 16 (4)");
            tabNodes[4][17] = GameObject.Find("Nodes/Node 17 (4)");
            tabNodes[4][18] = GameObject.Find("Nodes/Node 18 (4)");
            tabNodes[4][19] = GameObject.Find("Nodes/Node 19 (4)");
            tabNodes[4][20] = GameObject.Find("Nodes/Node 20 (4)");
            tabNodes[4][21] = GameObject.Find("Nodes/Node 21 (4)");

            tabNodes[5][0] = GameObject.Find("Nodes/Node 0 (5)");
            tabNodes[5][1] = GameObject.Find("Nodes/Node 1 (5)");
            tabNodes[5][2] = GameObject.Find("Nodes/Node 2 (5)");
            tabNodes[5][3] = GameObject.Find("Nodes/Node 3 (5)");
            tabNodes[5][4] = GameObject.Find("Nodes/Node 4 (5)");
            tabNodes[5][5] = GameObject.Find("Nodes/Node 5 (5)");
            tabNodes[5][6] = GameObject.Find("Nodes/Node 6 (5)");
            tabNodes[5][7] = GameObject.Find("Nodes/Node 7 (5)");
            tabNodes[5][8] = GameObject.Find("Nodes/Node 8 (5)");
            tabNodes[5][9] = GameObject.Find("Nodes/Node 9 (5)");
            tabNodes[5][10] = GameObject.Find("Nodes/Node 10 (5)");
            tabNodes[5][11] = GameObject.Find("Nodes/Node 11 (5)");
            tabNodes[5][12] = GameObject.Find("Nodes/Node 12 (5)");
            tabNodes[5][13] = GameObject.Find("Nodes/Node 13 (5)");
            tabNodes[5][14] = GameObject.Find("Nodes/Node 14 (5)");
            tabNodes[5][15] = GameObject.Find("Nodes/Node 15 (5)");
            tabNodes[5][16] = GameObject.Find("Nodes/Node 16 (5)");
            tabNodes[5][17] = GameObject.Find("Nodes/Node 17 (5)");
            tabNodes[5][18] = GameObject.Find("Nodes/Node 18 (5)");
            tabNodes[5][19] = GameObject.Find("Nodes/Node 19 (5)");
            tabNodes[5][20] = GameObject.Find("Nodes/Node 20 (5)");
            tabNodes[5][21] = GameObject.Find("Nodes/Node 21 (5)");

            tabNodes[6][0] = GameObject.Find("Nodes/Node 0 (6)");
            tabNodes[6][1] = GameObject.Find("Nodes/Node 1 (6)");
            tabNodes[6][2] = GameObject.Find("Nodes/Node 2 (6)");
            tabNodes[6][3] = GameObject.Find("Nodes/Node 3 (6)");
            tabNodes[6][4] = GameObject.Find("Nodes/Node 4 (6)");
            tabNodes[6][5] = GameObject.Find("Nodes/Node 5 (6)");
            tabNodes[6][6] = GameObject.Find("Nodes/Node 6 (6)");
            tabNodes[6][7] = GameObject.Find("Nodes/Node 7 (6)");
            tabNodes[6][8] = GameObject.Find("Nodes/Node 8 (6)");
            tabNodes[6][9] = GameObject.Find("Nodes/Node 9 (6)");
            tabNodes[6][10] = GameObject.Find("Nodes/Node 10 (6)");
            tabNodes[6][11] = GameObject.Find("Nodes/Node 11 (6)");
            tabNodes[6][12] = GameObject.Find("Nodes/Node 12 (6)");
            tabNodes[6][13] = GameObject.Find("Nodes/Node 13 (6)");
            tabNodes[6][14] = GameObject.Find("Nodes/Node 14 (6)");
            tabNodes[6][15] = GameObject.Find("Nodes/Node 15 (6)");
            tabNodes[6][16] = GameObject.Find("Nodes/Node 16 (6)");
            tabNodes[6][17] = GameObject.Find("Nodes/Node 17 (6)");
            tabNodes[6][18] = GameObject.Find("Nodes/Node 18 (6)");
            tabNodes[6][19] = GameObject.Find("Nodes/Node 19 (6)");
            tabNodes[6][20] = GameObject.Find("Nodes/Node 20 (6)");
            tabNodes[6][21] = GameObject.Find("Nodes/Node 21 (6)");

            tabNodes[7][0] = GameObject.Find("Nodes/Node 0 (7)");
            tabNodes[7][1] = GameObject.Find("Nodes/Node 1 (7)");
            tabNodes[7][2] = GameObject.Find("Nodes/Node 2 (7)");
            tabNodes[7][3] = GameObject.Find("Nodes/Node 3 (7)");
            tabNodes[7][4] = GameObject.Find("Nodes/Node 4 (7)");
            tabNodes[7][5] = GameObject.Find("Nodes/Node 5 (7)");
            tabNodes[7][6] = GameObject.Find("Nodes/Node 6 (7)");
            tabNodes[7][7] = GameObject.Find("Nodes/Node 7 (7)");
            tabNodes[7][8] = GameObject.Find("Nodes/Node 8 (7)");
            tabNodes[7][9] = GameObject.Find("Nodes/Node 9 (7)");
            tabNodes[7][10] = GameObject.Find("Nodes/Node 10 (7)");
            tabNodes[7][11] = GameObject.Find("Nodes/Node 11 (7)");
            tabNodes[7][12] = GameObject.Find("Nodes/Node 12 (7)");
            tabNodes[7][13] = GameObject.Find("Nodes/Node 13 (7)");
            tabNodes[7][14] = GameObject.Find("Nodes/Node 14 (7)");
            tabNodes[7][15] = GameObject.Find("Nodes/Node 15 (7)");
            tabNodes[7][16] = GameObject.Find("Nodes/Node 16 (7)");
            tabNodes[7][17] = GameObject.Find("Nodes/Node 17 (7)");
            tabNodes[7][18] = GameObject.Find("Nodes/Node 18 (7)");
            tabNodes[7][19] = GameObject.Find("Nodes/Node 19 (7)");
            tabNodes[7][20] = GameObject.Find("Nodes/Node 20 (7)");
            tabNodes[7][21] = GameObject.Find("Nodes/Node 21 (7)");

            tabNodes[8][0] = GameObject.Find("Nodes/Node 0 (8)");
            tabNodes[8][1] = GameObject.Find("Nodes/Node 1 (8)");
            tabNodes[8][2] = GameObject.Find("Nodes/Node 2 (8)");
            tabNodes[8][3] = GameObject.Find("Nodes/Node 3 (8)");
            tabNodes[8][4] = GameObject.Find("Nodes/Node 4 (8)");
            tabNodes[8][5] = GameObject.Find("Nodes/Node 5 (8)");
            tabNodes[8][6] = GameObject.Find("Nodes/Node 6 (8)");
            tabNodes[8][7] = GameObject.Find("Nodes/Node 7 (8)");
            tabNodes[8][8] = GameObject.Find("Nodes/Node 8 (8)");
            tabNodes[8][9] = GameObject.Find("Nodes/Node 9 (8)");
            tabNodes[8][10] = GameObject.Find("Nodes/Node 10 (8)");
            tabNodes[8][11] = GameObject.Find("Nodes/Node 11 (8)");
            tabNodes[8][12] = GameObject.Find("Nodes/Node 12 (8)");
            tabNodes[8][13] = GameObject.Find("Nodes/Node 13 (8)");
            tabNodes[8][14] = GameObject.Find("Nodes/Node 14 (8)");
            tabNodes[8][15] = GameObject.Find("Nodes/Node 15 (8)");
            tabNodes[8][16] = GameObject.Find("Nodes/Node 16 (8)");
            tabNodes[8][17] = GameObject.Find("Nodes/Node 17 (8)");
            tabNodes[8][18] = GameObject.Find("Nodes/Node 18 (8)");
            tabNodes[8][19] = GameObject.Find("Nodes/Node 19 (8)");
            tabNodes[8][20] = GameObject.Find("Nodes/Node 20 (8)");
            tabNodes[8][21] = GameObject.Find("Nodes/Node 21 (8)");

            tabNodes[9][0] = GameObject.Find("Nodes/Node 0 (9)");
            tabNodes[9][1] = GameObject.Find("Nodes/Node 1 (9)");
            tabNodes[9][2] = GameObject.Find("Nodes/Node 2 (9)");
            tabNodes[9][3] = GameObject.Find("Nodes/Node 3 (9)");
            tabNodes[9][4] = GameObject.Find("Nodes/Node 4 (9)");
            tabNodes[9][5] = GameObject.Find("Nodes/Node 5 (9)");
            tabNodes[9][6] = GameObject.Find("Nodes/Node 6 (9)");
            tabNodes[9][7] = GameObject.Find("Nodes/Node 7 (9)");
            tabNodes[9][8] = GameObject.Find("Nodes/Node 8 (9)");
            tabNodes[9][9] = GameObject.Find("Nodes/Node 9 (9)");
            tabNodes[9][10] = GameObject.Find("Nodes/Node 10 (9)");
            tabNodes[9][11] = GameObject.Find("Nodes/Node 11 (9)");
            tabNodes[9][12] = GameObject.Find("Nodes/Node 12 (9)");
            tabNodes[9][13] = GameObject.Find("Nodes/Node 13 (9)");
            tabNodes[9][14] = GameObject.Find("Nodes/Node 14 (9)");
            tabNodes[9][15] = GameObject.Find("Nodes/Node 15 (9)");
            tabNodes[9][16] = GameObject.Find("Nodes/Node 16 (9)");
            tabNodes[9][17] = GameObject.Find("Nodes/Node 17 (9)");
            tabNodes[9][18] = GameObject.Find("Nodes/Node 18 (9)");
            tabNodes[9][19] = GameObject.Find("Nodes/Node 19 (9)");
            tabNodes[9][20] = GameObject.Find("Nodes/Node 20 (9)");
            tabNodes[9][21] = GameObject.Find("Nodes/Node 21 (9)");

            tabNodes[10][0] = GameObject.Find("Nodes/Node 0 (10)");
            tabNodes[10][1] = GameObject.Find("Nodes/Node 1 (10)");
            tabNodes[10][2] = GameObject.Find("Nodes/Node 2 (10)");
            tabNodes[10][3] = GameObject.Find("Nodes/Node 3 (10)");
            tabNodes[10][4] = GameObject.Find("Nodes/Node 4 (10)");
            tabNodes[10][5] = GameObject.Find("Nodes/Node 5 (10)");
            tabNodes[10][6] = GameObject.Find("Nodes/Node 6 (10)");
            tabNodes[10][7] = GameObject.Find("Nodes/Node 7 (10)");
            tabNodes[10][8] = GameObject.Find("Nodes/Node 8 (10)");
            tabNodes[10][9] = GameObject.Find("Nodes/Node 9 (10)");
            tabNodes[10][10] = GameObject.Find("Nodes/Node 10 (10)");
            tabNodes[10][11] = GameObject.Find("Nodes/Node 11 (10)");
            tabNodes[10][12] = GameObject.Find("Nodes/Node 12 (10)");
            tabNodes[10][13] = GameObject.Find("Nodes/Node 13 (10)");
            tabNodes[10][14] = GameObject.Find("Nodes/Node 14 (10)");
            tabNodes[10][15] = GameObject.Find("Nodes/Node 15 (10)");
            tabNodes[10][16] = GameObject.Find("Nodes/Node 16 (10)");
            tabNodes[10][17] = GameObject.Find("Nodes/Node 17 (10)");
            tabNodes[10][18] = GameObject.Find("Nodes/Node 18 (10)");
            tabNodes[10][19] = GameObject.Find("Nodes/Node 19 (10)");
            tabNodes[10][20] = GameObject.Find("Nodes/Node 20 (10)");
            tabNodes[10][21] = GameObject.Find("Nodes/Node 21 (10)");

            tabNodes[11][0] = GameObject.Find("Nodes/Node 0 (11)");
            tabNodes[11][1] = GameObject.Find("Nodes/Node 1 (11)");
            tabNodes[11][2] = GameObject.Find("Nodes/Node 2 (11)");
            tabNodes[11][3] = GameObject.Find("Nodes/Node 3 (11)");
            tabNodes[11][4] = GameObject.Find("Nodes/Node 4 (11)");
            tabNodes[11][5] = GameObject.Find("Nodes/Node 5 (11)");
            tabNodes[11][6] = GameObject.Find("Nodes/Node 6 (11)");
            tabNodes[11][7] = GameObject.Find("Nodes/Node 7 (11)");
            tabNodes[11][8] = GameObject.Find("Nodes/Node 8 (11)");
            tabNodes[11][9] = GameObject.Find("Nodes/Node 9 (11)");
            tabNodes[11][10] = GameObject.Find("Nodes/Node 10 (11)");
            tabNodes[11][11] = GameObject.Find("Nodes/Node 11 (11)");
            tabNodes[11][12] = GameObject.Find("Nodes/Node 12 (11)");
            tabNodes[11][13] = GameObject.Find("Nodes/Node 13 (11)");
            tabNodes[11][14] = GameObject.Find("Nodes/Node 14 (11)");
            tabNodes[11][15] = GameObject.Find("Nodes/Node 15 (11)");
            tabNodes[11][16] = GameObject.Find("Nodes/Node 16 (11)");
            tabNodes[11][17] = GameObject.Find("Nodes/Node 17 (11)");
            tabNodes[11][18] = GameObject.Find("Nodes/Node 18 (11)");
            tabNodes[11][19] = GameObject.Find("Nodes/Node 19 (11)");
            tabNodes[11][20] = GameObject.Find("Nodes/Node 20 (11)");
            tabNodes[11][21] = GameObject.Find("Nodes/Node 21 (11)");

            tabNodes[12][0] = GameObject.Find("Nodes/Node 0 (12)");
            tabNodes[12][1] = GameObject.Find("Nodes/Node 1 (12)");
            tabNodes[12][2] = GameObject.Find("Nodes/Node 2 (12)");
            tabNodes[12][3] = GameObject.Find("Nodes/Node 3 (12)");
            tabNodes[12][4] = GameObject.Find("Nodes/Node 4 (12)");
            tabNodes[12][5] = GameObject.Find("Nodes/Node 5 (12)");
            tabNodes[12][6] = GameObject.Find("Nodes/Node 6 (12)");
            tabNodes[12][7] = GameObject.Find("Nodes/Node 7 (12)");
            tabNodes[12][8] = GameObject.Find("Nodes/Node 8 (12)");
            tabNodes[12][9] = GameObject.Find("Nodes/Node 9 (12)");
            tabNodes[12][10] = GameObject.Find("Nodes/Node 10 (12)");
            tabNodes[12][11] = GameObject.Find("Nodes/Node 11 (12)");
            tabNodes[12][12] = GameObject.Find("Nodes/Node 12 (12)");
            tabNodes[12][13] = GameObject.Find("Nodes/Node 13 (12)");
            tabNodes[12][14] = GameObject.Find("Nodes/Node 14 (12)");
            tabNodes[12][15] = GameObject.Find("Nodes/Node 15 (12)");
            tabNodes[12][16] = GameObject.Find("Nodes/Node 16 (12)");
            tabNodes[12][17] = GameObject.Find("Nodes/Node 17 (12)");
            tabNodes[12][18] = GameObject.Find("Nodes/Node 18 (12)");
            tabNodes[12][19] = GameObject.Find("Nodes/Node 19 (12)");
            tabNodes[12][20] = GameObject.Find("Nodes/Node 20 (12)");
            tabNodes[12][21] = GameObject.Find("Nodes/Node 21 (12)");

            tabNodes[13][0] = GameObject.Find("Nodes/Node 0 (13)");
            tabNodes[13][1] = GameObject.Find("Nodes/Node 1 (13)");
            tabNodes[13][2] = GameObject.Find("Nodes/Node 2 (13)");
            tabNodes[13][3] = GameObject.Find("Nodes/Node 3 (13)");
            tabNodes[13][4] = GameObject.Find("Nodes/Node 4 (13)");
            tabNodes[13][5] = GameObject.Find("Nodes/Node 5 (13)");
            tabNodes[13][6] = GameObject.Find("Nodes/Node 6 (13)");
            tabNodes[13][7] = GameObject.Find("Nodes/Node 7 (13)");
            tabNodes[13][8] = GameObject.Find("Nodes/Node 8 (13)");
            tabNodes[13][9] = GameObject.Find("Nodes/Node 9 (13)");
            tabNodes[13][10] = GameObject.Find("Nodes/Node 10 (13)");
            tabNodes[13][11] = GameObject.Find("Nodes/Node 11 (13)");
            tabNodes[13][12] = GameObject.Find("Nodes/Node 12 (13)");
            tabNodes[13][13] = GameObject.Find("Nodes/Node 13 (13)");
            tabNodes[13][14] = GameObject.Find("Nodes/Node 14 (13)");
            tabNodes[13][15] = GameObject.Find("Nodes/Node 15 (13)");
            tabNodes[13][16] = GameObject.Find("Nodes/Node 16 (13)");
            tabNodes[13][17] = GameObject.Find("Nodes/Node 17 (13)");
            tabNodes[13][18] = GameObject.Find("Nodes/Node 18 (13)");
            tabNodes[13][19] = GameObject.Find("Nodes/Node 19 (13)");
            tabNodes[13][20] = GameObject.Find("Nodes/Node 20 (13)");
            tabNodes[13][21] = GameObject.Find("Nodes/Node 21 (13)");

            tabNodes[14][0] = GameObject.Find("Nodes/Node 0 (14)");
            tabNodes[14][1] = GameObject.Find("Nodes/Node 1 (14)");
            tabNodes[14][2] = GameObject.Find("Nodes/Node 2 (14)");
            tabNodes[14][3] = GameObject.Find("Nodes/Node 3 (14)");
            tabNodes[14][4] = GameObject.Find("Nodes/Node 4 (14)");
            tabNodes[14][5] = GameObject.Find("Nodes/Node 5 (14)");
            tabNodes[14][6] = GameObject.Find("Nodes/Node 6 (14)");
            tabNodes[14][7] = GameObject.Find("Nodes/Node 7 (14)");
            tabNodes[14][8] = GameObject.Find("Nodes/Node 8 (14)");
            tabNodes[14][9] = GameObject.Find("Nodes/Node 9 (14)");
            tabNodes[14][10] = GameObject.Find("Nodes/Node 10 (14)");
            tabNodes[14][11] = GameObject.Find("Nodes/Node 11 (14)");
            tabNodes[14][12] = GameObject.Find("Nodes/Node 12 (14)");
            tabNodes[14][13] = GameObject.Find("Nodes/Node 13 (14)");
            tabNodes[14][14] = GameObject.Find("Nodes/Node 14 (14)");
            tabNodes[14][15] = GameObject.Find("Nodes/Node 15 (14)");
            tabNodes[14][16] = GameObject.Find("Nodes/Node 16 (14)");
            tabNodes[14][17] = GameObject.Find("Nodes/Node 17 (14)");
            tabNodes[14][18] = GameObject.Find("Nodes/Node 18 (14)");
            tabNodes[14][19] = GameObject.Find("Nodes/Node 19 (14)");
            tabNodes[14][20] = GameObject.Find("Nodes/Node 20 (14)");
            tabNodes[14][21] = GameObject.Find("Nodes/Node 21 (14)");

            tabNodes[15][0] = GameObject.Find("Nodes/Node 0 (15)");
            tabNodes[15][1] = GameObject.Find("Nodes/Node 1 (15)");
            tabNodes[15][2] = GameObject.Find("Nodes/Node 2 (15)");
            tabNodes[15][3] = GameObject.Find("Nodes/Node 3 (15)");
            tabNodes[15][4] = GameObject.Find("Nodes/Node 4 (15)");
            tabNodes[15][5] = GameObject.Find("Nodes/Node 5 (15)");
            tabNodes[15][6] = GameObject.Find("Nodes/Node 6 (15)");
            tabNodes[15][7] = GameObject.Find("Nodes/Node 7 (15)");
            tabNodes[15][8] = GameObject.Find("Nodes/Node 8 (15)");
            tabNodes[15][9] = GameObject.Find("Nodes/Node 9 (15)");
            tabNodes[15][10] = GameObject.Find("Nodes/Node 10 (15)");
            tabNodes[15][11] = GameObject.Find("Nodes/Node 11 (15)");
            tabNodes[15][12] = GameObject.Find("Nodes/Node 12 (15)");
            tabNodes[15][13] = GameObject.Find("Nodes/Node 13 (15)");
            tabNodes[15][14] = GameObject.Find("Nodes/Node 14 (15)");
            tabNodes[15][15] = GameObject.Find("Nodes/Node 15 (15)");
            tabNodes[15][16] = GameObject.Find("Nodes/Node 16 (15)");
            tabNodes[15][17] = GameObject.Find("Nodes/Node 17 (15)");
            tabNodes[15][18] = GameObject.Find("Nodes/Node 18 (15)");
            tabNodes[15][19] = GameObject.Find("Nodes/Node 19 (15)");
            tabNodes[15][20] = GameObject.Find("Nodes/Node 20 (15)");
            tabNodes[15][21] = GameObject.Find("Nodes/Node 21 (15)");

            tabNodes[16][0] = GameObject.Find("Nodes/Node 0 (16)");
            tabNodes[16][1] = GameObject.Find("Nodes/Node 1 (16)");
            tabNodes[16][2] = GameObject.Find("Nodes/Node 2 (16)");
            tabNodes[16][3] = GameObject.Find("Nodes/Node 3 (16)");
            tabNodes[16][4] = GameObject.Find("Nodes/Node 4 (16)");
            tabNodes[16][5] = GameObject.Find("Nodes/Node 5 (16)");
            tabNodes[16][6] = GameObject.Find("Nodes/Node 6 (16)");
            tabNodes[16][7] = GameObject.Find("Nodes/Node 7 (16)");
            tabNodes[16][8] = GameObject.Find("Nodes/Node 8 (16)");
            tabNodes[16][9] = GameObject.Find("Nodes/Node 9 (16)");
            tabNodes[16][10] = GameObject.Find("Nodes/Node 10 (16)");
            tabNodes[16][11] = GameObject.Find("Nodes/Node 11 (16)");
            tabNodes[16][12] = GameObject.Find("Nodes/Node 12 (16)");
            tabNodes[16][13] = GameObject.Find("Nodes/Node 13 (16)");
            tabNodes[16][14] = GameObject.Find("Nodes/Node 14 (16)");
            tabNodes[16][15] = GameObject.Find("Nodes/Node 15 (16)");
            tabNodes[16][16] = GameObject.Find("Nodes/Node 16 (16)");
            tabNodes[16][17] = GameObject.Find("Nodes/Node 17 (16)");
            tabNodes[16][18] = GameObject.Find("Nodes/Node 18 (16)");
            tabNodes[16][19] = GameObject.Find("Nodes/Node 19 (16)");
            tabNodes[16][20] = GameObject.Find("Nodes/Node 20 (16)");
            tabNodes[16][21] = GameObject.Find("Nodes/Node 21 (16)");

            tabNodes[17][0] = GameObject.Find("Nodes/Node 0 (17)");
            tabNodes[17][1] = GameObject.Find("Nodes/Node 1 (17)");
            tabNodes[17][2] = GameObject.Find("Nodes/Node 2 (17)");
            tabNodes[17][3] = GameObject.Find("Nodes/Node 3 (17)");
            tabNodes[17][4] = GameObject.Find("Nodes/Node 4 (17)");
            tabNodes[17][5] = GameObject.Find("Nodes/Node 5 (17)");
            tabNodes[17][6] = GameObject.Find("Nodes/Node 6 (17)");
            tabNodes[17][7] = GameObject.Find("Nodes/Node 7 (17)");
            tabNodes[17][8] = GameObject.Find("Nodes/Node 8 (17)");
            tabNodes[17][9] = GameObject.Find("Nodes/Node 9 (17)");
            tabNodes[17][10] = GameObject.Find("Nodes/Node 10 (17)");
            tabNodes[17][11] = GameObject.Find("Nodes/Node 11 (17)");
            tabNodes[17][12] = GameObject.Find("Nodes/Node 12 (17)");
            tabNodes[17][13] = GameObject.Find("Nodes/Node 13 (17)");
            tabNodes[17][14] = GameObject.Find("Nodes/Node 14 (17)");
            tabNodes[17][15] = GameObject.Find("Nodes/Node 15 (17)");
            tabNodes[17][16] = GameObject.Find("Nodes/Node 16 (17)");
            tabNodes[17][17] = GameObject.Find("Nodes/Node 17 (17)");
            tabNodes[17][18] = GameObject.Find("Nodes/Node 18 (17)");
            tabNodes[17][19] = GameObject.Find("Nodes/Node 19 (17)");
            tabNodes[17][20] = GameObject.Find("Nodes/Node 20 (17)");
            tabNodes[17][21] = GameObject.Find("Nodes/Node 21 (17)");

            tabNodes[18][0] = GameObject.Find("Nodes/Node 0 (18)");
            tabNodes[18][1] = GameObject.Find("Nodes/Node 1 (18)");
            tabNodes[18][2] = GameObject.Find("Nodes/Node 2 (18)");
            tabNodes[18][3] = GameObject.Find("Nodes/Node 3 (18)");
            tabNodes[18][4] = GameObject.Find("Nodes/Node 4 (18)");
            tabNodes[18][5] = GameObject.Find("Nodes/Node 5 (18)");
            tabNodes[18][6] = GameObject.Find("Nodes/Node 6 (18)");
            tabNodes[18][7] = GameObject.Find("Nodes/Node 7 (18)");
            tabNodes[18][8] = GameObject.Find("Nodes/Node 8 (18)");
            tabNodes[18][9] = GameObject.Find("Nodes/Node 9 (18)");
            tabNodes[18][10] = GameObject.Find("Nodes/Node 10 (18)");
            tabNodes[18][11] = GameObject.Find("Nodes/Node 11 (18)");
            tabNodes[18][12] = GameObject.Find("Nodes/Node 12 (18)");
            tabNodes[18][13] = GameObject.Find("Nodes/Node 13 (18)");
            tabNodes[18][14] = GameObject.Find("Nodes/Node 14 (18)");
            tabNodes[18][15] = GameObject.Find("Nodes/Node 15 (18)");
            tabNodes[18][16] = GameObject.Find("Nodes/Node 16 (18)");
            tabNodes[18][17] = GameObject.Find("Nodes/Node 17 (18)");
            tabNodes[18][18] = GameObject.Find("Nodes/Node 18 (18)");
            tabNodes[18][19] = GameObject.Find("Nodes/Node 19 (18)");
            tabNodes[18][20] = GameObject.Find("Nodes/Node 20 (18)");
            tabNodes[18][21] = GameObject.Find("Nodes/Node 21 (18)");

            tabNodes[19][0] = GameObject.Find("Nodes/Node 0 (19)");
            tabNodes[19][1] = GameObject.Find("Nodes/Node 1 (19)");
            tabNodes[19][2] = GameObject.Find("Nodes/Node 2 (19)");
            tabNodes[19][3] = GameObject.Find("Nodes/Node 3 (19)");
            tabNodes[19][4] = GameObject.Find("Nodes/Node 4 (19)");
            tabNodes[19][5] = GameObject.Find("Nodes/Node 5 (19)");
            tabNodes[19][6] = GameObject.Find("Nodes/Node 6 (19)");
            tabNodes[19][7] = GameObject.Find("Nodes/Node 7 (19)");
            tabNodes[19][8] = GameObject.Find("Nodes/Node 8 (19)");
            tabNodes[19][9] = GameObject.Find("Nodes/Node 9 (19)");
            tabNodes[19][10] = GameObject.Find("Nodes/Node 10 (19)");
            tabNodes[19][11] = GameObject.Find("Nodes/Node 11 (19)");
            tabNodes[19][12] = GameObject.Find("Nodes/Node 12 (19)");
            tabNodes[19][13] = GameObject.Find("Nodes/Node 13 (19)");
            tabNodes[19][14] = GameObject.Find("Nodes/Node 14 (19)");
            tabNodes[19][15] = GameObject.Find("Nodes/Node 15 (19)");
            tabNodes[19][16] = GameObject.Find("Nodes/Node 16 (19)");
            tabNodes[19][17] = GameObject.Find("Nodes/Node 17 (19)");
            tabNodes[19][18] = GameObject.Find("Nodes/Node 18 (19)");
            tabNodes[19][19] = GameObject.Find("Nodes/Node 19 (19)");
            tabNodes[19][20] = GameObject.Find("Nodes/Node 20 (19)");
            tabNodes[19][21] = GameObject.Find("Nodes/Node 21 (19)");

            tabNodes[20][0] = GameObject.Find("Nodes/Node 0 (20)");
            tabNodes[20][1] = GameObject.Find("Nodes/Node 1 (20)");
            tabNodes[20][2] = GameObject.Find("Nodes/Node 2 (20)");
            tabNodes[20][3] = GameObject.Find("Nodes/Node 3 (20)");
            tabNodes[20][4] = GameObject.Find("Nodes/Node 4 (20)");
            tabNodes[20][5] = GameObject.Find("Nodes/Node 5 (20)");
            tabNodes[20][6] = GameObject.Find("Nodes/Node 6 (20)");
            tabNodes[20][7] = GameObject.Find("Nodes/Node 7 (20)");
            tabNodes[20][8] = GameObject.Find("Nodes/Node 8 (20)");
            tabNodes[20][9] = GameObject.Find("Nodes/Node 9 (20)");
            tabNodes[20][10] = GameObject.Find("Nodes/Node 10 (20)");
            tabNodes[20][11] = GameObject.Find("Nodes/Node 11 (20)");
            tabNodes[20][12] = GameObject.Find("Nodes/Node 12 (20)");
            tabNodes[20][13] = GameObject.Find("Nodes/Node 13 (20)");
            tabNodes[20][14] = GameObject.Find("Nodes/Node 14 (20)");
            tabNodes[20][15] = GameObject.Find("Nodes/Node 15 (20)");
            tabNodes[20][16] = GameObject.Find("Nodes/Node 16 (20)");
            tabNodes[20][17] = GameObject.Find("Nodes/Node 17 (20)");
            tabNodes[20][18] = GameObject.Find("Nodes/Node 18 (20)");
            tabNodes[20][19] = GameObject.Find("Nodes/Node 19 (20)");
            tabNodes[20][20] = GameObject.Find("Nodes/Node 20 (20)");
            tabNodes[20][21] = GameObject.Find("Nodes/Node 21 (20)");
        }
    }
}
