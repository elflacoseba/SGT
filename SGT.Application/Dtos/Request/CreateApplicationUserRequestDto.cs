﻿namespace SGT.Application.Dtos.Request
{
    public class CreateApplicationUserRequestDto
    {      
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
