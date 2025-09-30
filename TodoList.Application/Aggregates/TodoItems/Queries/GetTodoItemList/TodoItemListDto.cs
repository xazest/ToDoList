namespace TodoList.Application.Aggregates.TodoItems.Queries.GetTodoItemList
{
    public class TodoItemListDto
    {
        public IList<TodoItemLookupDto> TodoListDtos { get; set; }
    }
}
