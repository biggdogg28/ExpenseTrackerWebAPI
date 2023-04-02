using AutoMapper.Execution;
using System.ComponentModel.DataAnnotations;
using ExpenseTrackerWebAPI.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace ExpenseTrackerWebAPI.Authentication
{
    public class AuthenticationResponse
    {
        public Guid IdLocation { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(Location user, string token)
        {
            IdLocation = user.IdLocation;
            Name = user.Name;
            Token = token;
        }
    }
}
