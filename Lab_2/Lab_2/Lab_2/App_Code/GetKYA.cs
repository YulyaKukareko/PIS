﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_2.App_Code
{
    public class GetKYA : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;

            response.Write("GET-Http-XYZ:ParmA = " + context.Request["ParamA"] + " ParmB = " + context.Request["ParamB"] + " browser version: " + context.Request.Browser + " user agent: " + HttpContext.Current.Request.UserAgent);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}