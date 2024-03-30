--2.1. Menampilkan total amount transaksi masing-masing kota:
SELECT b.City, SUM(a.Amount) AS Totla_Amount
FROM TB_R_ORDER_H a
JOIN TB_M_SUPPLIER b ON a.SUPPLIER_CODE = b.SUPPLIER_CODE
GROUP BY City;



-- 2.2. Menampilkan total amount transaksi per Supplier untuk bulan Januari 2019 saja:
SELECT b.SUPPLIER_NAME, SUM(a.Amount) AS Total_Amount, a.ORDER_DATE
FROM TB_R_ORDER_H a
JOIN TB_M_SUPPLIER b ON a.SUPPLIER_CODE = b.SUPPLIER_CODE
WHERE a.ORDER_DATE BETWEEN '2019-01-01' AND '2019-01-31'
GROUP BY b.SUPPLIER_NAME, a.ORDER_DATE



--2.3. Menampilkan tanggal transaksi terakhir dari masing-masing supplier:
SELECT b.SUPPLIER_NAME, MAX(a.ORDER_DATE) AS Last_Date_Trasnaction
FROM TB_R_ORDER_H a
JOIN TB_M_SUPPLIER b ON b.SUPPLIER_CODE = b.SUPPLIER_CODE
GROUP BY b.SUPPLIER_NAME



--2.4. Menampilkan semua transaksi dari Supplier yang ada di provinsi Jawa Barat dengan amount transaksi nya di atas 30,000,000:
SELECT a.ORDER_NO, a.ORDER_DATE, a.SUPPLIER_CODE, a.AMOUNT
FROM TB_R_ORDER_H a
JOIN TB_M_SUPPLIER b ON a.SUPPLIER_CODE = b.SUPPLIER_CODE
WHERE b.PROVINCE = 'Jawa Barat' AND a.Amount > 30000000;



--2.5. Menampilkan urutan supplier berdasarkan total amount transaksi, dari yang terbesar ke yang terkecil selama tahun 2019:
SELECT b.SUPPLIER_NAME, SUM(a.Amount) AS Total_Amount
FROM TB_R_ORDER_H a
JOIN TB_M_SUPPLIER b ON a.SUPPLIER_CODE = b.SUPPLIER_CODE
GROUP BY b.SUPPLIER_NAME
ORDER BY Total_Amount DESC, b.SUPPLIER_NAME ASC;
