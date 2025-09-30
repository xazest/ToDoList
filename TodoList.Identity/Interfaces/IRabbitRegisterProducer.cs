namespace TodoList.Identity.Interfaces
{
    public interface IRabbitRegisterProducer
    {
        Task ProduceAsync(string queueName, string userId);
    }
}
