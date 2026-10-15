$patterns = @(
    '\.BackColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    '\.ForeColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    'DefaultCellStyle\.ForeColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    'ColumnHeadersDefaultCellStyle\.BackColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    'ColumnHeadersDefaultCellStyle\.ForeColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    '\.Font\s*=\s*new\s+(System\.Drawing\.)?Font\([^\)]*\)\s*;',
    'ColumnHeadersDefaultCellStyle\.Font\s*=\s*new\s+Font\([^\)]*\)\s*;',
    'this\.BackColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    'this\.ForeColor\s*=\s*(System\.Drawing\.)?Color\.[A-Za-z0-9_]+\s*;',
    'this\.Font\s*=\s*new\s+System\.Drawing\.Font\([^\)]*\)\s*;'
)

$files = Get-ChildItem -Path . -Include *.cs -Recurse -File
foreach ($file in $files) {
    $text = Get-Content $file.FullName -Raw -ErrorAction SilentlyContinue
    if ($null -eq $text) { continue }
    $new = $text
    foreach ($p in $patterns) {
        # Eliminamos cualquier ocurrencia que coincida en la línea (ignore-case)
        $new = [regex]::Replace($new, $p, '', 'IgnoreCase')
        # Limpiamos líneas en blanco dobles que podrían quedar
        $new = [regex]::Replace($new, "(?m)^\s*\r?\n", "", 'None')
    }
    if ($new -ne $text) {
        Set-Content -Path $file.FullName -Value $new -Encoding UTF8
        Write-Host "Modificado:" $file.FullName
    }
}
Write-Host "Proceso finalizado. No se crearon backups. Compila y prueba la solución."   