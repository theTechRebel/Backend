using Backend.Services.Builder;
using Backend.Services.Decorator.Concrete;
using Backend.Services.Factory;
using Backend.Services.Prototype;
using Backend.Services.Singleton;
using Backend.Services.State;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    //[Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DesignPatterns : ControllerBase
    {

        [HttpGet]
        [Route("get")]
        public ActionResult<string> Get()
        {
            //Singleton
            //var singleton = new Singleton();
            var singleInstance = Singleton.getInstance();
            var anotherOne = Singleton.getInstance();

            //Builder pattern
            StringCarBuilder jsonCarBuilder = new StringCarBuilder();
            CarDirector director = new CarDirector();
            director.ConstructBlackToyotaHatch(jsonCarBuilder);
            var result = jsonCarBuilder.Build();


            //Prototype
            var shapeMaker = new Shape();
            var shape1 = shapeMaker.GetShape();
            var shape2 = shape1.Clone();

            //Factory pattern
            var format1 = FormatFactory.Create("1");
            var format2 = FormatFactory.Create("07/07/2023");
            var format3 = FormatFactory.Create("Hello!");

            //Decorator pattern
            EmailBaseDecorator email = new EmailGreeting("Jonathan")
            {
                AddedState = new EmailBody("Hello World")
                {
                    AddedState = new EmailRegards("The Sender") { }
                }
            };

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
