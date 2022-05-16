using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmbaralharLetras : MonoBehaviour
{
    List<Transform> letras = new List<Transform>();
    private void Start()
    {
        acharLetras();
        embaralharLetras();
    }

    private void acharLetras()
    {
        foreach(Transform letra in transform)
        {
            letras.Add(letra);
        }
    }

    private void embaralharLetras()
    {
        foreach (Transform letra in letras)
        {
            letra.SetSiblingIndex(Random.Range(0, letras.Count));
        }
    }
}
