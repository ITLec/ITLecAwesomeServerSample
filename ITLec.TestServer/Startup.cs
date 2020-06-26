using ITLec.TestServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AwesomeServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.RegisterTimerMiddleware();

            app.MapWhen(c => c.Request.Path == "/foo/bar", config =>
            {
                config.Run(async (context) =>
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello World!");
                });
            })
                .MapWhen(c => c.Request.Path == "/ITLec/Rasheed", config =>
            {
                config.Run(async (context) =>
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello Rasheed!");


                    //string test = "Hello Rasheed!";

                    //// convert string to stream
                    //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(test);
                    // context.Response.Body= new System.IO.MemoryStream(byteArray);

                });
            })
            .Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found");
            });


        }
    }
}
