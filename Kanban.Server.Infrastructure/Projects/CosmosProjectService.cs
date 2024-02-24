using Kanban.Server.Application.Abstractions;
using Kanban.Server.Application.Projects;
using Kanban.Server.Domain;
using Kanban.Server.Domain.Abstractions;
using Kanban.Server.Domain.Projects;
using Microsoft.Azure.Cosmos;

namespace Kanban.Server.Infrastructure.Projects;

public class CosmosProjectService : ICosmosProjectService
{
  private Microsoft.Azure.Cosmos.Container _container;
  private const string databaseName = "kanban";
  private const string containerName = "Projects";

  public CosmosProjectService( CosmosClient dbClient )
  {
    _container = dbClient.GetContainer( databaseName, containerName );
  }

  public Task<Result<List<Project>>> GetProjectsAsync(DateTime? minCreatedDate = null)
  {
    throw new NotImplementedException();
  }

  public async Task<Result<CosmosResult>> UpsertProjectAsync( Project project)
  {
    try
    {
      var json = project.GetJson();
      JSONUtilities.Set(json, "partitionKey", project.Id.ToString());

      var cosmosResult = await _container.UpsertItemAsync(json, new PartitionKey(project.Id.ToString()));
      return Result.Success(new CosmosResult(cosmosResult.StatusCode, cosmosResult.RequestCharge));
    }catch(Exception e)
    {
      return Result.Failure<CosmosResult>(new Error(e.Message, e.Message));
    }
  }

}
