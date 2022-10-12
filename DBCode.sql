CREATE TABLE orders(
	id SERIAL not null PRIMARY	KEY,
	manager_login varchar(32),
	submanager_login varchar(32),
	id_client integer not null,
	status_order varchar(32) not null
);

comment on column orders.manager_login is 'менеджер';
comment on column orders.submanager_login is 'соучастник';
comment on column orders.status is 'статус';

CREATE TABLE order_structure(
	id_order integer not null,
	article integer NOT NULL,
	quantity integer not null
);

comment on column order_structure.article is 'артикль';
comment on column order_structure.quantity is 'количество';


CREATE TABLE product(
	article serial not null primary key,
	type_code varchar(32) not null,
	product_name varchar(256),
	lenght integer,
	width integer,
	edge_size numeric(6,2),
	has_drawing BOOLEAN default false,
	constructor_login varchar(32)
);

comment on column product.article is 'артикль';
comment on column product.type_code is 'тип';
comment on column product.product_name is 'наименование товара';
comment on column product.lenght is 'длина';
comment on column product.width is 'ширина';
comment on column product.edge_size is 'кант';
comment on column product.has_drawing is 'чертеж';
comment on column product.constructor_login is 'проектировщик';

CREATE TABLE product_type(
	type_code varchar(32) not null primary key,
	type_name varchar(256)
);

comment on column product_type.type_name is 'тип товара';

ALTER TABLE order_structure add primary key(
	id_order, article);
	
CREATE TABLE status (
	status_name varchar(32) not null primary key,
	is_final bool DEFAULT false	
);

comment on column status.status_name is 'статус';
comment on column status.is_final is 'выполнение';
	
CREATE TABLE divan(
	article serial not null primary key,
	fasteners_type varchar(32),
	softness_name varchar(32),
	mechanism varchar(32),
	back_degree integer,
	textile_name varchar(64)
);

comment on column divan.article is 'артикл';
comment on column divan.fasteners_type is 'тип крепежа';
comment on column divan.softness_name is 'жесткость';
comment on column divan.mechanism is 'механизм';
comment on column divan.back_degree is 'наклон спинки';
comment on column divan.textile_name is 'материал';

CREATE TABLE fastener(
	fastener_name varchar(32) not null primary key
);

comment on column fastener.fastener_name is 'крепеж';

CREATE TABLE softness(
	softness_name varchar(32) not null primary key
);

comment on column softness.softness_name is 'жесткость';

CREATE TABLE mechanism(
	mechanism_name varchar(32) not null primary key
);

comment on column mechanism.mechanism_name is 'механизм';

CREATE TABLE textile(
	textile_name varchar(32) not null primary key
);

comment on column textile.textile_name is 'материал';