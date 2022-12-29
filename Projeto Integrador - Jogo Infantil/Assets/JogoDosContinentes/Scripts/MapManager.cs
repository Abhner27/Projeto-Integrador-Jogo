using UnityEngine.Networking;
using Newtonsoft.Json;
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
            Verificador.Pontos++;
            EnviarResultados();
        }
    }

    private void OnApplicationQuit()
    {
        EnviarResultados();
    }

    private static void EnviarResultados()
    {
        Resultado aluno = AzureWebRequest.CriarResultado(IDAluno.id, 2, Verificador.contarTempo.TempoJogada, Verificador.Acertos, Verificador.Erros, Verificador.Pontos);

        string meuJson = JsonConvert.SerializeObject(aluno);

        Debug.Log("Processo iniciado...");

        Debug.Log("Json enviado: " + meuJson);

        UnityWebRequest uni = AzureWebRequest.CreateUnityWebRequest("https://pi3webgameapp.azurewebsites.net/api/APIResultadoJogadas", meuJson);

        uni.SendWebRequest();
    }
}
