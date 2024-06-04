
            double[,] matrix = {
            {2, 5, -1, 4, 5},
            {3, 2, 8, -1, 1},
            {6, -1, 3, 4, 1},
            {4, 4, 1, -2, 6}};
        

            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            // İleri Eleme
            for (int pivotRow = 0; pivotRow < rowCount - 1; pivotRow++)
            {
                // Pivot sıfır olursa alt satırlarlardan uygunuyla değiştirdik
                if (matrix[pivotRow, pivotRow] == 0)
                {
                    for (int row = pivotRow + 1; row < rowCount; row++)
                    {
                        if (matrix[row, pivotRow] != 0)
                        {
                            for (int col = pivotRow; col < columnCount; col++)
                            {
                                double temp = matrix[pivotRow, col];
                                matrix[pivotRow, col] = matrix[row, col];
                                matrix[row, col] = temp;
                            }
                            break;
                        }
                    }
                }

                // Pivotlama ve ileri eleme
                for (int row = pivotRow + 1; row < rowCount; row++)
                {
                    double factor = matrix[row, pivotRow] / matrix[pivotRow, pivotRow];
                    for (int col = pivotRow; col < columnCount; col++)
                    {
                        matrix[row, col] -= factor * matrix[pivotRow, col];
                    }
                }
            }

            // Geriye Doğru Yerine Koyma
            double[] solutions = new double[rowCount];
            for (int row = rowCount - 1; row >= 0; row--)
            {
                double sum = 0;
                for (int col = row + 1; col < columnCount - 1; col++)
                {
                    sum += matrix[row, col] * solutions[col];
                }
                solutions[row] = (matrix[row, columnCount - 1] - sum) / matrix[row, row];
            }

            // Sonuçları yazdır
            Console.WriteLine("Çözümler:");
            for (int i = 0; i < rowCount; i++)
            {
                Console.WriteLine("x" + (i + 1) + " = " + solutions[i]);
            }
        
    

