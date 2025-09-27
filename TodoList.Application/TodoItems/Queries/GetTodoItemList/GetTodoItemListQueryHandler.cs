using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Interfaces;

namespace TodoList.Application.TodoItems.Queries.GetTodoItemList
{
    public class GetTodoItemListQueryHandler
        : IRequestHandler<GetTodoItemListQuery, TodoItemListDto>
    {
        private readonly ITodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTodoItemListQueryHandler(
            ITodoListDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<TodoItemListDto> Handle(GetTodoItemListQuery request, 
            CancellationToken cancellationToken)
        {
            var todoListsQuery = await _dbContext.TodoListItems
                .Where(t => t.UserId == request.UserId)
                .ProjectTo<TodoItemLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TodoItemListDto { TodoListDtos = todoListsQuery };
        }
    }
}
