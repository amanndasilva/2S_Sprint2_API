USE boletim;

/*DQL: Data Query Language*/

-- Seleciona e mostra TODOS os dados da tabela que foi criada
SELECT * FROM trabalho;

-- Seleciona um dado específico na tabela
SELECT * FROM aluno WHERE IdAluno = 1;

-- Seleciona como (LIKE) busca específica
SELECT * FROM aluno WHERE Ra LIKE '%8%';

-- Ordena de forma crescente (padrão), podem ser de duas formas
SELECT * FROM aluno ORDER BY Nome;

SELECT * FROM aluno ORDER BY Nome ASC;

-- Ordena de forma decrescente
SELECT * FROM materia ORDER BY Titulo DESC;

-- Seleciona dados com condições específicas
SELECT * FROM aluno WHERE IdAluno > 1 AND IdAluno < 3;
SELECT * FROM aluno;

-- Seleciona dados ENTRE valores específicos
SELECT * FROM aluno WHERE IdAluno BETWEEN '2' AND '3';