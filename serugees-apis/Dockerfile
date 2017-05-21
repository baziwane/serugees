FROM microsoft/dotnet:1.1-sdk

WORKDIR /serugees-apis

MAINTAINER Ken, Raymo, Davi

ENV DOTNET_USE_POLLING_FILE_WATCHER=1

EXPOSE 5001
ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT="Development"

# copy csproj and restore as distinct layers
COPY serugees-api.csproj .
RUN dotnet restore

# copy and build everything else
COPY . .
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/serugees-api.dll"]

CMD ["/bin/bash", "-c", "dotnet restore && dotnet ef database update && dotnet run"]
#COPY . /serugees-apis

# https://github.com/DanWahlin/AspNetCorePostgreSQLDockerApp/blob/master/src/AspNetCorePostgreSQLDockerApp/aspnetcore.development.dockerfile
# Build the image:
#docker build -f aspnetcore.development.dockerfile -t [baziwane]/dotnet:1.0.0 

# Option 1
# Start PostgreSQL and ASP.NET Core (link ASP.NET core to ProgreSQL container with legacy linking)
 
#docker run -d --name dbpostgres-db -e POSTGRES_PASSWORD=Lz3hxHhqFmM3872Q postgres
#docker run -d -p 5000:5000 --link dbpostgres-db:postgres [baziwane]/dotnet:1.0.0

# Option 2: Create a custom bridge network and add containers into it

# docker network create --driver bridge isolated_network
# docker run -d --net=isolated_network --name postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d --net=isolated_network --name aspnetcoreapp -p 5000:5000 [yourDockerHubID]/dotnet:1.0.0

# t - tag
# docker build -t kentest-build -f Dockerfile.dev .

# docker run -d -p 8081:5000 -t webapp

# https://www.sep.com/sep-blog/2017/02/24/nginx-reverse-proxy-to-asp-net-core-same-container/
# https://www.sep.com/sep-blog/2017/02/27/nginx-reverse-proxy-to-asp-net-core-separate-docker-containers/



# Uncomment the ENV line below if you're running Docker for Windows or Mac
# It makes dotnet-watch work with a virtual mounted drive volume
#ENV DOTNET_USE_POLLING_FILE_WATCHER=1

# CMD dotnet restore && dotnet watch run --server.urls http://*:5000