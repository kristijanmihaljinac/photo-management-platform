﻿using PhotoManagementPlatform.Application.Package.Repositories;
using PhotoManagementPlatform.Persistence;
using Microsoft.EntityFrameworkCore;
using PhotoManagementPlatform.Application.Package.UseCases.OverviewPackage;

namespace PhotoManagementPlatform.Infrastructure.Repositories.Package;

public class PackageReadOnlyRepository : IPackageReadOnlyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PackageReadOnlyRepository(ApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Domain.Package.Package?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbContext.Set<Domain.Package.Package>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


    public async Task<List<OverviewPackageDto>> OverviewAsync(CancellationToken cancellationToken) =>
        await _dbContext.Set<Domain.Package.Package>().Select(x => new OverviewPackageDto(x.Id, x.Code, x.Name)).ToListAsync(cancellationToken);
    
}