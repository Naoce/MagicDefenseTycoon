using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private bool    startAnim = false;
    private bool    endAnim = false;
    private float   timer = 0f;

    void Update()
    {
        if (startAnim == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.25f)
            {
                timer = 0.5f;
                startAnim = false;
                endAnim = true;
            }
            GetComponent<Image>().color = new Color(0f, 0f, 0f, timer * 4);
        }
        else if (endAnim == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                timer = 0f;
                endAnim = false;
                gameObject.SetActive(false);
            }
            GetComponent<Image>().color = new Color(0f, 0f, 0f, timer * 2);
        }
    }

    public void StartAnimation()
    {
        startAnim = true;
        endAnim = false;
        timer = 0f;
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
    }
}
