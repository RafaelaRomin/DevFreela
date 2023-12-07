## Freelas para Desenvolvedores 🖥️

#### ***DevFreela foi desenvolvido com o objetivo de fixação dos conceitos de arquitetura limpa, padrão repository, CQRS, JTW e testes unitários.*** 
#### ***É uma API onde os usuários podem se cadastrar como Freelancers e/ou Clientes, ofertando projetos (no caso de clientes) e prestando serviços (no caso de Freelancers). O Cliente publica um projeto com as informações iniciais (titúlo, descrição, valor) na qual procura um freelancer disposto à executar aquele projeto.***

### **Tecnologias Utilizadas** ⌨️
- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- XUnit
- Autenticação e Autorização com JWT Bearer

### **Funcionalidades** ⚙️
- Cadastro de usuários (Cliente e Freelancer)
- Login de usuários utilizando autenticação e autorização
- CRUD (Create, Read, Update, Delete) de Projetos, onde apenas o Cliente tem as permissões de criação, edição e exclusão o projeto.
- Adicionar comentários ao projeto (Cliente e Freelancers podem deixar comentários para comunicação sobre o projeto)
- Status do projeto - [Start e Finish] Apenas o cliente pode alterar o status do projeto.

### **Padrões, conceitos e arquitetura utilizada** 📂
- Padrão Repository
- Arquitetura Limpa
- CQRS
- Fluent Validation para validação de API
- Testes unitários utilizando XUnit, e a biblioteca NSubstitute
