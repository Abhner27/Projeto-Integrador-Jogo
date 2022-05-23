[System.Serializable]
public class fruta
{
    public string nome;
    public string cor; //codigo (i.e. #FFFFFF)
    public int id; //codigo (i.e. #FFFFFF)

    public fruta(string _nome, string _cor, int _id)
    {
        this.nome = _nome;
        this.cor = _cor;
        this.id = _id;
    }
}