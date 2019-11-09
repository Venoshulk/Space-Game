using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player_body;
    public float offsetx;
    public float offsety;
    public float offsetz;
    public float sens = 10f;
    private float vert;
    private float horiz;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        vert += Input.GetAxis("Mouse Y") * -1 * sens * Time.deltaTime;
        horiz += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        vert = Mathf.Clamp(vert, -90f, 90f);

        transform.position = new Vector3((player_body.transform.position.x + offsetx), (player_body.transform.position.y + offsety), (player_body.transform.position.z + offsetz));
        transform.localRotation = Quaternion.Euler(vert, horiz, 0);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
        }
    }
}
