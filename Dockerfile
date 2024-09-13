# Step 1: Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution and project files (for all layers)
#COPY srcHomeTest.sln", "./
COPY src/GetDinners.Api/*.csproj ./src/GetDinners.Api/
COPY src/GetDinners.Application/*.csproj ./src/GetDinners.Application/
COPY src/GetDinners.Domain/*.csproj ./src/GetDinners.Domain/
COPY src/GetDinners.Infrastructure/*.csproj ./src/GetDinners.Infrastructure/

# Restore dependencies
RUN dotnet restore ./src/GetDinners.Api/GetDinners.Api.csproj

# Copy the rest of the code and build the app
COPY . .

# Step 2: Publish the app to the publish directory
RUN dotnet publish ./src/GetDinners.Api/GetDinners.Api.csproj -c Release -o /app/publish

# Step 3: Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

#copie les fichiers publié depuis l'étape de build
COPY --from=build /app/publish .

# Expose port 80 for HTTP traffic
EXPOSE 80

# Set the entry point to run the app
ENTRYPOINT ["dotnet", "GetDinners.Api.dll"]


