using System;
using System.Threading.Tasks;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BridgeManagement.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/InterfaceInfo")]
	public class InterfaceInfoController : Controller
	{
		private readonly IInterfaceInfoRepository interfaceInfoRepository;

		public InterfaceInfoController(IInterfaceInfoRepository interfaceInfoRepository)
		{
			this.interfaceInfoRepository =
				interfaceInfoRepository ?? throw new ArgumentNullException(nameof(interfaceInfoRepository));
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await interfaceInfoRepository.GetAllQueryable().ToListAsync();
			return Ok(data);
		}

		[HttpGet("{id}", Name = "GetInterfaceInfo")]
		public IActionResult GetById(short id)
		{
			var item = interfaceInfoRepository.Get(id);
			if (item == null)
			{
				return NotFound();
			}

			return Ok(item);
		}
	}
}