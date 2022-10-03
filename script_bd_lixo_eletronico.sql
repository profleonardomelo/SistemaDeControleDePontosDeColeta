CREATE SCHEMA `bd_lixo_eletronico` ;

USE `bd_lixo_eletronico` ;

CREATE TABLE `bd_lixo_eletronico`.`usuario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(20) NOT NULL,
  `senha` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`));

INSERT INTO `bd_lixo_eletronico`.`usuario`
(`login`,
`senha`)
VALUES
('raiane',
'1234');

CREATE TABLE `bd_lixo_eletronico`.`estado` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`));

INSERT INTO `bd_lixo_eletronico`.`estado`
(`nome`)
VALUES
('Bahia');

INSERT INTO `bd_lixo_eletronico`.`estado`
(`nome`)
VALUES
('São paulo');

CREATE TABLE `bd_lixo_eletronico`.`cidade` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  `id_estado` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_cidade_estado_idx` (`id_estado` ASC) VISIBLE,
  CONSTRAINT `fk_cidade_estado`
    FOREIGN KEY (`id_estado`)
    REFERENCES `bd_lixo_eletronico`.`estado` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

INSERT INTO `bd_lixo_eletronico`.`cidade`
(`nome`,
`id_estado`)
VALUES
('Feira de Santana',
1);

INSERT INTO `bd_lixo_eletronico`.`cidade`
(`nome`,
`id_estado`)
VALUES
('Salvador',
1);

INSERT INTO `bd_lixo_eletronico`.`cidade`
(`nome`,
`id_estado`)
VALUES
('São Paulo',
2);

INSERT INTO `bd_lixo_eletronico`.`cidade`
(`nome`,
`id_estado`)
VALUES
('Guarulhos',
2);

CREATE TABLE `bd_lixo_eletronico`.`bairro` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  `id_cidade` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_bairro_cidade`
    FOREIGN KEY (`id_cidade`)
    REFERENCES `bd_lixo_eletronico`.`cidade` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Pituba',
2);

INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Cajazeiras VIII',
2);
INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Sobradinho',
1);

INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Centro',
1);

INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Itaquera',
3);


INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Butantã',
3);

INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Jardim Albertina',
4);

INSERT INTO `bd_lixo_eletronico`.`bairro`
(`nome`,
`id_cidade`)
VALUES
('Cocaia',
4);

CREATE TABLE `bd_lixo_eletronico`.`ponto_de_coleta` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  `logradouro` VARCHAR(35) NOT NULL,
  `numero` INT NOT NULL,
  `id_bairro` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_ponto_de_coleta_bairro`
    FOREIGN KEY (`id_bairro`)
    REFERENCES `bd_lixo_eletronico`.`bairro` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);