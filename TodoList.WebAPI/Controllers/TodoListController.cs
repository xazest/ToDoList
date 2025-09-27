using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Interfaces;
using TodoList.Application.TodoItems.Commands.CreateTodoItem;
using TodoList.Application.TodoItems.Commands.UpdateTodoItem;
using TodoList.Application.TodoItems.Queries.GetTodoItem;
using TodoList.Application.TodoItems.Queries.GetTodoItemList;
using TodoList.Application.TodoLists.Commands.DeleteTodoList;
using TodoList.Application.TodoLists.Queries.GetTodoItem;
using TodoList.Application.TodoLists.Queries.GetTodoItemList;
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
        public async Task<ActionResult<TodoItemListDto>> GetAll()
        {
            var query = new GetTodoItemListQuery
            {
                UserId = _currentUserService.UserId
            };
            var todoLists = await _mediator.Send(query);
            return Ok(todoLists);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> Get(Guid id)
        {
            var query = new GetTodoItemQuery
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
            var command = _mapper.Map<CreateTodoItemCommand>(dto);
            command.UserId = _currentUserService.UserId;
            var todoListId = await _mediator.Send(command);
            return Ok(todoListId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoListDto dto)
        {
            var command = _mapper.Map<UpdateTodoItemCommand>(dto);
            command.Id = id;
            command.UserId = _currentUserService.UserId;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTodoItemCommand
            {
                Id = id,
                UserId = _currentUserService.UserId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
