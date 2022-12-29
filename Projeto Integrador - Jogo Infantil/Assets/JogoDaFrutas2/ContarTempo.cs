using UnityEngine;
using System.Collections;

public class ContarTempo : MonoBehaviour
{
    public int TempoJogada;

    public void Iniciar()
    {
        StartCoroutine(PassarSegundo());
    }

    IEnumerator PassarSegundo()
    {
        TempoJogada++;
        yield return new WaitForSeconds(1);
        StartCoroutine(PassarSegundo());
    }
}

