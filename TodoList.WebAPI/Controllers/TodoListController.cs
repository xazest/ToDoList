using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTodoListDto createTodoListDto)
        {
            var command = new CreateTodoListCommand(createTodoListDto.Title, createTodoListDto.Description);
            var todoListId = await _mediator.Send(command);
            return Ok(todoListId);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListVm>> GetById(int id)
        {
            var query = new GetTodoListByIdQuery(id);
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet]
        public async Task<ActionResult<TodoListsVm>> GetAll()
        {
            var query = new GetTodoListsQuery();
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoListDto updateTodoListDto)
        {
            var command = new UpdateTodoListCommand(id, updateTodoListDto.Title, updateTodoListDto.Description);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTodoListCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
