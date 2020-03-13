using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player_body;
    public GameObject player_cam;
    private Rigidbody rb;

    public float gunThrust;
    public float fuelThrust;
    public float fuelTotal;
    public float fuelConsumption;
    public float currentFuel;
    public float fuelRegen;

    private float doubleTapTimer;
    public float doubleTapDelay;

    private bool hasDashed = false;
    private const float EMPTY = 0f;

    private const string JUMP = "Jump";
    private const string SHIFT = "Descend";

    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fuelTotal = 100f;
        fuelConsumption = 0.2f;
        currentFuel = fuelTotal;
        rb = player_body.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(player_cam.transform.forward * -1 * gunThrust);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //lateral movement logic start
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetButtonDown(SHIFT) && currentFuel > EMPTY)
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Descend") && Time.time < doubleTapTimer)
                {
                    Debug.Log("Descend with dash");
                    Vector3 forceToAdd = new Vector3(0, fuelThrust * fuelThrust * -1, 0);
                    rb.AddForce(forceToAdd);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("Descend no dash");
                    Vector3 forceToAdd = new Vector3(0, fuelThrust * -1, 0);
                    rb.AddForce(forceToAdd);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //lateral movement logic start
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        else if (Input.GetButtonDown(JUMP) && currentFuel > EMPTY)
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;

            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Jump") && Time.time < doubleTapTimer)
                {
                    Debug.Log("jump with dash");
                    Vector3 forceToAdd = new Vector3(0, fuelThrust * fuelThrust, 0);
                    rb.AddForce(forceToAdd);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("jump no dash");
                    Vector3 forceToAdd = new Vector3(0, fuelThrust, 0);
                    rb.AddForce(forceToAdd);
                }
            }

        }
        //if shift and space is not pressed
        else if (!Input.GetButton(JUMP) && !Input.GetButton(SHIFT))
        {
            currentFuel = currentFuel + fuelRegen < fuelTotal ? currentFuel += fuelRegen : fuelTotal;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //lateral movement logic end
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetButtonDown("Left"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;
            playerAnimator.ResetTrigger("movingRight");
            playerAnimator.SetTrigger("movingLeft");
            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Left") && Time.time < doubleTapTimer)
                {
                    Debug.Log("left with dash");
                    rb.AddForce(player_cam.transform.right * -1 * fuelThrust * fuelThrust);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("left no dash");
                    rb.AddForce(player_cam.transform.right * -1 * fuelThrust);
                }
            }
        }
        if (Input.GetButtonDown("Right"))
        {
            doubleTapTimer = Time.time + doubleTapDelay;
            hasDashed = false;
            playerAnimator.ResetTrigger("movingLeft");
            playerAnimator.SetTrigger("movingRight");
            while (Time.time < doubleTapTimer && !hasDashed)
            {
                if (Input.GetButtonDown("Right") && Time.time < doubleTapTimer)
                {
                    Debug.Log("right with dash");
                    rb.AddForce(player_cam.transform.right * fuelThrust * fuelThrust);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("right no dash");
                    rb.AddForce(player_cam.transform.right * fuelThrust);
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
                    rb.AddForce(player_cam.transform.forward * fuelThrust * fuelThrust);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("forward no dash");
                    rb.AddForce(player_cam.transform.forward * fuelThrust);
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
                    rb.AddForce(player_cam.transform.forward * -1 * fuelThrust * fuelThrust);
                    hasDashed = true;
                }
                else
                {
                    Debug.Log("backward no dash");
                    rb.AddForce(player_cam.transform.forward * -1 * fuelThrust);
                }
            }
        }
        if (Input.GetButton("Jump") && currentFuel > EMPTY)
        {
            Debug.Log("space");
            Vector3 forceToAdd = new Vector3(0, fuelThrust, 0);
            rb.AddForce(forceToAdd);
            currentFuel = currentFuel - fuelConsumption > EMPTY ? currentFuel - fuelConsumption : EMPTY;

        }
        if (Input.GetButton("Descend") && currentFuel > EMPTY)
        {
            Debug.Log("shift");
            Vector3 forceToAdd = new Vector3(0, fuelThrust * -1, 0);
            rb.AddForce(forceToAdd);
            currentFuel = currentFuel - fuelConsumption > EMPTY ? currentFuel - fuelConsumption : EMPTY;
        }
        if (Input.GetButton("Left"))
        {
            playerAnimator.ResetTrigger("movingRight");
            playerAnimator.SetTrigger("movingLeft");
            Debug.Log("left");
            rb.AddForce(player_cam.transform.right * -1 * fuelThrust);
        }
        if (Input.GetButton("Right"))
        {
            playerAnimator.ResetTrigger("movingLeft");
            playerAnimator.SetTrigger("movingRight");
            Debug.Log("right");
            rb.AddForce(player_cam.transform.right * fuelThrust);
        }
        if (Input.GetButton("Forward"))
        {
            Debug.Log("right");
            rb.AddForce(player_cam.transform.forward * fuelThrust);
        }
        if (Input.GetButton("Backward"))
        {
            Debug.Log("right");
            rb.AddForce(player_cam.transform.forward * -1 * fuelThrust);
        }

    }
}