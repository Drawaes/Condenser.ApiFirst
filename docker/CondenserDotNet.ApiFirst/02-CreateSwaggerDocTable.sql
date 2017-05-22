
USE CondenserApiFirst
GO


CREATE TABLE [dbo].[SwaggerDoc]
(
    SwaggerDocId int NOT NULL IDENTITY (1, 1),
	ServiceId varchar(800) NOT NULL,
	AgentId varchar(800) NOT NULL,
    ServiceName varchar(1024) NOT NULL,
    SwaggerDoc varchar(max) NULL,
    DateSaved datetime2 NOT NULL,
    --Primary key definition
    CONSTRAINT PK_SwaggerDoc PRIMARY KEY (SwaggerDocId)
)
GO