using UnityEngine;
using System.Collections;

public class DragonDeFeu : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;

    public int damage;
    public int id;

    private Vector2 newPos = new Vector2(0, 0);

    private int currentNumeroAnim = 1;
    private float timer = 0f;
    private float animTime = 0.08f;

    public void GetPos(Vector2 newVec, int newDamage, Shoots.Direction newDirection)
    {
        newPos = newVec;
        float distance = Vector2.Distance(transform.position, newPos);
        if (distance < 50)
        {
            newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);
        }
        damage = newDamage;
        print(newPos);
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
            if (currentNumeroAnim == 1)
            {
                GetComponent<SpriteRenderer>().sprite = sprite1;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 2)
            {
                GetComponent<SpriteRenderer>().sprite = sprite2;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 3)
            {
                GetComponent<SpriteRenderer>().sprite = sprite3;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 4)
            {
                GetComponent<SpriteRenderer>().sprite = sprite4;
                currentNumeroAnim++;
            }
            else if (currentNumeroAnim == 5)
            {
                GetComponent<SpriteRenderer>().sprite = sprite5;
                currentNumeroAnim++;
            }
            if (currentNumeroAnim == 6)
                currentNumeroAnim = 1;
            timer = 0f;
        }
    }
}
