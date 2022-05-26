using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeFrutas : MonoBehaviour
{
    [SerializeField]
    Transform[] posicoes;

    [SerializeField]
    GameObject[] frutas;

    private void Start()
    {
        StartCoroutine(cooldown());
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        GerarFruta();
        StartCoroutine(cooldown());
    }


    private void GerarFruta()
    {
        int posAleatoria = Random.Range(0, posicoes.Length);
        int frutaAleatoria = Random.Range(0, frutas.Length);

        Instantiate(frutas[frutaAleatoria], posicoes[posAleatoria].position, Quaternion.identity);
    }
}
