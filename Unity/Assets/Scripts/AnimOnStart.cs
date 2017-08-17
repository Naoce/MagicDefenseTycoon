using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimOnStart : MonoBehaviour
{
    public  Sprite[]    spriteTab;
    private float       timer = 0f;
    public  float       timeAnim;
    private int         iTab = 0;
    public  bool        loop;
    public  bool        playOnStart;
    public  bool        isFiole;
    public  bool        quitOnEnd;
    public  GameObject  player;

    void Update()
    {
        if (playOnStart == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeAnim)
            {
                timer = 0f;
                if (iTab < spriteTab.Length)
                    GetComponent<Image>().sprite = spriteTab[iTab];
                iTab++;

                if (isFiole == true && player != null)
                    player.GetComponent<StatsPlayer>().animFiole = iTab;

                if (iTab >= spriteTab.Length && loop == true)
                    iTab = 0;
                else if (loop == false &&
                        quitOnEnd == true)
                {
                    iTab = 0;
                    playOnStart = false;
                    gameObject.SetActive(false);
                }
            }
        }
    } 

    public void StartAnimationByScript()
    {
        if (gameObject.activeSelf == true)
        {
            iTab = 0;
            playOnStart = true;
        }
    }

    public void SetAnimNb(int nb)
    {
        iTab = nb;
    }
}
