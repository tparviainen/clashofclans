using ClashOfClans.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace ClashOfClans.Blazor.Pages
{
    public partial class ClashClans : ComponentBase
    {
        private string? _clanTag;
        private Clan? _clan;
        private ClanMemberList? _clanMemberList;

        [Inject]
        protected IClans Clans { get; set; } = default!;

        [Parameter]
        public string? ClanTag { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (_clanTag != ClanTag)
            {
                _clanTag = ClanTag;

                _clan = default;
                _clanMemberList = default;

                _clan = await Clans.GetClanAsync($"#{_clanTag}");
                _clanMemberList = (ClanMemberList)await Clans.GetClanMembersAsync($"#{_clanTag}");
            }
        }

        private static string DonationRatio(ClanMember member)
        {
            if (member.DonationsReceived == 0)
            {
                return string.Empty;
            }
            else
            {
                return $"{member.Donations / (float)member.DonationsReceived:0.00}";
            }
        }

        private static string GetRoleDecorations(Role role)
        {
            return role switch
            {
                Role.CoLeader => "font-weight-bold text-warning",
                Role.Leader => "font-weight-bold text-danger",
                _ => "",
            };
        }

        private static string[] Split(string? text)
        {
            return text?.Split("\n") ?? Array.Empty<string>();
        }
    }
}
