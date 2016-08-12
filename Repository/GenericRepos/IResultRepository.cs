using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepos
{
    public interface IResultRepository : IRepository<results>
    {
        List<MatchData> GetAllMatches(); // team1+team2+goal1+goal2
        List<GlobalResults> GetAllResults(); // teamname + numberOfWins
    }
}
