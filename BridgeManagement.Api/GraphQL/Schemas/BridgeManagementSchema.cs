using System;
using BridgeManagement.Api.GraphQL.Queries;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Schemas
{
	public class BridgeManagementSchema : Schema
    {
	    public BridgeManagementSchema(Func<Type, GraphType> resolveType)
		    : base(resolveType)
	    {
		    Query = (BridgeManagementQuery) resolveType(typeof(BridgeManagementQuery));
	    }
    }
}
