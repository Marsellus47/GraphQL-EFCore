using Microsoft.EntityFrameworkCore;

using GraphQL.Types;

using BridgeManagement.Api.GraphQL.Types.InterfaceInfo;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery
	{
		private void InitializeInterfaceInfoQuery(IInterfaceInfoRepository interfaceInfoRepository)
		{
			Field<InterfaceInfoType>(
				"interface",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "id",
						Description = "id of the interface"
					}),
				resolve: context =>
				{
					var id = context.GetArgument<short>("id");
					return interfaceInfoRepository.Get(id);
				});

			Field<ListGraphType<InterfaceInfoType>>(
				"interfaces",
				resolve: context => interfaceInfoRepository.GetAllQueryable()
					.ToListAsync()
					.Result);
		}
	}
}
