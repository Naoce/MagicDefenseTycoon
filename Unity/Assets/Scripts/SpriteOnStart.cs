using UnityEngine;
using System.Collections;

public class SpriteOnStart : MonoBehaviour
{
    public Sprite[] spriteTab;
    public float timeAnim;
    private int iTab = 0;

    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        GetComponent<SpriteRenderer>().sprite = spriteTab[iTab++];
        yield return new WaitForSeconds(timeAnim);

        if (iTab < spriteTab.Length)
            StartCoroutine(StartAnimation());
        else
            Destroy(this.gameObject);
    }
}
