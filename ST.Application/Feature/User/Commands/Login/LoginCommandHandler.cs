using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Domain.Repositories;

namespace ST.Application.Feature.User.Commands.Login
{
    internal class LoginCommandHandler : ICommandHandler<LoginCommand, Response<AuthResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<Response<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetByUserName(request.Username);
            if (user == null)
            {
                return Response.Fail<AuthResponse>("Khong tim thay ten nguoi dung");
            }

        }
    }
}
