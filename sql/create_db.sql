-- Создание базы и таблиц (выполните в psql или pgAdmin)
-- Примечание: если база уже создана, пропустите команду CREATE DATABASE
-- CREATE DATABASE polyclinic_db;

-- Таблицы
CREATE TABLE IF NOT EXISTS Patients (
  id serial PRIMARY KEY,
  fullname varchar(100) NOT NULL,
  birthdate date,
  phone varchar(50)
);

CREATE TABLE IF NOT EXISTS Doctors (
  id serial PRIMARY KEY,
  fullname varchar(100) NOT NULL,
  specialty varchar(100)
);

CREATE TABLE IF NOT EXISTS Appointments (
  id serial PRIMARY KEY,
  datetime timestamp NOT NULL,
  patientid integer NOT NULL REFERENCES patients(id) ON DELETE CASCADE,
  doctorid integer NOT NULL REFERENCES doctors(id) ON DELETE RESTRICT,
  notes text
);

-- Примеры данных
INSERT INTO Patients (fullname, birthdate, phone) VALUES
('Иванов Иван Иванович', '1990-05-12', '+37060000001'),
('Петров Пётр Петрович', '1985-11-30', '+37060000002');

INSERT INTO Doctors (fullname, specialty) VALUES
('Смирнова Ольга Сергеевна', 'Терапевт'),
('Кузнецов Андрей Игоревич', 'Хирург');

INSERT INTO Appointments (datetime, patientid, doctorid, notes) VALUES
('2026-02-01 10:00', 1, 1, 'Первичный прием'),
('2026-02-02 14:30', 2, 2, 'Повторный осмотр');

ALTER TABLE appointments 
DROP CONSTRAINT appointments_doctorid_fkey,
ADD CONSTRAINT appointments_doctorid_fkey 
    FOREIGN KEY (doctorid) 
    REFERENCES doctors(id) 
    ON DELETE CASCADE;