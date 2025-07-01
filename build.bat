@echo off
setlocal

rem ===== 설정 =====
set TARGET_EXE=bin\Debug\net8.0-windows\WinFormsApp1.exe

msbuild /p:Configuration=Debug

endlocal
