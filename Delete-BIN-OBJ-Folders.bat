@ECHO off
cls

ECHO Deleting all BIN and OBJ folders...
ECHO.

ECHO.Deleting: packages
rd /s/q "packages"

FOR /d /r . %%d in (bin,obj) DO (
	IF EXIST "%%d" (		 	 
		ECHO %%d | FIND /I "\node_modules\" > Nul && ( 
			ECHO.Skipping: %%d
		) || (
			ECHO.Deleting: %%d
			rd /s/q "%%d"
		)
	)
)

ECHO.
ECHO.BIN and OBJ folders have been successfully deleted. Press any key to exit.
pause > nul