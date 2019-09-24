using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject brickPrefab;

    int height = 7;
    float gap = 0.05f;
    float colorRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        var brickLen = brickPrefab.GetComponent<Renderer>().bounds.size.x;
        var brickMaterial = brickPrefab.GetComponent<Renderer>().sharedMaterial;

        var pos = transform.position;
        pos.y += brickLen / 2 + gap;

        // stack bricks in a pyramid
        for (int r = 0; r < height; r++) {
            pos.x = -0.5f * (height - r) * (brickLen + gap);
            for (int c = 0; c < height - r; c++) {
                // postition brick
                var brick = Instantiate<GameObject>(brickPrefab, transform);
                brick.transform.position = pos;
                pos.x += brickLen + gap;

                // color brick
                float randomFactor() => 1 + Random.Range(-colorRange/2, colorRange/2);
                var mat = Instantiate<Material>(brickMaterial);
                var color = mat.color;
                color.r *= randomFactor();
                color.g *= randomFactor();
                color.b *= randomFactor();
                mat.color = color;
                brick.GetComponent<Renderer>().material = mat;
            }
            pos.x = 0;
            pos.y += brickLen + gap;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
