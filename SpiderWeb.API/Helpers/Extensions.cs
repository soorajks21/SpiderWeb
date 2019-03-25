using System;
using Microsoft.AspNetCore.Http;

namespace SpiderWeb.API.Helpers
{
    public static class Extensions
    {

        public static void AddApplicationError(this HttpResponse response, string mesage){
            response.Headers.Add("Application-Error", mesage);
            response.Headers.Add("Access-control-Expose-Headers","Applicaton-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }


        public static int CalculateAge(this DateTime theDateTime){
            var age = DateTime.Today.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today)
             age--;
           
         return age;
        }
    }
}