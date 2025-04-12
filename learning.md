📌 Nome do Projeto
"BankSafeAPI" — API de Transações Bancárias Seguras

🎯 Objetivo
Criar uma API REST segura para simular movimentações bancárias (depósitos, saques, transferências entre contas), com autenticação, regras de limite, histórico de transações e auditoria.

🧱 Estrutura de Domínio
Entidades principais:
User (usuário autenticado)

Account (conta bancária)

Transaction (histórico de movimentações)

AuditLog (registro de ações e falhas)

TransferLimitPolicy (regras de limite diário/semanal)

🧠 O que estudar
✅ Back-end em C#
ASP.NET Core Web API

Controllers, Middlewares, Dependency Injection
📘 Microsoft Docs - ASP.NET Core Web API

Entity Framework Core (EF Core)

Migrations, DbContext, Relacionamentos
📘 EF Core Overview

Autenticação com JWT

Autenticação baseada em token, Claims, Policies
📘 JWT Bearer Authentication in ASP.NET Core

Validação com FluentValidation

Regras claras para entrada de dados
📘 FluentValidation Docs

Swagger para documentação 📘 Swashbuckle (Swagger para ASP.NET)

Middleware de logging / auditoria

Para capturar e registrar requisições sensíveis

🛡️ Segurança
Boas práticas com JWT + Refresh Token

Autorização por Roles (admin, cliente)

Limite de requisições (rate limiting)

Proteção contra Injection (EF Core ajuda bastante nisso)

🗂️ Arquitetura
Clean Architecture ou DDD (Domain Driven Design)
📘 Clean Architecture explicada em .NET

🔧 Tecnologias recomendadas
Item	Tecnologia
Framework	ASP.NET Core
ORM	Entity Framework Core
Autenticação	JWT
Validações	FluentValidation
Log/Auditoria	Serilog / Middleware
Banco de dados	PostgreSQL ou SQL Server
Testes	xUnit + Moq
Documentação	Swagger (Swashbuckle)
📚 Cursos & Materiais
Cursos Gratuitos:
Curso de ASP.NET Core + JWT (YouTube - AmigosCode)

Entity Framework Core - Curso Completo (YouTube - Macoratti)

Cursos pagos (opcional):
Balta.io - ASP.NET Core Expert

Udemy - ASP.NET Core Web API e Entity Framework Core