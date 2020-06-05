using ClashOfClans.Search;
using System;
using System.Text.RegularExpressions;

#nullable enable

namespace ClashOfClans.Core
{
    /// <summary>
    /// Automatically validated request.
    /// </summary>
    internal class AutoValidatedRequest
    {
        public Guid CorrelationId { get; } = Guid.NewGuid();

        #region WAR_TAG
        private string? _warTag;

        public string? WarTag
        {
            get => _warTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("War tag must not be empty");

                if (value == Constants.InvalidWarTag)
                    throw new ArgumentException("War tag is not valid");

                _warTag = value;
            }
        }
        #endregion

        #region CLAN_TAG
        private string? _clanTag;

        public string? ClanTag
        {
            get => _clanTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Clan tag must not be empty");

                if (!value.StartsWith(Constants.TagStartChar))
                    throw new ArgumentException($"Clan tags start with hash character '{Constants.TagStartChar}'");

                _clanTag = value;
            }
        }
        #endregion

        #region QUERY
        private Query? _query;

        public Query? Query
        {
            get => _query;

            set
            {
                if (value?.After != null && value?.Before != null)
                    throw new ArgumentException("Only after or before can be specified for a query, not both");

                _query = value;
            }
        }
        #endregion

        #region QUERY_CLANS
        private static readonly Regex _labelIdsRegex = new Regex(@"^\d+(,\d+)*$");

        public QueryClans? QueryClans
        {
            get => (QueryClans?)_query;

            set
            {
                if (value == null)
                    throw new ArgumentException("Query must not be empty");

                if (value.Name != null && value.Name.Length < Constants.MinQueryNameLength)
                    throw new ArgumentException($"Name needs to be at least {Constants.MinQueryNameLength} characters long");

                if (value.LabelIds != null && !_labelIdsRegex.IsMatch(value.LabelIds))
                    throw new ArgumentException($"Invalid format for parameter {nameof(QueryClans.LabelIds)}");

                Query = value;
            }
        }
        #endregion

        #region URI
        private string _uri = default!;

        public string Uri
        {
            get => $"{_uri}{Query}";

            set
            {
#if DEBUG
                if (!value.StartsWith("/"))
                    throw new ArgumentException($"{nameof(Uri)} must start with '/' character");
#endif
                // Hash character '#' needs to be URL-encoded properly to work in URL
                _uri = value.Replace("#", "%23").Substring(1);
            }
        }
        #endregion

        #region PLAYER_TAG
        private string? _playerTag;

        public string? PlayerTag
        {
            get => _playerTag;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Player tag must not be empty");

                if (!value.StartsWith(Constants.TagStartChar))
                    throw new ArgumentException($"Player tags start with hash character '{Constants.TagStartChar}'");

                _playerTag = value;
            }
        }
        #endregion

        #region LEAGUE_ID
        private int? _leagueId;

        public int? LeagueId
        {
            get => _leagueId;

            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("League identifier must not be empty");

                _leagueId = value;
            }
        }
        #endregion

        #region LOCATION_ID
        private int? _locationId;

        public int? LocationId
        {
            get => _locationId;

            set
            {
                if (!value.HasValue)
                    throw new ArgumentException("Location identifier must not be empty");

                _locationId = value;
            }
        }
        #endregion

        #region SEASON_ID
        private string? _seasonId;

        public string? SeasonId
        {
            get => _seasonId;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Season identifier must not be empty");

                _seasonId = value;
            }
        }
        #endregion
    }
}
