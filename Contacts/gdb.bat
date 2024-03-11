

dotnet ef dbcontext scaffold  "Server=localhost;Database=contactDb;User Id=sa;Password=asd@123_#;Integrated Security=false;TrustServerCertificate=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer   -s  %cd%/ReadModel/ReadModel.Infrastructure/ReadModel.Infrastructure.csproj  -p %cd%/ReadModel/ReadModel.Infrastructure/ReadModel.Infrastructure.csproj -o Models -f