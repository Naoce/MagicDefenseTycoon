using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public  GameObject      EnemyGuerrier;
    static  public  int[]   playerMaxXP = new int[15];
    public  int             playerMaxHP;
    public  int             playerXP;
    public  int             playerLevel;
    public  int             playerDamage;

    private float           timerSpawn = 0f;
    private float           timerMax = 5f;
    private bool            spawnLeft = true;
    private Quaternion      rot = new Quaternion(0, 0, 0, 0);
    public  Vector2         posLeft = new Vector2(0, 0);
    public  Vector2         posRight = new Vector2(0, 0);
    public List<GameObject> enemiesList = new List<GameObject>();

	void Start ()
    {
        playerMaxXP[0] = 20;
        playerMaxXP[1] = 30;
        playerMaxXP[2] = 50;
        playerMaxXP[3] = 80;
        playerMaxXP[4] = 130;
        playerMaxXP[5] = 210;
        playerMaxXP[6] = 340;
        playerMaxXP[7] = 550;
        playerMaxXP[8] = 890;
        playerMaxXP[9] = 1440;
        playerMaxXP[10] = 2330;
        playerMaxXP[11] = 3770;
        playerMaxXP[12] = 6100;
        playerMaxXP[13] = 8970;
        playerMaxXP[14] = 15970;
        
    }
	
	void Update ()
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
        enemiesList.Add(obj);
    }
}
