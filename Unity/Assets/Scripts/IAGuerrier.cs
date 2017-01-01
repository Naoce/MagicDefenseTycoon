using UnityEngine;
using System.Collections;

public class IAGuerrier : MonoBehaviour 
{
    public  Sprite      leftIdle;
    public	Sprite 		left1;
	public	Sprite 		left2;
	public	Sprite 		left3;
	public	Sprite 		left4;
    public  Sprite      leftDeath1;
    public  Sprite      leftDeath2;
    public  Sprite      leftDeath3;
    public  Sprite      leftDeath4;
    public  Sprite      leftDeath5;
    public  Sprite      leftAttack1;
    public  Sprite      leftAttack2;
    public  Sprite      leftAttack3;

    public  Sprite      rightIdle;
    public	Sprite 		right1;
	public	Sprite 		right2;
	public	Sprite 		right3;
	public	Sprite 		right4;
    public  Sprite      rightDeath1;
    public  Sprite      rightDeath2;
    public  Sprite      rightDeath3;
    public  Sprite      rightDeath4;
    public  Sprite      rightDeath5;
    public  Sprite      rightAttack1;
    public  Sprite      rightAttack2;
    public  Sprite      rightAttack3;

    public  Sprite      topIdle;
    public  Sprite      top1;
    public  Sprite      top2;
    public  Sprite      top3;
    public  Sprite      top4;

    public  Sprite      botIdle;
    public  Sprite      bot1;
    public  Sprite      bot2;
    public  Sprite      bot3;
    public  Sprite      bot4;

    public GameObject   healthBarGreen;

    private	GameObject	player;
	public  Vector2 	newPos = new Vector2(0, 0);
    public  Vector2     obstaclePos = new Vector2(0, 0);
    public  bool        isBypassing = false;
    public  GameObject  lastObstacle = null;
    public  int         lastObstacleCorner = 0;
    private int         currentNumeroAnim = 1;
	private	float		timer = 0f;
	private float		animTime = 0.12f;
    private float       attackTimer = 0f;
    private float       attackCooldown = 1f;

    private int         currHP;
    public  int         maxHP;
    public  int         damage;
    public  int         valueXP;
    private Vector2     baseScale;
    private Vector2     newScale;
    private bool        isDead = false;
    private bool        isAttacking = false;
    private bool        canAttack = true;
    private bool        rightSide = false;
    private bool        needToMove = true;

	void Start () 
	{
        currHP = maxHP;
        baseScale = healthBarGreen.transform.localScale;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{
        if (isDead == false)
        {
            if (isAttacking == false && 
                canAttack == false)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer > attackCooldown)
                {
                    attackTimer = 0f;
                    canAttack = true;
                }
            }
            if (Vector2.Distance(player.transform.position, transform.position) <= 0.51f &&
                player.GetComponent<Deplacements>().isDead == false)
            {
                needToMove = false;
                if (canAttack == true)
                {
                    isAttacking = true;
                    canAttack = false;
                    StartCoroutine(AttackAnimation(player.transform.position));
                }
                else if (isAttacking == false)
                {
                    if (rightSide == true)
                        GetComponent<SpriteRenderer>().sprite = leftIdle;
                    else
                        GetComponent<SpriteRenderer>().sprite = rightIdle;
                }
            }
            else
                needToMove = true;
            if (isAttacking == false && needToMove == true)
            {
                timer += Time.deltaTime;
                if (transform.position.x == obstaclePos.x &&
                        transform.position.y == obstaclePos.y)
                    isBypassing = false;
                if (isBypassing == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, obstaclePos, Time.deltaTime);
                    if (timer > animTime &&
                    (transform.position.y != obstaclePos.y ||
                    transform.position.x != obstaclePos.x))
                    {
                        if (((rightSide == true &&
                            obstaclePos.x > transform.position.x) ||
                            (rightSide == false &&
                            obstaclePos.x < transform.position.x)) &&
                            obstaclePos.y < transform.position.y)
                        {
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
                        }
                        else if (((rightSide == true &&
                            obstaclePos.x > transform.position.x) ||
                            (rightSide == false &&
                            obstaclePos.x < transform.position.x)) &&
                            obstaclePos.y > transform.position.y)
                        {
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
                        }
                        else if (obstaclePos.x < transform.position.x)
                        {
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
                        }
                        else
                        {
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
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                        timer = 0f;
                    }
                }
                else
                {
                    if (transform.position.x < player.transform.position.x)
                    {
                        rightSide = false;
                        newPos = new Vector2(player.transform.position.x - 0.5f, player.transform.position.y);
                    }
                    else
                    {
                        rightSide = true;
                        newPos = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y);
                    }
                    transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime);
                    if (timer > animTime &&
                    (transform.position.y != newPos.y ||
                    transform.position.x != newPos.x))
                    {
                        if (((rightSide == true &&
                            newPos.x > transform.position.x) ||
                            (rightSide == false &&
                            newPos.x < transform.position.x)) &&
                            newPos.y < transform.position.y)
                        {
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
                        }
                        else if (((rightSide == true &&
                            newPos.x > transform.position.x) ||
                            (rightSide == false &&
                            newPos.x < transform.position.x)) &&
                            newPos.y > transform.position.y)
                        {
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
                        }
                        else if (newPos.x < transform.position.x)
                        {
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
                        }
                        else
                        {
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
                        }
                        if (currentNumeroAnim == 5)
                            currentNumeroAnim = 1;
                        timer = 0f;
                    }
                }       
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamageFromPlayer(other.GetComponent<Projectile>().damage, other.transform.position);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamageFromPlayer(int damageTaken, Vector2 damagePos)
    {
        currHP -= damageTaken;
        if (currHP < 0)
            currHP = 0;
        float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
        float diff;
        diff = baseScale.x * currHP / maxHP;
        newScale = new Vector2(diff, baseScale.y);
        healthBarGreen.transform.localScale = newScale;

        float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

        float difference = newValue - originalValue;

        healthBarGreen.transform.Translate(new Vector2(difference, 0));

        if (currHP == 0)
        {
            player.GetComponent<StatsPlayer>().EarnXP(valueXP);
            isDead = true;
            StartCoroutine(DeathAnimation(damagePos));
        }
    }

    IEnumerator DeathAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x < directionPos.x)
            animRight = false;
        else
            animRight = true;

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath1;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath1;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath2;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath2;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath3;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath3;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath4;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath4;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath5;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath5;
        yield return new WaitForSeconds(0.08f);

        Destroy(gameObject);
    }

    IEnumerator AttackAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x > directionPos.x)
        {
            rightSide = true;
            animRight = false;
        }
        else
        {
            rightSide = false;
            animRight = true;
        }

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightAttack1;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack1;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightAttack2;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack2;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightAttack3;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack3;
        yield return new WaitForSeconds(0.08f);

        player.GetComponent<StatsPlayer>().TakeDamage(damage, transform.position);
        isAttacking = false;
        canAttack = false;
        timer = 0.09f;

        if (rightSide == true)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
    }
}
