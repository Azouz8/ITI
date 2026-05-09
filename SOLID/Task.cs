namespace OrderSystem;

// ── Entities ────────────────────────────────────────────
public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CustomerEmail { get; set; }
    public string OrderType { get; set; }  // "Standard", "Premium", "Bulk"
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}


public interface IOrderProcessor
{
    void ProcessOrder(Order order);
}
public interface IOrderNotifier
{
    void SendConfirmationEmail(Order order);

}
public interface IOrderReporter
{
    string GenerateReport(IEnumerable<Order> orders);
    string ExportToCsv(IEnumerable<Order> orders);
}

public interface IOrderStorage
{
    void Save(Order order);
}
public interface IOrderEmailSender
{
    void Send(string to, string subject, string body);
}
public interface IOrderLogger
{
    void Log(string message);
}

public interface IDiscountStrategy
{
    decimal GetDiscount(Order order);
}

public interface IOrderWriter
{
    void Save(Order order);
}
public interface IOrderReader
{
    IEnumerable<Order> GetAll();
}


public class OrderProcessor(
    OrderValidator validator,
    IDiscountStrategy discountStrategy,
    IOrderStorage storage,
    IOrderNotifier notifier,
    IOrderLogger logger) : IOrderProcessor
{
    public OrderProcessor(
     OrderValidator validator,
     IDiscountStrategy discountStrategy,
     IOrderStorage storage,
     IOrderNotifier notifier,
     IOrderLogger logger)
    {
        _validator = validator;
        _discountStrategy = discountStrategy;
        _storage = storage;
        _notifier = notifier;
        _logger = logger;
    }


    public void ProcessOrder(Order order)
    {
        _logger.Log($"Processing order {order.Id}");
        if (!_validator.IsValid(order)) return;
        var discount = _discountStrategy.GetDiscount(order);
        var finalAmount = order.TotalAmount - (order.TotalAmount * discount);
        _logger.Log($"Final amount after {discount:P0} discount: {finalAmount:C}");

        _storage.Save(order);
        _notifier.SendConfirmationEmail(order);

    }

}

public class StandardDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order) => 0.00m;
}
public class PremiumDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order) => 0.10m;
}

public class BulkDiscountStrategy : IDiscountStrategy
{
    public decimal GetDiscount(Order order) => 0.20m;
}


public class OrderValidator
{
    private readonly IOrderLogger _logger;
    public OrderValidator(IOrderLogger logger) => _logger = logger;
    public bool IsValid(Order order)
    {
        if (order.Items.Count == 0) { _logger.Log("No items."); return false; }
        if (string.IsNullOrWhiteSpace(order.CustomerEmail)) { _logger.Log("No items."); return false; }
        return true;
    }
}

public class OrderEmailSender : IOrderNotifier
{
    private readonly IOrderEmailSender _emailer;
    public OrderEmailSender(IOrderEmailSender emailer) => _emailer = emailer;

    public void SendConfirmationEmail(Order order) =>
        _emailer.Send(order.CustomerEmail, $"Order {order.Id} Confirmed", "...");
}

public class OrderReportService : IOrderReporter
{
    public string GenerateReport(IEnumerable<Order> orders) =>
    $"Orders: {orders.Count()} | Revenue: {orders.Sum(o => o.TotalAmount):C}";

    public string ExportToCsv(IEnumerable<Order> orders) =>
        string.Join("\n", orders.Select(o => $"{o.Id},{o.CustomerEmail},{o.TotalAmount}"));
}

public class SqlOrderStorage : IOrderReader, IOrderWriter
{
    public void Save(Order o) => Console.WriteLine($"[SQL] Saved {o.Id}");
    public IEnumerable<Order> GetAll() => Enumerable.Empty<Order>();
}

public class ArchiveOrderStorage : IOrderReader
{
    public IEnumerable<Order> GetAll() => Enumerable.Empty<Order>();
}

public class SmtpEmailSender : IOrderEmailSender
{
    public void Send(string to, string subject, string body)
        => Console.WriteLine($"[SMTP] → {to} | {subject}");
}

public class FileOrderLogger : IOrderLogger
{
    public void Log(string message)
        => Console.WriteLine($"[LOG] {message}");
}

public class SqlOrderStorageAdapter : IOrderStorage
{
    private readonly SqlOrderStorage _inner = new();
    public void Save(Order order) => _inner.Save(order);
}

public static class CompositionRoot
{
    public static OrderProcessor Setup(string orderType = "Standard")
    {
        IOrderLogger logger = new FileOrderLogger();
        IOrderEmailSender emailer = new SmtpEmailSender();
        IOrderStorage storage = new SqlOrderStorageAdapter();

        var validator = new OrderValidator(logger);

        IDiscountStrategy discount = orderType switch
        {
            "Premium" => new PremiumDiscountStrategy(),
            "Bulk" => new BulkDiscountStrategy(),
            _ => new StandardDiscountStrategy(),
        };

        IOrderNotifier notifier = new OrderEmailSender(emailer);

        return new OrderProcessor(validator, discount, storage, notifier, logger);
    }
}