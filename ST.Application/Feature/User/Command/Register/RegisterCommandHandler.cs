using ST.Application.Commons.Abstractions;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Domain.Repositories;

namespace ST.Application.Feature.User.Command.Register
{
    internal class RegisterCommandHandler(IAccountRepository accountRepository, IPasswordHasher passwordHasher) : ICommandHandler<RegisterCommand, Response>
    {
        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await accountRepository.GetByUserName(request.Request.Username);

            if (existingUser != null)
            {
                return Response.Failure("Username already exists");
            }

            var (hashedPassword, salt) = passwordHasher.HashPassword(request.Request.Password);

            var newUser = new Domain.Entities.Account
            {
                Username = request.Request.Username,
                Password = hashedPassword,
                Salt = salt,
                Email = request.Request.Email,
                FullName = request.Request.FullName,
                Phone = request.Request.Phone,
                RoleId = request.Request.RoleId,
                DoB = request.Request.DoB,
            };

            await accountRepository.CreateAsync(newUser);

            return Response.Success("User registered successfully!!!");
        }
    }
}