using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Server.Application.Abstractions;
using Kanban.Server.Domain.Abstractions;
using Kanban.Server.Domain.Projects;

namespace Kanban.Server.Application.Projects;
public interface ICosmosProjectService
{
  Task<Result<List<Project>>> GetProjectsAsync(DateTime? minCreatedDate = null);
  Task<Result<CosmosResult>> UpsertProjectAsync(Project project);
}
