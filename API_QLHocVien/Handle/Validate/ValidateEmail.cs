﻿using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace API_QLHocVien.Handle.Validate
{
    public class ValidateEmail
    {
        public static bool isValidEmail(string email)
        {
            var emailValidation = new EmailAddressAttribute();
            return emailValidation.IsValid(email);
        }
    }
}
