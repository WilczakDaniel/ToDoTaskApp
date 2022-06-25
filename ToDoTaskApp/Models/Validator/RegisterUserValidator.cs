using FluentValidation;
using ToDoTaskApp.Database;

namespace ToDoTaskApp.Models.Validator;

public class RegisterUserValidator:AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator(AppDbContext dbContext)
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).MinimumLength(6);
        RuleFor(x=>x.Email)
            .Custom((value,context)=>
            {
                var emailInuse = dbContext.Users.Any(u => u.Email == value);
                if (emailInuse)
                {
                    context.AddFailure("Email", "Email already in use");
                }
            });
    }
}