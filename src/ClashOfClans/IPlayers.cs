﻿using ClashOfClans.Models;
using System.Threading.Tasks;

namespace ClashOfClans
{
    /// <summary>
    /// Interface for player related data
    /// </summary>
    public interface IPlayers
    {
        /// <summary>
        /// Get player information
        /// </summary>
        /// <param name="playerTag">Tag of the player to retrieve</param>
        /// <exception cref="Core.ClashOfClansException">Communication error with the backend API</exception>
        /// <exception cref="System.ArgumentException">Argument is invalid</exception>
        /// <returns>Requested player data</returns>
        Task<PlayerDetail> GetAsync(string playerTag);
    }
}
