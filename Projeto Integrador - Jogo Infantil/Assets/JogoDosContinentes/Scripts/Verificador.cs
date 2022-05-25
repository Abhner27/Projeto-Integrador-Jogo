using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verificador : MonoBehaviour
{
    public string resposta;
    [SerializeField]
    private GameObject letraPrefab;

    private int index = 0;
    [SerializeField]
    Transform[] listaDePalavras;

    List<Transform> listaDeletras = new List<Transform>();

    [SerializeField]
    GameObject canvasPrincipal;

    private void Start()
    {
        for(int i =0; i<listaDePalavras.Length; i++) //para cada palavra
        {
            for (int j =0; j < listaDePalavras[i].childCount; j++) //em cada letra dessa palavra
            {
                listaDeletras.Add(listaDePalavras[i].GetChild(j));
            }
        }
    }

    public void verificarLetra(BotoesLetras letra)
    {
        if (resposta[index] == letra.letra)
        {
            //correto!
            //add letra no lugr do espaço e tira letra dentre as disponíveis!
            GameObject letraCorreta = Instantiate(letraPrefab, listaDeletras[index]);
            letraCorreta.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = letra.letra.ToString();
            index++;
            Destroy(letra.gameObject);
            //toca som!
            AudioManager.instance.PlaySound("Bong", 1f + (float)index/resposta.Length);

            if (index == resposta.Length)
            {
                StartCoroutine(acertou());
            }
        }
        else
        {
            //mostra um UI de erro!
            AudioManager.instance.PlaySound("Wrong");
            Debug.Log("Essa letra esta errada!");
        }
    }


    IEnumerator acertou()
    {
        MapManager.instance.atualizarContinente();

        yield return new WaitForSeconds(0.6f);
        AudioManager.instance.MudarPitch("Bong", 1f);
        yield return new WaitForSeconds(0.2f);
        AudioManager.instance.PlaySound("LetrasCorretasSound");

        foreach (Transform l in listaDeletras)
        {
            l.GetComponent<Animator>().SetTrigger("UpDown");
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2.5f);

        gameObject.SetActive(false);
        canvasPrincipal.SetActive(true);

    }

}