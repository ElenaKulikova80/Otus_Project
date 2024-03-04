namespace Identity.WebAPI.RabbitMq
{
    public interface IRabbitMqProducer
    {
        public void SendMessage<T> (T Message);
    }
}
