using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class AzureWebRequest : MonoBehaviour
{
    //https://pi3webgameapp.azurewebsites.net/api/ApiAlunos
    //https://pi3webgameapp.azurewebsites.net/api/APIResultadoJogadas

    void Start()
    {
        //AlunoID aluno = CriarJsonDeAlunoID();

        Resultado aluno = CriarResultado();

        string meuJson = JsonConvert.SerializeObject(aluno);

        Debug.Log("Processo iniciado...");

        Debug.Log("Json enviado: " + meuJson);

        UnityWebRequest uni = CreateUnityWebRequest("https://pi3webgameapp.azurewebsites.net/api/APIResultadoJogadas", meuJson);

        uni.SendWebRequest();
    }

    private static AlunoID CriarJsonDeAlunoID()
    {
        AlunoID aluno = new AlunoID(5, "", new int[1] { 10 }, 5, "Abhner", System.DateTime.Now, "3B", 2002650, 1, "65652");

        return aluno;
    }

    public static Resultado CriarResultado()
    {
        System.DateTime now = System.DateTime.Now;
        System.TimeSpan dateTime = new System.TimeSpan(now.Hour, now.Minute, now.Second);

        Resultado resultado = new Resultado(9, null, null, 10, System.DateTime.Now.Date, dateTime, 20, 1, 40, 15, 10, 50);

        return resultado;
    }

    public static Resultado CriarResultado(int alunoID,int jogoID, int tempoJogada, int acerto, int erro, int pontuacao)
    {
        System.DateTime now = System.DateTime.Now;
        System.TimeSpan dateTime = new System.TimeSpan(now.Hour, now.Minute, now.Second);

        Resultado resultado = new Resultado(9, null, null, 10, System.DateTime.Now.Date, dateTime, alunoID, jogoID, tempoJogada, acerto, erro, pontuacao);

        return resultado;
    }

    public static UnityWebRequest CreateUnityWebRequest(string url, string param)
    {
        UnityWebRequest requestU = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        byte[] bytes = Encoding.UTF8.GetBytes(param);

        UploadHandlerRaw uH = new UploadHandlerRaw(bytes);
        requestU.uploadHandler = uH;
        requestU.SetRequestHeader("Content-Type", "application/json");

        CastleDownloadHandler dH = new CastleDownloadHandler();
        requestU.downloadHandler = dH; //É preciso um download handler para ler a resposta ao envio de dados.
        return requestU;
    }
}

class CastleDownloadHandler : DownloadHandlerScript
{
    public delegate void Finished();
    public event Finished onFinished;

    protected override void CompleteContent()
    {
        UnityEngine.Debug.Log("Processo finalizado com sucesso!");
        base.CompleteContent();
        if (onFinished != null)
        {
            onFinished();
        }
    }
}