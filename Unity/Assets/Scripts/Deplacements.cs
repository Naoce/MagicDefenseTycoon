using UnityEngine;
using System.Collections;

public class Deplacements : MonoBehaviour 
{
    public  GameObject  cam;
    private GameObject  gm;
    private GameObject  mapManager;
    public  float       speed;
    private float       celerityRuneBonus;
    public  float       movementBonus;
    private float       timerMovementBonus = 0f;

    public Sprite leftIdle;
    public Sprite left1;
    public Sprite left2;
    public Sprite left3;
    public Sprite left4;

    public Sprite leftAttack1;
    public Sprite leftAttack2;
    public Sprite leftAttack3;
    public Sprite leftAttack4;

    public Sprite rightIdle;
    public Sprite right1;
    public Sprite right2;
    public Sprite right3;
    public Sprite right4;

    public Sprite rightAttack1;
    public Sprite rightAttack2;
    public Sprite rightAttack3;
    public Sprite rightAttack4;

    public Sprite topIdle;
    public Sprite top1;
    public Sprite top2;
    public Sprite top3;
    public Sprite top4;

    public Sprite topAttack1;
    public Sprite topAttack2;
    public Sprite topAttack3;
    public Sprite topAttack4;

    public Sprite botIdle;
    public Sprite bot1;
    public Sprite bot2;
    public Sprite bot3;
    public Sprite bot4;

    public Sprite botAttack1;
    public Sprite botAttack2;
    public Sprite botAttack3;
    public Sprite botAttack4;

    private Vector3 	            newPosition = new Vector3(0, 0, 0);
    private Vector3                 newPosCam = new Vector3(0, 0, -10);
    public  int                     currentNumeroAnim = 1;
    private float                   timer = 0f;
    private float                   animTime = 0.08f;
    private bool                    isMovingHorizontally = false;
    public  bool                    isAttacking = false;
    public  Shoots.Direction        attackDirection;
    private Shoots.Direction        movementDirection = Shoots.Direction.TOP;
    public  bool                    isDead = false;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        cam = GameObject.Find("Main Camera");
        mapManager = GameObject.Find("MapManager");
    }

    void Update()
    {
        if (isDead == false &&
            gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (movementBonus != 0f)
            {
                timerMovementBonus += Time.deltaTime;
                if (timerMovementBonus >= 1f)
                {
                    timerMovementBonus = 0f;
                    movementBonus = 1f;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                isMovingHorizontally = true;

                if ((Input.GetKey(KeyCode.Z) &&
                    gm.GetComponent<GameManager>().zqsdMode == true) ||
                    (Input.GetKey(KeyCode.W) &&
                    gm.GetComponent<GameManager>().zqsdMode == false))
                    newPosition = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.y / 1000f);
                else if (Input.GetKey(KeyCode.S))
                    newPosition = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.y / 1000f);
                else
                    newPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.y / 1000f);

                if (newPosition.x > mapManager.GetComponent<MapManager>().LimitD)
                    newPosition.x = mapManager.GetComponent<MapManager>().LimitD;

                if (newPosition.y > mapManager.GetComponent<MapManager>().LimitH)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitH;

                if (newPosition.y < mapManager.GetComponent<MapManager>().LimitB)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitB;

                if (GetComponent<Shoots>().isRuneCelerity == true)
                    celerityRuneBonus = 1 + (((float)GetComponent<StatsPlayer>().level / (float)100) * 2);
                else
                    celerityRuneBonus = 1;

                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed * celerityRuneBonus * movementBonus);

                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    if (isAttacking == true)
                        AttackAnimation();
                    else
                    {
                        movementDirection = Shoots.Direction.RIGHT;
                        if (currentNumeroAnim == 1)
                        {
                            GetComponent<SpriteRenderer>().sprite = right1;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 2)
                        {
                            GetComponent<SpriteRenderer>().sprite = right2;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 3)
                        {
                            GetComponent<SpriteRenderer>().sprite = right3;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 4)
                        {
                            GetComponent<SpriteRenderer>().sprite = right4;
                            currentNumeroAnim++;
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                    }
                    timer = 0f;
                }
            }
            else if ((Input.GetKey(KeyCode.Q) &&
                    gm.GetComponent<GameManager>().zqsdMode == true) ||
                    (Input.GetKey(KeyCode.A) &&
                    gm.GetComponent<GameManager>().zqsdMode == false))
            {
                isMovingHorizontally = true;

                if ((Input.GetKey(KeyCode.Z) &&
                    gm.GetComponent<GameManager>().zqsdMode == true) ||
                    (Input.GetKey(KeyCode.W) &&
                    gm.GetComponent<GameManager>().zqsdMode == false))
                    newPosition = new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.y / 1000f);
                else if (Input.GetKey(KeyCode.S))
                    newPosition = new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.y / 1000f);
                else
                    newPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.y / 1000f);

                if (newPosition.x < mapManager.GetComponent<MapManager>().LimitG)
                    newPosition.x = mapManager.GetComponent<MapManager>().LimitG;

                if (newPosition.y > mapManager.GetComponent<MapManager>().LimitH)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitH;

                if (newPosition.y < mapManager.GetComponent<MapManager>().LimitB)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitB;

                if (GetComponent<Shoots>().isRuneCelerity == true)
                    celerityRuneBonus = 1 + (((float)GetComponent<StatsPlayer>().level / (float)100) * 2);
                else
                    celerityRuneBonus = 1;

                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed * celerityRuneBonus * movementBonus);

                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    if (isAttacking == true)
                        AttackAnimation();
                    else
                    {
                        movementDirection = Shoots.Direction.LEFT;
                        if (currentNumeroAnim == 1)
                        {
                            GetComponent<SpriteRenderer>().sprite = left1;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 2)
                        {
                            GetComponent<SpriteRenderer>().sprite = left2;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 3)
                        {
                            GetComponent<SpriteRenderer>().sprite = left3;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 4)
                        {
                            GetComponent<SpriteRenderer>().sprite = left4;
                            currentNumeroAnim++;
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                    }
                    timer = 0f;
                }
            }
            else
                isMovingHorizontally = false;
            if (((Input.GetKey(KeyCode.Z) &&
                    gm.GetComponent<GameManager>().zqsdMode == true) ||
                    (Input.GetKey(KeyCode.W) &&
                    gm.GetComponent<GameManager>().zqsdMode == false)) &&
                    isMovingHorizontally == false)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.y / 1000f);

                if (newPosition.y > mapManager.GetComponent<MapManager>().LimitH)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitH;

                if (GetComponent<Shoots>().isRuneCelerity == true)
                    celerityRuneBonus = 1 + (((float)GetComponent<StatsPlayer>().level / (float)100) * 2);
                else
                    celerityRuneBonus = 1;

                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed * celerityRuneBonus * movementBonus);

                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    if (isAttacking == true)
                        AttackAnimation();
                    else
                    {
                        movementDirection = Shoots.Direction.TOP;
                        if (currentNumeroAnim == 1)
                        {
                            GetComponent<SpriteRenderer>().sprite = top1;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 2)
                        {
                            GetComponent<SpriteRenderer>().sprite = top2;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 3)
                        {
                            GetComponent<SpriteRenderer>().sprite = top3;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 4)
                        {
                            GetComponent<SpriteRenderer>().sprite = top4;
                            currentNumeroAnim++;
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                    }
                    timer = 0f;
                }
            }
            else if (Input.GetKey(KeyCode.S) &&
                    isMovingHorizontally == false)
            {
                newPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.y / 1000f);

                if (newPosition.y < mapManager.GetComponent<MapManager>().LimitB)
                    newPosition.y = mapManager.GetComponent<MapManager>().LimitB;

                if (GetComponent<Shoots>().isRuneCelerity == true)
                    celerityRuneBonus = 1 + (((float)GetComponent<StatsPlayer>().level / (float)100) * 2);
                else
                    celerityRuneBonus = 1;

                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed * celerityRuneBonus * movementBonus);

                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    if (isAttacking == true)
                        AttackAnimation();
                    else
                    {
                        movementDirection = Shoots.Direction.BOTTOM;
                        if (currentNumeroAnim == 1)
                        {
                            GetComponent<SpriteRenderer>().sprite = bot1;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 2)
                        {
                            GetComponent<SpriteRenderer>().sprite = bot2;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 3)
                        {
                            GetComponent<SpriteRenderer>().sprite = bot3;
                            currentNumeroAnim++;
                        }
                        else if (currentNumeroAnim == 4)
                        {
                            GetComponent<SpriteRenderer>().sprite = bot4;
                            currentNumeroAnim++;
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                    }
                    timer = 0f;
                }
            }
            else if (isAttacking == true &&
            (isMovingHorizontally == false))
            {
                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    AttackAnimation();
                    timer = 0f;
                }
            }
            else if (isAttacking == false &&
                (isMovingHorizontally == false))
            {
                timer += Time.deltaTime;
                if (timer >= animTime)
                {
                    if (movementDirection == Shoots.Direction.BOTTOM)
                        GetComponent<SpriteRenderer>().sprite = botIdle;
                    else if (movementDirection == Shoots.Direction.TOP)
                        GetComponent<SpriteRenderer>().sprite = topIdle;
                    else if (movementDirection == Shoots.Direction.RIGHT)
                        GetComponent<SpriteRenderer>().sprite = rightIdle;
                    else if (movementDirection == Shoots.Direction.LEFT)
                        GetComponent<SpriteRenderer>().sprite = leftIdle;
                    timer = 0f;
                }
            }

            newPosCam.x = transform.position.x;
            if (newPosCam.x < mapManager.GetComponent<MapManager>().LimitG + 5f)
                newPosCam.x = mapManager.GetComponent<MapManager>().LimitG + 5f;
            else if (newPosCam.x > mapManager.GetComponent<MapManager>().LimitD - 5f)
                newPosCam.x = mapManager.GetComponent<MapManager>().LimitD - 5f;

            newPosCam.y = transform.position.y;
            if (newPosCam.y < mapManager.GetComponent<MapManager>().LimitB + 2.6f)
                newPosCam.y = mapManager.GetComponent<MapManager>().LimitB + 2.6f;
            else if (newPosCam.y > mapManager.GetComponent<MapManager>().LimitH - 2.7f)
                newPosCam.y = mapManager.GetComponent<MapManager>().LimitH - 2.7f;

            cam.transform.position = newPosCam;
        }
    }

    public void SetMovementBonus()
    {
        movementBonus = 1 + GetComponent<Shoots>().movementBonus;
        timer = 0f;
    }

    void AttackAnimation()
    {
        if (attackDirection == Shoots.Direction.RIGHT ||
            attackDirection == Shoots.Direction.TOPRIGHT ||
            attackDirection == Shoots.Direction.BOTTOMRIGHT)
        {
            if (currentNumeroAnim == 1)
            {
                GetComponent<SpriteRenderer>().sprite = rightAttack1;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 2)
            {
                GetComponent<SpriteRenderer>().sprite = rightAttack2;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 3)
            {
                GetComponent<SpriteRenderer>().sprite = rightAttack3;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 4)
            {
                GetComponent<SpriteRenderer>().sprite = rightAttack4;
                currentNumeroAnim++;
            }
            if (currentNumeroAnim == 5)
            {
                currentNumeroAnim = 1;
                SetMovementDirection();
                isAttacking = false;
            }
        }
        else if (attackDirection == Shoots.Direction.LEFT ||
            attackDirection == Shoots.Direction.TOPLEFT ||
            attackDirection == Shoots.Direction.BOTTOMLEFT)
        {
            if (currentNumeroAnim == 1)
            {
                GetComponent<SpriteRenderer>().sprite = leftAttack1;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 2)
            {
                GetComponent<SpriteRenderer>().sprite = leftAttack2;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 3)
            {
                GetComponent<SpriteRenderer>().sprite = leftAttack3;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 4)
            {
                GetComponent<SpriteRenderer>().sprite = leftAttack4;
                currentNumeroAnim++;
            }
            if (currentNumeroAnim == 5)
            {
                currentNumeroAnim = 1;
                SetMovementDirection();
                isAttacking = false;
            }
        }
        else if (attackDirection == Shoots.Direction.TOP)
        {
            if (currentNumeroAnim == 1)
            {
                GetComponent<SpriteRenderer>().sprite = topAttack1;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 2)
            {
                GetComponent<SpriteRenderer>().sprite = topAttack2;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 3)
            {
                GetComponent<SpriteRenderer>().sprite = topAttack3;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 4)
            {
                GetComponent<SpriteRenderer>().sprite = topAttack4;
                currentNumeroAnim++;
            }
            if (currentNumeroAnim == 5)
            {
                currentNumeroAnim = 1;
                SetMovementDirection();
                isAttacking = false;
            }
        }
        else if (attackDirection == Shoots.Direction.BOTTOM)
        {
            if (currentNumeroAnim == 1)
            {
                GetComponent<SpriteRenderer>().sprite = botAttack1;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 2)
            {
                GetComponent<SpriteRenderer>().sprite = botAttack2;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 3)
            {
                GetComponent<SpriteRenderer>().sprite = botAttack3;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 4)
            {
                GetComponent<SpriteRenderer>().sprite = botAttack4;
                currentNumeroAnim++;
            }
            if (currentNumeroAnim == 5)
            {
                currentNumeroAnim = 1;
                SetMovementDirection();
                isAttacking = false;
            }
        }
    }

    void SetMovementDirection()
    {
        if (attackDirection == Shoots.Direction.TOP)
            movementDirection = Shoots.Direction.TOP;
        else if (attackDirection == Shoots.Direction.TOPLEFT ||
                attackDirection == Shoots.Direction.BOTTOMLEFT ||
                attackDirection == Shoots.Direction.LEFT)
            movementDirection = Shoots.Direction.LEFT;
        else if (attackDirection == Shoots.Direction.TOPRIGHT ||
                attackDirection == Shoots.Direction.BOTTOMRIGHT ||
                attackDirection == Shoots.Direction.RIGHT)
            movementDirection = Shoots.Direction.RIGHT;
        else if (attackDirection == Shoots.Direction.BOTTOM)
            movementDirection = Shoots.Direction.BOTTOM;
    }
}
