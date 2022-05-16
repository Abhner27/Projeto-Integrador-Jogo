var unityInstance = UnityLoader.instantiate("unityContainer", "Build/JogoWeb.json", { onProgress: UnityProgress });

function ChamarMetodo(nomeDoObjeto, nomeDoMetodo, args) //os 3 argumentos são do tipo 'string'
{
    unityInstance.SendMessage(nomeDoObjeto, nomeDoMetodo, args);
}

function printarNoConsole() {
    console.log(textoGravadoNaVariavel);
}


let numero = 0;
function mudarNumero() {
    console.log('numero antes: ' + numero);
    numero = ChamarMetodo('MeuObjeto', 'retornarSoma');
    console.log('numero depois: ' + numero);
}

function somarValor(valor) {
    console.log('numero antes: ' + numero);
    numero += valor;
    console.log('numero depois: ' + numero);
}

//var javascriptVariable = '<%= textoSalvo %>'



//function teste() {
    //let val = unityInstance.Module.asmLibraryArg._AddNumbers(1,1);
    //console.log(val);
    //console.log(unityInstance.Module.asmLibraryArg.);
    //unityInstance.Module.asmLibraryArg._AddPonto(1);
    //console.log(unityInstance.Module.asmLibraryArg._retornarPontos());
//}

//function retornarPontuacao() {
    //unityInstance.Module.asmLibraryArg._AddPonto(1);
    //console.log(unityInstance.Module.asmLibraryArg._retornarPontos());
//}


let testObj = { nome: "Abhner", idade: 21 };
let jsonString = JSON.stringify(testObj);
