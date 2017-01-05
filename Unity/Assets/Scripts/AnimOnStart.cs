using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimOnStart : MonoBehaviour
{
    public  Sprite[]    spriteTab;
    public  float       timeAnim;
    private int         iTab = 0;

	void Start ()
    {
        StartCoroutine(StartAnimation());
	} 

    IEnumerator StartAnimation()
    {
        GetComponent<Image>().sprite = spriteTab[iTab++];
        yield return new WaitForSeconds(timeAnim);

        if (iTab < spriteTab.Length)
            StartCoroutine(StartAnimation());
    }
}
