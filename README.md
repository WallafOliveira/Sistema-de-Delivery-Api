# 🚀 Sistema de Delivery - Documentação Completa

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat\&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?style=flat\&logo=mysql\&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14.0-239120?style=flat\&logo=c-sharp)
![License](https://img.shields.io/badge/license-MIT-green)

Sistema completo de delivery com arquitetura de microserviços, desenvolvido em **.NET 10**, seguindo princípios de **Clean Architecture** e **DDD (Domain-Driven Design)**.
---

# 📚 Documentação Complementar

A documentação foi organizada em arquivos separados para facilitar a consulta:

## 📘 Backend

* Setup do banco de dados MySQL
* Configuração do Entity Framework Core

## 📙 Documentação Técnica

* Visão geral da arquitetura
* Diagramas de fluxo
* Modelo Entidade-Relacionamento
* Padrões utilizados
* Estrutura de diretórios

---

# 🎯 Quick Start

## Para Desenvolvedores Backend

```bash
# 1. Clone o repositório
git clone https://github.com/WallafOliveira/Sistema-de-Delivery-Api

# 2. Configure o banco de dados
# Edite o arquivo appsettings.json com suas credenciais MySQL

# 3. Execute as APIs

# Terminal 1
cd Sistema-de-delivery-back
dotnet run

# Terminal 2
cd Sistema-de-delivery-cardapio
dotnet run

# Terminal 3
cd Sistema-de-delivery-pedido
dotnet run
```

### Swagger

| Serviço  | URL                           |
| -------- | ----------------------------- |
| Usuários | http://localhost:5001/swagger |
| Cardápio | http://localhost:5002/swagger |
| Pedidos  | http://localhost:5003/swagger |

---

# 🏗️ Arquitetura do Sistema

O sistema é composto por **3 microserviços independentes**:

```text
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

---

# 📊 Tecnologias Utilizadas

## Backend

| Tecnologia                       | Versão | Finalidade          |
| -------------------------------- | ------ | ------------------- |
| .NET                             | 10.0   | Framework principal |
| C#                               | 14.0   | Linguagem           |
| Entity Framework Core            | 9.0    | ORM                 |
| MySQL                            | 8.0+   | Banco de dados      |

---

# 📦 APIs Disponíveis

## 🔐 API Back (Usuários)

**Porta:** `5001`

### Endpoints

```http
POST   /api/Usuario
GET    /api/Usuario
GET    /api/Usuario/{id}
PUT    /api/Usuario/{id}
```

---

## 🍽️ API Cardápio

**Porta:** `5002`

### Restaurantes

```http
POST   /api/Restaurante
GET    /api/Restaurante/abertos
PUT    /api/Restaurante/{id}
```

### Produtos

```http
POST   /api/Produto
GET    /api/Produto/restaurante/{id}
PUT    /api/Produto/{id}
```

---

## 📦 API Pedido

**Porta:** `5003`

### Endpoints

```http
POST    /api/Pedido
GET     /api/Pedido/{id}
GET     /api/Pedido/cliente/{id}
PUT     /api/Pedido/{id}/status
DELETE  /api/Pedido/{id}/cancelar
```

---

# 🗄️ Modelo de Dados

## Entidades

* Usuarios
* Restaurantes
* Produtos
* Pedidos
* ItensPedido

## Relacionamentos

```text
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

---

# 🔄 Fluxos Principais

## Fluxo de Compra

```text
Cliente
   ↓
Login
   ↓
Listar Restaurantes
   ↓
Visualizar Cardápio
   ↓
Adicionar ao Carrinho
   ↓
Finalizar Pedido
   ↓
Acompanhar Status
   ↓
Receber Pedido
```

## Status do Pedido

```text
Pendente
   ↓
Confirmado
   ↓
Em Preparo
   ↓
Em Entrega
   ↓
Entregue

ou

Cancelado
```

---

# 🧪 Testando o Sistema

## Swagger

1. Acesse a documentação da API desejada
2. Expanda o endpoint
3. Clique em **Try it out**
4. Informe os dados
5. Execute a requisição

---

## cURL

### Criar usuário

```bash
curl -X POST http://localhost:5001/api/Usuario \
-H "Content-Type: application/json" \
-d '{
  "nome":"João Silva",
  "email":"joao@email.com",
  "telefone":"11999999999",
  "tipo":"Cliente",
  "senha":"senha123"
}'
```

### Listar restaurantes

```bash
curl http://localhost:5002/api/Restaurante/abertos
```

### Criar pedido

```bash
curl -X POST http://localhost:5003/api/Pedido \
-H "Content-Type: application/json" \
-d '{
  "clienteId":"guid-cliente",
  "restauranteId":"guid-restaurante",
  "itens":[
    {
      "produtoId":"guid-produto",
      "nomeProduto":"Pizza",
      "quantidade":2,
      "valorUnitario":45.90
    }
  ]
}'
```

---

# 📚 Recursos Adicionais

## Documentação Oficial

* .NET Documentation
* Entity Framework Core
* MySQL Documentation

## Temas Recomendados

* Clean Architecture
* Domain-Driven Design (DDD)
* Microservices com .NET
* React + APIs REST


---

# 📊 Status do Projeto

| Módulo         | Status               |
| -------------- | -------------------- |
| Backend        | ✅ Completo           |
| Banco de Dados | ✅ Operacional        |
| APIs REST      | ✅ Funcionais         |
| Documentação   | ✅ Completa           |
| Frontend       | ⏳ Em desenvolvimento |

---

