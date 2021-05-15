FROM mcr.microsoft.com/dotnet/sdk:5.0 as backendBuilder

WORKDIR /app/src/

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out **/TestYourStudents.API.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

WORKDIR /app

COPY --from=backendBuilder /app/src/out .

COPY docker-entrypoint.sh /usr/bin/docker-entrypoint.sh
RUN chmod +x /usr/bin/docker-entrypoint.sh
CMD ["docker-entrypoint.sh"]
