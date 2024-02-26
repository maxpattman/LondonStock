using LondonStock.Application.DTOs.StockType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LondonStock.Application.Features.StockType.Queries;
using Microsoft.AspNetCore.SignalR.Protocol;
using Application.DTOs.TransactionType;
using LondonStock.Application.Features.StockType.Queries.GetAllStockType;
using LondonStock.Application.Features.StockType.Queries.GetStockType;
using LondonStock.Application.Features.StockType.Queries.GetStockList;
using LondonStock.Application.Features.TransactionType.Commands.CreateTransactionType;

namespace LondonStock.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LondonStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LondonStockController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<ActionResult<List<StockTypeDto>>> GetAll()
        {
            var response = await _mediator.Send(new GetAllStockRequest());
            return Ok(response);
        }

        [HttpGet("{ticker}")]
        public async Task<ActionResult<StockTypeDto>> Get(string ticker)
        {
            var response = await _mediator.Send(new GetStockRequest { Ticker = ticker });
            return Ok(response);
        }

        [HttpGet]
        [Route("/list")]
        public async Task<ActionResult<List<StockTypeDto>>> GetList([FromBody]string[] tickerlist)
        {
            var list = tickerlist.ToList<string>();
            var response = await _mediator.Send(new GetStockListRequest(list));
            return Ok(response);
            
        }
        [HttpPost]
        public async Task<ActionResult> PostTransaction([FromBody] TransactionTypeDto transaction) 
        {
            var result = await _mediator.Send( new CreateTransactionCommand { TransactionTypeDto = transaction});
            return Ok(result);
        }

    }
}
