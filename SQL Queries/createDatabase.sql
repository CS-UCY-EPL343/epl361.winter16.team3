CREATE TABLE [dbo].[EMPLOYEE](
	[SSN] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[Monthly Salary] [Smallmoney] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Phone Number] [int] NOT NULL,
	CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY 
	([SSN] ASC)
)

CREATE TABLE [dbo].[PRODUCT](
	[Product ID] [int] NOT NULL,
	[Picture Path] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Rating] [int] NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Category ID] [int] NOT NULL,
	CONSTRAINT [PK_PRODUCT] PRIMARY KEY 
	([Product ID] ASC)
)

CREATE TABLE [dbo].[CATEGORY](
	[Category ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_CATEGORY] PRIMARY KEY 
	([Category ID] ASC)
)

CREATE TABLE [dbo].[ORDER](
	[Order ID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Price] [smallmoney] NOT NULL,
	CONSTRAINT [PK_ORDER] PRIMARY KEY 
	([Order ID] ASC)
)

CREATE TABLE [dbo].[ORDERED PRODUCT](
	[Order ID] [int] NOT NULL,
	[Product ID] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	CONSTRAINT [PK_ORDERED PRODUCT] PRIMARY KEY 
	([Order ID],[Product ID] ASC)
)

CREATE TABLE [dbo].[INCOME](
	[Date] [date] NOT NULL,
	[Income] [smallmoney]NOT NULL,
	CONSTRAINT [PK_INCOME] PRIMARY KEY 
	([Date] ASC)
)

CREATE TABLE [dbo].[MANAGER](
	[SSN] [int] NOT NULL,
	[Username] [nvarchar](20)NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	CONSTRAINT [PK_MANAGER] PRIMARY KEY 
	([UserName] ASC)
)

ALTER TABLE [dbo].[MANAGER]  WITH CHECK ADD  CONSTRAINT [FK_MANAGER_EMPLOYEE] FOREIGN KEY([SSN])
REFERENCES [dbo].[EMPLOYEE] ([SSN])
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_CATEGORY] FOREIGN KEY([Category ID])
REFERENCES [dbo].[CATEGORY] ([Category ID])
GO
ALTER TABLE [dbo].[ORDERED PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_ORDERED_PRODUCT_ORDER] FOREIGN KEY([Order ID])
REFERENCES [dbo].[ORDER] ([Order ID])
GO
ALTER TABLE [dbo].[ORDERED PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_ORDERED_PRODUCT_PRODUCT] FOREIGN KEY([Product ID])
REFERENCES [dbo].[PRODUCT] ([Product ID])

INSERT [dbo].[EMPLOYEE] ([SSN],[Name],[Surname],[Monthly Salary],[Address],[Phone Number]) VALUES (1458754,'Kostas', 'Yeorgiou', 1524.2,'Ayio Nikolao 15',99787878)
INSERT [dbo].[EMPLOYEE] ([SSN],[Name],[Surname],[Monthly Salary],[Address],[Phone Number]) VALUES (1475482,'Panais', 'Dimou', 720.15,'Ayio Pafitio 2',99741235)
INSERT [dbo].[EMPLOYEE] ([SSN],[Name],[Surname],[Monthly Salary],[Address],[Phone Number]) VALUES (8745852,'Vaggelis', 'Aristos', 1427.67,'Ayio Alaminiio 17',97145631)
INSERT [dbo].[EMPLOYEE] ([SSN],[Name],[Surname],[Monthly Salary],[Address],[Phone Number]) VALUES (8625954,'Mike', 'Papamixail', 1124.72,'Ayio Fasoulio 78',99141236)
INSERT [dbo].[EMPLOYEE] ([SSN],[Name],[Surname],[Monthly Salary],[Address],[Phone Number]) VALUES (1478512,'Antrikkos', 'Damianou', 755.55,'Ayio Polemio 71',96478512)

INSERT [dbo].[Manager] ([SSN],[Username],[Password]) VALUES (1458754,'kchara17', 'ksnv123')

INSERT [dbo].[CATEGORY] ([Category ID],[Name]) VALUES (1,'Cold Coffees')
INSERT [dbo].[CATEGORY] ([Category ID],[Name]) VALUES (2,'Hot Coffees')
INSERT [dbo].[CATEGORY] ([Category ID],[Name]) VALUES (3,'Alcoholic Drinks')
INSERT [dbo].[CATEGORY] ([Category ID],[Name]) VALUES (4,'Other Beverages')
INSERT [dbo].[CATEGORY] ([Category ID],[Name]) VALUES (5,'Food')

INSERT [dbo].[PRODUCT] ([Product ID],[Name],[Description],[Picture Path],[Price],[Rating],[Category ID]) VALUES (1,'Iced Latte','Espresso with milk','icedlatte.jpg',3.20,8,1)
INSERT [dbo].[PRODUCT] ([Product ID],[Name],[Description],[Picture Path],[Price],[Rating],[Category ID]) VALUES (2,'Latte','Espresso with milk','latte.jpg',3.20,8,2)
INSERT [dbo].[PRODUCT] ([Product ID],[Name],[Description],[Picture Path],[Price],[Rating],[Category ID]) VALUES (3,'Smirnoff Ice','4% alcohol','smirnoffice.jpg',4.20,8,3)
INSERT [dbo].[PRODUCT] ([Product ID],[Name],[Description],[Picture Path],[Price],[Rating],[Category ID]) VALUES (4,'Water','Kikkos','water.jpg',0.50,8,4)
INSERT [dbo].[PRODUCT] ([Product ID],[Name],[Description],[Picture Path],[Price],[Rating],[Category ID]) VALUES (5,'Sandwitch','Tuna,lountza,halloumi,cheese,tomato,lettuce','sandwitch.jpg',3.50,8,5)