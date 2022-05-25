using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapManager : MonoBehaviour
{
    private string resposta;

    private GameObject continente;
    private TextMeshProUGUI text;
    private Button button;

    public static MapManager instance;

    [SerializeField]
    private GameObject vitoriaGO;

    const int totalContinentes = 6;
    int quantContinentes = 0;


    private void Awake()
    {
        instance = this;
    }

    public void passarResposta(string res)
    {
        resposta = res;
    }

    public void passarGameObject(GameObject c)
    {
        continente = c;
        text = continente.GetComponentInChildren<TextMeshProUGUI>();
        button = continente.GetComponent<Button>();
    }

    public void atualizarContinente()
    {
        button.interactable = false;
        text.text = resposta;
        continente.transform.localScale = Vector3.one;

        quantContinentes++;
        if (quantContinentes == totalContinentes)
        {
            vitoriaGO.SetActive(true);
        }


    }

}
