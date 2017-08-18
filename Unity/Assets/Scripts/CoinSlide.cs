using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSlide : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(-30f, -190f, 0f);
    private Vector3 endPosition = new Vector3(-30f, -290f, 0f);

    private void Update()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(-30, GetComponent<RectTransform>().localPosition.y - (Time.deltaTime * 800), 0f);
        if (GetComponent<RectTransform>().localPosition.y < endPosition.y)
            GetComponent<RectTransform>().localPosition = endPosition;
    }

    public void StartAnimation()
    {
        GetComponent<RectTransform>().localPosition = startPosition;
    }
}
