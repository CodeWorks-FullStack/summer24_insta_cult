CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) UNIQUE COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  cults (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    fee INT UNSIGNED NOT NULL,
    description TEXT NOT NULL,
    coverImg VARCHAR(3000) NOT NULL,
    leaderId VARCHAR(255) NOT NULL,
    FOREIGN KEY (leaderId) REFERENCES accounts (id) ON DELETE CASCADE
  );

SELECT
  *
FROM
  accounts;

INSERT INTO
  cults (name, fee, description, coverImg, leaderId)
VALUES
  (
    "The Cultergeists",
    0,
    "We move things around on the lectern. We unplug cords. Evan is maybe a member.",
    "https://plus.unsplash.com/premium_photo-1683121243798-8f0eb5b0e03b?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
    "66bb8ddd637da0ef8d71e1e7"
  );