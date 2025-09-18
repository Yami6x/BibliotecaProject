CREATE DATABASE BIBLIOTECA;

GO
USE BIBLIOTECA;
GO

CREATE TABLE Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE
);

GO

CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT
);

GO

CREATE TABLE Idiomas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
    Codigo VARCHAR(10),
    Origen VARCHAR(100)
);

GO

CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200),
    ISBN VARCHAR(50),
    AnioPublicacion INT,
    IdAutor INT,
    IdCategoria INT,
    IdIdioma INT,
    FOREIGN KEY (IdAutor) REFERENCES Autores(Id),
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id),
    FOREIGN KEY (IdIdioma) REFERENCES Idiomas(Id)
);

GO

CREATE TABLE Miembros (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(150),
    Telefono VARCHAR(30),
    FechaRegistro DATE
);

GO

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(150),
    Telefono VARCHAR(30),
    Cargo VARCHAR(50),
    FechaIngreso DATE
);

GO

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion TEXT
);

GO

CREATE TABLE Empleados_Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoId INT,
    RolId INT,
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

GO

CREATE TABLE Prestamos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdLibro INT,
    IdMiembro INT,
    FechaPrestamo DATE,
    FechaDevolucion DATE,
    Estado VARCHAR(50),
    FOREIGN KEY (IdLibro) REFERENCES Libros(Id),
    FOREIGN KEY (IdMiembro) REFERENCES Miembros(Id)
);

GO

CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdLibro INT,
    IdMiembro INT,
    FechaReserva DATE,
    Estado VARCHAR(50),
    FOREIGN KEY (IdLibro) REFERENCES Libros(Id),
    FOREIGN KEY (IdMiembro) REFERENCES Miembros(Id)
);

GO

CREATE TABLE Multas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(10,2),
    FechaMulta DATE,
    IdPrestamo INT,
    Estado VARCHAR(50),
    FOREIGN KEY (IdPrestamo) REFERENCES Prestamos(Id)
);

GO

CREATE TABLE Pagos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(10,2),
    FechaPago DATE,
    MetodoPago VARCHAR(50),
    IdMulta INT,
    FOREIGN KEY (IdMulta) REFERENCES Multas(Id)
);

GO

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Contacto VARCHAR(100),
    Telefono VARCHAR(30),
    Email VARCHAR(150)
);

GO

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Stock INT,
    Precio DECIMAL(10,2),
    IdProveedor INT,
    FOREIGN KEY (IdProveedor) REFERENCES Proveedores(Id)
);

GO

CREATE TABLE Consumos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT,
    IdMiembro INT,
    Cantidad INT,
    Fecha DATE,
    FOREIGN KEY (IdProducto) REFERENCES Productos(Id),
    FOREIGN KEY (IdMiembro) REFERENCES Miembros(Id)
);

GO

INSERT INTO Autores (Nombre, Apellido, Nacionalidad, FechaNacimiento) VALUES
('Gabriel', 'Garcia Marquez', 'Colombiana', '1927-03-06'),
('Mario', 'Vargas Llosa', 'Peruana', '1936-03-28'),
('Julio', 'Cortázar', 'Argentina', '1914-08-26'),
('Isabel', 'Allende', 'Chilena', '1942-08-02'),
('Jorge', 'Luis Borges', 'Argentina', '1899-08-24');

INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Novela', 'Narrativa extensa que relata historias ficticias'),
('Ensayo', 'Textos reflexivos sobre diversos temas'),
('Cuento', 'Narración breve de hechos imaginarios'),
('Poesía', 'Expresión artística de la palabra'),
('Historia', 'Estudios de hechos pasados');

-- Inserts Idiomas
INSERT INTO Idiomas (Nombre, Codigo, Origen) VALUES
('Español', 'ES', 'Latinoamérica'),
('Inglés', 'EN', 'Inglaterra'),
('Francés', 'FR', 'Francia'),
('Portugués', 'PT', 'Portugal'),
('Italiano', 'IT', 'Italia');

INSERT INTO Libros (Titulo, ISBN, AnioPublicacion, IdAutor, IdCategoria, IdIdioma) VALUES
('Cien años de soledad', '978-03-16-148410-0', 1967, 1, 1, 1),
('La ciudad y los perros', '978-03-16-148411-7', 1963, 2, 2, 1),
('Rayuela', '978-03-16-148412-4', 1963, 3, 3, 1),
('La casa de los espíritus', '978-03-16-148413-1', 1982, 4, 4, 1),
('Ficciones', '978-03-16-148414-8', 1944, 5, 5, 1);

INSERT INTO Miembros (Nombre, Apellido, Email, Telefono, FechaRegistro) VALUES
('Carlos', 'Pérez', 'carlos.perez@mail.com', '1234567890', '2023-01-15'),
('María', 'Gómez', 'maria.gomez@mail.com', '2345678901', '2023-02-20'),
('Ana', 'Sánchez', 'ana.sanchez@mail.com', '3456789012', '2023-03-10'),
('Luis', 'Martínez', 'luis.martinez@mail.com', '4567890123', '2023-04-05'),
('Pedro', 'López', 'pedro.lopez@mail.com', '5678901234', '2023-05-25');

INSERT INTO Empleados (Nombre, Apellido, Email, Telefono, Cargo, FechaIngreso) VALUES
('Juan', 'Ramírez', 'juan.ramirez@biblioteca.com', '1234567890', 'Bibliotecario', '2022-05-10'),
('Laura', 'Martínez', 'laura.martinez@biblioteca.com', '2345678901', 'Director', '2020-08-15'),
('Pedro', 'Gómez', 'pedro.gomez@biblioteca.com', '3456789012', 'Asistente', '2021-06-22'),
('Marta', 'Fernández', 'marta.fernandez@biblioteca.com', '4567890123', 'Recepcionista', '2022-03-30'),
('Luis', 'Sánchez', 'luis.sanchez@biblioteca.com', '5678901234', 'Archivista', '2023-01-18');

-- Inserts Roles
INSERT INTO Roles (Nombre, Descripcion) VALUES
('Administrador', 'Encargado de la gestión completa de la biblioteca'),
('Bibliotecario', 'Responsable de la organización y préstamo de libros'),
('Recepcionista', 'Atiende las solicitudes de los usuarios'),
('Director', 'Encargado de la supervisión general de la biblioteca'),
('Asistente', 'Apoya en tareas administrativas y de atención al público');

INSERT INTO Empleados_Roles (EmpleadoId, RolId) VALUES
(1, 2),
(2, 4),
(3, 5),
(4, 3),
(5, 2);

INSERT INTO Prestamos (IdLibro, IdMiembro, FechaPrestamo, FechaDevolucion, Estado) VALUES
(1, 1, '2023-06-01', '2023-06-10', 'Devuelto'),
(2, 2, '2023-07-15', '2023-07-22', 'Pendiente'),
(3, 3, '2023-05-20', '2023-05-25', 'Devuelto'),
(4, 4, '2023-08-05', '2023-08-12', 'Pendiente'),
(5, 5, '2023-09-01', '2023-09-10', 'Devuelto');

INSERT INTO Reservas (IdLibro, IdMiembro, FechaReserva, Estado) VALUES
(1, 1, '2023-06-01', 'Confirmada'),
(2, 2, '2023-07-15', 'Pendiente'),
(3, 3, '2023-05-20', 'Confirmada'),
(4, 4, '2023-08-05', 'Cancelada'),
(5, 5, '2023-09-01', 'Confirmada');

INSERT INTO Multas (Monto, FechaMulta, IdPrestamo, Estado) VALUES
(10.00, '2023-06-15', 1, 'Pagada'),
(5.00, '2023-07-20', 2, 'Pendiente'),
(15.00, '2023-05-28', 3, 'Pagada'),
(7.00, '2023-08-15', 4, 'Pendiente'),
(20.00, '2023-09-12', 5, 'Pagada');

INSERT INTO Pagos (FechaPago, Monto, MetodoPago, IdMulta) VALUES
('2023-06-16', 10.00, 'Tarjeta de Crédito', 1),
('2023-07-21', 5.00, 'Efectivo', 2),
('2023-05-29', 15.00, 'Transferencia', 3),
('2023-08-16', 7.00, 'Efectivo', 4),
('2023-09-13', 20.00, 'Tarjeta de Crédito', 5);

INSERT INTO Proveedores (Nombre, Contacto, Telefono, Email) VALUES
('Editorial Planeta', 'Carlos Mendoza', '1234567890', 'contacto@planeta.com'),
('Editorial Penguin', 'Ana López', '2345678901', 'contacto@penguin.com'),
('Editorial Random House', 'Luis Fernández', '3456789012', 'contacto@randomhouse.com'),
('Editorial Santillana', 'Jorge Sánchez', '4567890123', 'contacto@santillana.com'),
('Editorial Norma', 'Claudia Rivera', '5678901234', 'contacto@norma.com');

-- Inserts Productos
INSERT INTO Productos (Nombre, Descripcion, Stock, Precio, IdProveedor) VALUES
('Marcadores', 'Marcadores de diferentes colores', 100, 5.00, 1),
('Libretas', 'Libretas tamaño A4', 200, 3.50, 2),
('Lápices', 'Lápices de madera', 500, 1.00, 3),
('Gomas de borrar', 'Gomas para borrar lápiz', 150, 0.50, 4),
('Carpetas', 'Carpetas plásticas', 80, 2.00, 5);

INSERT INTO Consumos (IdProducto, IdMiembro, Cantidad, Fecha) VALUES
(1, 1, 2, '2023-06-01'),
(2, 2, 1, '2023-07-01'),
(3, 3, 5, '2023-07-15'),
(4, 4, 3, '2023-08-01'),
(5, 5, 1, '2023-09-01');
GO
