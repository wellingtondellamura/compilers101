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



## Configuração

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