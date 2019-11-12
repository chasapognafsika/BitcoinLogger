using System;
using System.ComponentModel.DataAnnotations;

namespace BitCoinLogger.API.Dtos
{
  public class UserForRegisterDto
  {
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(15,MinimumLength = 4, ErrorMessage = "You must specify password over 4 characters.")]
    public string Password { get; set; }

  }
}