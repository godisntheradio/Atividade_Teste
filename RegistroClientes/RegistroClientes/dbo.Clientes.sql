CREATE TABLE [dbo].[Clientes] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [Email] VARCHAR (50) NOT NULL,
    [DOB]   DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

