namespace DataApplications.Data;

public class InitializeContext
{
    public static void Initialize(DeliveryDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
