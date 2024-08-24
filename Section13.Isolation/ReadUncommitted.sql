﻿SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION MyTransaction
BEGIN TRY
SELECT * FROM Products
COMMIT TRANSACTION MyTransaction
PRINT('Transaction Success')
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION MyTransaction
PRINT('Transaction Failed')
END CATCH