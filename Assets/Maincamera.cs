using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 now = new Vector3(0, 0, 0);

    void Start()
    {
        now.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        now.x = transform.position.x;
        now.z = transform.position.z;
        transform.position = now;
    }
}
