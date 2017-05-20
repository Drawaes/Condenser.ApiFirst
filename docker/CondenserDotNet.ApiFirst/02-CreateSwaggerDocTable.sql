-- =========================================
-- Create system-versioned temporal table template
-- Use the Specify Values for Template Parameters command (Ctrl-Shift-M) to fill in the parameter values below.
-- 
-- This template creates a system-versioned temporal table.
-- 
-- For more details on system-versioned temporal tables please refer to MSDN documentation:
-- https://msdn.microsoft.com/en-IN/library/dn935015.aspx#Anchor_0
-- 
-- To learn more how to use system-versioned tables in your applications, take a look at "Getting Started with System-Versioned Temporal Tables":
-- https://msdn.microsoft.com/en-US/library/mt604462.aspx
-- =========================================

USE CondenserApiFirst
GO

BEGIN
    --If table is system-versioned, SYSTEM_VERSIONING must be set to OFF first 
    IF ((SELECT temporal_type FROM SYS.TABLES WHERE object_id = OBJECT_ID('dbo.SwaggerDoc', 'U')) = 2)
    BEGIN
        ALTER TABLE [dbo].[SwaggerDoc] SET (SYSTEM_VERSIONING = OFF)
    END
    DROP TABLE IF EXISTS [dbo].[SwaggerDoc]
END
GO

--Create system-versioned temporal table. It must have primary key and two datetime2 columns that are part of SYSTEM_TIME period definition
CREATE TABLE [dbo].[SwaggerDoc]
(
    ServiceHash binary(32) NOT NULL,
	ServiceId varchar(800) NOT NULL,
	AgentId varchar(800) NOT NULL,
    ServiceName varchar(1024) NOT NULL,
    SwaggerDoc varchar(max) NULL,

    --Period columns and PERIOD FOR SYSTEM_TIME definition
    SysStartTime datetime2(7) GENERATED ALWAYS AS ROW START  NOT NULL ,
    SysEndTime datetime2(7) GENERATED ALWAYS AS ROW END  NOT NULL ,
    PERIOD FOR SYSTEM_TIME(SysStartTime,SysEndTime),

    --Primary key definition
    CONSTRAINT PK_SwaggerDoc PRIMARY KEY (ServiceHash)
)
WITH
(
    --Set SYSTEM_VERSIONING to ON and provide reference to HISTORY_TABLE. 
    SYSTEM_VERSIONING = ON 
    (
        --If HISTORY_TABLE does not exists, default table will be created.
        HISTORY_TABLE = [dbo].[SwaggerDoc_history],
        --Specifies whether data consistency check will be performed across current and history tables (default is ON)
        DATA_CONSISTENCY_CHECK = ON
    )
)
GO