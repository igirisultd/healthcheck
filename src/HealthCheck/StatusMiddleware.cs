﻿using System.Threading.Tasks;

using Microsoft.Owin;

namespace HealthCheck.Controllers
{
    public class StatusMiddleware : OwinMiddleware
    {
        public StatusMiddleware(OwinMiddleware next) 
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (context.Request.Uri.AbsoluteUri.EndsWith("/status"))
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Hello!");
                return;
            }

            await Next.Invoke(context);
        }
    }
}
