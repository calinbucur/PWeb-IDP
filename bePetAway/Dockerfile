FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
RUN dotnet dev-certs https
COPY . .
RUN dotnet restore "Petaway.Api/Petaway.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet publish "Petaway.Api/Petaway.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Petaway.Api.dll"]