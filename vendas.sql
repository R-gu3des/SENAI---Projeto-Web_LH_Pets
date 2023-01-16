CREATE DATABASE vendas;

USE vendas;

CREATE TABLE tblClientes(
    cpf_cnpj VARCHAR(20) PRIMARY KEY,
    nome VARCHAR(30),
    endereco VARCHAR(50),
    rg_ie VARCHAR(15),
    tipo CHAR,
    valor FLOAT,
    valor_imposto FLOAT,
    total float
);


-- PESSOAS FÍSICAS

INSERT INTO tblClientes VALUES ('123.456.789-00', 'Pedro da Silva', 'Vera Cruz 1123', '4.564.852', 'f', 3600.00, 25, 3625.00);
INSERT INTO tblClientes VALUES ('356.159.753-11', 'Ana Claudia Vieira', 'Bairro Novo 155', '3.474.256', 'f', 3251.00, 100, 3625.00);
INSERT INTO tblClientes VALUES ('365.654.977-22', 'Pedro da Silva', 'Vera Cruz 1123', '4.564.852', 'f', 2400.00, 300, 3625.00);

-- Pessoas Jurídicas
INSERT INTO tblClientes VALUES ('123.456.789/5460-00', 'Fintech Brasil', 'santo Amaro 696', '466.564.852', 'j', 45680.00, 3654, 4571654.00);
INSERT INTO tblClientes VALUES ('123.456.789/5555-00', 'FMINT LAB', 'Avenidad Brasil 776', '456.664.442', 'j', 30000.00, 500, 30500);
INSERT INTO tblClientes VALUES ('123.456.789/6666-00', 'Fats Aplicativos', 'Imbiribeira 654', '555.666.777', 'j', 60000.00, 200, 60200.00);
INSERT INTO tblClientes VALUES ('123.456.789/7777-00', 'Soft Brasil', 'Recife 852', '999.666.888', 'j', 80000.00, 300, 800300.00);

-- Digitar no console --> "dotnet new web --use-program-main" 