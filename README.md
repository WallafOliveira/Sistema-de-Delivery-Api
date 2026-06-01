# 🚀 Sistema de Delivery - Documentação Completa

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?style=flat&logo=mysql&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14.0-239120?style=flat&logo=c-sharp)
![License](https://img.shields.io/badge/license-MIT-green)

Sistema completo de delivery com arquitetura de microserviços, desenvolvido em .NET 10, seguindo princípios de Clean Architecture e DDD (Domain-Driven Design).

---

## 📑 Índice de Documentação

Toda a documentação está organizada nos seguintes arquivos:

### 📘 Para Desenvolvedores Backend

1. **[INSTRUCOES_BANCO_DE_DADOS.md](INSTRUCOES_BANCO_DE_DADOS.md)**
   - Setup do banco de dados MySQL
   - Configuração do Entity Framework Core
   - Migrations e troubleshooting
   - Como verificar se as tabelas foram criadas

### 📗 Para Desenvolvedores Frontend

2. **[GUIA_API_FRONTEND.md](GUIA_API_FRONTEND.md)** ⭐ **PRINCIPAL**
   - Documentação completa de todas as rotas
   - Exemplos de Request/Response
   - Payloads esperados
   - Códigos de status HTTP
   - Fluxos recomendados

3. **[EXEMPLOS_CODIGO_FRONTEND.md](EXEMPLOS_CODIGO_FRONTEND.md)** 💻
   - Código JavaScript/TypeScript pronto para usar
   - Services completos (Usuario, Restaurante, Produto, Pedido)
   - Exemplos em React e Vue
   - Tratamento de erros
   - Utilitários (formatação, validação)

4. **[CHECKLIST_INTEGRACAO_FRONTEND.md](CHECKLIST_INTEGRACAO_FRONTEND.md)** ✅
   - Checklist passo a passo
   - Testes de integração
   - Troubleshooting comum
   - Boas práticas de performance
   - Validações essenciais

### 📙 Documentação Técnica

5. **[ARQUITETURA_SISTEMA.md](ARQUITETURA_SISTEMA.md)** 🏗️
   - Visão geral da arquitetura
   - Diagramas de fluxo
   - Modelo de dados (ER)
   - Padrões de design utilizados
   - Estrutura de diretórios

---

## 🎯 Quick Start

### Para Backend (Desenvolvedor Backend)

```bash
# 1. Clone o repositório
git clone https://github.com/WallafOliveira/Sistema-de-Delivery-Api

# 2. Configure o banco de dados
# Edite appsettings.json com suas credenciais MySQL

# 3. Execute as 3 APIs simultaneamente
# Terminal 1
cd Sistema-de-delivery-back
dotnet run

# Terminal 2
cd Sistema-de-delivery-cardapio
dotnet run

# Terminal 3
cd Sistema-de-delivery-pedido
dotnet run

# 4. Acesse os Swaggers
# http://localhost:5001/swagger (Usuários)
# http://localhost:5002/swagger (Cardápio)
# http://localhost:5003/swagger (Pedidos)
```

**📖 Consulte:** [INSTRUCOES_BANCO_DE_DADOS.md](INSTRUCOES_BANCO_DE_DADOS.md)

### Para Frontend (Desenvolvedor Frontend)

```bash
# 1. Certifique-se que as 3 APIs estão rodando

# 2. Crie seu projeto frontend
npm create vite@latest frontend-delivery
# ou
npx create-react-app frontend-delivery

# 3. Copie os services da pasta examples/ ou do guia
cp EXEMPLOS_CODIGO_FRONTEND.md src/services/

# 4. Configure as URLs das APIs
# Edite src/config/api.config.js

# 5. Comece a desenvolver!
```

**📖 Consulte:** 
- [GUIA_API_FRONTEND.md](GUIA_API_FRONTEND.md) - Rotas e endpoints
- [EXEMPLOS_CODIGO_FRONTEND.md](EXEMPLOS_CODIGO_FRONTEND.md) - Código pronto
- [CHECKLIST_INTEGRACAO_FRONTEND.md](CHECKLIST_INTEGRACAO_FRONTEND.md) - Passo a passo

---

## 🏗️ Arquitetura do Sistema

O sistema é dividido em **3 microserviços independentes**:

```
┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
│   API Back      │  │  API Cardápio   │  │   API Pedido    │
│   (Usuários)    │  │ (Rest/Produtos) │  │   (Pedidos)     │
│   Port: 5001    │  │   Port: 5002    │  │   Port: 5003    │
└────────┬────────┘  └────────┬────────┘  └────────┬────────┘
         │                    │                     │
         └────────────────────┼─────────────────────┘
                              │
                    ┌─────────▼──────────┐
                    │   MySQL Database   │
                    │  sistema_delivery  │
                    └────────────────────┘
```

**📖 Consulte:** [ARQUITETURA_SISTEMA.md](ARQUITETURA_SISTEMA.md)

---

## 📊 Tecnologias Utilizadas

### Backend

| Tecnologia | Versão | Uso |
|------------|--------|-----|
| .NET | 10.0 | Framework principal |
| C# | 14.0 | Linguagem |
| Entity Framework Core | 9.0 | ORM |
| MySQL | 8.0+ | Banco de dados |
| Pomelo.EntityFrameworkCore.MySql | 9.0 | Provider MySQL |
| Swagger/OpenAPI | - | Documentação de API |

### Frontend (Sugestões)

- React 18+ / Vue 3+ / Angular 17+
- Axios / Fetch API
- React Query / SWR (cache e polling)
- TailwindCSS / Material-UI / Bootstrap

---

## 📦 APIs Disponíveis

### 🔐 API Back - Usuários (Port 5001)

Gerenciamento de usuários do sistema.

**Endpoints principais:**
- `POST /api/Usuario` - Criar usuário
- `GET /api/Usuario` - Listar todos
- `GET /api/Usuario/{id}` - Buscar por ID
- `PUT /api/Usuario/{id}` - Atualizar

**Swagger:** http://localhost:5001/swagger

---

### 🍽️ API Cardápio - Restaurantes & Produtos (Port 5002)

Gerenciamento de restaurantes e seus produtos.

**Endpoints principais:**

**Restaurantes:**
- `POST /api/Restaurante` - Criar restaurante
- `GET /api/Restaurante/abertos` - Listar abertos
- `PUT /api/Restaurante/{id}` - Atualizar

**Produtos:**
- `POST /api/Produto` - Criar produto
- `GET /api/Produto/restaurante/{id}` - Listar por restaurante
- `PUT /api/Produto/{id}` - Atualizar

**Swagger:** http://localhost:5002/swagger

---

### 📦 API Pedido - Pedidos (Port 5003)

Gerenciamento de pedidos e acompanhamento.

**Endpoints principais:**
- `POST /api/Pedido` - Criar pedido
- `GET /api/Pedido/{id}` - Buscar por ID
- `GET /api/Pedido/cliente/{id}` - Histórico do cliente
- `PUT /api/Pedido/{id}/status` - Atualizar status
- `DELETE /api/Pedido/{id}/cancelar` - Cancelar

**Swagger:** http://localhost:5003/swagger

---

## 🗄️ Modelo de Dados

### Tabelas Criadas

- **Usuarios** - Clientes, restaurantes, entregadores, admins
- **Restaurantes** - Estabelecimentos cadastrados
- **Produtos** - Itens do cardápio de cada restaurante
- **Pedidos** - Pedidos realizados pelos clientes
- **ItensPedido** - Itens individuais de cada pedido

### Relacionamentos

```
Usuario (1) ─── (N) Pedido (N) ─── (1) Restaurante
                     │
                     │ (1)
                     │
                     ▼ (N)
                ItemPedido (N) ─── (1) Produto
                                        │
                                        │ (N)
                                        ▼ (1)
                                   Restaurante
```

**📖 Consulte:** [ARQUITETURA_SISTEMA.md](ARQUITETURA_SISTEMA.md#-modelo-de-dados)

---

## 🔄 Fluxos Principais

### 1. Fluxo de Pedido Completo

```
Cliente → Login → Listar Restaurantes → Ver Cardápio 
→ Adicionar ao Carrinho → Finalizar Pedido 
→ Acompanhar Status → Receber Pedido
```

**📖 Consulte:** [GUIA_API_FRONTEND.md - Fluxos Recomendados](GUIA_API_FRONTEND.md#-fluxos-recomendados)

### 2. Fluxo de Status do Pedido

```
Pendente → Confirmado → Em Preparo → Em Entrega → Entregue
                                                  ↓
                                              Cancelado
```

---

## 🧪 Testando o Sistema

### Via Swagger (Recomendado)

1. Acesse: http://localhost:5001/swagger (ou 5002, 5003)
2. Expanda um endpoint
3. Clique em "Try it out"
4. Preencha os dados
5. Execute
6. Veja a resposta

### Via cURL

```bash
# Criar usuário
curl -X POST http://localhost:5001/api/Usuario \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "João Silva",
    "email": "joao@email.com",
    "telefone": "11999999999",
    "tipo": "Cliente",
    "senha": "senha123"
  }'

# Listar restaurantes abertos
curl http://localhost:5002/api/Restaurante/abertos

# Criar pedido
curl -X POST http://localhost:5003/api/Pedido \
  -H "Content-Type: application/json" \
  -d '{
    "clienteId": "guid-do-cliente",
    "restauranteId": "guid-do-restaurante",
    "itens": [
      {
        "produtoId": "guid-do-produto",
        "nomeProduto": "Pizza",
        "quantidade": 2,
        "valorUnitario": 45.90
      }
    ]
  }'
```

### Via Postman

Importe a collection do Swagger:
1. Abra Swagger
2. Clique no link JSON no topo
3. Copie a URL
4. No Postman: Import → Link → Cole a URL

---

## 📝 Exemplos de Código

### JavaScript/TypeScript

Todos os exemplos prontos para usar estão em:
**📖 [EXEMPLOS_CODIGO_FRONTEND.md](EXEMPLOS_CODIGO_FRONTEND.md)**

#### Criar Pedido (Preview)

```javascript
import PedidoService from './services/pedido.service';

async function criarPedido() {
  const pedido = await PedidoService.criar({
    clienteId: localStorage.getItem('userId'),
    restauranteId: 'guid-restaurante',
    itens: [
      {
        produtoId: 'guid-produto',
        nomeProduto: 'Pizza Margherita',
        quantidade: 2,
        valorUnitario: 45.90
      }
    ]
  });
  
  console.log('Pedido criado:', pedido);
  // Redirecionar para acompanhamento
  window.location.href = `/pedido/${pedido.id}`;
}
```

---

## 🐛 Troubleshooting

### Problema: APIs não iniciam

**Solução:**
1. Verifique se o MySQL está rodando
2. Verifique a connection string no `appsettings.json`
3. Execute `dotnet build` para verificar erros

### Problema: CORS Error

**Solução:**
Adicione no `Program.cs` de cada API (já configurado):
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

app.UseCors("AllowAll");
```

### Problema: Tabelas não criadas

**Solução:**
1. Delete o banco: `DROP DATABASE sistema_delivery;`
2. Crie novamente: `CREATE DATABASE sistema_delivery;`
3. Execute qualquer API (tabelas serão criadas automaticamente)

**📖 Consulte:** [INSTRUCOES_BANCO_DE_DADOS.md - Troubleshooting](INSTRUCOES_BANCO_DE_DADOS.md#-troubleshooting)

**📖 Consulte:** [CHECKLIST_INTEGRACAO_FRONTEND.md - Troubleshooting](CHECKLIST_INTEGRACAO_FRONTEND.md#-troubleshooting)

---

## ✅ Checklist de Desenvolvimento

### Backend

- [x] Estrutura do projeto configurada
- [x] Entity Framework configurado
- [x] Models criados
- [x] Repositories implementados
- [x] Use Cases implementados
- [x] Controllers implementados
- [x] Swagger configurado
- [x] Banco de dados inicializado automaticamente
- [x] CORS configurado
- [x] Compilação sem erros

### Frontend (A fazer)

- [ ] Services criados
- [ ] Componentes de UI
- [ ] Telas principais
- [ ] Fluxo de pedido completo
- [ ] Tratamento de erros
- [ ] Loading states
- [ ] Responsividade

**📖 Consulte:** [CHECKLIST_INTEGRACAO_FRONTEND.md](CHECKLIST_INTEGRACAO_FRONTEND.md)

---

## 📚 Recursos Adicionais

### Documentação Oficial

- [.NET 10 Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [MySQL Documentation](https://dev.mysql.com/doc/)

### Tutoriais Recomendados

- Clean Architecture em .NET
- DDD (Domain-Driven Design)
- Microservices com .NET
- React + API REST

---

## 🤝 Contribuindo

Este é um projeto acadêmico, mas contribuições são bem-vindas!

1. Fork o projeto
2. Crie uma branch: `git checkout -b feature/MinhaFeature`
3. Commit: `git commit -m 'Adiciona MinhaFeature'`
4. Push: `git push origin feature/MinhaFeature`
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está sob a licença MIT.

---

## 👥 Autores

- **Wallace Oliveira** - [GitHub](https://github.com/WallafOliveira)

---

## 📞 Suporte

Em caso de dúvidas:

1. Consulte a documentação apropriada (veja índice acima)
2. Verifique o Troubleshooting
3. Teste no Swagger
4. Abra uma issue no GitHub

---

## 🎯 Roadmap Futuro

- [ ] Autenticação JWT
- [ ] Sistema de avaliações
- [ ] Notificações em tempo real (SignalR)
- [ ] Integração com pagamentos
- [ ] Dashboard administrativo
- [ ] App mobile
- [ ] Deploy em produção

---

## 📊 Status do Projeto

✅ **Backend:** Completo e funcional  
✅ **Banco de Dados:** Configurado e operacional  
✅ **Documentação:** Completa para integração frontend  
⏳ **Frontend:** A ser desenvolvido  

---

<div align="center">

### 🚀 Sistema pronto para integração com Frontend!

**Toda a documentação necessária está disponível nos arquivos listados acima.**

**Comece por:** [GUIA_API_FRONTEND.md](GUIA_API_FRONTEND.md)

---

**Desenvolvido com ❤️ usando .NET 10 e Clean Architecture**

</div>
