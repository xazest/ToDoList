using AutoMapper;
using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, TodoListDto>
    {
        private readonly ITodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTodoListQueryHandler(ITodoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TodoListDto> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TodoListItems.FindAsync([request.Id], cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoListItem), request.Id);
            }
            return _mapper.Map<TodoListDto>(entity);
        }
    }
}
