FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as builder

WORKDIR /app
COPY . /app

RUN dotnet restore
RUN dotnet publish -o ./allPubs

FROM mcr.microsoft.com/dotnet/core/aspnet:latest as run

WORKDIR /app
COPY --from=builder /app/allPubs ./
ENTRYPOINT ["dotnet", "MyDockService.dll"]

# docker image build -t mydockservice:latest .
# docker run -d -e Instance__Id=3 -e ASPNETCORE_URLS='http://*:6000' -p 6000:6000 --name dockService mydockservice:latest

# kubectl create deployment hello-node --image=mydockservice:latest
# kubectl create deployment hello-node --image=ptatv/mydockservice:latest