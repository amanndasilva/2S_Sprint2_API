/*DDLs - Criamos o Banco*/
CREATE DATABASE boletim;

/*Usamos o banco*/
USE boletim;

/*Excluir banco*/
/*DROP DATABASE boletim;*/

/*Criamos a tabela de Aluno*/
/*IDENTITY: gera os IDs automaticamente e de forma sequencial*/
CREATE TABLE aluno(
	IdAluno INT IDENTITY PRIMARY KEY NOT NULL,
	Nome VARCHAR (100) NOT NULL,
	Ra VARCHAR (20),
	Idade INT
);

/*Criamos a tabela de Materia*/
CREATE TABLE materia(
	IdMateria INT IDENTITY PRIMARY KEY NOT NULL,
	Titulo VARCHAR (50) NOT NULL
);

/*Criamos a tabela de Trabalho*/
CREATE TABLE trabalho(
	IdTrabalho INT IDENTITY PRIMARY KEY NOT NULL,
	Nota DECIMAL,

	-- Estamos chamando as Foreign Keys
	IdAluno INT FOREIGN KEY REFERENCES aluno (IdAluno),
	IdMateria INT FOREIGN KEY REFERENCES materia (IdMateria)
);

/*Incluimos a cluna esquecida: DataEntrega*/
ALTER TABLE trabalho ADD DataEntrega DATETIME;

/*Criamos uma coluna de teste que será excluída*/
ALTER TABLE trabalho ADD teste INT;

/*Excluindo a coluna*/
ALTER TABLE trabalho DROP COLUMN teste;