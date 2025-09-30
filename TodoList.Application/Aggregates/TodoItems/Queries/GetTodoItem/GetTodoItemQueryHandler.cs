using AutoMapper;
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemDto>
    {
        private readonly ITodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTodoItemQueryHandler(ITodoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }
            return _mapper.Map<TodoItemDto>(entity);
        }
    }
}
