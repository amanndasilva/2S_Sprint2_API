USE boletim;

/*DML: Data Manipulation Language*/

--INSERT: insere dados na tabela

INSERT INTO aluno (Nome, Ra, Idade)
	VALUES ('Rodrigo', 4584, 17);
SELECT * FROM aluno;

INSERT INTO materia (Titulo)
	VALUES ('Geografia')
SELECT * FROM materia;

INSERT INTO trabalho (Nota, DataEntrega, IdAluno, IdMateria)
	VALUES (9, '2020-08-05T09:00:00', 1, 1)
SELECT * FROM trabalho;