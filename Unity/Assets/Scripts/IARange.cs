using UnityEngine;
using System.Collections;

public class IARange : MonoBehaviour
{
    /*public GameObject           arrow;
   
    public Sprite               leftDeath1;
    public Sprite               leftDeath2;
    public Sprite               leftDeath3;
    public Sprite               leftDeath4;
    public Sprite               leftDeath5;
    public Sprite               leftAttack1;
    public Sprite               leftAttack2;
    public Sprite               leftAttack3;

    public Sprite               rightDeath1;
    public Sprite               rightDeath2;
    public Sprite               rightDeath3;
    public Sprite               rightDeath4;
    public Sprite               rightDeath5;
    public Sprite               rightAttack1;
    public Sprite               rightAttack2;
    public Sprite               rightAttack3;

    public Sprite               rightIdle;
    public Sprite               leftIdle;
    public Sprite               topIdle;
    public Sprite               topRightIdle;
    public Sprite               topLeftIdle;
    public Sprite               botIdle;
    public Sprite               botRightIdle;
    public Sprite               botLeftIdle;

    public GameObject           healthBarGreen;

    private GameObject          player;
    private GameObject          gm;
    private float               attackTimer = 0f;
    private float               attackCooldown = 1f;
    private bool                isAttackCC = false;
    private float               timerCC = 0f;
    private float               cooldownCC = 0f;
    private float               timerFlying = 0f;
    private float               cooldownFlying = 0f;

    private int                 currHP;
    public int                  maxHP;
    public int                  damage;
    public int                  valueXP;
    private float               speed = 1f;
    private float               slow = 0f;
    private Vector2             baseScale;
    private Vector2             newScale;
    private Vector2             initialScale;
    private bool                isDead = false;
    private bool                isFlying = false;
    private bool                isAttacking = false;
    private bool                canAttack = true;
    private int                 lastDragonTaken = -1;
    public  Shoots.Direction    directionAttack;

    void Start()
    {
        initialScale = transform.localScale;
        gm = GameObject.Find("GameManager");
        currHP = maxHP;
        baseScale = healthBarGreen.transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (isAttackCC == true)
            {
                timerCC += Time.deltaTime;
                if (timerCC > cooldownCC)
                {
                    canAttack = true;
                    isAttackCC = false;
                    timerCC = 0f;
                }

            }
            if (isFlying == true)
            {
                Vector2 newScaleGo = new Vector2(transform.localScale.x + 0.002f, transform.localScale.y + 0.002f);
                transform.localScale = newScaleGo;
                timerFlying += Time.deltaTime;
                if (timerFlying > cooldownFlying)
                {
                    canAttack = true;
                    timerFlying = 0f;
                    isFlying = false;
                    transform.localScale = initialScale;
                }
            }
            if (isDead == false && player.GetComponent<Deplacements>().isDead == false)
            {
                if (isAttacking == false &&
                    canAttack == false &&
                    isAttackCC == false &&
                    isFlying == false)
                {
                    attackTimer += Time.deltaTime;
                    if (attackTimer > attackCooldown)
                    {
                        attackTimer = 0f;
                        canAttack = true;
                    }
                }
                if (Vector2.Distance(player.transform.position, transform.position) <= 5.5f &&
                    player.GetComponent<Deplacements>().isDead == false)
                {
                    if (canAttack == true)
                    {
                        isAttacking = true;
                        canAttack = false;
                        StartCoroutine(AttackAnimation(player.transform.position));
                    }
                    else if (isAttacking == false)
                    {
                        if (directionAttack == Shoots.Direction.LEFT)
                            GetComponent<SpriteRenderer>().sprite = leftIdle;
                        else
                            GetComponent<SpriteRenderer>().sprite = rightIdle;
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
            other.GetComponent<Projectile>().ExplosionChar();
        }
        else if (other.tag == "IceShard")
        {
            TakeDamageFromPlayer(other.GetComponent<IceShard>().damage, other.transform.position);
            other.GetComponent<IceShard>().ExplosionChar();
        }
        else if (other.tag == "DragonDeFeu" &&
                lastDragonTaken != other.GetComponent<DragonDeFeu>().id)
        {
            TakeDamageFromPlayer(other.GetComponent<DragonDeFeu>().damage, other.transform.position);
            lastDragonTaken = other.GetComponent<DragonDeFeu>().id;
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
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
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<CircleCollider2D>());
            StartCoroutine(DeathAnimation(damagePos));
        }
    }

    public void Fly(float duration)
    {
        cooldownFlying = duration;
        canAttack = false;
        isFlying = true;
        ApplyCC(duration);
    }

    public void ApplyCC(float duration)
    {
        canAttack = false;
        isAttackCC = true;
        cooldownCC = duration;
        timerCC = 0f;
    }

    void FindShootDirection()
    {
        Vector2 newPosTarget = player.transform.position;
        Vector2 newPosTop = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 newPosTopRight = new Vector2(transform.position.x + 0.8f, transform.position.y + 0.8f);
        Vector2 newPosTopLeft = new Vector2(transform.position.x - 0.8f, transform.position.y + 0.8f);
        Vector2 newPosBot = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 newPosBotRight = new Vector2(transform.position.x + 0.8f, transform.position.y - 0.8f);
        Vector2 newPosBotLeft = new Vector2(transform.position.x - 0.8f, transform.position.y - 0.8f);
        Vector2 newPosRight = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 newPosLeft = new Vector2(transform.position.x - 1, transform.position.y);

        float distanceTop = Vector2.Distance(newPosTop, newPosTarget);
        float distanceTopRight = Vector2.Distance(newPosTopRight, newPosTarget);
        float distanceTopLeft = Vector2.Distance(newPosTopLeft, newPosTarget);
        float distanceBot = Vector2.Distance(newPosBot, newPosTarget);
        float distanceBotRight = Vector2.Distance(newPosBotRight, newPosTarget);
        float distanceBotLeft = Vector2.Distance(newPosBotLeft, newPosTarget);
        float distanceRight = Vector2.Distance(newPosRight, newPosTarget);
        float distanceLeft = Vector2.Distance(newPosLeft, newPosTarget);

        if (distanceRight < distanceTop &&
            distanceRight < distanceBot &&
            distanceRight < distanceLeft &&
            distanceRight < distanceTopRight &&
            distanceRight < distanceTopLeft &&
            distanceRight < distanceBotRight &&
            distanceRight < distanceBotLeft)
            directionAttack = Shoots.Direction.RIGHT;
        else if (distanceLeft < distanceTop &&
            distanceLeft < distanceBot &&
            distanceLeft < distanceRight &&
            distanceLeft < distanceTopRight &&
            distanceLeft < distanceTopLeft &&
            distanceLeft < distanceBotRight &&
            distanceLeft < distanceBotLeft)
            directionAttack = Shoots.Direction.LEFT;
        else if (distanceBot < distanceTop &&
            distanceBot < distanceLeft &&
            distanceBot < distanceRight &&
            distanceBot < distanceTopRight &&
            distanceBot < distanceTopLeft &&
            distanceBot < distanceBotRight &&
            distanceBot < distanceBotLeft)
            directionAttack = Shoots.Direction.BOTTOM;
        else if (distanceTop < distanceBot &&
            distanceTop < distanceLeft &&
            distanceTop < distanceRight &&
            distanceTop < distanceTopRight &&
            distanceTop < distanceTopLeft &&
            distanceTop < distanceBotRight &&
            distanceTop < distanceBotLeft)
            directionAttack = Shoots.Direction.TOP;
        else if (distanceTopRight < distanceBot &&
            distanceTopRight < distanceLeft &&
            distanceTopRight < distanceRight &&
            distanceTopRight < distanceTop &&
            distanceTopRight < distanceTopLeft &&
            distanceTopRight < distanceBotRight &&
            distanceTopRight < distanceBotLeft)
            directionAttack = Shoots.Direction.TOPRIGHT;
        else if (distanceTopLeft < distanceBot &&
            distanceTopLeft < distanceLeft &&
            distanceTopLeft < distanceRight &&
            distanceTopLeft < distanceTop &&
            distanceTopLeft < distanceTopRight &&
            distanceTopLeft < distanceBotRight &&
            distanceTopLeft < distanceBotLeft)
            directionAttack = Shoots.Direction.TOPLEFT;
        else if (distanceBotRight < distanceBot &&
            distanceBotRight < distanceLeft &&
            distanceBotRight < distanceRight &&
            distanceBotRight < distanceTop &&
            distanceBotRight < distanceTopRight &&
            distanceBotRight < distanceTopLeft &&
            distanceBotRight < distanceBotLeft)
            directionAttack = Shoots.Direction.BOTTOMRIGHT;
        else if (distanceBotLeft < distanceBot &&
            distanceBotLeft < distanceLeft &&
            distanceBotLeft < distanceRight &&
            distanceBotLeft < distanceTop &&
            distanceBotLeft < distanceTopRight &&
            distanceBotLeft < distanceTopLeft &&
            distanceBotLeft < distanceBotRight)
            directionAttack = Shoots.Direction.BOTTOMLEFT;
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

        gm.GetComponent<GameManager>().PopEnemy(GetComponent<Enemy>().id);

        Destroy(gameObject);
    }

    IEnumerator AttackAnimation(Vector2 directionPos)
    {
        FindShootDirection();

        if (directionAttack == Shoots.Direction.RIGHT)
            GetComponent<SpriteRenderer>().sprite = rightAttack1;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack1;
        yield return new WaitForSeconds(0.08f);

        if (directionAttack == Shoots.Direction.RIGHT)
            GetComponent<SpriteRenderer>().sprite = rightAttack2;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack2;
        yield return new WaitForSeconds(0.08f);

        if (directionAttack == Shoots.Direction.RIGHT)
            GetComponent<SpriteRenderer>().sprite = rightAttack3;
        else
            GetComponent<SpriteRenderer>().sprite = leftAttack3;
        yield return new WaitForSeconds(0.08f);

        player.GetComponent<StatsPlayer>().TakeDamage(damage, transform.position);
        isAttacking = false;
        canAttack = false;

        if (directionAttack == Shoots.Direction.RIGHT)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
    }*/
}
