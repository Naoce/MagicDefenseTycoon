using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public  GameObject  gm;
    public  GameObject  mapManager;
    public  GameObject  playerElem;
    private GameObject  player;
    private GameObject  cam;
    public  Texture2D   cursorNormal;
    public  Texture2D   cursorRight;
    public  Texture2D   cursorWrong;
    public  CursorMode  cursorMode;
    private bool        cursorIsNormal = true;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        cam = GameObject.Find("Main Camera");

        Vector2 playerPos = mapManager.GetComponent<MapManager>().playerStartPos;
        player = (GameObject)Instantiate(playerElem, playerPos, transform.rotation);
        mapManager.GetComponent<MapManager>().player = player;
        mapManager.GetComponent<MapManager>().alliesList.Add(player);
        SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
    }

    public void SetNormalMouse(Vector2 pos)
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

    public void CheckMouse()
    {
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
            if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 2f)
            {
                RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                if (hit.collider != null)
                {
                    if ((hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier") && cursorIsNormal == false)
                    {
                        SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                        cursorIsNormal = true;
                    }
                    else if (hit.collider.tag != "EnemyGuerrier" && cursorIsNormal == true &&
                            hit.collider.tag != "BossGuerrier")
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
            if (Vector2.Distance(player.transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 2f)
            {
                RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                if (hit.collider != null)
                {
                    if ((hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier") && cursorIsNormal == false)
                    {
                        SetRightMouse(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition));
                        cursorIsNormal = true;
                    }
                    else if (hit.collider.tag != "EnemyGuerrier" && cursorIsNormal == true &&
                            hit.collider.tag != "BossGuerrier")
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
