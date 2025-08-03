set OLDDIR=%CD%

cd "C:\mysiwork"
call git_push.bat

cd "C:\parent"
call git_push.bat

cd "C:\myonenote"
call git_push.bat

cd "C:\myhome"
call git_push.bat

cd "C:\mynote"
call git_push.bat

cd "C:\myprivate"
call git_push.bat

cd "C:\projects\UnityProjectBase"
call git_push.bat

cd "C:\projects\godot_prototype_2d"
call git_push.bat

cd %OLDDIR%
