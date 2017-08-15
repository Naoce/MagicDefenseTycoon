using UnityEngine;
using System.Collections;

public class SpriteOnStart : MonoBehaviour
{
    public Sprite[] spriteTab;
    public float timeAnim;
    private int iTab = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeAnim)
        {
            timer = 0f;

            if (iTab < spriteTab.Length)
                GetComponent<SpriteRenderer>().sprite = spriteTab[iTab++];
            else
                Destroy(this.gameObject);
        }
    }
}
