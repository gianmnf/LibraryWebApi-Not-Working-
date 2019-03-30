create schema livraria
use livraria
create table if not exists livros(
    livroId char(36) not null,
    nome varchar(150) not null,
    preco float not null,
    tipo varchar(80) not null,
    autor varchar(100) not null,
    primary key (livroId)
    ) ENGINE=INNODB;
    insert into livros(livroId,nome,preco,tipo,autor) values ('d4599e236d5d41a694edc6bbc4d13a57','Harry Potter e a Pedra Filosofal',29.90,'Aventura','J.K Howlling')