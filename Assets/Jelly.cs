using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    // Start is called before the first frame update
    float cometome;
    Rigidbody2D jelRig;
    void Start()
    {
        jelRig = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frameasd
    void Update()
    {
        cometome = cookiehuman.CK.cometome;
        if(Mathf.Abs(transform.position.x-cookiehuman.CTF.position.x) <= cometome &&
            Mathf.Abs(transform.position.y- cookiehuman.CTF.position.y) <= cometome)
        {
            Vector2 dirtoPat = Pat.PTF.position - transform.position;
            float stren = 0.5f / Vector2.Distance(Pat.PTF.position, transform.position);
            jelRig.AddForce(stren * dirtoPat, ForceMode2D.Impulse);
        }
    }
    
}
