using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SpiderWeb.API.Helpers
{
    public static class Extensions
    {

        public static void AddApplicationError(this HttpResponse response, string mesage){
            response.Headers.Add("Application-Error", mesage);
            response.Headers.Add("Access-control-Expose-Headers","Applicaton-Error");
            response.Headers.Add("Access-Control-Allow-Origin","*");
        }


    public static void AddPagination(this HttpResponse response, int currentPage, 
    int itemsPerPage, int totalItems, int totalPages)
    {
        var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
           response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-control-Expose-Headers","Pagination");
    }

        public static int CalculateAge(this DateTime theDateTime){
            var age = DateTime.Today.Year - theDateTime.Year;
            if(theDateTime.AddYears(age) > DateTime.Today)
             age--;
           
         return age;
        }
    }
}