﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Service
{
    public class Services : IServices
    {
        private readonly IHttpContextAccessor _httpContext;

        public Services(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
