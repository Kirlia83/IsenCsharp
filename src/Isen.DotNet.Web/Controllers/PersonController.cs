using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Web.Models;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.Web.Controllers
{
    public class PersonController : BaseController<Person, IPersonRepository>
    {
        public PersonController(IPersonRepository repository) : base(repository)
        {
        }
    }
}