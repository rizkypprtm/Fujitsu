USE [TEST_FID]
GO
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'AB', N'PT Aneka Besi', N'Jln Sudirman', N'DKI Jakarta', N'Jakarta Pusat', N'Mr. Amir')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'DG', N'PT Diesel Guna', N'Jln Setiabudi', N'Jawa Barat', N'Bandung', N'Mrs Indah')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'DK', N'PT. ssss', N'Jln Setiabudi', N'DKI Jakarta', N'Jakarta Pusat', N'Mr. john wick')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'KH', N'PT. Simbadda', N'dimanaaa', N'DKI Jakarta', N'Jakarta Barat', N'Mr. koaa')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'KL', N'PT Kriya Lestari', N'Jln Melati', N'Jawa Tengah', N'Solo', N'Mrs. Safitri')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'KS', N'PT Test upd uplod', N'sasdad', N'DKI Jakarta', N'Jakarta Barat', N'Mr. koaaddd')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'LO', N'PT. Konterpen', N'asdads sdad', N'Jawa Barat', N'Bandung', N'Mr. koaa')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'MN', N'PT Multi Nusa', N'Jln Balikpapan', N'Sumatera Barat', N'Padang', N'Ms. Maria')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'PS', N'PT Test', N'Jl muararajeun Baru', N'Jawa Barat', N'Bandung', N'Mr. koaaddd')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'ST', N'PT Sempurna', N'Jln Jayakarta', N'DKI Jakarta', N'Jakarta Barat', N'Mr. Didi')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'SU', N'PT. saos keccap', N'asdasdad', N'DKI Jakarta', N'Jakarta Pusat', N'Mr. koaaddd')
INSERT [dbo].[TB_M_SUPPLIER] ([SUPPLIER_CODE], [SUPPLIER_NAME], [ADDRESS], [PROVINCE], [CITY], [PIC]) VALUES (N'TE', N'PT. kurang tidur', N'dimana aja boeleee', N'DKI Jakarta', N'Jakarta Pusat', N'Mr. john wick')
GO
SET IDENTITY_INSERT [dbo].[TB_MCITY] ON 

INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (1, N'DKI Jakarta', N'Jakarta Barat')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (2, N'DKI Jakarta', N'Jakarta Pusat')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (3, N'DKI Jakarta', N'Jakarta Selatan')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (4, N'Jawa Barat', N'Bandung')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (5, N'Jawa Barat', N'Bogor')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (6, N'Jawa Barat', N'Bekasi')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (7, N'Jawa Tengah', N'Solo')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (8, N'Jawa Tengah', N'Semarang')
INSERT [dbo].[TB_MCITY] ([Id], [Province], [City]) VALUES (9, N'Sumatera Barat', N'Padang')
SET IDENTITY_INSERT [dbo].[TB_MCITY] OFF
GO
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-001', CAST(N'2019-01-01' AS Date), N'AB', CAST(150000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-002', CAST(N'2019-01-04' AS Date), N'DG', CAST(250000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-003', CAST(N'2019-01-05' AS Date), N'KL', CAST(35000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-004', CAST(N'2019-01-08' AS Date), N'KL', CAST(40000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-005', CAST(N'2019-02-08' AS Date), N'ST', CAST(51000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-006', CAST(N'2019-02-12' AS Date), N'KL', CAST(16500000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-007', CAST(N'2019-02-13' AS Date), N'MN', CAST(25000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-008', CAST(N'2019-02-15' AS Date), N'MN', CAST(350000000 AS Numeric(18, 0)))
INSERT [dbo].[TB_R_ORDER_H] ([ORDER_NO], [ORDER_DATE], [SUPPLIER_CODE], [AMOUNT]) VALUES (N'ORD-009', CAST(N'2019-02-20' AS Date), N'AB', CAST(1200000000 AS Numeric(18, 0)))
GO
