using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimOnStart : MonoBehaviour
{
    public  Sprite[]    spriteTab;
    public  float       timeAnim;
    private int         iTab = 0;
    public  bool        loop;
    public  bool        playOnStart;
    public  bool        isFiole;
    public  bool        quitOnEnd;
    public  GameObject  player;

    void Start ()
    {
        if (playOnStart == true)
            StartCoroutine(StartAnimation());
	} 

    IEnumerator StartAnimation()
    {
        if (iTab < spriteTab.Length)
        GetComponent<Image>().sprite = spriteTab[iTab];
        iTab++;

        if (isFiole == true && player != null)
            player.GetComponent<StatsPlayer>().animFiole = iTab;
        yield return new WaitForSeconds(timeAnim);

        if (iTab < spriteTab.Length)
            StartCoroutine(StartAnimation());
        else if (loop == true)
        {
            iTab = 0;
            StartCoroutine(StartAnimation());
        }
        else if(loop == false &&
                quitOnEnd == true)
        {
            iTab = 0;
            gameObject.SetActive(false);
        }
    }

    public void StartAnimationByScript()
    {
        if (gameObject.active)
        {
            iTab = 0;
            StartCoroutine(StartAnimation());
        }

    }

    public void SetAnimNb(int nb)
    {
        iTab = nb;
    }
}
