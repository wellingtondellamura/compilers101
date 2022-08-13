# Instalação do ANTLR


ANTLR tool and Java Target
Complete ANTLR 4.10.1 Java binaries jar.  (https://www.antlr.org/download/antlr-4.10.1-complete.jar)
Complete ANTLR 4.10.1 tool, Java runtime and ST 4.0.8, which lets you run the tool and the generated code.

ANTLR 4.10.1 distribution (zip). (https://github.com/antlr/antlr4/archive/4.10.1.zip)
Everything you need to build the tool and Java runtime from source.

ANTLR 4.10.1 Java runtime binaries jar. (https://www.antlr.org/download/antlr-runtime-4.10.1.jar)
Only what's needed for building and executing parsers/lexers generated in Java.


ANTLR 4.10.1 .NET runtime (https://www.nuget.org/packages/Antlr4.Runtime.Standard)
Package: Antlr4.Runtime.Standard

java -jar antlr4-4.10.1.jar -Dlanguage=CSharp grammar.g4


## DOCS
https://github.com/antlr/antlr4/blob/4.10.1/doc/index.md

https://github.com/antlr/antlr4/blob/master/doc/faq/index.md


## Editor

VSCode 
https://code.visualstudio.com/

ANTLR4 grammar syntax support
https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4



## Configuração do Plugin
``
"antlr4.generation": {
        "mode": "external",
        "language": "CSharp",
        "listeners": true,
        "visitors": true, 
        "outputDir": "output",
        "package": "Grammar"
    },
``

## Configuração do Debug

É possível utilizar a função **"Run and Debug"** disponível no Visual Studio Code para testar sua gramática com **ANTLR**.

Para que isso seja possível, além de instalar a extensão do ANTLR, também é preciso criar uma rotina de execução e um arquivo de entrada. 

Os passos a seguir podem lhe ajudar com esta tarefa:

1. Criar um arquivo de execução chamado `launch.json` na raíz do seu projeto dentro da pasta `.vscode`. Observe o conteúdo a seguir de exemplo e ajuste para as suas necessidades.

2. Criar um arquivo de entrada na raíz do seu projeto. Sugiro utilizar o nome `input.txt`. Mas se preferir pode ser outro nome desde que você atualize essa informação no item `input` dentro do arquivo `launch.json`.

3. Para executar sua gramática, basta preencher o arquivo de entrada com o programa e ativar o debug do Visual Studio Code. Nesta função será possível visualizar a árvore de derivação e também os tokens encontrados. 

### Exemplo de código para `launch.json`
    {
        "version": "2.0.0",
        "configurations": [
            {
            "name": "antlr4",
            "type": "antlr-debug",
            "request": "launch",
            "input": "input.txt",
            "grammar": "${file}",
            "startRule": "prog",
            "printParseTree": true,
            "visualParseTree": true
        }]
    }