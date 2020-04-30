Get-ChildItem .\ -Include bin,obj -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }
Get-ChildItem .\ -Include .mfractor -Attributes Hidden -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }
Get-ChildItem .\ -Include .vs -Attributes Hidden -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }
Get-ChildItem .\ -Include *.csproj.user -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }