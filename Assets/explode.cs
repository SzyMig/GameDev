using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("layer"))
        {
            playerMovement temp = other.GetComponent<playerMovement>();
            if (temp != null) 
            {
                temp.playerHP--;
            }

        }
        if (other.CompareTag("Enemy"))
        {
            enemyAI temp = other.GetComponent<enemyAI>();
            if (temp != null)
            {
                temp.enemyHP--;
            }

        }
    }
}
