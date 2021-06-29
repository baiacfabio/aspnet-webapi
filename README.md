# aspnet-webapi

[![Test](https://github.com/baiacfabio/aspnet-webapi/actions/workflows/main.yml/badge.svg?branch=main)](https://github.com/baiacfabio/aspnet-webapi/actions/workflows/main.yml)

Exemplo de WEB API com ASPNET Core

Nessa aplicação de exemplo foi exposta uma API para listagem, inclusão e edição de usuários.

Os endpoints seguem o padrão REST, embora a API não seja RESTFULL.

Foram implementadas algumas validações para o caso de alguem tentar criar um usuario com dados inválidos ou tentar alterar um usuario inexistente.

Ao executar a listagem de usuarios pela primeira vez, um algoritmo cria 100 registros aleatorios não repetidos com base em alguns nomes e sobrenomes comuns.


## GET USUARIOS
GET https://localhost:5001/v1/usuarios

Lista todos os usuarios cadastrados.


## GET USUARIOS/:id
GET https://localhost:5001/v1/usuarios/:id

Obtem um usuario pelo ID informado.


## POST USUARIOS
POST https://localhost:5001/v1/usuarios

Cria um usuario.

JSON da Requisição:
```json
{
    "nome": "Fulano",
    "email": "fu.lano",
    "dataNascimento": "2015-12-29"
}
```


## PUT USUARIOS
PUT https://localhost:5001/v1/usuarios

Altera um usuario existente.

JSON da Requisição:
```json
{
    "nome": "Joseph Alves",
    "email": "joseph.alves@email.com.br",
    "dataNascimento": "1989-02-11",
    "id": 3
}
```
