using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCesta : MonoBehaviour
{
    Camera minhaCam;

    const float limiteEsq = -3f;
    const float limiteDir = 7.5f;

    private void Start()
    {
        minhaCam = Camera.main;
    }

    void Update()
    {
        float x = minhaCam.ScreenToWorldPoint(Input.mousePosition).x;


        if (x <= limiteEsq || x >= limiteDir)
            return;

        transform.position = new Vector2(x, transform.position.y);
    }
}
