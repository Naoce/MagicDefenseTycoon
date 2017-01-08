using UnityEngine;
using System.Collections;

public class DragonDeFeu : MonoBehaviour
{
    public Sprite left1;
    public Sprite left2;
    public Sprite left3;
    public Sprite left4;

    public Sprite right1;
    public Sprite right2;
    public Sprite right3;
    public Sprite right4;

    public Sprite top1;
    public Sprite top2;
    public Sprite top3;
    public Sprite top4;

    public Sprite topleft1;
    public Sprite topleft2;
    public Sprite topleft3;
    public Sprite topleft4;

    public Sprite topright1;
    public Sprite topright2;
    public Sprite topright3;
    public Sprite topright4;

    public Sprite bot1;
    public Sprite bot2;
    public Sprite bot3;
    public Sprite bot4;

    public Sprite botleft1;
    public Sprite botleft2;
    public Sprite botleft3;
    public Sprite botleft4;

    public Sprite botright1;
    public Sprite botright2;
    public Sprite botright3;
    public Sprite botright4;

    public int damage;
    public int id;

    private Vector2 newPos = new Vector2(0, 0);
    private Vector2 originalPos = new Vector2(0, 0);

    private int currentNumeroAnim = 1;
    private float timer = 0f;
    private float animTime = 0.08f;
    public  Shoots.Direction direction;
    private bool isExploding = false;

    void Start()
    {
        originalPos = transform.position;
    }

    public void GetPos(Vector2 newVec, int newDamage, Shoots.Direction newDirection)
    {
        newPos = newVec;
        float distance = Vector2.Distance(transform.position, newPos);
        if (distance < 50)
        {
            newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);
        }
        damage = newDamage;
        direction = newDirection;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 4);
        if (transform.position.x == newPos.x &&
            transform.position.y == newPos.y)
            Destroy(this.gameObject);
        timer += Time.deltaTime;
        if (timer > animTime)
        {
            if (direction == Shoots.Direction.RIGHT)
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
            else if (direction == Shoots.Direction.LEFT)
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
            else if (direction == Shoots.Direction.TOP)
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
            else if (direction == Shoots.Direction.BOTTOM)
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
            else if (direction == Shoots.Direction.BOTTOMRIGHT)
            {
                if (currentNumeroAnim == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = botright1;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = botright2;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = botright3;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = botright4;
                    currentNumeroAnim++;
                }
            }
            else if (direction == Shoots.Direction.BOTTOMLEFT)
            {
                if (currentNumeroAnim == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = botleft1;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = botleft2;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = botleft3;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = botleft4;
                    currentNumeroAnim++;
                }
            }
            else if (direction == Shoots.Direction.TOPRIGHT)
            {
                if (currentNumeroAnim == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = topright1;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = topright2;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = topright3;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = topright4;
                    currentNumeroAnim++;
                }
            }
            else if (direction == Shoots.Direction.TOPLEFT)
            {
                if (currentNumeroAnim == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = topleft1;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = topleft2;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = topleft3;
                    currentNumeroAnim++;
                }
                else if (currentNumeroAnim == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = topleft4;
                    currentNumeroAnim++;
                }
            }
            if (currentNumeroAnim == 5)
                currentNumeroAnim = 1;
            timer = 0f;
        }
    }
}
