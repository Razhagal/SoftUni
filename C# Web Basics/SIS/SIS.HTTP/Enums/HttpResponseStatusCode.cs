﻿namespace SIS.HTTP.Enums
{
    public enum HttpResponseStatusCode
    {
        // Currently only those required. Can add more if needed in future updates
        Ok = 200,
        Created = 201,
        Found = 302,
        SeeOther = 303,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
