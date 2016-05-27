# Asp.Net_Framework_API_RC2

####Add DataContext class
```
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            builder.Entity<User>(u =>
            {
                u.Property<string>("FirstName").HasMaxLength(50).IsRequired();
                u.Property<string>("LastNamePrefix").HasMaxLength(20);
                u.Property<string>("LastName").HasMaxLength(50).IsRequired();
                u.Property<int>("Age").HasMaxLength(3).IsRequired();
            });
            
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
        }

        public DbSet<User> Users { get; set; } // TODO: Add User class
    }
    
```
For more: [Entity Framework Code First Migrations](http://developer.telerik.com/featured/entity-framework-code-first-migrations/)

####Add connection string to appsetting.json
```
"Data": {
    "DefaultConnection": {
      "ConnectionString": "Server=WINDOWS10\\SQLEXPRESS;Database=AC_DB_01;Trusted_Connection=True;MultipleActiveResultSets=true;"
    }
    }
```
####Add to StartUp ConfigureServices
```
services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
```

####Tools ‣ Nuget Package Manager ‣ Package Manager Console
```
PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Pre
```
####Add 'Microsoft.EntityFrameworkCore.Tools' to the 'tools' section in project.json
```
"Microsoft.EntityFrameworkCore.Tools": {
      "version": "1.0.0-preview1-final",
      "imports": [
        "portable-net45+win8+dnxcore50",
        "portable-net45+win8"
      ]
    }
```
```
PM> Add-Migration -OutputDir 01_DataAccess\Migrations FirstMigration

To undo this action, use Remove-Migration

//everytime you change the Db, create a new Migration(Add-Migration Migrations_addUserLastname) and Update-Database.
//To remove the last Migration do PM> Remove-Migration
```
```
PM> Update-Database
```

For more Microsoft PM Comand Line , see the [Package Manager Console (Visual Studio)](https://docs.efproject.net/en/latest/cli/powershell.html). 

[ASP.NET Core Application to New Database](https://docs.efproject.net/en/latest/platforms/aspnetcore/new-db.html).


