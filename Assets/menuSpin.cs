using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpin : MonoBehaviour
{
    GameObject focus;
    private Vector3 offset;
    private float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        focus = GameObject.Find("Focus");
        
       
        offset = transform.position - focus.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(focus != null)
        {
            offset = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up) * offset;

            transform.position = focus.transform.position + offset;
            transform.LookAt(focus.transform.position);
        }
        
    }
}
