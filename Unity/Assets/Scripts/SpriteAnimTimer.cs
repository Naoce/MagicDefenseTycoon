using UnityEngine;
using System.Collections;

public class SpriteAnimTimer : MonoBehaviour
{
    public  Sprite[]    spriteTab;
    public  float       timeAnim;
    private int         iTab = 0;
    private float       timer = 0f;
    private float       timerTotal = 0f;
    public  float       timerMax;
    public  bool        loop;
    public  bool        doNotDestroy;
    public  bool        onStart;
    public  bool        isPlaying;

    private void Update()
    {
        timer += Time.deltaTime;
        timerTotal += Time.deltaTime;

        if (timer > timeAnim)
        {
            timer = 0f;
            if (timerTotal >= timerMax && doNotDestroy == false)
            {
                if (doNotDestroy == false)
                    Destroy(gameObject);
                else
                    isPlaying = false;
            }
            else
            {
                if (iTab < spriteTab.Length)
                    GetComponent<SpriteRenderer>().sprite = spriteTab[iTab++];
                else
                {
                    if (loop == true)
                    {
                        iTab = 0;
                        GetComponent<SpriteRenderer>().sprite = spriteTab[iTab++];
                    }
                }
            }
        }
    }

    public void StartAnim(float duration)
    {
        if (isPlaying == false)
        {
            isPlaying = true;
            timerTotal = 0f;
            timer = 0f;
            timerMax = duration;
        }
    }
}
