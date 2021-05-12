using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pat : MonoBehaviour
{
    // Start is called before the first frame update
    public static Pat pat;
    public static Transform PTF;
    void Start()
    {
        pat = this;
        PTF = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jelly"))
        {
            cookiehuman.CK.score += 10;
            Destroy(collision.gameObject);
        }
    }
    
}
