namespace Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    IDbConnectionFactory CreateOpenConnection();
}
