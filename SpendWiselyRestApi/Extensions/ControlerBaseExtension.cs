using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace SpendWiselyRestApi.Extensions
{
    public static class ControllerBaseExtension
    {
        public static Guid GetLoggedUserId(this ControllerBase controller)
        {
            var userIdClaim = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Guid.Parse(userIdClaim!);
        }
    }
}
