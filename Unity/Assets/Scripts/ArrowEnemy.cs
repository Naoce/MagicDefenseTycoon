using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{
    public GameObject hitSprite;
    public GameObject bloodSprite;

    public int damage;

    private Vector2 newPos = new Vector2(0, 0);
    private Vector2 originalPos = new Vector2(0, 0);

    private int currentNumeroAnim = 0;
    private float timer = 0f;
    private float animTime = 0.08f;
    private bool isExploding = false;
    private GameObject gm;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        originalPos = transform.position;
    }

    public void GetPos(Vector2 newVec, int newDamage, float newAngle, GameObject go)
    {
        newPos = newVec;
        transform.eulerAngles = new Vector3(0f, 0f, newAngle);

        float distance = Vector2.Distance(transform.position, newPos);

        if (distance < 3)
            newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);

        damage = newDamage;

        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * 4);
        if (Vector2.Distance(originalPos, transform.position) >= 3 || (transform.position.x == newPos.x && transform.position.y == newPos.y))
            Destroy(this.gameObject);
    }

    public void ExplosionChar(bool onDefense)
    {
        Destroy(GetComponent<PolygonCollider2D>());
        Quaternion zero = new Quaternion(0, 0, 0, 0);
        if (gm.GetComponent<GameManager>().bloodless == true || onDefense == true)
            Instantiate(hitSprite, transform.position, zero);
        else
            Instantiate(bloodSprite, transform.position, zero);

        Destroy(gameObject);
    }
}
