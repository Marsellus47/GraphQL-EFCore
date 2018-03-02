using BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries;
using BridgeManagement.Api.GraphQL.Schemas;
using BridgeManagement.Api.GraphQL.Types.InterfaceInfo;
using BridgeManagement.Api.GraphQL.Types.SessionInfo;
using BridgeManagement.Api.GraphQL.Types.Shared;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.DataAccessLayer;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfo;
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
			services.AddTransient<IInterfaceInfoRepository, InterfaceInfoRepository>();
			services.AddTransient<ISessionInfoRepository, SessionInfoRepository>();

			services.AddDbContext<BmtContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IDocumentExecuter, DocumentExecuter>();
			services.AddTransient<LogLevelEnum>();
			services.AddTransient<ProjectionType>();
			services.AddTransient<SortType>();
			services.AddTransient<SortingDirectionEnum>();
			services.AddTransient<ConditionType>();
			services.AddTransient<LogicalOperatorEnum>();
			services.AddTransient<ComparisonOperatorEnum>();
			services.AddTransient<InterfaceInfoType>();
			services.AddTransient<InterfaceDirectionEnum>();
			services.AddTransient<SessionInfoType>();
			services.AddTransient<SessionResultEnum>();

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
