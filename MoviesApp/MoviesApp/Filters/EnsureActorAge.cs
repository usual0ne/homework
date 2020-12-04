using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class EnsureActorAge : Attribute, IActionFilter
    {
        public EnsureActorAge(int smallestAge, int biggestAge)
        {
            SmallestAge = smallestAge;
            BiggestAge = biggestAge;
        }

        public int SmallestAge { get; }
        public int BiggestAge { get; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var BirthDate = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]);
            int age = DateTime.Now.Year - BirthDate.Year;
            if (age < SmallestAge | age > BiggestAge)
            {
                context.Result = new BadRequestResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        
    }
}
