CREATE TABLE mydata(
  id SERIAL PRIMARY KEY,
  name VARCHAR(50),
  age INT,
  email VARCHAR(100)
);

INSERT INTO mydata (name, age, email)
VALUES 
('Anjali', 20, 'anjali@example.com'),
('Rahul', 22, 'rahul@example.com'),
('Simran', 21, 'simran@example.com'),
('Aman', 23, 'aman@example.com'),
('Veedhi', 21, 'veedhi@example.com');

SELECT * FROM mydata;

DELETE FROM mydata WHERE name = 'Simran';

SELECT * FROM mydata WHERE age>21;

UPDATE mydata SET email = 'newmail@example.com' WHERE name = 'Aman';

select name,age from mydata where name='Veedhi' and age='21';

select name,age,email from mydata where name like 'A%';

CREATE TABLE orders (
  order_id SERIAL PRIMARY KEY,
  user_id INT,
  product VARCHAR(100),
  FOREIGN KEY (user_id) REFERENCES mydata(id)
);

INSERT INTO orders (user_id, product)
VALUES
(1, 'Laptop'),
(2, 'Mobile'),
(4, 'Tablet'),
(1, 'Keyboard');

SELECT mydata.name, orders.product
FROM mydata
INNER JOIN orders ON mydata.id = orders.user_id;

SELECT mydata.name, orders.product
FROM mydata
LEFT JOIN orders ON mydata.id = orders.user_id;

