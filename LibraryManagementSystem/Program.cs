using LibraryManagementSystem.Extensions;


var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddPresentation(builder.Configuration);

}

var app = builder.Build();
{
    //  Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
