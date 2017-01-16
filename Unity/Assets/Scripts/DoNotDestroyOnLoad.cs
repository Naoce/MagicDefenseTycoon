using UnityEngine;
using System.Collections;

public class DoNotDestroyOnLoad : MonoBehaviour
{
	void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        if (tag == "GameManager")
            Application.LoadLevel("SceneMenu");
	}
}
