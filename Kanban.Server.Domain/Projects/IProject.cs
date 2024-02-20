using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Server.Domain.Abstractions;

namespace Kanban.Server.Domain.Projects;
public interface IProject :IEntity
{
  Guid Id { get; set; }
  ProjectName Name { get; set; }

}
