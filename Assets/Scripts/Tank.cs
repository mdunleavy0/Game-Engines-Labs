using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject bulletPrefab;

    float spd = 5;
    float rotSpd = 180;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // control tank
        var deltaForward = Input.GetAxis("Vertical") * spd * Time.deltaTime;
        var deltaRot = Input.GetAxis("Horizontal") * rotSpd * Time.deltaTime;
        transform.Translate(0, 0, deltaForward);
        transform.Rotate(0, deltaRot, 0);

        // fire bullets
        if (Input.GetButtonDown("Fire1")) {
            var barrel = transform.Find("Barrel");
            var bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            bullet.transform.Rotate(-90, 0, 0);
        }
    }
}
