const express = require('express');
const app = express();
const PORT = process.env.PORT || 3000;

// Middleware para processar JSON
app.use(express.json());

// Banco de dados em memória
let produtos = [];
let proximoId = 1;

// ==================== ROTAS CRUD ====================

// CREATE - Criar um novo produto
app.post('/products', (req, res) => {
  const { nome, marca, categoria, preco, estoque, descricao } = req.body;
  
  // Validação básica
  if (!nome || !marca || !preco) {
    return res.status(400).json({ 
      erro: 'Campos obrigatórios: nome, marca e preco' 
    });
  }
  
  if (preco < 0) {
    return res.status(400).json({ 
      erro: 'O preço não pode ser negativo' 
    });
  }
  
  const novoProduto = {
    id: proximoId++,
    nome,
    marca,
    categoria: categoria || 'Não categorizado',
    preco: parseFloat(preco),
    estoque: estoque || 0,
    descricao: descricao || '',
    dataCriacao: new Date().toISOString()
  };
  
  produtos.push(novoProduto);
  res.status(201).json(novoProduto);
});

// READ - Buscar todos os produtos
app.get('/products', (req, res) => {
  const { categoria, marca } = req.query;
  
  let produtosFiltrados = produtos;
  
  // Filtro por categoria
  if (categoria) {
    produtosFiltrados = produtosFiltrados.filter(p => 
      p.categoria.toLowerCase() === categoria.toLowerCase()
    );
  }
  
  // Filtro por marca
  if (marca) {
    produtosFiltrados = produtosFiltrados.filter(p => 
      p.marca.toLowerCase() === marca.toLowerCase()
    );
  }
  
  res.json({
    total: produtosFiltrados.length,
    produtos: produtosFiltrados
  });
});

// READ - Buscar um produto específico por ID
app.get('/products/:id', (req, res) => {
  const id = parseInt(req.params.id);
  
  if (isNaN(id)) {
    return res.status(400).json({ 
      erro: 'ID inválido' 
    });
  }
  
  const produto = produtos.find(p => p.id === id);
  
  if (!produto) {
    return res.status(404).json({ 
      erro: 'Produto não encontrado' 
    });
  }
  
  res.json(produto);
});

// UPDATE - Atualizar um produto
app.put('/products/:id', (req, res) => {
  const id = parseInt(req.params.id);
  
  if (isNaN(id)) {
    return res.status(400).json({ 
      erro: 'ID inválido' 
    });
  }
  
  const index = produtos.findIndex(p => p.id === id);
  
  if (index === -1) {
    return res.status(404).json({ 
      erro: 'Produto não encontrado' 
    });
  }
  
  const { nome, marca, categoria, preco, estoque, descricao } = req.body;
  
  // Validação de preço
  if (preco !== undefined && preco < 0) {
    return res.status(400).json({ 
      erro: 'O preço não pode ser negativo' 
    });
  }
  
  // Atualizar campos fornecidos
  const produtoAtualizado = {
    ...produtos[index],
    nome: nome !== undefined ? nome : produtos[index].nome,
    marca: marca !== undefined ? marca : produtos[index].marca,
    categoria: categoria !== undefined ? categoria : produtos[index].categoria,
    preco: preco !== undefined ? parseFloat(preco) : produtos[index].preco,
    estoque: estoque !== undefined ? estoque : produtos[index].estoque,
    descricao: descricao !== undefined ? descricao : produtos[index].descricao,
    dataAtualizacao: new Date().toISOString()
  };
  
  produtos[index] = produtoAtualizado;
  res.json(produtoAtualizado);
});

// DELETE - Excluir um produto
app.delete('/products/:id', (req, res) => {
  const id = parseInt(req.params.id);
  
  if (isNaN(id)) {
    return res.status(400).json({ 
      erro: 'ID inválido' 
    });
  }
  
  const index = produtos.findIndex(p => p.id === id);
  
  if (index === -1) {
    return res.status(404).json({ 
      erro: 'Produto não encontrado' 
    });
  }
  
  const produtoRemovido = produtos[index];
  produtos.splice(index, 1);
  
  res.json({ 
    mensagem: 'Produto excluído com sucesso',
    produto: produtoRemovido
  });
});

// Rota raiz
app.get('/', (req, res) => {
  res.json({
    mensagem: 'API de Cosméticos - CRUD',
    endpoints: {
      'POST /products': 'Criar novo produto',
      'GET /products': 'Listar todos os produtos',
      'GET /products/:id': 'Buscar produto por ID',
      'PUT /products/:id': 'Atualizar produto',
      'DELETE /products/:id': 'Excluir produto'
    }
  });
});

// Iniciar servidor
app.listen(PORT, () => {
  console.log(`Servidor rodando na porta ${PORT}`);
  console.log(`Acesse: http://localhost:${PORT}`);
});
