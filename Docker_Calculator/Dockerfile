# Use the official .NET SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file to the working directory
COPY *.csproj .

# Restore dependencies
RUN dotnet restore

# Copy the entire application to the working directory
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the built application from the build image
COPY --from=build /app/out .

# Expose the port the app will run on
EXPOSE 80

# Command to run the application
CMD ["dotnet", "Docker_Calculator.dll"]
