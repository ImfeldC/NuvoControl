FROM mcr.microsoft.com/dotnet/sdk:8.0

COPY . /home/src
WORKDIR /home/src
RUN dotnet build -c Release
RUN dotnet publish -c Release -o out

COPY /Server/NuvoControl.Server.WebConsole/bin/Release/net8.0-windows /home/app/WebConsole
WORKDIR /home/app/WebConsole

ENTRYPOINT ["dotnet", "/home/app/WebConsole/NuvoControl.Server.WebConsole.exe"]