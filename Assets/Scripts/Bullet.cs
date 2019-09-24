using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float spd = 20;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, spd * Time.deltaTime);
    }

    void destroy() { Destroy(this); }
}
