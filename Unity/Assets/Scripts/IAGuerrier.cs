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
    private int         currentNumeroAnim = 0;
	private	float		timer = 0f;
	private float		animTime = 0.12f;
    private float       attackTimer = 0f;
    private float       attackCooldown = 1f;
    private float       timerCC = 0f;
    private float       cooldownCC = 0f;
    private float       timerFlying = 0f;
    private float       cooldownFlying = 0f;
    private float       timerSlow = 0f;
    private float       cooldownSlow = 0f;
    private bool        changedTarget = false;
    private GameObject  targetAttacking = null;

    private int         difficulty;
    private int         currHP;
    public  int[]       maxHP;
    public  int[]       damage;
    public  int         valueXP;
    private float       speed = 1f;
    private float       slow = 0f;
    private Vector2     baseScale;
    private Vector2     newScale;
    private Vector2     initialScale;
    private bool        canMove = true;
    private bool        isFlying = false;
    private bool        isSlowed = false;
    private bool        isAttacking = false;
    private bool        canAttack = true;
    private bool        rightSide = false;
    private bool        needToMove = true;
    public  GameObject  target = null;
    private int         lastDragonTaken = -1;
    private int         lastTornadoTaken = -1;
    public  bool        isBoss;
    private bool        hasLaunched = false;
    private bool        canShootProjectile = false;
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

	void Update ()
	{
        if (gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (type == EnemyType.Magician &&
                hasLaunched == false &&
                target != null)
            {
                hasLaunched = true;
                InstantiateCheck(target.transform.position);
            }
            if (isSlowed == true)
            {
                timerSlow += Time.deltaTime;
                if (timerSlow > cooldownSlow)
                {
                    timerSlow = 0f;
                    slow = 0f;
                    isSlowed = false;
                }
            }
            if (canMove == false)
            {
                timerCC += Time.deltaTime;
                if (timerCC > cooldownCC)
                {
                    canAttack = true;
                    canMove = true;
                    timerCC = 0f;
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
            }
            if (GetComponent<Enemy>().isDead == false && player.GetComponent<Deplacements>().isDead == false &&
                canMove == true)
            {
                target = FindClosestTarget();
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
                if (Vector2.Distance(target.transform.position, transform.position) <= range &&
                    ((target.tag == "Player" &&
                    target.GetComponent<Deplacements>().isDead == false) ||
                    (target.tag == "AgentGuerrier" &&
                    target.GetComponent<IAGuerrierAgent>().isDead == false) ||
                    (target.tag == "Defense" &&
                    target.GetComponent<Defense>().isDead == false)))
                {
                    if (type == EnemyType.Magician &&
                        canShootProjectile == false)
                        needToMove = true;
                    else
                    {
                        needToMove = false;
                        if (canAttack == true)
                        {
                            isAttacking = true;
                            targetAttacking = target;
                            canAttack = false;
                            if (type != EnemyType.Magician)
                                StartCoroutine(AttackAnimation(target.transform.position));
                            else if (type == EnemyType.Magician &&
                                    canShootProjectile == true)
                                StartCoroutine(AttackDistanceAnimation(target.transform.position));
                        }
                        else if (isAttacking == false)
                        {
                            if (rightSide == true)
                                GetComponent<SpriteRenderer>().sprite = leftIdle;
                            else
                                GetComponent<SpriteRenderer>().sprite = rightIdle;
                        }
                    }
                }
                else
                    needToMove = true;
                if (isAttacking == false && needToMove == true)
                {
                    timer += Time.deltaTime;

                    GameObject targetTmp = FindClosestTarget();
                    if (targetTmp != target)
                    {
                        target = targetTmp;
                        changedTarget = true;
                    }

                    if (changedTarget == true ||
                        Vector2.Distance(newPos, transform.position) <= 0.05f ||
                        Vector2.Distance(newPos, transform.position) >= 1f ||
                        Vector2.Distance(transform.position, target.transform.position) <= 1f)
                    {
                        changedTarget = false;

                        if (target != null)
                            newPos = GetComponent<AStar>().StartPathFinding(target.transform.position);
                    }

                    transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * (speed - slow));

                    if (timer > animTime &&
                    (transform.position.y != newPos.y ||
                    transform.position.x != newPos.x))
                    {
                        if ((!(newPos.x - 0.5f < transform.position.x &&
                            transform.position.x < newPos.x + 0.5f) &&
                             transform.position.x > newPos.x) ||
                             (transform.position.x > newPos.x &&
                             Vector2.Distance(transform.position, newPos) < 0.55f))
                            GetComponent<SpriteRenderer>().sprite = leftSprites[currentNumeroAnim++];
                        else if ((!(newPos.x - 0.5f < transform.position.x &&
                            transform.position.x < newPos.x + 0.5f) &&
                             transform.position.x < newPos.x) ||
                                (transform.position.x < newPos.x &&
                                Vector2.Distance(transform.position, newPos) < 0.55f))
                            GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                        else if (newPos.y > transform.position.y)
                            GetComponent<SpriteRenderer>().sprite = topSprites[currentNumeroAnim++];
                        else if (newPos.y < transform.position.y)
                            GetComponent<SpriteRenderer>().sprite = botSprites[currentNumeroAnim++];

                        if (currentNumeroAnim == leftSprites.Length)
                            currentNumeroAnim = 0;
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

    IEnumerator DeathAnimation(Vector2 directionPos)
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

    IEnumerator AttackDistanceAnimation(Vector2 targetPos)
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

    void FindShootDirection(Vector2 targetPos)
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

    GameObject FindClosestTarget()
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

    private void InstantiateCheck(Vector2 targetCheck)
    {
        GameObject obj = (GameObject)Instantiate(projectileCheck, transform.position, transform.rotation);
        obj.GetComponent<CheckPath>().target = targetCheck;
        obj.GetComponent<CheckPath>().parentAStar = gameObject;
    }
}
