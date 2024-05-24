CREATE TABLE user (
	id bigint primary key,
    username varchar(255),
    emailid_user1 varchar(255) unique,
    password varchar(255),
    name varchar(255),
    sex varchar(255),
    role varchar(255)
);

CREATE TABLE subject (
	id bigint primary key,
    name varchar(255),
    professor varchar(255),
    year int,
    faculty varchar(255),
    university varchar(255),
    credits int
);

CREATE TABLE teaching (
	id bigint primary key,
	id_user bigint,
    id_subject bigint,
    FOREIGN KEY (id_user) REFERENCES user(id),
    FOREIGN KEY (id_subject) REFERENCES subject(id)
);

CREATE TABLE review (
	id bigint primary key,
    rating int,
    comment varchar(255),
    id_user bigint,
    FOREIGN KEY (id_user) REFERENCES user(id)
);

CREATE TABLE request (
	id bigint primary key,
    id_user1 bigint,
    id_user2 bigint,
    id_subject bigint,
    accepted bool,
    FOREIGN KEY (id_user1) REFERENCES user(id),
    FOREIGN KEY (id_user2) REFERENCES user(id),
    FOREIGN KEY (id_subject) REFERENCES subject(id),
    CONSTRAINT UNIQUE (id_user1, id_user2, id_subject)
);

CREATE TABLE chat (
	id bigint primary key,
    id_user1 bigint,
    id_user2 bigint,
    FOREIGN KEY (id_user1) REFERENCES user(id),
    FOREIGN KEY (id_user2) REFERENCES user(id)
);

CREATE TABLE message (
	id bigint primary key,
    text varchar(255),
    id_chat bigint,
    id_user bigint,
    hour varchar(255),
    send_date date,
    FOREIGN KEY (id_user) REFERENCES user(id),
    FOREIGN KEY (id_chat) REFERENCES chat(id)
);
