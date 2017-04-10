using UnityEngine;
using System.Collections;

public class SpriteAnimTimer : MonoBehaviour
{
    public  Sprite[]    spriteTab;
    public  float       timeAnim;
    private int         iTab = 0;
    private float       timer = 0f;
    public  float       timerMax;
    public  bool        loop;
    public  bool        doNotDestroy;
    public  bool        onStart;

    private void Start()
    {
        if (onStart == true)
            StartCoroutine(StartAnimation());
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerMax &&
            doNotDestroy == false)
            Destroy(gameObject);
    }

    IEnumerator StartAnimation()
    {
        GetComponent<SpriteRenderer>().sprite = spriteTab[iTab++];
        yield return new WaitForSeconds(timeAnim);

        if (iTab < spriteTab.Length)
            StartCoroutine(StartAnimation());
        else if (iTab >= spriteTab.Length &&
                loop == true)
        {
            iTab = 0;
            StartCoroutine(StartAnimation());
        }
    }


    public void StartAnim(float duration)
    {
        timerMax = duration;
        StartCoroutine(StartAnimation());
    }
}
