using UnityEngine;
using System.Collections;

public class DalleSol : MonoBehaviour
{
    public  Vector2 positionStart;
    public  bool    isMandatory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyGuerrier")
        {
            float distanceNewPos = Vector2.Distance(other.GetComponent<IAGuerrier>().newPos, other.transform.position);
            float distanceAfter = Vector2.Distance(positionStart, other.GetComponent<IAGuerrier>().newPos);
            if (distanceAfter > distanceNewPos)
            {
                if (isMandatory == true)
                {
                    other.GetComponent<IAGuerrier>().obstaclePos = positionStart;
                    other.GetComponent<IAGuerrier>().lastObstacle = this.gameObject;
                    other.GetComponent<IAGuerrier>().isBypassing = true;
                }
            }
            else
            {
                other.GetComponent<IAGuerrier>().obstaclePos = positionStart;
                other.GetComponent<IAGuerrier>().lastObstacle = this.gameObject;
                other.GetComponent<IAGuerrier>().isBypassing = true;
            }
        }
        else if (other.tag == "AgentGuerrier")
        {
            float distanceNewPos = Vector2.Distance(other.GetComponent<IAGuerrierAgent>().newPos, other.transform.position);
            float distanceAfter = Vector2.Distance(positionStart, other.GetComponent<IAGuerrierAgent>().newPos);
            if (distanceAfter > distanceNewPos)
            {
                if (isMandatory == true)
                {
                    other.GetComponent<IAGuerrierAgent>().obstaclePos = positionStart;
                    other.GetComponent<IAGuerrierAgent>().lastObstacle = this.gameObject;
                    other.GetComponent<IAGuerrierAgent>().isBypassing = true;
                }
            }
            else
            {
                other.GetComponent<IAGuerrierAgent>().obstaclePos = positionStart;
                other.GetComponent<IAGuerrierAgent>().lastObstacle = this.gameObject;
                other.GetComponent<IAGuerrierAgent>().isBypassing = true;
            }
        }
    }
}
