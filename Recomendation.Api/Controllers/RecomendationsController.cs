using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recomendation.Domain.Interfaces;
using Recomendation.Domain.Models;

namespace Recomendation.Api.Controllers
{
    [Route("api/recomendations")]
    [ApiController]
    public class RecomendationsController : ControllerBase
    {
    }
}
