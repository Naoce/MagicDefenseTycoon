using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMeleeBasic : MonoBehaviour
{
    private GameObject gm;
    private GameObject gameManager;

    void Start()
    {
        gm = GameObject.Find("MapManager");
        gameManager = gm.GetComponent<MapManager>().gm;
    }

    void Update()
    {
        if (gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (GetComponent<IAGuerrier>().type == IAGuerrier.EnemyType.Magician &&
                GetComponent<IAGuerrier>().hasLaunched == false &&
                GetComponent<IAGuerrier>().target != null)
            {
                GetComponent<IAGuerrier>().hasLaunched = true;
                GetComponent<IAGuerrier>().InstantiateCheck(GetComponent<IAGuerrier>().target.transform.position);
            }
            if (GetComponent<IAGuerrier>().isSlowed == true)
            {
                GetComponent<IAGuerrier>().timerSlow += Time.deltaTime;
                if (GetComponent<IAGuerrier>().timerSlow > GetComponent<IAGuerrier>().cooldownSlow)
                {
                    GetComponent<IAGuerrier>().timerSlow = 0f;
                    GetComponent<IAGuerrier>().slow = 0f;
                    GetComponent<IAGuerrier>().isSlowed = false;
                }
            }
            if (GetComponent<IAGuerrier>().canMove == false)
            {
                GetComponent<IAGuerrier>().timerCC += Time.deltaTime;
                if (GetComponent<IAGuerrier>().timerCC > GetComponent<IAGuerrier>().cooldownCC)
                {
                    GetComponent<IAGuerrier>().canAttack = true;
                    GetComponent<IAGuerrier>().canMove = true;
                    GetComponent<IAGuerrier>().timerCC = 0f;
                }
                if (GetComponent<IAGuerrier>().isFlying == true)
                {
                    GetComponent<IAGuerrier>().timerFlying += Time.deltaTime;
                    if (GetComponent<IAGuerrier>().flyingLeft == true)
                    {
                        if (GetComponent<IAGuerrier>().tornado != null)
                        {
                            Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().tornado.transform.position.x - 1f, transform.position.y, transform.position.y / 100);
                            transform.Translate(new Vector3(0f, -(GetComponent<IAGuerrier>().tornado.transform.position.x - transform.position.x) / 50f, 0f));
                            transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * 1.5f);
                            if (transform.position.x < GetComponent<IAGuerrier>().tornado.transform.position.x - 0.25f)
                                GetComponent<IAGuerrier>().flyingLeft = false;
                        }
                    }
                    else
                    {
                        if (GetComponent<IAGuerrier>().tornado != null)
                        {
                            Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().tornado.transform.position.x + 1f, transform.position.y, transform.position.y / 100);
                            transform.Translate(new Vector3(0f, -(GetComponent<IAGuerrier>().tornado.transform.position.x - transform.position.x) / 50f, 0f));
                            transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * 1.5f);
                            if (transform.position.x > GetComponent<IAGuerrier>().tornado.transform.position.x + 0.25f)
                                GetComponent<IAGuerrier>().flyingLeft = true;
                        }
                    }

                    if (GetComponent<IAGuerrier>().timerFlying > GetComponent<IAGuerrier>().cooldownFlying)
                    {
                        GetComponent<IAGuerrier>().canAttack = true;
                        GetComponent<IAGuerrier>().timerFlying = 0f;
                        GetComponent<IAGuerrier>().isFlying = false;
                    }
                }
            }
            if (GetComponent<Enemy>().isDead == false && GetComponent<IAGuerrier>().player.GetComponent<Deplacements>().isDead == false &&
                GetComponent<IAGuerrier>().canMove == true)
            {
                GetComponent<IAGuerrier>().target = GetComponent<IAGuerrier>().FindClosestTarget();
                if (GetComponent<IAGuerrier>().isAttacking == false &&
                    GetComponent<IAGuerrier>().canAttack == false)
                {
                    GetComponent<IAGuerrier>().attackTimer += Time.deltaTime;
                    if (GetComponent<IAGuerrier>().attackTimer > GetComponent<IAGuerrier>().attackCooldown)
                    {
                        GetComponent<IAGuerrier>().attackTimer = 0f;
                        GetComponent<IAGuerrier>().canAttack = true;
                    }
                }
                if (Vector2.Distance(GetComponent<IAGuerrier>().target.transform.position, transform.position) <= GetComponent<IAGuerrier>().range &&
                    ((GetComponent<IAGuerrier>().target.tag == "Player" &&
                    GetComponent<IAGuerrier>().target.GetComponent<Deplacements>().isDead == false) ||
                    (GetComponent<IAGuerrier>().target.tag == "AgentGuerrier" &&
                    GetComponent<IAGuerrier>().target.GetComponent<IAGuerrierAgent>().isDead == false) ||
                    (GetComponent<IAGuerrier>().target.tag == "Defense" &&
                    GetComponent<IAGuerrier>().target.GetComponent<Defense>().isDead == false)))
                {
                    if (GetComponent<IAGuerrier>().type == IAGuerrier.EnemyType.Magician &&
                        GetComponent<IAGuerrier>().canShootProjectile == false)
                        GetComponent<IAGuerrier>().needToMove = true;
                    else
                    {
                        GetComponent<IAGuerrier>().needToMove = false;
                        if (GetComponent<IAGuerrier>().canAttack == true)
                        {
                            GetComponent<IAGuerrier>().isAttacking = true;
                            GetComponent<IAGuerrier>().targetAttacking = GetComponent<IAGuerrier>().target;
                            GetComponent<IAGuerrier>().canAttack = false;
                            if (GetComponent<IAGuerrier>().type != IAGuerrier.EnemyType.Magician)
                                StartCoroutine(GetComponent<IAGuerrier>().AttackAnimation(GetComponent<IAGuerrier>().target.transform.position));
                            else if (GetComponent<IAGuerrier>().type == IAGuerrier.EnemyType.Magician &&
                                    GetComponent<IAGuerrier>().canShootProjectile == true)
                                StartCoroutine(GetComponent<IAGuerrier>().AttackDistanceAnimation(GetComponent<IAGuerrier>().target.transform.position));
                        }
                        else if (GetComponent<IAGuerrier>().isAttacking == false)
                        {
                            if (GetComponent<IAGuerrier>().rightSide == true)
                            {
                                GetComponent<SpriteRenderer>().flipX = false;
                                GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightIdle;
                            }
                            else
                            {
                                GetComponent<SpriteRenderer>().flipX = true;
                                GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightIdle;
                            }
                        }
                    }
                }
                else
                    GetComponent<IAGuerrier>().needToMove = true;
                if (GetComponent<IAGuerrier>().isAttacking == false && GetComponent<IAGuerrier>().needToMove == true)
                {
                    GetComponent<IAGuerrier>().timer += Time.deltaTime;

                    GameObject targetTmp = GetComponent<IAGuerrier>().FindClosestTarget();
                    if (targetTmp != GetComponent<IAGuerrier>().target)
                    {
                        GetComponent<IAGuerrier>().target = targetTmp;
                        GetComponent<IAGuerrier>().changedTarget = true;
                    }

                    if (GetComponent<IAGuerrier>().changedTarget == true ||
                        Vector2.Distance(GetComponent<IAGuerrier>().newPos, transform.position) <= 0.05f ||
                        Vector2.Distance(GetComponent<IAGuerrier>().newPos, transform.position) >= 1f ||
                        Vector2.Distance(transform.position, GetComponent<IAGuerrier>().target.transform.position) <= 1f)
                    {
                        GetComponent<IAGuerrier>().changedTarget = false;

                        if (GetComponent<IAGuerrier>().target != null)
                            GetComponent<IAGuerrier>().newPos = GetComponent<AStar>().StartPathFinding(GetComponent<IAGuerrier>().target.transform.position);
                    }

                    Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().newPos.x, GetComponent<IAGuerrier>().newPos.y, GetComponent<IAGuerrier>().newPos.y / 100);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * (GetComponent<IAGuerrier>().speed - GetComponent<IAGuerrier>().slow));

                    if (GetComponent<IAGuerrier>().timer > GetComponent<IAGuerrier>().animTime &&
                    (transform.position.y != GetComponent<IAGuerrier>().newPos.y ||
                    transform.position.x != GetComponent<IAGuerrier>().newPos.x))
                    {
                        if (transform.position.x > GetComponent<IAGuerrier>().target.transform.position.x)
                        {
                            GetComponent<SpriteRenderer>().flipX = true;
                            GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightSprites[GetComponent<IAGuerrier>().currentNumeroAnim++];
                        }
                        else
                        {
                            GetComponent<SpriteRenderer>().flipX = false;
                            GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightSprites[GetComponent<IAGuerrier>().currentNumeroAnim++];
                        }

                        if (GetComponent<IAGuerrier>().currentNumeroAnim == GetComponent<IAGuerrier>().rightSprites.Length)
                            GetComponent<IAGuerrier>().currentNumeroAnim = 0;
                        GetComponent<IAGuerrier>().timer = 0f;
                    }
                }
            }
        }
    }
}
