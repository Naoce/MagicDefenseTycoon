using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public  GameObject  dragonHG;
    public  GameObject  dragonHD;
    public  GameObject  dragonH;
    public  GameObject  dragonG;
    public  GameObject  dragonD;
    public  GameObject  dragonBG;
    public  GameObject  dragonBD;
    public  GameObject  dragonB;
    private GameObject  gm;
    private GameObject  usingSpellIcon;

	private Vector2 	newPos = new Vector2(0, 0);
	private Quaternion 	rot = new Quaternion (0, 0, 0, 0);

    private float       timerAttack = 0f;
    private float       timerSpell2 = 0f;
    private float       timerSpell3 = 0f;
    private float       timerSpell4 = 0f;
    private float       timerSpell5 = 0f;
    private float       timerSpell6 = 0f;
    private float       timerSpell7 = 0f;
    private float       timerSpell8 = 0f;
    public float        cooldownAttack;
    public float        cooldownSpell2;
    public float        cooldownSpell3;
    public float        cooldownSpell4;
    public float        cooldownSpell5;
    public float        cooldownSpell6;
    public float        cooldownSpell7;
    public float        cooldownSpell8;
    private bool        spell1Ready = true;
    private bool        spell2Ready = true;
    private bool        spell3Ready = true;
    private bool        spell4Ready = true;
    private bool        spell5Ready = true;
    private bool        spell6Ready = true;
    private bool        spell7Ready = true;
    private bool        spell8Ready = true;
    public  int         spellSelected = 1;
    private Vector2[]   posUsingSpell = new Vector2[8] { new Vector2(680, 55), new Vector2(760, 55), new Vector2(840, 55), new Vector2(920, 55), new Vector2(1000, 55), new Vector2(1080, 55), new Vector2(1160, 55), new Vector2(1240, 55)};
    private GameObject  cdSpell1;
    private GameObject  cdSpell2;
    private GameObject  cdSpell3;
    private GameObject  cdSpell4;
    private GameObject  cdSpell5;
    private GameObject  cdSpell6;
    private GameObject  cdSpell7;
    private GameObject  cdSpell8;
    private int         idSpell8 = 0;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        usingSpellIcon = GameObject.Find("UsingSpell");
        cdSpell1 = GameObject.Find("Slider Cooldown Spell 1");
        cdSpell2 = GameObject.Find("Slider Cooldown Spell 2");
        cdSpell3 = GameObject.Find("Slider Cooldown Spell 3");
        cdSpell4 = GameObject.Find("Slider Cooldown Spell 4");
        cdSpell5 = GameObject.Find("Slider Cooldown Spell 5");
        cdSpell6 = GameObject.Find("Slider Cooldown Spell 6");
        cdSpell7 = GameObject.Find("Slider Cooldown Spell 7");
        cdSpell8 = GameObject.Find("Slider Cooldown Spell 8");
    } 

    void Update () 
	{
        if (spell1Ready == false)
        {
            timerAttack += Time.deltaTime;
            cdSpell1.GetComponent<Slider>().value = 1 - (float)timerAttack / (float)cooldownAttack;
            if (timerAttack > cooldownAttack)
            {
                timerAttack = 0f;
                cdSpell1.GetComponent<Slider>().value = 0;
                spell1Ready = true;
            }
        }
        if (spell2Ready == false)
        {
            timerSpell2 += Time.deltaTime;
            cdSpell2.GetComponent<Slider>().value = 1 - (float)timerSpell2 / (float)cooldownSpell2;
            if (timerSpell2 > cooldownSpell2)
            {
                timerSpell2 = 0f;
                cdSpell2.GetComponent<Slider>().value = 0;
                spell2Ready = true;
            }
        }
        if (spell3Ready == false)
        {
            timerSpell3 += Time.deltaTime;
            cdSpell3.GetComponent<Slider>().value = 1 - (float)timerSpell3 / (float)cooldownSpell3;
            if (timerSpell3 > cooldownSpell3)
            {
                timerSpell3 = 0f;
                cdSpell3.GetComponent<Slider>().value = 0;
                spell3Ready = true;
            }
        }
        if (spell4Ready == false)
        {
            timerSpell4 += Time.deltaTime;
            cdSpell4.GetComponent<Slider>().value = 1 - (float)timerSpell4 / (float)cooldownSpell4;
            if (timerSpell4 > cooldownSpell4)
            {
                timerSpell4 = 0f;
                cdSpell4.GetComponent<Slider>().value = 0;
                spell4Ready = true;
            }
        }
        if (spell5Ready == false)
        {
            timerSpell5 += Time.deltaTime;
            cdSpell5.GetComponent<Slider>().value = 1 - (float)timerSpell5 / (float)cooldownSpell5;
            if (timerSpell5 > cooldownSpell5)
            {
                timerSpell5 = 0f;
                cdSpell5.GetComponent<Slider>().value = 0;
                spell5Ready = true;
            }
        }
        if (spell6Ready == false)
        {
            timerSpell6 += Time.deltaTime;
            cdSpell6.GetComponent<Slider>().value = 1 - (float)timerSpell6 / (float)cooldownSpell6;
            if (timerSpell6 > cooldownSpell6)
            {
                timerSpell6 = 0f;
                cdSpell6.GetComponent<Slider>().value = 0;
                spell6Ready = true;
            }
        }
        if (spell7Ready == false)
        {
            timerSpell7 += Time.deltaTime;
            cdSpell7.GetComponent<Slider>().value = 1 - (float)timerSpell7 / (float)cooldownSpell7;
            if (timerSpell7 > cooldownSpell7)
            {
                timerSpell7 = 0f;
                cdSpell7.GetComponent<Slider>().value = 0;
                spell7Ready = true;
            }
        }
        if (spell8Ready == false)
        {
            timerSpell8 += Time.deltaTime;
            cdSpell8.GetComponent<Slider>().value = 1 - (float)timerSpell8 / (float)cooldownSpell8;
            if (timerSpell8 > cooldownSpell8)
            {
                timerSpell8 = 0f;
                cdSpell8.GetComponent<Slider>().value = 0;
                spell8Ready = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellSelected = 1;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellSelected = 2;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spellSelected = 3;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spellSelected = 4;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            spellSelected = 5;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[4];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            spellSelected = 6;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[5];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) &&
                spell7Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false)
        {
            cdSpell7.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            spell7Ready = false;
            StartCoroutine(SpellSeisme());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            spellSelected = 8;
            usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[7];
        }
        if (spellSelected == 1 &&
            Input.GetMouseButton(0) &&
            spell1Ready == true && 
            GetComponent<Deplacements>().isDead == false &&
            GetComponent<Deplacements>().isAttacking == false &&
            Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
		{
            cdSpell1.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell1Ready = false;
            StartCoroutine(InstantiateProjectile(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
        }
        else if (spellSelected == 2 &&
                Input.GetMouseButtonDown(0) && 
                spell2Ready == true && 
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier")
                {
                    cdSpell2.GetComponent<Slider>().value = 1;
                    StartCoroutine(SpellFoudre(hit.collider.gameObject));
                    GetComponent<Deplacements>().isAttacking = true;
                    GetComponent<Deplacements>().currentNumeroAnim = 1;
                    FindShootDirection();
                    spell2Ready = false;
                    StartCoroutine(GoBackToAA());
                }
            }
        }
        else if (spellSelected == 3 &&
                Input.GetMouseButtonDown(0) &&
                spell3Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            cdSpell3.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell3Ready = false;
            StartCoroutine(InstantiateEclatsGlace(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
            StartCoroutine(GoBackToAA());
        }
        else if (spellSelected == 4 &&
                Input.GetMouseButtonDown(0) &&
                spell4Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
        {
            cdSpell4.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell4Ready = false;
            StartCoroutine(SpellMeteore());
            StartCoroutine(GoBackToAA());
        }
        else if (spellSelected == 5 &&
                Input.GetMouseButtonDown(0) &&
                spell5Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
        {
            cdSpell5.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell5Ready = false;
            StartCoroutine(SpellTornade());
            StartCoroutine(GoBackToAA());
        }
        else if (spellSelected == 6 &&
                Input.GetMouseButtonDown(0) &&
                spell6Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) < 3f)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "EnemyGuerrier")
                {
                    cdSpell6.GetComponent<Slider>().value = 1;
                    StartCoroutine(SpellPrisonGlace(hit.collider.gameObject));
                    GetComponent<Deplacements>().isAttacking = true;
                    GetComponent<Deplacements>().currentNumeroAnim = 1;
                    FindShootDirection();
                    spell6Ready = false;
                    StartCoroutine(GoBackToAA());
                }
            }
        }
        else if (spellSelected == 8 &&
                Input.GetMouseButtonDown(0) &&
                spell8Ready == true &&
                GetComponent<Deplacements>().isDead == false &&
                GetComponent<Deplacements>().isAttacking == false &&
                Vector2.Distance(transform.position, cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) > 0.2f)
        {
            cdSpell8.GetComponent<Slider>().value = 1;
            GetComponent<Deplacements>().isAttacking = true;
            GetComponent<Deplacements>().currentNumeroAnim = 1;
            FindShootDirection();
            spell8Ready = false;
            StartCoroutine(SpellDragonFeu(cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)));
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
		obj.GetComponent<Projectile>().GetPos (directionPos, 5, GetComponent<Deplacements>().attackDirection);
	}

    IEnumerator InstantiateEclatsGlace(Vector2 directionPos)
    {
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

        GameObject obj1 = null;
        obj1 = (GameObject)Instantiate(projectile, newPos, rot);
        obj1.GetComponent<Projectile>().GetPos(directionPos, 2, GetComponent<Deplacements>().attackDirection);
        yield return new WaitForSeconds(0.06f);

        GameObject obj2 = null;
        obj2 = (GameObject)Instantiate(projectile, newPos, rot);
        obj2.GetComponent<Projectile>().GetPos(directionPos, 2, GetComponent<Deplacements>().attackDirection);
        yield return new WaitForSeconds(0.06f);

        GameObject obj3 = null;
        obj3 = (GameObject)Instantiate(projectile, newPos, rot);
        obj3.GetComponent<Projectile>().GetPos(directionPos, 2, GetComponent<Deplacements>().attackDirection);
        yield return new WaitForSeconds(0.06f);

        GameObject obj4 = null;
        obj4 = (GameObject)Instantiate(projectile, newPos, rot);
        obj4.GetComponent<Projectile>().GetPos(directionPos, 2, GetComponent<Deplacements>().attackDirection);
    }

    IEnumerator SpellFoudre(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        if (go.gameObject != null)
            go.GetComponent<IAGuerrier>().TakeDamageFromPlayer(8, transform.position);
    }

    IEnumerator GoBackToAA()
    {
        yield return new WaitForSeconds(0.1f);
        spellSelected = 1;
        usingSpellIcon.GetComponent<RectTransform>().position = posUsingSpell[0];
    }

    IEnumerator SpellMeteore()
    {
        Vector2 mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.4f);
        foreach(GameObject go in gm.GetComponent<GameManager>().enemiesList)
        {
            if (Vector2.Distance(go.transform.position, mousePos) < 1)
               go.GetComponent<IAGuerrier>().TakeDamageFromPlayer(6, mousePos);
        }
    }

    IEnumerator SpellTornade()
    {
        Vector2 mousePos = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        yield return new WaitForSeconds(0.2f);
        foreach (GameObject go in gm.GetComponent<GameManager>().enemiesList)
        {
            if (Vector2.Distance(go.transform.position, mousePos) < 1.5f)
                go.GetComponent<IAGuerrier>().Fly(2);
        }
    }

    IEnumerator SpellPrisonGlace(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        if (go.gameObject != null)
        {
            go.GetComponent<IAGuerrier>().TakeDamageFromPlayer(5, transform.position);
            go.GetComponent<IAGuerrier>().ApplyCC(2);
        }
    }

    IEnumerator SpellSeisme()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (GameObject go in gm.GetComponent<GameManager>().enemiesList)
        {
            if (Vector2.Distance(go.transform.position, transform.position) < 2)
            {
                go.GetComponent<IAGuerrier>().TakeDamageFromPlayer(7, transform.position);
                go.GetComponent<IAGuerrier>().ApplySlow(2f, 0.3f);
            }
        }
    }

    IEnumerator SpellDragonFeu(Vector2 directionPos)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = null;

        newPos.x = transform.position.x;
        newPos.y = transform.position.y;
        if (GetComponent<Deplacements>().attackDirection == Direction.RIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOPRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonHD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOMRIGHT)
        {
            newPos.x = transform.position.x + 0.1f;
            obj = (GameObject)Instantiate(dragonBD, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.LEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOPLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonHG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOMLEFT)
        {
            newPos.x = transform.position.x - 0.1f;
            obj = (GameObject)Instantiate(dragonBG, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.BOTTOM)
        {
            newPos.y = transform.position.y - 0.1f;
            obj = (GameObject)Instantiate(dragonB, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
        else if (GetComponent<Deplacements>().attackDirection == Direction.TOP)
        {
            newPos.y = transform.position.y + 0.1f;
            obj = (GameObject)Instantiate(dragonH, newPos, rot);
            obj.GetComponent<DragonDeFeu>().GetPos(directionPos, 8, GetComponent<Deplacements>().attackDirection);
            obj.GetComponent<DragonDeFeu>().id = idSpell8++;
        }
    }
}
