using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomber : MonoBehaviour
{
    public GameObject explode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3.0f);
        gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
    private void OnDestroy()
    {
        Instantiate(explode, transform.position, transform.rotation);
    }
}
