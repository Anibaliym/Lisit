using App.Domain.Core.Messaging;
using App.Domain.Interfaces;

namespace App.Domain.Commands.Region.Handlers
{
    public partial class RegionCommandHandler : CommandHandler
    {
        private readonly IRegionRepository _regionRepository;

        public RegionCommandHandler(IRegionRepository accionRepository)
        {
            _regionRepository= accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}
