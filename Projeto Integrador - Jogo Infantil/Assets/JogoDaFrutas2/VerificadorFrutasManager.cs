using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine;

public class VerificadorFrutasManager : MonoBehaviour
{
    // 0 -  maça
    // 1 -  abacaxi
    // 2 -  melancia
    // 3 -  morango
    // 4 -  pera
    // 5 -  uvas

    [HideInInspector]
    public int Rodada = 1;
    [HideInInspector]
    public int Erros = 0;
    [HideInInspector]
    public int Acertos = 0;
    [SerializeField]
    private PontuacaoFrutas pontuacao;

    private ContarTempo contarTempo;

    public GameObject VitoriaGO;
    public GameObject geradores;

    private void Start()
    {
        contarTempo = gameObject.AddComponent<ContarTempo>();
        contarTempo.Iniciar();
    }

    public void verificar(int ID)
    {
        if (frutas.pedidos[ID].quantAtual >= frutas.pedidos[ID].quantRequerida) //perde pontos?
        {
            pontuacao.addPontos(-10);
            AudioManager.instance.PlaySound("Wrong");
            Erros++;


            //if erro == 5
            //acaba!

            return;
        }

        PedidosFrutas.addFruta(frutas.pedidos[ID]);
        //addPontos!
        pontuacao.addPontos(10);
        Acertos++;
        AudioManager.instance.PlaySound("Pop", Random.Range(0.9f, 1.2f));

        if (PedidosFrutas.completou() == true)
        {
            PedidosFrutas.novoPedido();
            AudioManager.instance.PlaySound("Vitória");
            pontuacao.addPontos(100);
            Rodada++;

            if (Rodada == 3)
            {
                DificuldadeFrutas.MaiorValorTempo -= 1f;
            }

            if (Rodada == 5)
            {
                DificuldadeFrutas.QuantMaxPedidos++;
            }

            if (Rodada == 7)
            {
                DificuldadeFrutas.MaiorValorTempo -= 1f;
            }

            if (Rodada == 9)
            {
                DificuldadeFrutas.QuantMaxPedidos++;
            }
            if (Rodada == 10)
            {
                EnviarJson();
                VitoriaGO.SetActive(true);
                geradores.SetActive(false);
                //Acabar jogo!
            }
        }
    }

    private void EnviarJson()
    {
        Resultado aluno = AzureWebRequest.CriarResultado(IDAluno.id, 1, contarTempo.TempoJogada, Acertos, Erros, pontuacao.Pontos);

        string meuJson = JsonConvert.SerializeObject(aluno);

        Debug.Log("Processo iniciado...");

        Debug.Log("Json enviado: " + meuJson);

        UnityWebRequest uni = AzureWebRequest.CreateUnityWebRequest("https://pi3webgameapp.azurewebsites.net/api/APIResultadoJogadas", meuJson);

        uni.SendWebRequest();
    }

    public void VoltarAoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
