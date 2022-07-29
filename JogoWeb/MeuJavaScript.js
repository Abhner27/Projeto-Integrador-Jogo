var unityInstance = UnityLoader.instantiate("unityContainer", "Build/JogoWeb.json", { onProgress: UnityProgress });

function ChamarMetodo(nomeDoObjeto, nomeDoMetodo, args) //os 3 argumentos são do tipo 'string'
{
    unityInstance.SendMessage(nomeDoObjeto, nomeDoMetodo, args);
}
