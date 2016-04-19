SET IDENTITY_INSERT [dbo].[Books] ON
INSERT INTO [dbo].[Books] ([Id], [Title], [Year], [Price], [Genre], [AuthorId]) VALUES (1, N'Pride and Prejudice', 1813, CAST(9.99 AS Decimal(18, 2)), N'Comedy of manners', 1)
INSERT INTO [dbo].[Books] ([Id], [Title], [Year], [Price], [Genre], [AuthorId]) VALUES (2, N'Northanger Abbey', 1817, CAST(12.95 AS Decimal(18, 2)), N'Gothic parody', 1)
INSERT INTO [dbo].[Books] ([Id], [Title], [Year], [Price], [Genre], [AuthorId]) VALUES (3, N'David Copperfield', 1850, CAST(15.00 AS Decimal(18, 2)), N'Bildungsroman', 2)
INSERT INTO [dbo].[Books] ([Id], [Title], [Year], [Price], [Genre], [AuthorId]) VALUES (4, N'Don Quixote', 1617, CAST(8.95 AS Decimal(18, 2)), N'Picaresque', 3)
SET IDENTITY_INSERT [dbo].[Books] OFF
