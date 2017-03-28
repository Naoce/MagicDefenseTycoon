using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour
{
    public GameObject explosionChar;
    public GameObject explosion;
    public GameObject fade;

    public Sprite[] leftSprites;
    public Sprite[] rightSprites;
    public Sprite[] topSprites;
    public Sprite[] topleftSprites;
    public Sprite[] toprightSprites;
    public Sprite[] botSprites;
    public Sprite[] botleftSprites;
    public Sprite[] botrightSprites;

    public int damage;

    private Vector2 newPos = new Vector2(0, 0);
    private Vector2 originalPos = new Vector2(0, 0);

    private int currentNumeroAnim = 0;
    private float timer = 0f;
    private float animTime = 0.08f;
    public Shoots.Direction direction;
    private bool isExploding = false;

    void Start()
    {
        originalPos = transform.position;
    }

    public void GetPos(Vector2 newVec, int newDamage, Shoots.Direction newDirection, GameObject go)
    {
        newPos = newVec;
        float distance = Vector2.Distance(transform.position, newPos);
        if (distance < 3)
        {
            newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);
        }
        damage = newDamage;
        direction = newDirection;
    }

    void Update()
    {
        if (isExploding == false)
        {
            if (Vector2.Distance(originalPos, transform.position) >= 3)
            {
                isExploding = true;
                Instantiate(fade, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 4);
            timer += Time.deltaTime;
            if (timer > animTime)
            {
                GetComponent<PolygonCollider2D>().isTrigger = true;
                if (direction == Shoots.Direction.RIGHT)
                {
                    if (currentNumeroAnim == 0)
                    {
                        GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.LEFT)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = leftSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = leftSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.TOP)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = topSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = topSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.BOTTOM)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = botSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = botSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.BOTTOMRIGHT)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = botrightSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = botrightSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.BOTTOMLEFT)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = botleftSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = botleftSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.TOPRIGHT)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = toprightSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = toprightSprites[currentNumeroAnim++];
                }
                else if (direction == Shoots.Direction.TOPLEFT)
                {
                    if (currentNumeroAnim == 1)
                    {
                        GetComponent<SpriteRenderer>().sprite = topleftSprites[currentNumeroAnim++];
                        Destroy(GetComponent<PolygonCollider2D>());
                        gameObject.AddComponent<PolygonCollider2D>();
                        GetComponent<PolygonCollider2D>().isTrigger = true;
                    }
                    else
                        GetComponent<SpriteRenderer>().sprite = topleftSprites[currentNumeroAnim++];
                }
                if (currentNumeroAnim == rightSprites.Length)
                    currentNumeroAnim = 0;
                timer = 0f;
            }
        }
    }

    public void Explosion()
    {
        isExploding = true;
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    public void ExplosionChar()
    {
        isExploding = true;
        Instantiate(explosionChar, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
