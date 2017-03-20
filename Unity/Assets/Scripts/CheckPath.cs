using UnityEngine;
using System.Collections;

public class CheckPath : MonoBehaviour
{
    public GameObject   parentAStar;
    public Vector2      target;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 100);
        if (transform.position.x == target.x &&
            transform.position.y == target.y)
        {
            parentAStar.GetComponent<AStar>().SetDirectPath(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DecorCollider")
        {
            parentAStar.GetComponent<AStar>().SetDirectPath(false);
            Destroy(gameObject);
        }
    }
}
