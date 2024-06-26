﻿using AutoMapper;
using ST.Application.Commons.Abstractions;
using ST.Application.Feature.Tickets.Command.UpdateTicket;
using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Commons.Abstractions;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.User.Command.Login
{
    internal class LoginCommandHandler(IAccountRepository accountRepository,
                    IMapper mapper,
                    IJwtProvider jwtProvider,
                    IPasswordHashChecker passwordHashChecker,
                    ITokenRepository tokenRepository)
                    : ICommandHandler<LoginCommand, Response<AuthResponse>>
    {
        public async Task<Response<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await accountRepository.GetByUserName(request.Request.userName);
            if (user == null)
            {
                return Response<AuthResponse>.NotFoundUserName(request.Request.userName);
            }
            var isValidPass = passwordHashChecker.HashesMatch(request.Request.Password, user);
            if (!isValidPass)
            {
                return Response<AuthResponse>.Failure("Invalid Password");
            }
            var roleUser = await accountRepository.GetRoleUser(user.RoleId);
            var token = jwtProvider.Generate(new Account
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
            tokenRepository.CreateAsync(new RefreshToken
            {
            });
            var result = new AuthResponse
            {
                token = token,
                Role = roleUser,
            };
            return Response<AuthResponse>.Success("Login successfully!!!", result);
        }

        public Task<Response> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}