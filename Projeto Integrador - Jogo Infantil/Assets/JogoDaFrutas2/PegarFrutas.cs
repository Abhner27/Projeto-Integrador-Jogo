using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarFrutas : MonoBehaviour
{
    VerificadorFrutasManager verificadorFrutas;
    private void Start()
    {
        verificadorFrutas = GetComponent<VerificadorFrutasManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colisor"))
        {
            verificadorFrutas.verificar(collision.GetComponent<FrutaId>().ID);

            Destroy(collision.gameObject);
        }
    }
}
