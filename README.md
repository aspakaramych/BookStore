# BookStore

## Description

This project is my first experience in ASP.NET. I implement simple REST API services of bookstore. 

## Setup and Run

### Download Sdk Dotnet 8.0 from Microsoft 

>Windows: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.404-windows-x86-installer   
Ubuntu: ```sudo apt-get install -y dotnet-sdk-8.0```

### Download PostgreSQL 16.2

>Windows: https://www.postgresql.org/download/windows/  
Ubuntu: ```sudo apt-get install -y postgresql```

### Change Appsettings

>> Go to appsettings.Development and change "BookDbContext" key

### Create migrations

>```cd Book.Api```  
```dotnet ef migrations add init```  
```dotnet ef update database```

### Run project

```dotnet run```
