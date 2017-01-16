using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UsingSpell : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite sprite11;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;
    public Sprite sprite15;
    public Sprite sprite16;
    public Sprite sprite17;
    public Sprite sprite18;
    public Sprite sprite19;
    public Sprite sprite20;
    public Sprite sprite21;
    public Sprite sprite22;
    public Sprite sprite23;
    public Sprite sprite24;
    public Sprite sprite25;
    public Sprite sprite26;
    public Sprite sprite27;
    public Sprite sprite28;
    public Sprite sprite29;
    public Sprite sprite30;
    public Sprite sprite31;
    public Sprite sprite32;

    private int         numberAnim = 1;
    private float       timer = 0f;
    private float       timerMax = 0.04f;
    public  GameObject  player;

	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0f;
            if (numberAnim == 1)
                GetComponent<Image>().sprite = sprite1;
            else if (numberAnim == 2)
                GetComponent<Image>().sprite = sprite2;
            else if (numberAnim == 3)
                GetComponent<Image>().sprite = sprite3;
            else if (numberAnim == 4)
                GetComponent<Image>().sprite = sprite4;
            else if (numberAnim == 5)
                GetComponent<Image>().sprite = sprite5;
            else if (numberAnim == 6)
                GetComponent<Image>().sprite = sprite6;
            else if (numberAnim == 7)
                GetComponent<Image>().sprite = sprite7;
            else if (numberAnim == 8)
                GetComponent<Image>().sprite = sprite8;
            else if (numberAnim == 9)
                GetComponent<Image>().sprite = sprite9;
            else if (numberAnim == 10)
                GetComponent<Image>().sprite = sprite10;
            else if (numberAnim == 11)
                GetComponent<Image>().sprite = sprite11;
            else if (numberAnim == 12)
                GetComponent<Image>().sprite = sprite12;
            else if (numberAnim == 13)
                GetComponent<Image>().sprite = sprite13;
            else if (numberAnim == 14)
                GetComponent<Image>().sprite = sprite14;
            else if (numberAnim == 15)
                GetComponent<Image>().sprite = sprite15;
            else if (numberAnim == 16)
                GetComponent<Image>().sprite = sprite16;
            else if (numberAnim == 17)
                GetComponent<Image>().sprite = sprite17;
            else if (numberAnim == 18)
                GetComponent<Image>().sprite = sprite18;
            else if (numberAnim == 19)
                GetComponent<Image>().sprite = sprite19;
            else if (numberAnim == 20)
                GetComponent<Image>().sprite = sprite20;
            else if (numberAnim == 21)
                GetComponent<Image>().sprite = sprite21;
            else if (numberAnim == 22)
                GetComponent<Image>().sprite = sprite22;
            else if (numberAnim == 23)
                GetComponent<Image>().sprite = sprite23;
            else if (numberAnim == 24)
                GetComponent<Image>().sprite = sprite24;
            else if (numberAnim == 25)
                GetComponent<Image>().sprite = sprite25;
            else if (numberAnim == 26)
                GetComponent<Image>().sprite = sprite26;
            else if (numberAnim == 27)
                GetComponent<Image>().sprite = sprite27;
            else if (numberAnim == 28)
                GetComponent<Image>().sprite = sprite28;
            else if (numberAnim == 29)
                GetComponent<Image>().sprite = sprite29;
            else if (numberAnim == 30)
                GetComponent<Image>().sprite = sprite30;
            else if (numberAnim == 31)
                GetComponent<Image>().sprite = sprite31;
            else if (numberAnim == 32)
                GetComponent<Image>().sprite = sprite32;

            numberAnim++;
            if (numberAnim > 32)
                numberAnim = 1;
            if (player != null)
                player.GetComponent<Shoots>().usingSpellInt = numberAnim;
        }
	}

    public void SetAnimNb(int nb)
    {
        numberAnim = nb;
    }
}
