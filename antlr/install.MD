# Instalação do ANTLR

## O que é ANTLR

A ferramenta ANTLR é um gerador de analisadores sintáticos e léxicos. Com ela é possível criar analisadores a partir de um arquivo contendo a gramática e os padrões dos *tokens*. Ferramentas dessa natureza proporcionam um grande avanço no desenvolvimento de compiladores e afins pois criam código para problemas comuns (análise léxica e sintática) de maneira automatizada.

## Como obter o ANTLR

A ferramenta ANTLR foi criada em Java mas é capaz de gerar código para uma enorme lista de linguagens de programação com a ajuda de bibliotecas adicionais (*ANTLR Runtime*). Para começar a utilizar o ANTLR é preciso baixar o gerador de códigos no site oficial [www.antlr.org](https://www.antlr.org/). 

Para criar seu analisador sinático é preciso utilizar a versão [completa do ANTLR](https://www.antlr.org/download/antlr-4.10.1-complete.jar). Nesta versão podemos gerar e testar código além de poder integrar com outra aplicação Java importando o arquivo JAR para nosso projeto.

Caso precise integrar o ANTLR com outra linguagem de programação, é preciso baixar o **runtime** do ANTLR. Esta biblioteca contém as classes e rotinas necessárias para executar o analisador sintático gerado na maioria das linguagens. Para ter mais detalhes de como isso funciona, por favor acesse o [repositório do projeto ANTLR](https://github.com/antlr/antlr4/tree/master/runtime).

## Como utilizar o ANTLR

Para gerar um analisador sintático, o ANTLR utiliza um arquivo de gramática com a extensão **.g4**. Neste arquivo podem ser descritos tanto o analisador sintático (Gramática) quanto o analisador léxico (Expressões Regulares). Também é possível gerar os arquivos de maneira independente como *Parser Grammar* e *Lexer Grammar*. Acredito que essa última opção é mais indicada para problemas complexos com grandes gramáticas.

O exemplo a seguir apresenta uma pequena gramática no arquivo `TestGrammar.g4`:
```antlr
grammar TestGrammar;
atrib: VAR '=' expr;
expr : NUM '+' expr | NUM '-' expr | NUM;

NUM  : [0-9]+;
SUM  : '+';
SUB  : '-';
VAR  : [a-zA-Z]+;
IF   : [iI][fF];
```

A partir do arquivo de gramática (*TestGrammar.g4*) basta invocar o ANTLR da seguinte forma:

    java -jar antlr-4.10.1-complete.jar TestGrammar.g4

**IMPORTANTE!** Note que o arquivo da gramática precisa ter o mesmo nome da gramática descrita nele.

Caso você esteja utilizando o ANTLR com Java, a maioria dos tutoriais na internet pode auxiliar a sua jornada.
Além disso, também é possível aprender muito sobre a construção da gramática nos itens a seguir:

- Documentação do ANTLR [https://github.com/antlr/antlr4/blob/4.10.1/doc/index.md](https://github.com/antlr/antlr4/blob/4.10.1/doc/index.md)

- Perguntas frequêntes [https://github.com/antlr/antlr4/blob/master/doc/faq/index.md](https://github.com/antlr/antlr4/blob/master/doc/faq/index.md)


Para utilizar o ANTLR com C# e .Net6 basta utilizar o runtime adequado: [ANTLR 4.10.1 .NET runtime](https://www.nuget.org/packages/Antlr4.Runtime.Standard) e gerar o código com o parâmetro de linguagem: 

    java -jar antlr4-4.10.1.jar -Dlanguage=CSharp TestGrammar.g4


## Editor

VSCode 
https://code.visualstudio.com/

ANTLR4 grammar syntax support
https://marketplace.visualstudio.com/items?itemName=mike-lischke.vscode-antlr4



## Configuração do Plugin
```json
"antlr4.generation": {
    "mode": "external",
    "language": "CSharp",
    "listeners": true,
    "visitors": true, 
    "outputDir": "output",
    "package": "Grammar"
},
```

## Configuração do Debug

É possível utilizar a função **"Run and Debug"** disponível no Visual Studio Code para testar sua gramática com **ANTLR**.

Para que isso seja possível, além de instalar a extensão do ANTLR, também é preciso criar uma rotina de execução e um arquivo de entrada. 

Os passos a seguir podem lhe ajudar com esta tarefa:

1. Criar um arquivo de execução chamado `launch.json` na raíz do seu projeto dentro da pasta `.vscode`. Observe o conteúdo a seguir de exemplo e ajuste para as suas necessidades.

2. Criar um arquivo de entrada na raíz do seu projeto. Sugiro utilizar o nome `input.txt`. Mas se preferir pode ser outro nome desde que você atualize essa informação no item `input` dentro do arquivo `launch.json`.

3. Para executar sua gramática, basta preencher o arquivo de entrada com o programa e ativar o debug do Visual Studio Code. Nesta função será possível visualizar a árvore de derivação e também os tokens encontrados. 

### Exemplo de código para `launch.json`

```json
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
```