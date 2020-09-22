/****** Object:  Table [dbo].[Tenant]    Script Date: 9/18/2020 11:17:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantId] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Name] [nvarchar](500) NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tenant] ADD  CONSTRAINT [DF_Tenant_TenantId]  DEFAULT (newid()) FOR [TenantId]
GO
ALTER TABLE [dbo].[Tenant] ADD  CONSTRAINT [DF_Tenant_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]