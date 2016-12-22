using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    private Vector3     newPosCam = new Vector3(0, 0, -10);
    public  float       speedCam = 0.15f;
 
	void Update ()
    {
        Cursor.lockState = CursorLockMode.Confined;
    /*    if (Input.mousePosition.x <= 0)
        {
            newPosCam.x = transform.position.x - speedCam;
            if (newPosCam.x < -3.2f)
                newPosCam.x = -3.2f;
            transform.position = newPosCam;
        }
        else if (Input.mousePosition.x >= 1279)
        {
            newPosCam.x = transform.position.x + speedCam;
            if (newPosCam.x > 3.13f)
                newPosCam.x = 3.13f;
            transform.position = newPosCam;
        }
        if (Input.mousePosition.y <= 0)
        {
            newPosCam.y = transform.position.y - speedCam;
            if (newPosCam.y < -1.75f)
                newPosCam.y = -1.75f;
            transform.position = newPosCam;
        }
        else if (Input.mousePosition.y >= 719)
        {
            newPosCam.y = transform.position.y + speedCam;
            if (newPosCam.y > 1.8f)
                newPosCam.y = 1.8f;
            transform.position = newPosCam;
        }*/
    }
}
