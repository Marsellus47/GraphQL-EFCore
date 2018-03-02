using BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries;
using BridgeManagement.Api.GraphQL.Schemas;
using BridgeManagement.Api.GraphQL.Types.ImportLogs;
using BridgeManagement.Api.GraphQL.Types.InterfaceInfos;
using BridgeManagement.Api.GraphQL.Types.RecordInfos;
using BridgeManagement.Api.GraphQL.Types.RecordStatusLogs;
using BridgeManagement.Api.GraphQL.Types.SessionInfos;
using BridgeManagement.Api.GraphQL.Types.Shared;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.Api.GraphQL.Types.StatusDefinitions;
using BridgeManagement.DataAccessLayer;
using BridgeManagement.DataAccessLayer.Repositories.ImportLogs;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos;
using BridgeManagement.DataAccessLayer.Repositories.RecordInfos;
using BridgeManagement.DataAccessLayer.Repositories.RecordStatusLogs;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfos;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BridgeManagement.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddScoped<BridgeManagementQuery>();
			services.AddTransient<IImportLogRepository, ImportLogRepository>();
			services.AddTransient<IInterfaceInfoRepository, InterfaceInfoRepository>();
			services.AddTransient<IRecordInfoRepository, RecordInfoRepository>();
			services.AddTransient<IRecordStatusLogRepository, RecordStatusLogRepository>();
			services.AddTransient<ISessionInfoRepository, SessionInfoRepository>();

			services.AddDbContext<BmtContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IDocumentExecuter, DocumentExecuter>();
			services.AddTransient<ComparisonOperatorEnum>();
			services.AddTransient<ConditionType>();
			services.AddTransient<ImportLogType>();
			services.AddTransient<InterfaceDirectionEnum>();
			services.AddTransient<InterfaceInfoType>();
			services.AddTransient<LogicalOperatorEnum>();
			services.AddTransient<LogLevelEnum>();
			services.AddTransient<ProcessingPhaseEnum>();
			services.AddTransient<ProjectionType>();
			services.AddTransient<RecordInfoType>();
			services.AddTransient<RecordStatusLogType>();
			services.AddTransient<SessionInfoType>();
			services.AddTransient<SessionResultEnum>();
			services.AddTransient<SortingDirectionEnum>();
			services.AddTransient<SortType>();
			services.AddTransient<StatusDefinitionType>();
			services.AddTransient<StatusResultEnum>();

			var sp = services.BuildServiceProvider();
			services.AddScoped<ISchema>(_ => new BridgeManagementSchema(type => (GraphType) sp.GetService(type))
			{
				Query = sp.GetService<BridgeManagementQuery>()
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}
