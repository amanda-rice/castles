CREATE TABLE castles (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'castle name',
  builtYear int comment 'castle construction year',
  destroyed TINYINT comment 'castle is destroyed'
) default charset utf8;
/* REVIEW */
CREATE TABLE knights (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'artist name',
  castleId int NOT NULL,
  FOREIGN KEY (castleId) REFERENCES castles(id) ON DELETE CASCADE
);
INSERT INTO
  knights (name, castleId)
VALUES
  ('Paul McCartney', 1);
SELECT
  *
FROM
  knights
WHERE
  castleId = 1;
  /* 
    SECTION AlterTable 
    */
  /* ALTER TABLE
    ALTER COLUMN name varchar(255) comment 'artist name'; */
  /* SECTION CREATE */
INSERT INTO
  castles (name, builtYear, destroyed)
VALUES
  ('Camelot', 1202, 1);
  /* SECTION READ
                    '*' is all columns
                     */
  /* getALL */
SELECT
  *
FROM
  castles;
  /* getBy */
DELETE FROM
  knights;