using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.TodoLists.Commands.CreateTodoList;
using TodoList.Application.TodoLists.Commands.UpdateTodoList;
using TodoList.Application.TodoLists.Commands.DeleteTodoList;
using TodoList.WebAPI.Models;

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
        
    }
}
