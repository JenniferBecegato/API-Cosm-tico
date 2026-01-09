# Exemplos de Uso da API 🧪

Este arquivo contém exemplos práticos de como usar a API de Cosméticos.

## Iniciando a API

```bash
npm install
npm start
```

A API estará rodando em `http://localhost:3000`

## Exemplos de Requisições

### 1. Criar Produtos

```bash
# Criar um batom
curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Batom Vermelho Matte",
    "marca": "Eudora",
    "categoria": "Maquiagem",
    "preco": 29.90,
    "estoque": 50,
    "descricao": "Batom vermelho matte de longa duração"
  }'

# Criar um perfume
curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Perfume Lily",
    "marca": "Boticário",
    "categoria": "Perfumaria",
    "preco": 89.90,
    "estoque": 30,
    "descricao": "Perfume floral feminino"
  }'

# Criar um hidratante
curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Hidratante Facial",
    "marca": "Nivea",
    "categoria": "Cuidados com a Pele",
    "preco": 25.00,
    "estoque": 100
  }'
```

### 2. Listar Produtos

```bash
# Listar todos os produtos
curl http://localhost:3000/products

# Filtrar produtos por categoria
curl "http://localhost:3000/products?categoria=Maquiagem"

# Filtrar produtos por marca
curl "http://localhost:3000/products?marca=Nivea"

# Combinar filtros
curl "http://localhost:3000/products?categoria=Maquiagem&marca=Eudora"
```

### 3. Buscar Produto Específico

```bash
# Buscar produto por ID
curl http://localhost:3000/products/1
```

### 4. Atualizar Produtos

```bash
# Atualizar apenas o preço
curl -X PUT http://localhost:3000/products/1 \
  -H "Content-Type: application/json" \
  -d '{
    "preco": 34.90
  }'

# Atualizar múltiplos campos
curl -X PUT http://localhost:3000/products/1 \
  -H "Content-Type: application/json" \
  -d '{
    "preco": 34.90,
    "estoque": 45,
    "descricao": "Batom vermelho matte de longa duração - Edição limitada"
  }'
```

### 5. Excluir Produtos

```bash
# Excluir produto por ID
curl -X DELETE http://localhost:3000/products/1
```

## Cenários de Uso

### Cenário 1: Adicionar Novo Estoque de Produtos

```bash
# Adicionar vários produtos de uma vez
curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{"nome":"Máscara de Cílios","marca":"Maybelline","categoria":"Maquiagem","preco":35.90,"estoque":60}'

curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{"nome":"Esmalte Vermelho","marca":"Risqué","categoria":"Unhas","preco":8.90,"estoque":120}'

curl -X POST http://localhost:3000/products \
  -H "Content-Type: application/json" \
  -d '{"nome":"Shampoo Nutritivo","marca":"Pantene","categoria":"Cabelos","preco":15.90,"estoque":80}'
```

### Cenário 2: Atualizar Preços em Promoção

```bash
# Reduzir preço do produto 1 em 20%
curl -X PUT http://localhost:3000/products/1 \
  -H "Content-Type: application/json" \
  -d '{"preco": 27.92}'
```

### Cenário 3: Gerenciar Inventário

```bash
# Listar produtos com estoque baixo (manualmente verificar)
curl http://localhost:3000/products

# Atualizar estoque após venda
curl -X PUT http://localhost:3000/products/1 \
  -H "Content-Type: application/json" \
  -d '{"estoque": 45}'
```

### Cenário 4: Consultar Catálogo por Categoria

```bash
# Ver todos os produtos de maquiagem
curl "http://localhost:3000/products?categoria=Maquiagem"

# Ver todos os produtos para cabelo
curl "http://localhost:3000/products?categoria=Cabelos"
```

## Respostas da API

### Resposta de Sucesso - Criar Produto (201)
```json
{
  "id": 1,
  "nome": "Batom Vermelho Matte",
  "marca": "Eudora",
  "categoria": "Maquiagem",
  "preco": 29.90,
  "estoque": 50,
  "descricao": "Batom vermelho matte de longa duração",
  "dataCriacao": "2024-01-09T19:00:00.000Z"
}
```

### Resposta de Sucesso - Listar Produtos (200)
```json
{
  "total": 3,
  "produtos": [
    {
      "id": 1,
      "nome": "Batom Vermelho Matte",
      "marca": "Eudora",
      "categoria": "Maquiagem",
      "preco": 29.90,
      "estoque": 50,
      "descricao": "Batom vermelho matte de longa duração",
      "dataCriacao": "2024-01-09T19:00:00.000Z"
    }
  ]
}
```

### Resposta de Erro - Validação (400)
```json
{
  "erro": "Campos obrigatórios: nome, marca e preco"
}
```

### Resposta de Erro - Não Encontrado (404)
```json
{
  "erro": "Produto não encontrado"
}
```

## Testando com Postman

1. Importe a coleção criando um novo request
2. Configure:
   - Method: POST, GET, PUT ou DELETE
   - URL: `http://localhost:3000/products`
   - Headers: `Content-Type: application/json`
   - Body (para POST/PUT): JSON com os dados do produto

## Testando com Navegador

Você pode testar os endpoints GET diretamente no navegador:

- `http://localhost:3000/` - Ver endpoints disponíveis
- `http://localhost:3000/products` - Listar todos os produtos
- `http://localhost:3000/products/1` - Ver produto específico
- `http://localhost:3000/products?categoria=Maquiagem` - Filtrar por categoria
