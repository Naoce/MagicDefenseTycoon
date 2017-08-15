using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAArcher : MonoBehaviour
{
    private GameObject gm;
    public float timerFirstAttack;
    public float timerSecondAttack;
    public float timerThirdAttack;

    void Start()
    {
        gm = GameObject.Find("MapManager");
    }

    void Update()
    {
        if (gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (GetComponent<IAGuerrier>().type == IAGuerrier.EnemyType.Range &&
                GetComponent<IAGuerrier>().hasLaunched == false &&
                GetComponent<IAGuerrier>().target != null)
            {
                GetComponent<IAGuerrier>().hasLaunched = true;
                GetComponent<IAGuerrier>().InstantiateCheck(GetComponent<IAGuerrier>().target.transform.position);
            }
            if (GetComponent<IAGuerrier>().isSlowed == true)
            {
                GetComponent<IAGuerrier>().timerSlow += Time.deltaTime;
                if (GetComponent<IAGuerrier>().timerSlow >= GetComponent<IAGuerrier>().cooldownSlow)
                {
                    GetComponent<IAGuerrier>().timerSlow = 0f;
                    GetComponent<IAGuerrier>().slow = 0f;
                    GetComponent<IAGuerrier>().isSlowed = false;
                }
            }
            if (GetComponent<IAGuerrier>().canMove == false)
            {
                GetComponent<IAGuerrier>().timerCC += Time.deltaTime;
                if (GetComponent<IAGuerrier>().timerCC >= GetComponent<IAGuerrier>().cooldownCC)
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
                            Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().tornado.transform.position.x - 1f, transform.position.y, transform.position.y / 1000f);
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
                            Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().tornado.transform.position.x + 1f, transform.position.y, transform.position.y / 1000f);
                            transform.Translate(new Vector3(0f, -(GetComponent<IAGuerrier>().tornado.transform.position.x - transform.position.x) / 50f, 0f));
                            transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * 1.5f);
                            if (transform.position.x > GetComponent<IAGuerrier>().tornado.transform.position.x + 0.25f)
                                GetComponent<IAGuerrier>().flyingLeft = true;
                        }
                    }

                    if (GetComponent<IAGuerrier>().timerFlying >= GetComponent<IAGuerrier>().cooldownFlying)
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
                    if (GetComponent<IAGuerrier>().attackTimer >= GetComponent<IAGuerrier>().attackCooldown)
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
                    if (GetComponent<IAGuerrier>().type == IAGuerrier.EnemyType.Range &&
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
                            if (GetComponent<IAGuerrier>().canShootProjectile == true)
                                StartCoroutine(AttackDistanceAnimation(GetComponent<IAGuerrier>().target));
                        }
                        else if (GetComponent<IAGuerrier>().isAttacking == false)
                        {
                            if (GetComponent<IAGuerrier>().target.transform.position.x > transform.position.x)
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

                    Vector3 destPos = new Vector3(GetComponent<IAGuerrier>().newPos.x, GetComponent<IAGuerrier>().newPos.y, transform.position.y / 1000f);
                    transform.position = Vector3.MoveTowards(transform.position, destPos, Time.deltaTime * (GetComponent<IAGuerrier>().speed - GetComponent<IAGuerrier>().slow));

                    if (GetComponent<IAGuerrier>().timer >= GetComponent<IAGuerrier>().animTime &&
                    (transform.position.y != GetComponent<IAGuerrier>().newPos.y ||
                    transform.position.x != GetComponent<IAGuerrier>().newPos.x))
                    {
                        if (transform.position.x > GetComponent<IAGuerrier>().newPos.x)
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

    public IEnumerator AttackDistanceAnimation(GameObject targetAttacking)
    {
        GetComponent<IAGuerrier>().FindShootDirection(targetAttacking.transform.position);

        float timerEffect = 0f;
        bool attack1Landed = false;
        bool attack2Landed = false;
        bool attack3Landed = false;
        int animAttack = 0;
        while (animAttack < GetComponent<IAGuerrier>().rightAttackSprites.Length)
        {
            if (GetComponent<Enemy>().isDead == true)
                yield break;
            else
            {
                if (transform.position.x < targetAttacking.transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightAttackSprites[animAttack];
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    GetComponent<SpriteRenderer>().sprite = GetComponent<IAGuerrier>().rightAttackSprites[animAttack];
                }

                timerEffect += GetComponent<IAGuerrier>().animAttackCD;

                if (timerEffect >= timerFirstAttack && attack1Landed == false)
                {
                    attack1Landed = true;
                    InstantiateArrow(targetAttacking);
                }
                else if (GetComponent<IAGuerrier>().classID > 0 && timerEffect >= timerSecondAttack && attack2Landed == false)
                {
                    attack2Landed = true;
                    InstantiateArrow(targetAttacking);
                }
                else if (GetComponent<IAGuerrier>().classID > 1 && timerEffect >= timerThirdAttack && attack3Landed == false)
                {
                    attack3Landed = true;
                    InstantiateArrow(targetAttacking);
                }

                yield return new WaitForSeconds(GetComponent<IAGuerrier>().animAttackCD);
                animAttack++;
            }
        }

        if (GetComponent<Enemy>().isDead == false)
        {
            if (attack1Landed == false)
            {
                attack1Landed = true;
                InstantiateArrow(targetAttacking);
            }
            else if (GetComponent<IAGuerrier>().classID > 0 && attack2Landed == false)
            {
                attack2Landed = true;
                InstantiateArrow(targetAttacking);
            }
            else if (GetComponent<IAGuerrier>().classID > 1 && attack3Landed == false)
            {
                attack3Landed = true;
                InstantiateArrow(targetAttacking);
            }

            GetComponent<IAGuerrier>().isAttacking = false;
            GetComponent<IAGuerrier>().canAttack = false;
            GetComponent<IAGuerrier>().attackTimer = 0f;

            if (transform.position.x < targetAttacking.transform.position.x)
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

    private float FindAngle(Vector2 targetPosition)
    {
        Vector2 myPos = new Vector3(transform.position.x, transform.position.y);
        Vector3 dir = myPos - targetPosition;
        dir = transform.InverseTransformDirection(dir);

        return (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    }

    private void InstantiateArrow(GameObject targetAttacking)
    {
        GameObject obj = null;

        GetComponent<IAGuerrier>().newPos.x = transform.position.x;
        GetComponent<IAGuerrier>().newPos.y = transform.position.y;
        if (GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.RIGHT ||
            GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.TOPRIGHT ||
            GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.BOTTOMRIGHT)
            GetComponent<IAGuerrier>().newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.LEFT ||
            GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.TOPLEFT ||
            GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.BOTTOMLEFT)
            GetComponent<IAGuerrier>().newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.BOTTOM)
            GetComponent<IAGuerrier>().newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<IAGuerrier>().directionAttack == Shoots.Direction.TOP)
            GetComponent<IAGuerrier>().newPos.y = transform.position.y + 0.1f;

        if (GetComponent<Enemy>().isDead == false)
        {
            obj = (GameObject)Instantiate(GetComponent<IAGuerrier>().projectile, GetComponent<IAGuerrier>().newPos, transform.rotation);
            obj.GetComponent<ArrowEnemy>().GetPos(targetAttacking.transform.position, GetComponent<IAGuerrier>().damage[GetComponent<IAGuerrier>().difficulty], FindAngle(targetAttacking.transform.position) + 180f, gameObject);
        }
    }
}
