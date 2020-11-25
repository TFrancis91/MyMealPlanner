dotnet new webapi -o MyMealPlanner
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
In Appsettings.json add 
"ConnectionStrings": {
    "MyMealPlannerDb":"Server=localhost;Database=MyMealPlannerDb;User=root;Password=root;"
  }
Create Models/Meal.cs and Models/MealPlannerContext.cs
Register context class in startup.cs
Scaffold controller class as,
    Create parameterless constructor in context class
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet tool install --global dotnet-aspnet-codegenerator --version 3.1.3
    dotnet aspnet-codegenerator controller -name MealPlannerController -async -api -m meal -dc MealPlannerContext -outDir Controllers
To Migrate Models to Database,
  dotnet ef migrations add Initialcreate
  dotnet ef database update
  dotnet ef migrations remove
  dotnet ef migrations list