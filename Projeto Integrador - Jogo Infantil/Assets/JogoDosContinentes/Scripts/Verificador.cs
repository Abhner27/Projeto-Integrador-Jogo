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

            if (index == resposta.Length)
            {
                    //da como correto!
                    //acaba essa prte a fase!
                    //atualiza o nome no mapa mundi!
                Debug.Log("Concluiu!");
                MapManager.instance.atualizarContinente();
                gameObject.SetActive(false);
                canvasPrincipal.SetActive(true);
            }
        }
        else
        {
            //mostra um UI de erro!
            Debug.Log("Essa letra esta errada!");
        }
    }
}