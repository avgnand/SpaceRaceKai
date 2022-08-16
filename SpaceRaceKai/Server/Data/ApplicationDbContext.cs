using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SpaceRaceKai.Server.Models;

namespace SpaceRaceKai.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Colony> Colonies { get; set; }
        public DbSet<PlanetType> PlanetTypes { get; set; }
        public DbSet<EventEffect> EventEffects { get; set; }
        public DbSet<WorldEvent> WorldEvents { get; set; }
        public DbSet<DecisionEvent> DecisionEvents { get; set; }
    }
}