public static int Score(ref QRCodeData qrCode) {
    var score = 0;
    var size = qrCode.ModuleMatrix.Count;
    
    // Penalty 1
    for (int y = 0; y < size; y++) {
        var modInRow = 0;
        var modInColumn = 0;
        var lastValRow = qrCode.ModuleMatrix[y][0];
        var lastValColumn = qrCode.ModuleMatrix[0][y];
        
        for (int x = 0; x < size; x++) {
            if (qrCode.ModuleMatrix[y][x] == lastValRow)
                modInRow++;
            else
                modInRow = 1;
            
            if (modInRow == 5)
                score += 3;
            else if (modInRow > 5)
                score++;
            
            lastValRow = qrCode.ModuleMatrix[y][x];
            
            if (qrCode.ModuleMatrix[x][y] == lastValColumn)
                modInColumn++;
            else
                modInColumn = 1;
            
            if (modInColumn == 5)
                score += 3;
            else if (modInColumn > 5)
                score++;
            
            lastValColumn = qrCode.ModuleMatrix[x][y];
        }
    }
    
    // Other penalties and scoring rules are not visible in the snippet
    
    return score;
}
