using FSGPM.Algorithms;
using FSGPM.DataAccess;
using FSGPM.Interfaces;
using FSGPM.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Initialize configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container
var connectionString = configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<DTUcontext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IBenchmarkService, BenchmarkService>();
builder.Services.AddTransient<IReportStatusService, ReportStatusService>();
builder.Services.AddTransient<IDatabaseService, DatabaseService>();
builder.Services.AddTransient<IDataSetRepository, DataSetRepository>();
builder.Services.AddTransient<IDataSetService, DataSetService>();
builder.Services.AddTransient<IStatService, StatService>(); 
builder.Services.AddTransient<IOverleafService, OverleafService>();

// Implementations of Helpers
builder.Services.AddTransient<ISA_Scan_Base_Context, Algo_Base_Context>();

//Implementations of Solutions 
#region SA_Scan_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_VLG>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BitVector>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BackBitVector>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BitVector>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BackBitVector>();
#endregion

#region SA_Scan_Binary_Search_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_VLG_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BackBitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BackBitVector_Binary_Search>();
#endregion

//#region SA_Scan_Binary_Search_With_Pruning_Filters
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_VLG_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BackBitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BackBitVector_Binary_SearchWithPruning>();
//#endregion

#region SA_Scan_Graph_Search_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_BackBitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, SA_Scan_TextChecking_BackBitVector_Graph_Search>();
#endregion

#region AC_GraphSearch_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_VLG>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BackBitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BitVector_Graph_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BackBitVector_Graph_Search>();
#endregion

#region AC_Scan_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_VLG_Intersect_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BitVector_Intersect_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BackBitVector_Intersect_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_Intersect_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BitVector_Intersect_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BackBitVector_Intersect_Search>();
#endregion

#region AC_Scan_Binary_Search_Filters
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_VLG_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BackBitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BitVector_Binary_Search>();
builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BackBitVector_Binary_Search>();
#endregion

//#region AC_Scan_Binary_Search_Filters
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_VLG_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_BackBitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BitVector_Binary_SearchWithPruning>();
//builder.Services.AddTransient<IFS_GPM_Implementation, AC_Automaton_TextChecking_BackBitVector_Binary_SearchWithPruning>();
//#endregion



builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add CORS before HTTPS redirection
app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
