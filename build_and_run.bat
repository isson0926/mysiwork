@echo off
setlocal

rem ===== 설정 =====
set TARGET_EXE=bin\Debug\net8.0-windows\WinFormsApp1.exe

msbuild /p:Configuration=Debug
if errorlevel 1 (
    exit /b 1
)

rem ===== 실행 =====
if exist %TARGET_EXE% (
	REM echo. 에서 끝네 점(.) 은 빈문자열 출력
	echo.  
	echo -----------------------------------------
    %TARGET_EXE%
) else (
	REM echo. 에서 끝네 점(.) 은 빈문자열 출력
	echo.  
	echo -----------------------------------------
    echo "%TARGET_EXE%" not found!
)
endlocal
