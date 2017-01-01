using UnityEngine;
using System.Collections;

public class Shoots : MonoBehaviour 
{
    public enum Direction
    {
        TOP,
        TOPRIGHT,
        TOPLEFT,
        BOTTOM,
        BOTTOMRIGHT,
        BOTTOMLEFT,
        LEFT,
        RIGHT
    };
	public  GameObject	cam;
	public  GameObject	projectile;

	private Vector2 	newPos = new Vector2(0, 0);
	private Quaternion 	rot = new Quaternion (0, 0, 0, 0);

    //Attaque normale
    private float       timer = 0f;
    public  float       cooldownAttack = 1f;
    private bool        canAttack = true;

    void Update () 
	{
        if (canAttack == false)
        {
            timer += Time.deltaTime;
            if (timer > cooldownAttack)
            {
                timer = 0f;
                canAttack = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && canAttack == true)
		{
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            canAttack = false;
            StartCoroutine(InstantiateProjectile(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
        }
	}

    void        FindShootDirection()
    {
        Vector2 newPosClick = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPosTop = new Vector2(transform.position.x, transform.position.y + 1);
        Vector2 newPosTopRight = new Vector2(transform.position.x + 0.8f, transform.position.y + 0.8f);
        Vector2 newPosTopLeft = new Vector2(transform.position.x - 0.8f, transform.position.y + 0.8f);
        Vector2 newPosBot = new Vector2(transform.position.x, transform.position.y - 1);
        Vector2 newPosBotRight = new Vector2(transform.position.x + 0.8f, transform.position.y - 0.8f);
        Vector2 newPosBotLeft = new Vector2(transform.position.x - 0.8f, transform.position.y - 0.8f);
        Vector2 newPosRight = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 newPosLeft = new Vector2(transform.position.x - 1, transform.position.y);

        float distanceTop = Vector2.Distance(newPosTop, newPosClick);
        float distanceTopRight = Vector2.Distance(newPosTopRight, newPosClick);
        float distanceTopLeft = Vector2.Distance(newPosTopLeft, newPosClick);
        float distanceBot = Vector2.Distance(newPosBot, newPosClick);
        float distanceBotRight = Vector2.Distance(newPosBotRight, newPosClick);
        float distanceBotLeft = Vector2.Distance(newPosBotLeft, newPosClick);
        float distanceRight = Vector2.Distance(newPosRight, newPosClick);
        float distanceLeft = Vector2.Distance(newPosLeft, newPosClick);

        if (distanceRight < distanceTop &&
            distanceRight < distanceBot &&
            distanceRight < distanceLeft &&
            distanceRight < distanceTopRight &&
            distanceRight < distanceTopLeft &&
            distanceRight < distanceBotRight &&
            distanceRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.RIGHT;
        else if (distanceLeft < distanceTop &&
            distanceLeft < distanceBot &&
            distanceLeft < distanceRight &&
            distanceLeft < distanceTopRight &&
            distanceLeft < distanceTopLeft &&
            distanceLeft < distanceBotRight &&
            distanceLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.LEFT;
        else if (distanceBot < distanceTop &&
            distanceBot < distanceLeft &&
            distanceBot < distanceRight &&
            distanceBot < distanceTopRight &&
            distanceBot < distanceTopLeft &&
            distanceBot < distanceBotRight &&
            distanceBot < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOM;
        else if (distanceTop < distanceBot &&
            distanceTop < distanceLeft &&
            distanceTop < distanceRight &&
            distanceTop < distanceTopRight &&
            distanceTop < distanceTopLeft &&
            distanceTop < distanceBotRight &&
            distanceTop < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOP;
        else if (distanceTopRight < distanceBot &&
            distanceTopRight < distanceLeft &&
            distanceTopRight < distanceRight &&
            distanceTopRight < distanceTop &&
            distanceTopRight < distanceTopLeft &&
            distanceTopRight < distanceBotRight &&
            distanceTopRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOPRIGHT;
        else if (distanceTopLeft < distanceBot &&
            distanceTopLeft < distanceLeft &&
            distanceTopLeft < distanceRight &&
            distanceTopLeft < distanceTop &&
            distanceTopLeft < distanceTopRight &&
            distanceTopLeft < distanceBotRight &&
            distanceTopLeft < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.TOPLEFT;
        else if (distanceBotRight < distanceBot &&
            distanceBotRight < distanceLeft &&
            distanceBotRight < distanceRight &&
            distanceBotRight < distanceTop &&
            distanceBotRight < distanceTopRight &&
            distanceBotRight < distanceTopLeft &&
            distanceBotRight < distanceBotLeft)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOMRIGHT;
        else if (distanceBotLeft < distanceBot &&
            distanceBotLeft < distanceLeft &&
            distanceBotLeft < distanceRight &&
            distanceBotLeft < distanceTop &&
            distanceBotLeft < distanceTopRight &&
            distanceBotLeft < distanceTopLeft &&
            distanceBotLeft < distanceBotRight)
            GetComponent<Deplacements>().attackDirection = Direction.BOTTOMLEFT;
    }

    IEnumerator InstantiateProjectile(Vector2 directionPos)
	{
        yield return new WaitForSeconds(0.2f);
		GameObject obj = null;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Direction.RIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPRIGHT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMRIGHT)
            newPos.x = transform.position.x + 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.LEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.TOPLEFT ||
            GetComponent<Deplacements>().attackDirection == Shoots.Direction.BOTTOMLEFT)
            newPos.x = transform.position.x - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOM)
            newPos.y = transform.position.y - 0.1f;
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOP)
            newPos.y = transform.position.y + 0.1f;

        obj = (GameObject)Instantiate (projectile, newPos, rot);
		obj.GetComponent<Projectile>().GetPos (directionPos, GetComponent<StatsPlayer>().damage, GetComponent<Deplacements>().attackDirection);
	}
}
