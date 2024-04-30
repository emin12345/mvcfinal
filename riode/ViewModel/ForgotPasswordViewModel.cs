﻿using System.ComponentModel.DataAnnotations;

namespace riode.ViewModel;

public class ForgotPasswordViewModel
{
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
