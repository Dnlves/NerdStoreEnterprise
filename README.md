# Nerd Store Enterprise

## CRIANDO OS PROJETOS 

### API's
```bash
dotnet new webapi -n NSE.Carrinho.API
dotnet new webapi -n NSE.Catalogo.API
dotnet new webapi -n NSE.Cliente.API
dotnet new webapi -n NSE.Identidade.API 
dotnet new webapi -n NSE.Pagamento.API
dotnet new webapi -n NSE.Pedido.API
```
### MVC
```bash
dotnet new mvc -n NSE.WebApp.MVC --razor-runtime-compilation 
```
### projeto Core
```bash
dotnet new classlib -n NSE.Core  
```
--------------------------------------------------------------------------------