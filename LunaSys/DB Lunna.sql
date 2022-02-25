CREATE DATABASE CURSO
USE CURSO

CREATE TABLE [Clientes] (
	ID_Cliente int  IDENTITY NOT NULL,
	Nome_Cliente varchar(100) NOT NULL,
	CPF varchar(15) NOT NULL UNIQUE,
	SEXO varchar(20),
	Data_Nasc datetime NOT NULL,
	Telefone varchar(14) NOT NULL,
	Lougradouro varchar(200)  ,
	Numero varchar(10)  ,
	Complemento varchar(100)  ,
	Bairro varchar(50)  ,
	Cidade varchar(100)  ,
	Estado char(2)  ,
	CEP varchar(9)  ,
  CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED
  (
  [ID_Cliente] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Produtos] (
	ID_Produto int IDENTITY NOT NULL,
	Nome_Produto varchar(100) NOT NULL,
	Fornecedor varchar(100)  ,
	Preco decimal(10,2) NOT NULL,
	Marca varchar(100)  ,
	Descricao varchar(100)  ,
	Quantidade int  ,
  CONSTRAINT [PK_PRODUTOS] PRIMARY KEY CLUSTERED
  (
  [ID_Produto] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Fornecedores] (
	ID_Fornecedor int IDENTITY NOT NULL,
	CNPJ varchar(20) NOT NULL UNIQUE,
	Razao_Social varchar(100) NOT NULL,
	Telefone varchar(14) NOT NULL,
	Lougradouro varchar(100)  ,
	Numero varchar(10)  ,
	Complemento varchar(100)  ,
	Bairro varchar(100)  ,
	Cidade varchar(100)  ,
	Estado char(2)  ,
	CEP varchar(9)  ,
  CONSTRAINT [PK_FORNECEDORES] PRIMARY KEY CLUSTERED
  (
  [ID_Fornecedor] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pedidos] (
	ID_Pedido int IDENTITY  NOT NULL,
	Data datetime  ,
	ID_PedidoCliente int  ,
	ID_PedidoUsuario int  ,
  CONSTRAINT [PK_PEDIDOS] PRIMARY KEY CLUSTERED
  (
  [ID_Pedido] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Usuarios] (
	ID_Usuario int IDENTITY NOT NULL,
	Nome varchar(100) ,
	Senha varchar(16)  ,
	Login varchar(20)  ,
	Nivel bit  ,
	CPF varchar(15) unique  ,
	Funcao varchar(100)  ,
	Telefone varchar(14)  ,
	photo image  ,
  CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED
  (
  [ID_Usuario] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ItensPedidos] (
	ID_ItensPedido int IDENTITY  NOT NULL,
	ID_ItensProduto int  ,
	Quantidade int  ,
	Valor_Total decimal (10,2) ,
	ID_PedidosPed int  ,
  CONSTRAINT [PK_ITENSPEDIDOS] PRIMARY KEY CLUSTERED
  (
  [ID_ItensPedido] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Produto_Fornecedor] (
	Idproduto_fornecedor int IDENTITY NOT NULL,
	ID_Fornecedor int  ,
	ID_Produtos int  ,
  CONSTRAINT [PK_PRODUTO_FORNECEDOR] PRIMARY KEY CLUSTERED
  (
  [Idproduto_fornecedor] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO



ALTER TABLE [Pedidos] WITH CHECK ADD CONSTRAINT [Pedidos_fk0] FOREIGN KEY ([ID_PedidoCliente]) REFERENCES [Clientes]([ID_Cliente])
ON UPDATE CASCADE
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [Pedidos_fk0]
GO
ALTER TABLE [Pedidos] WITH CHECK ADD CONSTRAINT [Pedidos_fk1] FOREIGN KEY ([ID_PedidoUsuario]) REFERENCES [Usuarios]([ID_Usuario])
ON UPDATE CASCADE
GO
ALTER TABLE [Pedidos] CHECK CONSTRAINT [Pedidos_fk1]
GO


ALTER TABLE [ItensPedidos] WITH CHECK ADD CONSTRAINT [ItensPedidos_fk0] FOREIGN KEY ([ID_ItensProduto]) REFERENCES [Produtos]([ID_Produto])
ON UPDATE CASCADE
GO
ALTER TABLE [ItensPedidos] CHECK CONSTRAINT [ItensPedidos_fk0]
GO
ALTER TABLE [ItensPedidos] WITH CHECK ADD CONSTRAINT [ItensPedidos_fk1] FOREIGN KEY ([ID_PedidosPed]) REFERENCES [Pedidos]([ID_Pedido])
ON UPDATE CASCADE
GO
ALTER TABLE [ItensPedidos] CHECK CONSTRAINT [ItensPedidos_fk1]
GO

ALTER TABLE [Produto_Fornecedor] WITH CHECK ADD CONSTRAINT [Produto_Fornecedor_fk0] FOREIGN KEY ([ID_Fornecedor]) REFERENCES [Fornecedores]([ID_Fornecedor])
ON UPDATE CASCADE
GO
ALTER TABLE [Produto_Fornecedor] CHECK CONSTRAINT [Produto_Fornecedor_fk0]
GO
ALTER TABLE [Produto_Fornecedor] WITH CHECK ADD CONSTRAINT [Produto_Fornecedor_fk1] FOREIGN KEY ([ID_Produtos]) REFERENCES [Produtos]([ID_Produto])
ON UPDATE CASCADE
GO
ALTER TABLE [Produto_Fornecedor] CHECK CONSTRAINT [Produto_Fornecedor_fk1]
GO


SELECT * FROM Usuarios
SELECT * FROM ItensPedidos
SELECT * FROM Pedidos
SELECT * FROM Produtos

DELETE FROM Pedidos
WHERE ID_Pedido='3';

DELETE FROM ItensPedidos
WHERE ID_PedidosPed='3';