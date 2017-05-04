using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject           explosionChar;
    public GameObject           explosion;
    public GameObject           fade;

    public Sprite               left1;
    public Sprite               left2;
    public Sprite               left3;
    public Sprite               left4;

    public int                  damage;

    private Vector2 	        newPos = new Vector2(0, 0);
	private Vector2 	        originalPos = new Vector2(0, 0);

    private int                 currentNumeroAnim = 1;
    private float               timer = 0f;
    private float               animTime = 0.08f;
    private bool                isExploding = false;

    void Start()
	{
		originalPos = transform.position;
	}

    public void GetPos(Vector2 newVec, int newDamage, float newRotation, GameObject go)
    {
        newPos = newVec;
        transform.eulerAngles = new Vector3(0f, 0f, newRotation);

        float distance = Vector2.Distance (transform.position, newPos);
		if (distance < 3) 
		{
			newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);
		}
        damage = newDamage;
	}

	void Update () 
	{
        if (isExploding == false)
        {
            GetComponent<PolygonCollider2D>().isTrigger = true;
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
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
                GetComponent<PolygonCollider2D>().isTrigger = true;
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
