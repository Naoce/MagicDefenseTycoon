using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public  Vector2 BypassPosTopLeft;
    public  Vector2 BypassPosTopRight;
    public  Vector2 BypassPosBotLeft;
    public  Vector2 BypassPosBotRight;

    public Vector2 CheckPosTopLeft;
    public Vector2 CheckPosTopRight;
    public Vector2 CheckPosBotLeft;
    public Vector2 CheckPosBotRight;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyGuerrier" || other.tag == "BossGuerrier")
        {
            if (other.GetComponent<IAGuerrier>().isBypassing == false)
            {
                other.GetComponent<IAGuerrier>().isBypassing = true;
                float distanceTopLeft = Vector2.Distance(CheckPosTopLeft, other.transform.position);
                float distanceTopRight = Vector2.Distance(CheckPosTopRight, other.transform.position);
                float distanceBotLeft = Vector2.Distance(CheckPosBotLeft, other.transform.position);
                float distanceBotRight = Vector2.Distance(CheckPosBotRight, other.transform.position);

                if (distanceTopLeft <= distanceTopRight &&
                    distanceTopLeft <= distanceBotLeft &&
                    distanceTopLeft <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrier>().lastObstacle != null &&
                        other.GetComponent<IAGuerrier>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrier>().lastObstacleCorner == 0)
                        {
                            if (BypassPosTopLeft != BypassPosBotLeft)
                            {
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotLeft;
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 3;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 1;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopRight;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrier>().lastObstacleCorner = 0;
                            other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopLeft;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrier>().lastObstacleCorner = 0;
                        other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopLeft;
                    }
                }
                else if (distanceTopRight <= distanceTopLeft &&
                        distanceTopRight <= distanceBotLeft &&
                        distanceTopRight <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrier>().lastObstacle != null &&
                       other.GetComponent<IAGuerrier>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrier>().lastObstacleCorner == 1)
                        {
                            if (BypassPosTopRight != BypassPosBotRight)
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 2;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotRight;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 0;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopLeft;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrier>().lastObstacleCorner = 1;
                            other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopRight;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrier>().lastObstacleCorner = 1;
                        other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopRight;
                    }
                }
                else if (distanceBotRight <= distanceTopRight &&
                        distanceBotRight <= distanceBotLeft &&
                        distanceBotRight <= distanceTopLeft)
                {
                    if (other.GetComponent<IAGuerrier>().lastObstacle != null &&
                        other.GetComponent<IAGuerrier>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrier>().lastObstacleCorner == 2)
                        {
                            if (BypassPosBotRight != BypassPosTopRight)
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 1;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopRight;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotLeft;
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 3;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrier>().lastObstacleCorner = 2;
                            other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotRight;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrier>().lastObstacleCorner = 2;
                        other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotRight;
                    }
                }
                else if (distanceBotLeft <= distanceTopRight &&
                        distanceBotLeft <= distanceTopLeft &&
                        distanceBotLeft <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrier>().lastObstacle != null &&
                        other.GetComponent<IAGuerrier>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrier>().lastObstacleCorner == 3)
                        {
                            if (BypassPosBotLeft != BypassPosTopLeft)
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 0;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosTopLeft;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrier>().lastObstacleCorner = 2;
                                other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotRight;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotLeft;
                            other.GetComponent<IAGuerrier>().lastObstacleCorner = 3;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrier>().obstaclePos = BypassPosBotLeft;
                        other.GetComponent<IAGuerrier>().lastObstacleCorner = 3;
                    }
                }
                other.GetComponent<IAGuerrier>().lastObstacle = this.gameObject;
            }
        }
        if (other.tag == "AgentGuerrier")
        {
            if (other.GetComponent<IAGuerrierAgent>().isBypassing == false)
            {
                other.GetComponent<IAGuerrierAgent>().isBypassing = true;
                float distanceTopLeft = Vector2.Distance(CheckPosTopLeft, other.transform.position);
                float distanceTopRight = Vector2.Distance(CheckPosTopRight, other.transform.position);
                float distanceBotLeft = Vector2.Distance(CheckPosBotLeft, other.transform.position);
                float distanceBotRight = Vector2.Distance(CheckPosBotRight, other.transform.position);

                if (distanceTopLeft <= distanceTopRight &&
                    distanceTopLeft <= distanceBotLeft &&
                    distanceTopLeft <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrierAgent>().lastObstacle != null &&
                        other.GetComponent<IAGuerrierAgent>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrierAgent>().lastObstacleCorner == 0)
                        {
                            if (BypassPosTopLeft != BypassPosBotLeft)
                            {
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotLeft;
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 3;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 1;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopRight;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 0;
                            other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopLeft;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 0;
                        other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopLeft;
                    }
                }
                else if (distanceTopRight <= distanceTopLeft &&
                        distanceTopRight <= distanceBotLeft &&
                        distanceTopRight <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrierAgent>().lastObstacle != null &&
                       other.GetComponent<IAGuerrierAgent>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrierAgent>().lastObstacleCorner == 1)
                        {
                            if (BypassPosTopRight != BypassPosBotRight)
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 2;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotRight;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 0;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopLeft;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 1;
                            other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopRight;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 1;
                        other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopRight;
                    }
                }
                else if (distanceBotRight <= distanceTopRight &&
                        distanceBotRight <= distanceBotLeft &&
                        distanceBotRight <= distanceTopLeft)
                {
                    if (other.GetComponent<IAGuerrierAgent>().lastObstacle != null &&
                        other.GetComponent<IAGuerrierAgent>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrierAgent>().lastObstacleCorner == 2)
                        {
                            if (BypassPosBotRight != BypassPosTopRight)
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 1;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopRight;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotLeft;
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 3;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 2;
                            other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotRight;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 2;
                        other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotRight;
                    }
                }
                else if (distanceBotLeft <= distanceTopRight &&
                        distanceBotLeft <= distanceTopLeft &&
                        distanceBotLeft <= distanceBotRight)
                {
                    if (other.GetComponent<IAGuerrierAgent>().lastObstacle != null &&
                        other.GetComponent<IAGuerrierAgent>().lastObstacle == this.gameObject)
                    {
                        if (other.GetComponent<IAGuerrierAgent>().lastObstacleCorner == 3)
                        {
                            if (BypassPosBotLeft != BypassPosTopLeft)
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 0;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosTopLeft;
                            }
                            else
                            {
                                other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 2;
                                other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotRight;
                            }
                        }
                        else
                        {
                            other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotLeft;
                            other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 3;
                        }
                    }
                    else
                    {
                        other.GetComponent<IAGuerrierAgent>().obstaclePos = BypassPosBotLeft;
                        other.GetComponent<IAGuerrierAgent>().lastObstacleCorner = 3;
                    }
                }
                other.GetComponent<IAGuerrierAgent>().lastObstacle = this.gameObject;
            }
        }
    }
}
