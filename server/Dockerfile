FROM mcr.microsoft.com/dotnet/sdk:8.0
COPY . /app
WORKDIR /app
RUN dotnet publish -c Release -o out

ENV ASPNETCORE_URLS http://*:5000
WORKDIR /app/out

ENTRYPOINT ["dotnet", "RecoCms6.dll"]
