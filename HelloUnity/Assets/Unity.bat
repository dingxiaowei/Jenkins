@echo off
echo update
call test.bat

echo "Delete Old Version"
rd /s /Q D:\git\JenkinsTest\build

echo "Start build apk..."
D:\Unity20170412\Unity\Editor\Unity.exe -projectPath D:\git\jenkinsTest\HelloUnity -quit -batchmode -executeMethod PerformBuild.CommandLineBuildAndroid -logFile build.log
REM %1 -projectPath %2 -quit -batchmode -executeMethod APKBuild.Build -logFile build.log

if not %errorlevel%==0 ( goto fail ) else ( goto success )
 
:success
echo Build APK OK

echo Copy APK
xcopy D:\git\JenkinsTest\build\android\HelloUnity.apk D:\ftpserver\ /y

if not %errorlevel%==0 ( goto fail ) else ( goto end )
 
:fail
echo Build APK Fail
goto end
 
:end
pause