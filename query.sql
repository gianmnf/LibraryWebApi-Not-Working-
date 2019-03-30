create schema livraria
use livraria
create table if not exists livros(
	livroId int not null auto_increment,
    nome varchar(150) not null,
    preco float not null,
    tipo varchar(80) not null,
    autor varchar(100) not null,
    primary key (livroId)
    ) ENGINE=INNODB;
    insert into livros(nome,preco,tipo,autor) values ('Harry Potter e a Pedra Filosofal',29.90,'Aventura','J.K Rowlling')