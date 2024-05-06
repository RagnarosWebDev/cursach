using System.ComponentModel;

namespace Market.Core.Models
{
    public enum OrderStatus
    {
        [Description("Создан")]
        Created,
        [Description("Забран")]
        Accept,
    }

    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }

        [DefaultValue(OrderStatus.Created)] public OrderStatus OrderStatus { get; set; }

        public string Products => string.Join(", ", OrderItems.Select(e => $"{e.Product.Name} {e.Count}"));
    }
    
    
    public class OrderItem
    {
        public int Id { get; set; }
    
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}