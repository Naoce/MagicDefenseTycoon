using UnityEngine;
using System.Collections;

public class Thunderbolt : MonoBehaviour
{
    public  GameObject  enemy;
    private Vector2     tmp;
	void Update ()
    {
	    if (enemy.gameObject != null)
        {
            tmp = enemy.transform.position;
            tmp.y += 0.5f;
            transform.position = tmp;
        }
	}
}
