﻿using UnityEngine;
using System.Collections;

public class IceShard : MonoBehaviour
{
    public GameObject explosionChar;
    public GameObject explosion;
    public GameObject fade;

    public Sprite left;

    public int damage;

    private Vector2 newPos = new Vector2(0, 0);
    private Vector2 originalPos = new Vector2(0, 0);

    private bool isExploding = false;

    void Start()
    {
        originalPos = transform.position;
    }

    public void GetPos(Vector2 newVec, int newDamage, float newRotation, GameObject go)
    {
        newPos = newVec;
        float distance = Vector2.Distance(transform.position, newPos);
        if (distance < 3)
        {
            newPos = new Vector2((newPos.x - transform.position.x) * 1000, (newPos.y - transform.position.y) * 1000);
        }
        damage = newDamage;
        transform.eulerAngles = new Vector3(0f, 0f, newRotation);
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<PolygonCollider2D>().isTrigger = true;
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
