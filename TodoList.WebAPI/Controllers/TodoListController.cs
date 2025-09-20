using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Interfaces;
using TodoList.Application.TodoLists.Commands.CreateTodoList;
using TodoList.Application.TodoLists.Commands.DeleteTodoList;
using TodoList.Application.TodoLists.Commands.UpdateTodoList;
using TodoList.Application.TodoLists.Queries.GetListOfTodoList;
using TodoList.Application.TodoLists.Queries.GetTodoList;
using TodoList.WebAPI.Models;

namespace TodoList.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public TodoListController(
            IMediator mediator,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public async Task<ActionResult<ListOfTodoListDto>> GetAll()
        {
            var query = new GetListOfTodoListQuery
            {
                UserId = _currentUserService.UserId
            };
            var todoLists = await _mediator.Send(query);
            return Ok(todoLists);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListDto>> Get(Guid id)
        {
            var query = new GetTodoListQuery
            {
                Id = id,
                UserId = _currentUserService.UserId
            };
            var todoList = await _mediator.Send(query);
            if (todoList == null)
                return NotFound();
            return Ok(todoList);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoListDto dto)
        {
            var command = _mapper.Map<CreateTodoListCommand>(dto);
            command.UserId = _currentUserService.UserId;
            var todoListId = await _mediator.Send(command);
            return Ok(todoListId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoListDto dto)
        {
            var command = _mapper.Map<UpdateTodoListCommand>(dto);
            command.Id = id;
            command.UserId = _currentUserService.UserId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTodoListCommand
            {
                Id = id,
                UserId = _currentUserService.UserId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
