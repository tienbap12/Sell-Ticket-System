using Microsoft.EntityFrameworkCore;
using ST.Application.Commons.Abstractions;
using ST.Application.Wrappers;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Data;
using ST.Domain.Entities;

namespace ST.Application.Feature.User.Commands.Register;

internal class RegisterCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher) : ICommandHandler<RegisterCommand, Response>
{
    public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userRepo = unitOfWork.GetRepository<Account>();
        var existingUser = await userRepo.BuildQuery.Where(x => x.Email == request.Request.Email).FirstOrDefaultAsync(cancellationToken);

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

        await userRepo.CreateAsync(newUser);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Response.Success("User registered successfully!!!");
    }
}