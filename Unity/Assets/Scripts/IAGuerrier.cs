using UnityEngine;
using System.Collections;

public class IAGuerrier : MonoBehaviour 
{
    public enum EnemyType
    {
        Normal,
        Player,
        Objectif,
        Magician
    };

    public  Sprite[]    leftSprites;
    public  Sprite      leftIdle;
    public  Sprite[]    leftDeathSprites;
    public  Sprite[]    leftAttackSprites;

    public  Sprite[]    rightSprites;
    public  Sprite      rightIdle;
    public  Sprite[]    rightDeathSprites;
    public  Sprite[]    rightAttackSprites;

    public  Sprite[]    topSprites;
    public  Sprite      topIdle;
    public Sprite[]     topDeathSprites;
    public Sprite[]     topAttackSprites;

    public  Sprite[]    botSprites;
    public  Sprite      botIdle;
    public Sprite[]     botDeathSprites;
    public Sprite[]     botAttackSprites;

    public  GameObject  healthBarGreen;
    public  EnemyType   type;

    public 	GameObject	player;
    private GameObject  gm;
    private GameObject  gameManager;
    public  Vector2     newPos;
    public  GameObject  projectileMagic;
    public  GameObject  projectileCheck;
    public  float       range;
    public  int         currentNumeroAnim;
	public	float		timer;
    public  float		animTime;
    public  float       attackTimer;
    public  float       attackCooldown;
    public  float       timerCC;
    public  float       cooldownCC;
    public  float       timerFlying;
    public  float       cooldownFlying;
    public  float       timerSlow;
    public  float       cooldownSlow;
    public  bool        changedTarget;
    public  GameObject  targetAttacking;

    private int         difficulty;
    private int         currHP;
    public  int[]       maxHP;
    public  int[]       damage;
    public  int         valueXP;
    public  float       speed;
    public  float       slow;
    private Vector2     baseScale;
    private Vector2     newScale;
    public  Vector2     initialScale;
    public  bool        canMove;
    public  bool        isFlying;
    public  bool        isSlowed;
    public  bool        isAttacking;
    public  bool        canAttack;
    public  bool        rightSide;
    public  bool        needToMove;
    public  GameObject  target;
    private int         lastDragonTaken = -1;
    private int         lastTornadoTaken = -1;
    public  bool        isBoss;
    public  bool        hasLaunched;
    public  bool        canShootProjectile;
    private Shoots.Direction directionAttack;

	void Start () 
	{
        initialScale = transform.localScale;
        gm = GameObject.Find("MapManager");
        gameManager = gm.GetComponent<MapManager>().gm;
        difficulty = gameManager.GetComponent<GameManager>().difficulty;
        currHP = maxHP[difficulty];
        if (isBoss == false)
            baseScale = healthBarGreen.transform.localScale;
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
            Physics2D.IgnoreCollision(other.GetComponent<PolygonCollider2D>(), GetComponent<BoxCollider2D>());
        }
        else if (other.tag == "Tornado" &&
                lastTornadoTaken != other.GetComponent<Tornado>().id)
        {
            Fly(other.GetComponent<Tornado>().CCDuration);
            lastTornadoTaken = other.GetComponent<Tornado>().id;
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    public void TakeDamageFromPlayer(int damageTaken, Vector2 damagePos)
    {
        if (GetComponent<Enemy>().isDead == false)
        {
            currHP -= damageTaken;
            if (currHP < 0)
                currHP = 0;
            if (isBoss == false)
            {
                float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
                float diff;
                diff = baseScale.x * currHP / maxHP[difficulty];
                newScale = new Vector2(diff, baseScale.y);
                healthBarGreen.transform.localScale = newScale;

                float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

                float difference = newValue - originalValue;

                healthBarGreen.transform.Translate(new Vector2(difference, 0));
            }
            else
                gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().BossTakeDamage(currHP, maxHP[difficulty]);

            if (currHP <= 0)
            {
                player.GetComponent<StatsPlayer>().EarnXP(valueXP);
                GetComponent<Enemy>().isDead = true;
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<CircleCollider2D>());
                StartCoroutine(DeathAnimation(damagePos));
            }
        }
    }

    public void TakeDamageFromAgent(int damageTaken, Vector2 damagePos, GameObject go)
    {
        if (GetComponent<Enemy>().isDead == false)
        {
            currHP -= damageTaken;
            if (currHP < 0)
                currHP = 0;
            if (isBoss == false)
            {
                float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
                float diff;
                diff = baseScale.x * currHP / maxHP[difficulty];
                newScale = new Vector2(diff, baseScale.y);
                healthBarGreen.transform.localScale = newScale;

                float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

                float difference = newValue - originalValue;

                healthBarGreen.transform.Translate(new Vector2(difference, 0));
            }
            else
                gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().BossTakeDamage(currHP, maxHP[difficulty]);


            if (currHP == 0)
            {
                if (gm.GetComponent<MapManager>().IsEnemyAlreadyDead(GetComponent<Enemy>().id) == false)
                {
                    go.GetComponent<IAGuerrierAgent>().EarnXP(valueXP);
                    gm.GetComponent<MapManager>().FillDeadList(GetComponent<Enemy>().id);
                    GetComponent<Enemy>().isDead = true;
                    Destroy(GetComponent<BoxCollider2D>());
                    Destroy(GetComponent<CircleCollider2D>());
                    StartCoroutine(DeathAnimation(damagePos));
                }
            }
        }
    }

    public void ApplySlow(float duration, float slowValue)
    {
        slow = slowValue;
        isSlowed = true;
        cooldownSlow = duration;
        timerSlow = 0f;
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
        canMove = false;
        canAttack = false;
        cooldownCC = duration;
        timerCC = 0f;
    }

    public IEnumerator DeathAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x < directionPos.x)
            animRight = false;
        else
            animRight = true;

        int animDeath = 0;
        while (animDeath < rightDeathSprites.Length)
        {
            if (animRight == true)
                GetComponent<SpriteRenderer>().sprite = rightDeathSprites[animDeath];
            else
                GetComponent<SpriteRenderer>().sprite = leftDeathSprites[animDeath];
            yield return new WaitForSeconds(0.08f);
            animDeath++;
        }

        gm.GetComponent<MapManager>().PopEnemy(GetComponent<Enemy>().id);
        if (isBoss == true)
            gm.GetComponent<MapManager>().WinGame();
        Destroy(gameObject);
    }

    public IEnumerator AttackAnimation(Vector2 directionPos)
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

        int animAttack = 0;
        while (animAttack < rightAttackSprites.Length)
        {
            if (animRight == true)
                GetComponent<SpriteRenderer>().sprite = rightAttackSprites[animAttack];
            else
                GetComponent<SpriteRenderer>().sprite = leftAttackSprites[animAttack];
            yield return new WaitForSeconds(0.08f);
            animAttack++;
        }

        if (targetAttacking == target)
        {
            if (target.tag == "Player")
                player.GetComponent<StatsPlayer>().TakeDamage(damage[difficulty], transform.position);
            else if (target.tag == "AgentGuerrier")
                target.GetComponent<IAGuerrierAgent>().TakeDamage(damage[difficulty], transform.position);
            else if (target.tag == "Defense")
                target.GetComponent<Defense>().TakeDamage(damage[difficulty]);
        }
        
        isAttacking = false;
        canAttack = false;
        timer = 0.09f;

        if (rightSide == true)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
    }

    public IEnumerator AttackDistanceAnimation(Vector2 targetPos)
    {
        FindShootDirection(targetPos);

        int animAttack = 0;
        while (animAttack < rightAttackSprites.Length &&
                GetComponent<Enemy>().isDead == false)
        {
            if (directionAttack == Shoots.Direction.RIGHT ||
                directionAttack == Shoots.Direction.TOPRIGHT ||
                directionAttack == Shoots.Direction.BOTTOMRIGHT)
                GetComponent<SpriteRenderer>().sprite = rightAttackSprites[animAttack];
            else if (directionAttack == Shoots.Direction.LEFT ||
                directionAttack == Shoots.Direction.TOPLEFT ||
                directionAttack == Shoots.Direction.BOTTOMLEFT)
                GetComponent<SpriteRenderer>().sprite = leftAttackSprites[animAttack];
            else if (directionAttack == Shoots.Direction.BOTTOM)
                GetComponent<SpriteRenderer>().sprite = botAttackSprites[animAttack];
            else if (directionAttack == Shoots.Direction.TOP)
                GetComponent<SpriteRenderer>().sprite = topAttackSprites[animAttack];

            yield return new WaitForSeconds(0.08f);
            animAttack++;
        }

        GameObject obj = null;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (directionAttack == Shoots.Direction.RIGHT ||
            directionAttack == Shoots.Direction.TOPRIGHT ||
            directionAttack == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (directionAttack == Shoots.Direction.LEFT ||
            directionAttack == Shoots.Direction.TOPLEFT ||
            directionAttack == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (directionAttack == Shoots.Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (directionAttack == Shoots.Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        if (GetComponent<Enemy>().isDead == false)
        {
            obj = (GameObject)Instantiate(projectileMagic, newPos, transform.rotation);
            obj.GetComponent<ProjectileEnemy>().GetPos(targetPos, damage[difficulty], directionAttack, gameObject);
        }

        isAttacking = false;
        canAttack = false;
        timer = 0.09f;

        if (rightSide == true)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
    }

    public void FindShootDirection(Vector2 targetPos)
    {
        Vector2 newPosTop = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 newPosTopRight = new Vector2(transform.position.x + 0.8f, transform.position.y + 0.8f);
        Vector2 newPosTopLeft = new Vector2(transform.position.x - 0.8f, transform.position.y + 0.8f);
        Vector2 newPosBot = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 newPosBotRight = new Vector2(transform.position.x + 0.8f, transform.position.y - 0.8f);
        Vector2 newPosBotLeft = new Vector2(transform.position.x - 0.8f, transform.position.y - 0.8f);
        Vector2 newPosRight = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 newPosLeft = new Vector2(transform.position.x - 1, transform.position.y);

        float distanceTop = Vector2.Distance(newPosTop, targetPos);
        float distanceTopRight = Vector2.Distance(newPosTopRight, targetPos);
        float distanceTopLeft = Vector2.Distance(newPosTopLeft, targetPos);
        float distanceBot = Vector2.Distance(newPosBot, targetPos);
        float distanceBotRight = Vector2.Distance(newPosBotRight, targetPos);
        float distanceBotLeft = Vector2.Distance(newPosBotLeft, targetPos);
        float distanceRight = Vector2.Distance(newPosRight, targetPos);
        float distanceLeft = Vector2.Distance(newPosLeft, targetPos);

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

    public GameObject FindClosestTarget()
    {
        GameObject obj = null;
        float distanceTarget = 10000;
        float distanceNew;
        bool first = true;

        if (type == EnemyType.Normal ||
            type == EnemyType.Magician)
        {
            foreach (GameObject go in gm.GetComponent<MapManager>().alliesList)
            {
                if (go.name == "Defense" ||
                    go.gameObject == player.gameObject ||
                    go.GetComponent<IAGuerrierAgent>().isDead == false)
                {
                    distanceNew = Vector2.Distance(transform.position, go.transform.position);
                    if (first == false)
                    {
                        if (distanceNew < distanceTarget)
                        {
                            distanceTarget = distanceNew;
                            obj = go;
                        }
                    }
                    else
                    {
                        distanceTarget = distanceNew;
                        obj = go;
                        first = false;
                    }
                }
            }
        }
        else if (type == EnemyType.Player)
            return (player);
        else if (type == EnemyType.Objectif)
            return (gm.GetComponent<MapManager>().defense);

        return (obj);
    }

    public void CanShootProjectile(bool canShoot)
    {
        hasLaunched = false;
        canShootProjectile = canShoot;
    }

    public void InstantiateCheck(Vector2 targetCheck)
    {
        GameObject obj = (GameObject)Instantiate(projectileCheck, transform.position, transform.rotation);
        obj.GetComponent<CheckPath>().target = targetCheck;
        obj.GetComponent<CheckPath>().parentAStar = gameObject;
    }
}