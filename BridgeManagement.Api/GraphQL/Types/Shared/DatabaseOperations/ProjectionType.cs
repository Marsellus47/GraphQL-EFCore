using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class ProjectionType : InputObjectGraphType
    {
	    public ProjectionType()
	    {
		    Name = nameof(Projection);
		    Description = "Data projection.";

		    Field<IntGraphType>(nameof(Projection.Page), "Page number.");
		    Field<IntGraphType>(nameof(Projection.PageSize), "Size of the Page.");
		    Field<ListGraphType<SortType>>(nameof(Projection.Sorts), "Sorting expression.");
		    Field<ConditionType>(nameof(Projection.Filter), "Filter expression.");
		}
	}
}
