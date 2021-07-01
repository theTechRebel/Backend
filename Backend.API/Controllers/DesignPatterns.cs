using Backend.Services.Builder;
using Backend.Services.Decorator.Concrete;
using Backend.Services.Decorator.Interfaces;
using Backend.Services.State;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Backend.API.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DesignPatterns : ControllerBase
    {

        [System.Web.Http.HttpGet]
        [Route("get")]
        public ActionResult<string> Get()
        {
            //Decorator pattern
            EmailBaseDecorator email = new EmailGreeting("Jonathan")
            {
                AddedState = new EmailBody("Hello World")
                {
                    AddedState = new EmailRegards("The Sender") { }
                }
            };

            //Builder pattern
            StringCarBuilder jsonCarBuilder = new StringCarBuilder();
            CarDirector director = new CarDirector();
            director.ConstructBlackToyotaHatch(jsonCarBuilder);
            jsonCarBuilder.Build();

            //State pattern
            ColorContext context = new ColorContext();
            IColorState state = new InitialColorState("");

            while (state._color != "none")
            {
                state = context.handleColorChange(state._color);
            }



            return Ok(email.GetDecoratedBody());
        }
    }
}
