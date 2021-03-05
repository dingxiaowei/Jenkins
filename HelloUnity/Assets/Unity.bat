@echo off
echo update

echo "Delete Old Version"
rd /s /Q D:\study\Unity\Jenkins\build

echo "Start build apk..."

C:\"Program Files"\Unity\Editor\Unity.exe -projectPath D:\study\Unity\Jenkins\HelloUnity -quit -batchmode -executeMethod PerformBuild.CommandLineBuildAndroid -logFile build.log
REM %1 -projectPath %2 -quit -batchmode -executeMethod APKBuild.Build -logFile build.log

if not %errorlevel%==0 ( goto fail ) else ( goto success )
 
:success
echo Build APK OK

echo Copy APK
xcopy D:\study\Unity\Jenkins\build\android\HelloUnity.apk D:\back\ /y

if not %errorlevel%==0 ( goto fail ) else ( goto end )
 
:fail
echo Build APK Fail
goto end
 
:end
pause