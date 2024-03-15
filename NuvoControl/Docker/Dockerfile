#FROM mcr.microsoft.com/dotnet/sdk:8.0
#FROM mcr.microsoft.com/dotnet/sdk:8.0.203-windowsservercore-ltsc2019
FROM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019
#FROM mcr.microsoft.com/windowsservercore:latest

run mkdir c:\App

COPY ReadMe.txt .
COPY dotnet-install.ps1 .
COPY ./out c:/App

# NuvoControl.Server.WebConsole.exe -p COM1 -r 700 -l 1

ENTRYPOINT ["powershell", ""]