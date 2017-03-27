using UnityEngine;
using System.Collections;

public class CheckPath : MonoBehaviour
{
    public GameObject   parentAStar;
    public Vector2      target;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 10);
        if (transform.position.x == target.x &&
            transform.position.y == target.y)
        {
            if (parentAStar.gameObject != null)
                parentAStar.GetComponent<AStar>().SetDirectPath(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DecorCollider")
        {
            if (parentAStar.gameObject != null)
                parentAStar.GetComponent<AStar>().SetDirectPath(false);
            Destroy(gameObject);
        }
    }
}
