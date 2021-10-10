using ClashOfClans.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ClashOfClans.Blazor.Pages
{
    public partial class ClashPlayer : ComponentBase
    {
        private Player? _player;

        [Inject]
        protected IPlayers Players { get; set; } = default!;

        [Parameter]
        public string? PlayerTag { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            _player = default;
            _player = await Players.GetPlayerAsync($"#{PlayerTag}");
        }
    }
}
