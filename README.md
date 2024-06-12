# 🏫 SCHOOL API  
Sistema básico de cadastro de estudantes e cursos
<br />
Usuário terá que efetuar login, e somente poderá realizar as ações se tiver "role" de admin

---

## 📖 SOBRE O PROJETO
Temos 3 tabelas no projeto, uma chamada "Students", outra chamada "Courses" e outra chamada "Users"

  ### Students
    CRUD básico, e uma rota onde busca todos os Students que tenham o mesmo "courseId"

  ### Courses
    CRUD básico

  ### Users
    POST e GET por ID apenas

  ### ROTA EXTRA (CADASTRO DE ESTUDANTE NO CURSO)
    Rota extra onde pede como parâmetro o ID do Student e o ID de um Course, que tem como objetivo cadastrar o estudante naquele curso

  ### ROTA EXTRA (EXCLUSÃO DE ESTUDANTE NO CURSO)
    Rota extra onde pede como parâmetro o ID do Student e o ID de um Course, que tem como objetivo excluir o estudante daquele curso

---

## 🚀 Tecnologias

### Dependências
AutoMapper | Authentication JWT | IdentityModel 
### Backend
C# | .NET 8 | Swagger
### Banco de dados
MySQL Server

---

## 🛠️ Instruções

### Backend
Entrar na pasta *CrudMongoApp* e executar os seguintes comandos

```
dotnet build
```
```
dotnet run
```

OBS: Irá ficar disponível em (http://localhost:5001/) mas terá que mudar para: (http://localhost:5001/swagger/) para visualizar o Swagger

### Banco de dados
Instalar o MongoDBCompass e criar um Banco chamado "CrudMongoDb"

OBS: Por padrão do MongoDB a "ConnectionString" é mongodb://localhost:27017

---
