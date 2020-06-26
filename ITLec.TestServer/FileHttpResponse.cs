using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeServer
{
    public class FileHttpResponse : HttpResponse
    {
        private readonly string path;
        HeaderDictionary _customHeader = new HeaderDictionary();
        public FileHttpResponse(AwesomeHttpContext httpContext, string path)
        {
            this.HttpContext = httpContext;
            
            this.path = path;
        }
        public override HttpContext HttpContext { get; }
        public override int StatusCode { get; set; }

        public override IHeaderDictionary Headers
        {
            get
            {
                return _customHeader;
            }
        }
        public override Stream Body { get; set; } = new MemoryStream();
        public override long? ContentLength { get; set; }
        public override string ContentType { get; set; }
        public override IResponseCookies Cookies => throw new NotImplementedException();
        public override bool HasStarted => true;

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
            var reader = new StreamReader(Body);
        //    {
                Body.Position = 0;
                var text = reader.ReadToEnd();
                File.WriteAllText(path, $"{this.StatusCode} - {text}");
                Body.Flush();
                //Body.Dispose();
              //  reader.Dispose();
         //   }
        }

        public override void OnStarting(Func<object, Task> callback, object state) {
            callback.Invoke(state);
        }
        public override void Redirect(string location, bool permanent) { }
    }


}
