using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Interfaces;

namespace TodoList.Application.TodoLists.Queries.GetListOfTodoList
{
    public class GetListOfTodoListQueryHandler
        : IRequestHandler<GetListOfTodoListQuery, ListOfTodoListDto>
    {
        private readonly ITodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListOfTodoListQueryHandler(
            ITodoListDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListOfTodoListDto> Handle(GetListOfTodoListQuery request, 
            CancellationToken cancellationToken)
        {
            var todoListsQuery = await _dbContext.TodoListItems
                .Where(t => t.UserId == request.UserId)
                .ProjectTo<TodoListLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ListOfTodoListDto { TodoListDtos = todoListsQuery };
        }
    }
}
