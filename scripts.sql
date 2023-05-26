PRAGMA foreign_keys = OFF;
DROP TABLE IF EXISTS Preco;
DROP TABLE IF EXISTS Produto;
PRAGMA foreign_keys = ON;

CREATE TABLE Produto (
    Id INTEGER PRIMARY KEY,
    Nome TEXT,
    Descricao TEXT
);

CREATE TABLE Preco (
    Id INTEGER PRIMARY KEY,
    ProdutoId INTEGER,
    Preco REAL,
    Data TEXT,
    Ativo INTEGER,
    FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);

INSERT INTO Produto (Nome, Descricao) VALUES ('Camiseta', 'Camiseta de algodão');
INSERT INTO Produto (Nome, Descricao) VALUES ('Calça Jeans', 'Calça jeans masculina');
INSERT INTO Produto (Nome, Descricao) VALUES ('Tênis', 'Tênis esportivo');

INSERT INTO Preco (ProdutoId, Preco, Data, Ativo) VALUES (1, 29.99, '2023-05-01', 1);
INSERT INTO Preco (ProdutoId, Preco, Data, Ativo) VALUES (2, 59.99, '2023-05-02', 1);
INSERT INTO Preco (ProdutoId, Preco, Data, Ativo) VALUES (3, 99.99, '2023-05-03', 1);
