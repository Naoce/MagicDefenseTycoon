using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour
{
    public int id;
    public float CCDuration;
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }
}
