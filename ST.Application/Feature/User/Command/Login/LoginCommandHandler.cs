using AutoMapper;
using ST.Application.Commons.Abstractions;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Domain.Commons;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.User.Command.Login
{
    internal class LoginCommandHandler : ICommandHandler<LoginCommand, Response<AuthResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHashChecker _passwordHashChecker;

        public LoginCommandHandler(IAccountRepository accountRepository, IMapper mapper, IJwtProvider jwtProvider, IPasswordHashChecker passwordHashChecker)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
            _passwordHashChecker = passwordHashChecker;
        }
        public async Task<Response<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetByUserName(request.Request.userName);
            if (user == null)
            {
                return Response<AuthResponse>.NotFoundUserName( request.Request.userName);
            }
            var isValidPass = _passwordHashChecker.HashesMatch(request.Request.Password, user);
            if (!isValidPass)
            {
                return Response<AuthResponse>.Failure("Invalid Password");
            }
            var roleUser = await _accountRepository.GetRoleUser(user.RoleId);
            var token = _jwtProvider.Generate(new Account
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                DoB = user.DoB,
                RoleId = user.RoleId,
                Phone = user.Phone, 
                Roles = new Role
                {
                    Id = user.RoleId,
                    Name = roleUser
                }
            });
            var result = new AuthResponse
            {
                token = token,
                Role = roleUser,
            };
            return Response<AuthResponse>.Success("Login successfully!!!", result);
        }
    }
}
