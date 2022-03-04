using CreateExam.Core.Enums;
using System;

namespace CreateExam.Application.Models.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
    }
}