using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public float speed = 3f; // The speed that the player will move at.
    Vector3 movement; // The vector to store the direction of the player's movement
    Rigidbody playerRigidbody; // Reference to the player's rigidbody.
    Animator anim;
    public int noBomb = 3;
    public GameObject bombPrefab;
    public int playerHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Move the player around the scene.
        Move(h, v);
        Animating(h, v);
        Turning();
        dropBomb();
        if (playerHP <= 0)
        {
            Destroy(gameObject);
        }

    }
    void Move(float h, float v)
    {

        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);
        // Normalise the movement vector and make it proportional to the speed per second
        movement = movement.normalized * speed * Time.deltaTime;
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
       
    }
    void Turning()
    {
        if (Input.GetKey(KeyCode.W))
        { //Up
            GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        { //Up
            GetComponent<Transform>().rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.S))
        { //Up
            GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        { //Up
            GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
        }


    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is nonzero.
        bool walking = h != 0f || v != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("isWalking", walking);

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("isDancing");

        }
        else
        {
            anim.ResetTrigger("isDancing");
        }
    }
    void dropBomb()
    {
        if (noBomb > 0 && Input.GetKeyUp(KeyCode.Space))
        { //Drop bomb
            Instantiate(bombPrefab, new Vector3(GetComponent<Transform>().position.x, bombPrefab.transform.position.y, GetComponent<Transform>().position.z), bombPrefab.transform.rotation);
            noBomb--;
        }

    }
}
