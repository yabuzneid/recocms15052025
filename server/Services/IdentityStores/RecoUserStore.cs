using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecoCms6.Data;
using RecoCms6.Models;

namespace RecoCms6.Services.IdentityStores;

public class RecoUserStore(IDbContextFactory<ApplicationIdentityDbContext> dbContextFactory) 
    : UserStore<ApplicationUser, IdentityRole, ApplicationIdentityDbContext>(dbContextFactory.CreateDbContext())
{
    public override ApplicationIdentityDbContext Context => dbContextFactory.CreateDbContext();

    public override async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken = new CancellationToken())
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var context = Context;
        var userId = user.Id;
        var query = from userRole in context.Set<IdentityUserRole<string>>()
            join role in context.Set<IdentityRole>() on userRole.RoleId equals role.Id
            where userRole.UserId.Equals(userId)
            select role.Name;
        return await query.ToListAsync(cancellationToken);
    }

    public override async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = new CancellationToken())
    {
        var context = Context;
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        context.Add(user);
        if (AutoSaveChanges)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        return IdentityResult.Success;
    }

    public override async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var context = Context;
        context.Attach(user);
        user.ConcurrencyStamp = Guid.NewGuid().ToString();
        context.Update(user);
        try
        {
            if (AutoSaveChanges)
            {
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(ErrorDescriber.ConcurrencyFailure());
        }
        return IdentityResult.Success;
    }

    public override async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var context = Context;
        context.Remove(user);
        try
        {
            if (AutoSaveChanges)
            {
                await context.SaveChangesAsync(cancellationToken);
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            return IdentityResult.Failed(ErrorDescriber.ConcurrencyFailure());
        }
        return IdentityResult.Success;
    }

    protected override async Task AddUserTokenAsync(IdentityUserToken<string> token)
    {
        var context = Context;
        context.UserTokens.Add(token);
        await context.SaveChangesAsync();
    }

    public override async Task AddToRoleAsync(ApplicationUser user, string normalizedRoleName,
        CancellationToken cancellationToken = new())
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(user);
        if (string.IsNullOrWhiteSpace(normalizedRoleName))
        {
            throw new ArgumentException("ValueCannotBeNullOrEmpty", nameof(normalizedRoleName));
        }

        var context = Context;

        var roleEntity = await FindRoleAsync(normalizedRoleName, cancellationToken);
        if (roleEntity == null)
        {
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "RoleNotFound", normalizedRoleName));
        }
        context.UserRoles.Add(CreateUserRole(user, roleEntity));
        await context.SaveChangesAsync(cancellationToken);
    }

    public override async Task RemoveFromRoleAsync(ApplicationUser user, string normalizedRoleName,
        CancellationToken cancellationToken = new())
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(user);
        if (string.IsNullOrWhiteSpace(normalizedRoleName))
        {
            throw new ArgumentException("ValueCannotBeNullOrEmpty", nameof(normalizedRoleName));
        }

        var context = Context;

        var roleEntity = await FindRoleAsync(normalizedRoleName, cancellationToken);
        if (roleEntity != null)
        {
            var userRole = await FindUserRoleAsync(user.Id, roleEntity.Id, cancellationToken);
            if (userRole != null)
            {
                context.UserRoles.Remove(userRole);
            }
        }
        await context.SaveChangesAsync(cancellationToken);
    }
}