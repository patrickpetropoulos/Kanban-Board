using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Kanban.Server.Domain.Abstractions;
public interface IEntity
{
  void PutJson(JObject json);
  JObject GetJson();
}
