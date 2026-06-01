namespace DataApplications.Data;

public class InitializeContext
{
    public static void Initialize(DeliveryDbContext context)
    {
        // Cria o banco de dados e as tabelas se não existirem
        // Ideal para desenvolvimento sem usar migrations
        context.Database.EnsureCreated();
    }
}
