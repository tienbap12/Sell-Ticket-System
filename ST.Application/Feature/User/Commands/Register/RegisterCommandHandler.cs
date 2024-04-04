using ST.Application.Commons.Abstractions;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Domain.Repositories;

namespace ST.Application.Feature.User.Commands.Register
{
    internal class RegisterCommandHandler : ICommandHandler<RegisterCommand, Response>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _accountRepository.GetByUserName(request.Request.Username);

            if (existingUser != null)
            {
                return Response.Failure("Username already exists");
            }

            var (hashedPassword, salt) =  _passwordHasher.HashPassword(request.Request.Password);

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

            await _accountRepository.CreateAsync(newUser);

            return Response.Success("User registered successfully");
        }
    }
}