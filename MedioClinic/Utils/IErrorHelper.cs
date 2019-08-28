using System;
using System.Web;
using System.Web.Mvc;

namespace MedioClinic.Utils
{
    public interface IErrorHelper
    {
        int UnprocessableStatusCode { get;  }

        void CheckEditMode(HttpContextBase httpContext, string source);

        HttpStatusCodeResult HandleException(string source, string eventCode, Exception exception, int statusCode = 500);

        void LogException(string source, string eventCode, Exception exception);
    }
}