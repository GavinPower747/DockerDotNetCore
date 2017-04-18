FROM microsoft/dotnet:latest

#Create working dir designate it as such
RUN mkdir -p /app
WORKDIR /app

#Copy everything into the working directory
COPY . /app

#Do a .Net restore
RUN dotnet restore

#Expose port 5000 (default kestrel port)
EXPOSE 5000

#Define environment variable
ENV ASPNETCORE_ENVIRONMENT Development

#dotnet run on startup
CMD ["dotnet", "run"]
