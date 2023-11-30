using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    private float speed = 100f; // Speed of rotation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the up axis of the GameObject
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

    }
}
