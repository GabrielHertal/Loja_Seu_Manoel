# 🕹️ Loja do Seu Manoel - Avaliação Técnica .NET

Este projeto consiste em uma **API em .NET 8** que automatiza o processo de **embalagem de pedidos** da loja online do Seu Manoel. A API recebe pedidos com produtos e suas dimensões e retorna a alocação ideal de caixas para o envio dos produtos, minimizando o número de caixas utilizadas.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8.0
- SQL Server
- Docker + Docker Compose
- Entity Framework Core
- Swagger
  
---

## 📦 Caixas Disponíveis

Seu Manoel possui os seguintes tamanhos de caixas:

| Caixa | Altura (cm) | Largura (cm) | Comprimento (cm) |
|-------|-------------|--------------|------------------|
| 1     | 30          | 40           | 80               |
| 2     | 80          | 50           | 40               |
| 3     | 50          | 80           | 60               |

---

## 🧪 Como Rodar o Projeto

### ✅ Pré-requisitos

- Docker instalado

### 🔧 Rodando com Docker Compose

```bash
docker-compose up --build
```

Isso irá:

- Construir a imagem da API
- Subir o container com SQL Server
- Aplicar as migrations e iniciar a aplicação com o banco de dados

### 🌐 Acessar Swagger

Após subir os containers, acesse:

```
http://localhost:5000/swagger
```

---

## 🧾 Exemplo de Uso

### ✅ Entrada (JSON)

```json
{
  "pedidos": [
    {
      "pedido_id": 1,
      "produtos": [
        {"produto_id": "PS5", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
        {"produto_id": "Volante", "dimensoes": {"altura": 40, "largura": 30, "comprimento": 30}}
      ]
    }
  ]
}
```

### 📦 Saída Esperada

```json
{
  "pedidos": [
    {
      "pedido_id": 1,
      "caixas": [
        {
          "caixa_id": "Caixa 2",
          "produtos": ["PS5", "Volante"]
        }
      ]
    }
  ]
}
```

---

## 🧑‍💻 Autor

Gabriel Prigol Hertal  
[GitHub](https://github.com/GabrielHertal)
