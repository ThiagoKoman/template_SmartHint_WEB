Comando para criação da tabela:
```
CREATE TABLE `clientes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `dataCadastro` date DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `cnpj` varchar(14) DEFAULT NULL,
  `inscricaoEstadual` varchar(14) DEFAULT NULL,
  `inscricaoEstadualIsento` tinyint(1) DEFAULT NULL,
  `genero` varchar(10) DEFAULT NULL,
  `nascimento` date DEFAULT NULL,
  `bloqueado` tinyint(1) DEFAULT NULL,
  `senha` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```
