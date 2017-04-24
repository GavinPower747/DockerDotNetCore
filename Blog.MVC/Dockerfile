FROM microsoft/dotnet:latest

#Create working directory
RUN mkdir -p /app

#Copy everything into the working directory
COPY . /app

#Set the app entry point as the working directory
WORKDIR /app/Blog.MVC

#Do a .Net restore
RUN dotnet restore ../TestMvcApp.sln

EXPOSE 5000

#Define environment variable
ENV ASPNETCORE_ENVIRONMENT Development

#dotnet run on startup
CMD ["dotnet", "run"]
