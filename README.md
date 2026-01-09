# API-Cosm-tico 💄

API REST para gerenciamento de produtos cosméticos com operações CRUD completas.

## 📋 Descrição

Esta API permite criar, listar, atualizar e excluir produtos de uma loja de cosméticos. Desenvolvida com Node.js e Express.

## 🚀 Como Executar

### Pré-requisitos
- Node.js instalado (versão 12 ou superior)

### Instalação

```bash
# Instalar dependências
npm install

# Iniciar o servidor
npm start
```

A API estará disponível em `http://localhost:3000`

## 📡 Endpoints da API

### 1. CREATE - Criar Produto
**POST** `/products`

Cria um novo produto cosmético.

**Body:**
```json
{
  "nome": "Batom Vermelho",
  "marca": "Eudora",
  "categoria": "Maquiagem",
  "preco": 29.90,
  "estoque": 50,
  "descricao": "Batom vermelho de longa duração"
}
```

**Campos obrigatórios:** `nome`, `marca`, `preco`

**Resposta de Sucesso (201):**
```json
{
  "id": 1,
  "nome": "Batom Vermelho",
  "marca": "Eudora",
  "categoria": "Maquiagem",
  "preco": 29.90,
  "estoque": 50,
  "descricao": "Batom vermelho de longa duração",
  "dataCriacao": "2024-01-09T19:00:00.000Z"
}
```

### 2. READ - Listar Todos os Produtos
**GET** `/products`

Lista todos os produtos cadastrados. Suporta filtros opcionais.

**Parâmetros de Query (opcionais):**
- `categoria` - Filtrar por categoria
- `marca` - Filtrar por marca

**Exemplos:**
```
GET /products
GET /products?categoria=Maquiagem
GET /products?marca=Eudora
```

**Resposta de Sucesso (200):**
```json
{
  "total": 2,
  "produtos": [
    {
      "id": 1,
      "nome": "Batom Vermelho",
      "marca": "Eudora",
      "categoria": "Maquiagem",
      "preco": 29.90,
      "estoque": 50,
      "descricao": "Batom vermelho de longa duração",
      "dataCriacao": "2024-01-09T19:00:00.000Z"
    }
  ]
}
```

### 3. READ - Buscar Produto por ID
**GET** `/products/:id`

Busca um produto específico pelo ID.

**Exemplo:**
```
GET /products/1
```

**Resposta de Sucesso (200):**
```json
{
  "id": 1,
  "nome": "Batom Vermelho",
  "marca": "Eudora",
  "categoria": "Maquiagem",
  "preco": 29.90,
  "estoque": 50,
  "descricao": "Batom vermelho de longa duração",
  "dataCriacao": "2024-01-09T19:00:00.000Z"
}
```

**Resposta de Erro (404):**
```json
{
  "erro": "Produto não encontrado"
}
```

### 4. UPDATE - Atualizar Produto
**PUT** `/products/:id`

Atualiza os dados de um produto existente.

**Body (todos os campos opcionais):**
```json
{
  "nome": "Batom Vermelho Intenso",
  "preco": 34.90,
  "estoque": 45
}
```

**Resposta de Sucesso (200):**
```json
{
  "id": 1,
  "nome": "Batom Vermelho Intenso",
  "marca": "Eudora",
  "categoria": "Maquiagem",
  "preco": 34.90,
  "estoque": 45,
  "descricao": "Batom vermelho de longa duração",
  "dataCriacao": "2024-01-09T19:00:00.000Z",
  "dataAtualizacao": "2024-01-09T19:15:00.000Z"
}
```

### 5. DELETE - Excluir Produto
**DELETE** `/products/:id`

Remove um produto do sistema.

**Exemplo:**
```
DELETE /products/1
```

**Resposta de Sucesso (200):**
```json
{
  "mensagem": "Produto excluído com sucesso",
  "produto": {
    "id": 1,
    "nome": "Batom Vermelho",
    "marca": "Eudora",
    "categoria": "Maquiagem",
    "preco": 29.90,
    "estoque": 50
  }
}
```

## 🧪 Testando a API

### Usando cURL:

```bash
# Criar produto
curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{"nome":"Batom Vermelho","marca":"Eudora","categoria":"Maquiagem","preco":29.90,"estoque":50}'

# Listar produtos
curl http://localhost:3000/products

# Buscar produto específico
curl http://localhost:3000/products/1

# Atualizar produto
curl -X PUT http://localhost:3000/products/1 \
  -H "Content-Type: application/json" \
  -d '{"preco":34.90}'

# Excluir produto
curl -X DELETE http://localhost:3000/products/1
```

## 📦 Estrutura de Dados

### Produto

| Campo | Tipo | Obrigatório | Descrição |
|-------|------|-------------|-----------|
| id | number | Auto | Identificador único |
| nome | string | Sim | Nome do produto |
| marca | string | Sim | Marca do produto |
| categoria | string | Não | Categoria (padrão: "Não categorizado") |
| preco | number | Sim | Preço do produto |
| estoque | number | Não | Quantidade em estoque (padrão: 0) |
| descricao | string | Não | Descrição do produto |
| dataCriacao | string | Auto | Data de criação (ISO 8601) |
| dataAtualizacao | string | Auto | Data da última atualização (ISO 8601) |

## 🛠️ Tecnologias Utilizadas

- Node.js
- Express.js

## 📝 Notas

- Esta API utiliza armazenamento em memória. Os dados serão perdidos ao reiniciar o servidor.
- Para produção, considere integrar um banco de dados como MongoDB ou PostgreSQL.

## 📄 Licença

ISC
