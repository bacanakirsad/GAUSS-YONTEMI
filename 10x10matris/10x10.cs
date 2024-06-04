                double[,] matrix = {
    {7, 3, 8, 0, 1, 6, 3, 2, 1, 4, 6},
    {5, 9, 8, 4, 2, 5, 4, 1, 7, 5, 7},
    {6, 4, 3, 8, 1, 2, 9, 3, 0, 1, 2},
    {6, 0, 3, 6, 8, 8, 9, 0, 7, 0, 9},
    {2, 6, 1, 8, 7, 4, 9, 6, 5, 4, 3},
    {5, 2, 1, 5, 4, 7, 7, 8, 9, 3, 4},
    {2, 8, 2, 3, 0, 4, 9, 7, 5, 4, 5},
    {3, 3, 5, 8, 3, 4, 1, 5, 8, 1, 6},
    {9, 0, 3, 8, 2, 5, 1, 5, 4, 7, 1},
    {1, 2, 6, 4, 6, 4, 3, 2, 8, 7, 3}
};


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
                        // Pivot satırı sıfır olduğunda ileri eleme yapılmayacak
                        if (matrix[pivotRow, pivotRow] != 0)
                        {
                            double factor = matrix[row, pivotRow] / matrix[pivotRow, pivotRow];
                            for (int col = pivotRow; col < columnCount; col++)
                            {
                                matrix[row, col] -= factor * matrix[pivotRow, col];
                            }
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
                    // Pivot satırı sıfır olduğunda çözümü hesaplamayacak
                    if (matrix[row, row] != 0)
                    {
                        solutions[row] = (matrix[row, columnCount - 1] - sum) / matrix[row, row];
                    }
                    else
                    {
                        solutions[row] = double.NaN; // Çözüm yok
                    }
                }

                // Sonuçları yazdır
                Console.WriteLine("Çözümler:");
                for (int i = 0; i < rowCount; i++)
                {
                    if (!double.IsNaN(solutions[i]))
                    {
                        Console.WriteLine("x" + (i + 1) + " = " + solutions[i]);
                    }
                    else
                    {
                        Console.WriteLine("x" + (i + 1) + " için çözüm bulunamadı.");
                    }
                }
            
        
    
