using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    public  Sprite[]        rightSpritesRun;
    public  Sprite[]        rightSpritesDeath;
    public  GameObject      meteor;
    public  GameObject      thunderbolt;
    public  GameObject      thunderboltBase;
    public  Vector2[]       startPos;
    public  Vector2[]       destinations;

    private int             lastDestination = -1;
    private int             currentDestination = 0;
    private int             currentSpell = 0;
    private int             currentAnim = 0;
    private float           timer = 0f;
    private float           cooldown = 0.03f;
    private bool            isDead = false;
    private bool            spellLanded = false;

    void Start()
    {
        ResetAnim();
    }

    void ResetAnim()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        spellLanded = false;

        currentDestination = Random.Range(0, destinations.Length);
        if (lastDestination == currentDestination)
        {
            if (currentDestination > 0)
                currentDestination--;
            else
                currentDestination++;
        }
        lastDestination = currentDestination;

        transform.position = startPos[currentDestination];
        GetComponent<SpriteRenderer>().sprite = rightSpritesRun[0];
        currentSpell = Random.Range(0, 2);
        currentAnim = 0;
        timer = 0f;
        if (transform.position.x < destinations[currentDestination].x)
            GetComponent<SpriteRenderer>().flipX = false;
        else
            GetComponent<SpriteRenderer>().flipX = true;
        isDead = false;
    }

	void Update ()
    {
        if (isDead == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, destinations[currentDestination], Time.deltaTime);

            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                GetComponent<SpriteRenderer>().sprite = rightSpritesRun[currentAnim++];
                if (currentAnim >= rightSpritesRun.Length)
                    currentAnim = 0;
                timer = 0f;
            }

            if (currentSpell == 0 &&
                spellLanded == false &&
                Vector2.Distance(transform.position, destinations[currentDestination]) < 0.2f)
            {
                spellLanded = true;
                StartCoroutine(ThunderAnim());
            }
            else if (currentSpell == 1 &&
                spellLanded == false &&
                Vector2.Distance(transform.position, destinations[currentDestination]) < 0.4f)
            {
                spellLanded = true;
                StartCoroutine(MeteorAnim());
            }
        }
	}

    IEnumerator ThunderAnim()
    {
        Vector2 vectorTmp = gameObject.transform.position;
        vectorTmp.y += 0.5f;
        GameObject obj = (GameObject)Instantiate(thunderbolt, vectorTmp, transform.rotation);
        obj.GetComponent<Thunderbolt>().enemy = gameObject;
        yield return new WaitForSeconds(0.16f);

        timer = 0f;
        StartCoroutine(DeathAnim());

        vectorTmp = gameObject.transform.position;
        vectorTmp.y += 0.5f;
        GameObject obj2 = (GameObject)Instantiate(thunderboltBase, vectorTmp, transform.rotation);
        obj2.GetComponent<Thunderbolt>().enemy = gameObject;
    }

    IEnumerator MeteorAnim()
    {
        Vector2 vectorTmp = destinations[currentDestination];
        vectorTmp.y += 0.5f;
        GameObject obj = (GameObject)Instantiate(meteor, vectorTmp, transform.rotation);
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(DeathAnim());
    }

    IEnumerator DeathAnim()
    {
        isDead = true;

        for (int i = 0; i < rightSpritesDeath.Length; i++)
        {
            GetComponent<SpriteRenderer>().sprite = rightSpritesDeath[i];
            yield return new WaitForSeconds(cooldown);
        }

        yield return new WaitForSeconds(0.2f);

        ResetAnim();
    }
}
