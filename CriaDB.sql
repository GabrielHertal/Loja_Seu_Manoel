IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Loja_Seu_Manoel')
BEGIN
    CREATE DATABASE Loja_Seu_Manoel;
END