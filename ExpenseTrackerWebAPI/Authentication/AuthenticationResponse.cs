using AutoMapper.Execution;
using System.ComponentModel.DataAnnotations;
using ExpenseTrackerWebAPI.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace ExpenseTrackerWebAPI.Authentication
{
    public class AuthenticationResponse
    {
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(Users user, string token)
        {
            IdUser = user.IdUser;
            Username = user.Username;
            Token = token;
        }
    }
}
