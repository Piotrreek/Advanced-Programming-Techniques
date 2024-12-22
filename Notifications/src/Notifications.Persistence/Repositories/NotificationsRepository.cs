using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Notifications.Persistence.Models;

namespace Notifications.Persistence.Repositories;

internal sealed class NotificationsRepository : INotificationsRepository
{
    private readonly IConfiguration _configuration;

    public NotificationsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task Add(Notification notification)
    {
        const string query =
            "INSERT INTO Notifications (Id, Type, Content, Receiver, Status, PublishDateTime) VALUES (@Id, @Type, @Content, @Receiver, @Status, @PublishDateTime)";

        var parameters = new DynamicParameters();

        parameters.Add("Id", notification.Id, DbType.Guid);
        parameters.Add("Type", notification.Type, DbType.Int16);
        parameters.Add("Content", notification.Content, DbType.String);
        parameters.Add("Receiver", notification.Receiver, DbType.String);
        parameters.Add("Status", notification.Status, DbType.Int16);
        parameters.Add("PublishDateTime", notification.PublishDateTime, DbType.DateTimeOffset);

        await using var connection = CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task Update(Guid notificationId, NotificationStatus status)
    {
        const string query = "UPDATE Notifications SET Status = @Status WHERE Id = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("Id", notificationId, DbType.Guid);
        parameters.Add("Status", status, DbType.Int16);

        await using var connection = CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }

    public async Task<IReadOnlyCollection<Notification>> GetAll()
    {
        const string query = "SELECT * FROM Notifications;";

        await using var connection = CreateConnection();
        return (await connection.QueryAsync<Notification>(query))
            .ToList();
    }

    public async Task<Notification> GetById(Guid notificationId)
    {
        const string query = "SELECT * FROM Notifications WHERE Id = @Id";

        var parameters = new DynamicParameters();
        parameters.Add("Id", notificationId, DbType.Guid);

        await using var connection = CreateConnection();

        return await connection.QuerySingleAsync<Notification>(query, parameters);
    }

    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("Notifications"));
    }
}
