using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int id;

    public void IgnoreCollider(GameObject obj)
    {
        Physics2D.IgnoreCollision(obj.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        GameObject player = GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }
}
