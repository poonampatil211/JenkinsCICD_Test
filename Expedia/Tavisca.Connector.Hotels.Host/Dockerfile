#FROM microsoft/dotnet:1.1.0-sdk-projectjson
FROM microsoft/dotnet:1.1.1-sdk

WORKDIR /app

EXPOSE 5000/tcp

ENV ASPNETCORE_ENVIRONMENT Development

CMD /usr/bin/dotnet /app/Tavisca.Connectors.Hotel.dll --server.urls http://*:5000 --environment $ASPNETCORE_ENVIRONMENT
