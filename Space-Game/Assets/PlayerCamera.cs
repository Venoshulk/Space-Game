using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject player_body;
    public float offsetx;
    public float offsety;
    public float offsetz;
    public float sens = 10f;
    float vert;
    float horiz;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Mouse Y") * -1 * sens * Time.deltaTime;
        horiz = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        mainCam.transform.position = new Vector3((player_body.transform.position.x + offsetx), (player_body.transform.position.y + offsety), (player_body.transform.position.z + offsetz));
        mainCam.transform.Rotate(vert, horiz, 0);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCam.transform.Rotate(mainCam.transform.rotation.x, mainCam.transform.rotation.y - 90, mainCam.transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            mainCam.transform.Rotate(mainCam.transform.rotation.x, mainCam.transform.rotation.y + 90, mainCam.transform.rotation.z);
        }
    }
}
