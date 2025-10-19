using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController(IPictureService pictureService) : ControllerBase
{

}