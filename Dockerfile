FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /src
COPY *.sln .

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

# copy and restore all projects
COPY KingdomCommunication.API/*.csproj KingdomCommunication.API/
COPY Us.DataAccess/*.csproj Us.DataAccess/
COPY UsApplication.Core/*.csproj UsApplication.Core/
COPY UsApplication.DTOs/*.csproj UsApplication.DTOs/
COPY UsApplication.Services/*.csproj UsApplication.Services/
COPY UsApplication.Models/*.csproj UsApplication.Models/

RUN dotnet restore

# Copy everything else
COPY . .


#Publishing
FROM base AS publish
RUN npm install clsx
RUN npm install @material-ui/core
RUN npm install @material-ui/icons
WORKDIR /src/KingdomCommunication.API
RUN dotnet publish -c Release -o /src/publish


#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .

#ENTRYPOINT ["dotnet", "KingdomCommunication.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet KingdomCommunication.API.dll