
-- Создаем таблицу работников.
CREATE TABLE [dbo].[Employee] (
    [Id]     INT        NOT NULL,
    [Name]   NCHAR (10) NULL,
    [Age]    INT        NULL,
    [Salary] INT        NULL,
    [Department] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Employee_ToDep] FOREIGN KEY ([Department]) REFERENCES [Department]([Id])
);

-- Создаем таблицу департаментов.
CREATE TABLE [dbo].[Department]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL
)
