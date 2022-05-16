using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MudarTexto : MonoBehaviour
{
    public Text texto;
    public string textoSalvo = "Abhner";

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    private void Start()
    {
        PlayerPrefs.SetString("Primeira string", "Olá mundo!");
        PlayerPrefs.SetString("Segunda string", "Tchau mundo!");
        Hello();
    }
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            texto.text = PlayerPrefs.GetString("Primeira string");
        }
        else if (Input.GetKeyDown("d"))
        {
            texto.text = PlayerPrefs.GetString("Segunda string");
        }
    }

    public void setText(string novoTexto)
    {
        texto.text = novoTexto;
    }

    public void JSLIBSetString(string novoTexto)
    {
        HelloString(novoTexto);
    }

    public string getText()
    {
        return texto.text;
    }

    public void saveText()
    {
        textoSalvo = texto.text;
    }

    public void showSavedText()
    {
        texto.text = textoSalvo;
    }

    public void MudarParaCena(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void setJson(string json)
    {
        JasonObj jsonObj = JsonUtility.FromJson<JasonObj>(json);
        texto.text = "Nome " + jsonObj.nome + ", idade: " + jsonObj.idade;
    }

    public class JasonObj
    {
        public string nome;
        public int idade;
    }
}
