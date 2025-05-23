CREATE TABLE Person (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    LastName VARCHAR(100),
    TypeDocument VARCHAR(50),
    DocumentNumber VARCHAR(50),
    Phone VARCHAR(20),
    Address VARCHAR(255),
    IsDeleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE User (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    Active BOOLEAN DEFAULT TRUE,
    IsDeleted BOOLEAN DEFAULT FALSE,
    PersonId INT,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

CREATE TABLE Rol (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    IsDeleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE Permission (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    IsDeleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE Form (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Url VARCHAR(255),
    IsDeleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE Module (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    IsDeleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE FormModule (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FormId INT NOT NULL,
    ModuleId INT NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (FormId) REFERENCES Form(Id),
    FOREIGN KEY (ModuleId) REFERENCES Module(Id)
);

CREATE TABLE RolFormPermission (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    RolId INT NOT NULL,
    FormId INT NOT NULL,
    PermissionId INT NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (RolId) REFERENCES Rol(Id),
    FOREIGN KEY (FormId) REFERENCES Form(Id),
    FOREIGN KEY (PermissionId) REFERENCES Permission(Id)
);

CREATE TABLE RolUser (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    RolId INT NOT NULL,
    UserId INT NOT NULL,
    IsDeleted BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (RolId) REFERENCES Rol(Id),
    FOREIGN KEY (UserId) REFERENCES User(Id)
);
