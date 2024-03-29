﻿using System.Collections.Generic;

namespace ClashOfClans.Models
{
    public class ClanMember : Identity
    {
        private Role? _role;
        private int? _expLevel;
        private int? _townHallLevel;
        private int? _trophies;
        private int? _builderBaseTrophies;
        private int? _clanRank;
        private int? _previousClanRank;
        private int? _donations;
        private int? _donationsReceived;

        public Role Role { get => _role ?? default; set => _role = value; }

        public int TownHallLevel { get => _townHallLevel ?? default; set => _townHallLevel = value; }

        public int ExpLevel { get => _expLevel ?? default; set => _expLevel = value; }

        public League League { get; set; } = default!;

        public int Trophies { get => _trophies ?? default; set => _trophies = value; }

        public int BuilderBaseTrophies { get => _builderBaseTrophies ?? default; set => _builderBaseTrophies = value; }

        public int ClanRank { get => _clanRank ?? default; set => _clanRank = value; }

        public int PreviousClanRank { get => _previousClanRank ?? default; set => _previousClanRank = value; }

        public int Donations { get => _donations ?? default; set => _donations = value; }

        public int DonationsReceived { get => _donationsReceived ?? default; set => _donationsReceived = value; }

        public PlayerHouse? PlayerHouse { get; set; }

        public BuilderBaseLeague? BuilderBaseLeague { get; set; }
    }
}
