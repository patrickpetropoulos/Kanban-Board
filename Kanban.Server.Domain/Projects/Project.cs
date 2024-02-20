using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanban.Server.Domain.Abstractions;
using Newtonsoft.Json.Linq;

namespace Kanban.Server.Domain.Projects;
public class Project : IProject
{
  public Project(Guid id,ProjectName name)
  {
    Id = id;
    Name = name;
  }

  public Project()
  {

  }

  public Guid Id { get; set; }

  public ProjectName Name { get; set; }



  public void PutJson(JObject json)
  {
    Id = Guid.Parse(JSONUtilities.GetString(json, "id"));
    Name = new ProjectName(JSONUtilities.GetString(json, "name"));
  }

  public JObject GetJson()
  {
    var json = new JObject();
    JSONUtilities.Set(json, "id", Id);
    JSONUtilities.Set(json, "name", Name.Value);

    return json;
  }
}
