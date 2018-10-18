
-- Создаем таблицу работников.
CREATE TABLE [dbo].[Employee] (
    [Id]     INT        NOT NULL,
    [Name]   NCHAR (10) NULL,
    [Age]    INT        NULL,
    [Salary] INT        NULL,
    [Department] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- Создаем таблицу департаментов.
CREATE TABLE [dbo].[Department]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL
)

-- Добавление данных по сотрудникам
SET IDENTITY_INSERT [dbo].[Employee] ON
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (0, N'Вася                                         ', 27, 65000, 0)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (1, N'Вася2                                        ', 34, 66000, 0)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (2, N'Невася                                       ', 23, 2222, 2)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (3, N'Коля                                         ', 22, 66666, 3)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (4, N'Петя                                         ', 27, 50000, 2)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (5, N'СуперВася                                    ', 999, 90000, 5)
INSERT INTO [dbo].[Employee] ([Id], [Name], [Age], [Salary], [DepartmentID]) VALUES (6, N'Шеф Ла Густ                                  ', 41, 150000, 4)
SET IDENTITY_INSERT [dbo].[Employee] OFF


-- Добавление данных по департаментам
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT INTO [dbo].[Department] ([Id], [Name]) VALUES (0, N'Менеджеры                ')
INSERT INTO [dbo].[Department] ([Id], [Name]) VALUES (2, N'Директора                ')
INSERT INTO [dbo].[Department] ([Id], [Name]) VALUES (3, N'Управляющие              ')
INSERT INTO [dbo].[Department] ([Id], [Name]) VALUES (4, N'Повара                   ')
INSERT INTO [dbo].[Department] ([Id], [Name]) VALUES (5, N'Василии                  ')
SET IDENTITY_INSERT [dbo].[Department] OFF
