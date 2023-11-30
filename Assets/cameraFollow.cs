using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.Find("Player");
        
       
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = player.transform.position + offset;
            
        }
        
    }
}
