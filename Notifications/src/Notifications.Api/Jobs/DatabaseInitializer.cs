using Dapper;
using Microsoft.Data.SqlClient;

namespace Notifications.Api.Jobs;

internal sealed class DatabaseInitializer : IHostedService
{
    private readonly IConfiguration _configuration;

    public DatabaseInitializer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var masterConnectionString = string.Join(";", _configuration.GetConnectionString("Notifications")!.Split(";")
            .Where(x => !x.Contains("Database")));

        const string createDatabaseQuery = """
                                           
                                                           IF DB_ID('notifications') IS NULL
                                                           BEGIN
                                                               CREATE DATABASE notifications;
                                                           END;
                                           """;

        await using var createDatabaseConnection = new SqlConnection(masterConnectionString);
        await createDatabaseConnection.ExecuteAsync(createDatabaseQuery);

        const string createTablesQuery = """
                                         
                                                         IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Notifications]') AND type = 'U')
                                                         BEGIN
                                                             CREATE TABLE Notifications (
                                                                 Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                                                                 Type INT NOT NULL,
                                                                 Content NVARCHAR(MAX) NOT NULL,
                                                                 Receiver NVARCHAR(255) NOT NULL,
                                                                 Status INT NOT NULL,
                                                                 PublishDateTime DATETIMEOFFSET(7)
                                                             );
                                                         END;
                                         """;

        await using var connection = new SqlConnection(_configuration.GetConnectionString("Notifications"));
        await connection.ExecuteAsync(createTablesQuery);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
