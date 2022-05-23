using UnityEngine;
using UnityEngine.UI;

public class CriarFruta : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    bool objCriado = false;
    GameObject obj;

    public delegate void verificar(GameObject gameObject);
    public static event verificar ver; 

    public void Criar(GameObject frutaImage)
    {
        obj = Instantiate(prefab, transform);
        objCriado = true;

        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        RectTransform frutaRectTransform = frutaImage.GetComponent<RectTransform>();

        obj.GetComponent<frutaAtributes>().fruta.id = frutaImage.GetComponent<frutaAtributes>().fruta.id;

        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, frutaRectTransform.rect.width);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, frutaRectTransform.rect.height);

        obj.GetComponent<Image>().sprite = frutaImage.GetComponent<Image>().sprite;
    }

    private void Update()
    {
        if (!objCriado)
            return;

        obj.transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            ver?.Invoke(obj);

            Destroy(obj);
            objCriado = false;
        }
    }
}
