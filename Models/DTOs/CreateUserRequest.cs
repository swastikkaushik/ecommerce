using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
}