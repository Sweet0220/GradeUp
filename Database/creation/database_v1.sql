CREATE TABLE users (
	id bigint primary key identity,
    username varchar(255),
    email varchar(255) unique,
    password varchar(255),
    name varchar(255),
    sex varchar(255),
    role varchar(255)
);

CREATE TABLE subject (
	id bigint primary key identity,
    name varchar(255),
    professor varchar(255),
    year int,
    faculty varchar(255),
    university varchar(255),
    credits int
);

CREATE TABLE teaching (
	id bigint primary key identity,
	id_user bigint,
    id_subject bigint,
    FOREIGN KEY (id_user) REFERENCES users(id),
    FOREIGN KEY (id_subject) REFERENCES subject(id)
);

CREATE TABLE review (
	id bigint primary key identity,
    rating int,
    comment varchar(255),
    id_user bigint,
    FOREIGN KEY (id_user) REFERENCES users(id)
);

CREATE TABLE request (
	id bigint primary key identity,
    id_user1 bigint,
    id_user2 bigint,
    id_subject bigint,
    accepted bit,
    FOREIGN KEY (id_user1) REFERENCES users(id),
    FOREIGN KEY (id_user2) REFERENCES users(id),
    FOREIGN KEY (id_subject) REFERENCES subject(id),
    CONSTRAINT Unique_Request UNIQUE (id_user1, id_user2, id_subject)
);

CREATE TABLE chat (
	id bigint primary key identity,
    id_user1 bigint,
    id_user2 bigint,
    FOREIGN KEY (id_user1) REFERENCES users(id),
    FOREIGN KEY (id_user2) REFERENCES users(id)
);

CREATE TABLE message (
	id bigint primary key identity,
    text varchar(255),
    id_chat bigint,
    id_user bigint,
    hour varchar(255),
    send_date date,
    FOREIGN KEY (id_user) REFERENCES users(id),
    FOREIGN KEY (id_chat) REFERENCES chat(id)
);