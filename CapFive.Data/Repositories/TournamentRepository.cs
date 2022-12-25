﻿using CapFive.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CapFive.Data.Repositories
{
    public class TournamentRepository : RepositoryBase, ITournamentRepository
    {
        public TournamentRepository(CapFiveDbContext db) : base(db)
        {
        }

        public void Add(Tournament tournament)
        {
            _db.Tournaments.Add(tournament);
        }

        public async Task<Tournament?> GetTournamentById(int id)
        {
            return await _db.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tournament>> GetTournaments()
        {
            return await _db.Tournaments.ToListAsync();
        }

        public void Update(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}