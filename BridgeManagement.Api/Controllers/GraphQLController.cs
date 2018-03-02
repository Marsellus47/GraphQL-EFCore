using System;
using System.Threading.Tasks;
using BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace BridgeManagement.Api.Controllers
{
	[Produces("application/json")]
	[Route("graphql")]
	public class GraphQLController : Controller
	{
		private readonly IDocumentExecuter _documentExecuter;
		private readonly ISchema _schema;

		public GraphQLController(
			IDocumentExecuter documentExecuter,
			ISchema schema)
		{
			_documentExecuter = documentExecuter ?? throw new ArgumentNullException(nameof(documentExecuter));
			_schema = schema ?? throw new ArgumentNullException(nameof(schema));
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] GraphQLQuery query)
		{
			if (query == null)
			{
				throw new ArgumentNullException(nameof(query));
			}

			var executionOptions = new ExecutionOptions
			{
				Schema = _schema,
				Query = query.Query,
				Inputs = query.Variables.ToInputs(),
				OperationName = query.OperationName
			};

			try
			{
				var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

				if (result.Errors?.Count > 0)
				{
					return BadRequest(result.Errors);
				}

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}
	}
}