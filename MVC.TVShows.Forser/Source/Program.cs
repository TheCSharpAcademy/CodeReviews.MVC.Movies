WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TVShowContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
})
.AddScoped<TVShowContext>()
.AddTransient<ITVShowRepository, TVShowRepository>()
.AddTransient<IShowGenreRepository, ShowGenreRepository>()
.AddTransient<IRatingRepository, RatingRepository>()
.AddScoped<IUnitOfWork, UnitOfWork>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseRequestLocalization("en-US", "en-GB");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TVShow}/{action=Index}/{tvshowId?}");

app.Run();