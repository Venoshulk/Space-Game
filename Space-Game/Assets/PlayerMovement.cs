using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player_body;
    public GameObject player_cam;
    private Rigidbody rb;

    public float gunRecoil;
    public float playerSpeed;
    public float maxFuel;
    public float fuelConsumption;
    private float doubleTapTimer;
    private float fuelRegen;
    public float currentFuel;
    public float doubleTapDelay;
    private bool hasDashed = false;
    private const float EMPTY = 0f;

    private const string JUMP = "Jump";
    private const string SHIFT = "Descend";

    // Start is called before the first frame update
    void Start()
    {
        maxFuel = 100f;
        fuelConsumption = 0.2f;
        fuelRegen = 0.05f;
        currentFuel = maxFuel;
        rb = player_body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Weapon movement logic
        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(player_cam.transform.forward * -1 * gunRecoil);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //lateral movement logic start
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        //if space pressed and fuel is not empty
        if (Input.GetButton(JUMP) && currentFuel > EMPTY )
        {

            Debug.Log("space");
            Vector3 forceToAdd = new Vector3(0, playerSpeed, 0);
            rb.AddForce(forceToAdd);

            //fuel is zero if no more fuel left, otherwise remove fuel
            currentFuel = currentFuel - fuelConsumption > EMPTY ? currentFuel - fuelConsumption : EMPTY;
        }

        //if pressed pressed and fuel is not empty
        else if (Input.GetButton("Descend") && currentFuel > EMPTY)
        {
            Debug.Log("shift");
            Vector3 forceToAdd = new Vector3(0, playerSpeed * -1, 0);
            rb.AddForce(forceToAdd);

            currentFuel = currentFuel - fuelConsumption > EMPTY ? currentFuel - fuelConsumption : EMPTY;

        }
        //if shift and space is not pressed
        else if (!Input.GetButton(JUMP) && !Input.GetButton("Descend"))
        {
            currentFuel = currentFuel + fuelRegen < maxFuel ? currentFuel += fuelRegen : maxFuel;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //lateral movement logic end
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetButtonDown("Left"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Left") && Time.time < doubleTapTimer)
                {
                    Debug.Log("left with dash");
                    rb.AddForce(player_cam.transform.right * -1 * playerSpeed * playerSpeed);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("left no dash");
                    rb.AddForce(player_cam.transform.right * -1 * playerSpeed);
                }
            }
        }
        if (Input.GetButtonDown("Right"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Right") && Time.time < doubleTapTimer)
                {
                    Debug.Log("right with dash");
                    rb.AddForce(player_cam.transform.right * playerSpeed * playerSpeed);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("right no dash");
                    rb.AddForce(player_cam.transform.right * playerSpeed);
                }
            }
        }
        if (Input.GetButtonDown("Forward"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Forward") && Time.time < doubleTapTimer)
                {
                    Debug.Log("forward with dash");
                    rb.AddForce(player_cam.transform.forward * playerSpeed * playerSpeed);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("forward no dash");
                    rb.AddForce(player_cam.transform.forward * playerSpeed);
                }
            }
        }
        if (Input.GetButtonDown("Backward"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Backward") && Time.time < doubleTapTimer)
                {
                    Debug.Log("backward with dash");
                    rb.AddForce(player_cam.transform.forward * -1 * playerSpeed * playerSpeed);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("backward no dash");
                    rb.AddForce(player_cam.transform.forward * -1 * playerSpeed);
                }
            }
        }
        if (Input.GetButton("Left"))
        {
            Debug.Log("left");
            rb.AddForce(player_cam.transform.right * -1 * playerSpeed);
        }
        if (Input.GetButton("Right"))
        {
            Debug.Log("right");
            rb.AddForce(player_cam.transform.right * playerSpeed);
        }
        if (Input.GetButton("Forward"))
        {
            Debug.Log("right");
            rb.AddForce(player_cam.transform.forward * playerSpeed);
        }
        if (Input.GetButton("Backward"))
        {
            Debug.Log("right");
            rb.AddForce(player_cam.transform.forward * -1 * playerSpeed);
        }

    }
}
