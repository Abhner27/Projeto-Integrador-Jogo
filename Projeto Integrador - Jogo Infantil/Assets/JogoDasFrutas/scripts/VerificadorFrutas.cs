using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificadorFrutas : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public int[,] frutasInfo = new int[3, 2]
        {
            {0, 10}, {0, 10}, {0, 10}
        };
    int pedidos = 0;
    int resposta = 0;
    

    private void Start()
    {
        CriarFruta.ver += verificarDistancia;
    }


    public void verificarDistancia(GameObject gameObject)
    {
        if (Vector2.Distance(gameObject.transform.position,  transform.position) < 150f)
        {
            Criar(gameObject);

            if (resposta == 0)
            {
                //certo!
                //add pontos
                frutasManager.instance.pontuacao.AddPontos(100);
                //chamar novoPedido
                frutasManager.instance.pedido.NovoPedido(Random.Range(1,4));
            }
        }
    }

    public void resetarParaPedido()
    {
        pedidos = 0;
        resposta = 0;

        foreach (Transform go in transform)
        {
            Destroy(go.gameObject);
        }
    }

    public void receberUmNovoPedido(int quantFrutas, int idFrutas)
    {
        frutasInfo[pedidos, 0] = quantFrutas;
        frutasInfo[pedidos,1] = idFrutas;
        pedidos++;

        resposta += quantFrutas;
    }

    public void Criar(GameObject frutaImage)
    {
        if (!verificarValorId(frutaImage.GetComponent<frutaAtributes>().fruta.id))
        {
            //da tela de erro!
            return;
        }

        GameObject obj = Instantiate(prefab, transform);

        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        RectTransform frutaRectTransform = frutaImage.GetComponent<RectTransform>();

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, frutaRectTransform.rect.width);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, frutaRectTransform.rect.height);

        obj.GetComponent<Image>().sprite = frutaImage.GetComponent<Image>().sprite;
        resposta--;
    }

    private bool verificarValorId(int id)
    {
        for(int i =0; i < frutasInfo.Length; i++)
        {
            if (frutasInfo[i, 1] == id)
            {
                frutasInfo[i, 0] = frutasInfo[i, 0] - 1;

                if (frutasInfo[i, 0] == 0)
                    frutasInfo[i, 1] = 10;

                return true;
            }
        }
        return false;
    }

    private void OnDestroy()
    {
        CriarFruta.ver -= verificarDistancia;
    }
}
