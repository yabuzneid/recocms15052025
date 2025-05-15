using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecoCms6.Data;

namespace RecoCms6.Services.IdentityStores;

public class RecoRoleStore(IDbContextFactory<ApplicationIdentityDbContext> dbContextFactory)
    : RoleStore<IdentityRole, ApplicationIdentityDbContext>(dbContextFactory.CreateDbContext())
{
    public override ApplicationIdentityDbContext Context => dbContextFactory.CreateDbContext();

    public override async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken = new CancellationToken())
    {
        cancellationToken.ThrowIfCancellationRequested();
        ThrowIfDisposed();
        ArgumentNullException.ThrowIfNull(role);

        var context = Context;
        context.Add(role);
        if (AutoSaveChanges)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
        return IdentityResult.Success;
    }
    
}