using System;
using System.Collections.Generic; 
using System.IO; 
using System.Linq; 
using System.Reflection; 
using System.Text; 
using System.Threading.Tasks; 
using System.Web; 
using System.Web.SessionState; 

 
 namespace CampusCourier.Tests
 { 
     public class MockHelper
     { 
         public static HttpContext FakeHttpContext() //http mockup from stackoverflow user Milox 
         { 
             var httpRequest = new HttpRequest("", "http://stackoverflow/", ""); 
             var stringWriter = new StringWriter(); 
             var httpResponse = new HttpResponse(stringWriter); 
             var httpContext = new HttpContext(httpRequest, httpResponse);  
 
             var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                     new HttpStaticObjectsCollection(), 10, true,
                                                     HttpCookieMode.AutoDetect,
                                                     SessionStateMode.InProc, false); 
 
 
             httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor( 
                                         BindingFlags.NonPublic | BindingFlags.Instance,
                                         null, CallingConventions.Standard,
                                       new[] { typeof(HttpSessionStateContainer) }, 
                                         null) 
                                 .Invoke(new object[] { sessionContainer }); 
 
 
             return httpContext; 
        } 
     } 
 } 
