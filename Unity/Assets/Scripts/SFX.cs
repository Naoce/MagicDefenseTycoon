using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    private float length = 10f;
    private float timer = 0f;

	void Start ()
    {
        length = GetComponent<AudioSource>().clip.length;
	}
	
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > length)
            Destroy(gameObject);
	}
}
