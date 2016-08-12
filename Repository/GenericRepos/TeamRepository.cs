using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.GenericRepos
{
    public class TeamRepository : GenericEFRepository<teams>, ITeamRepository
    {
        public TeamRepository(DbContext newctx) : base(newctx)
        {
        }

        public override teams GetById(int id)
        {
            return Get(akt => akt.team_id == id).SingleOrDefault();
        }

        public int GetTeamId()
        {
            var rawQuery = context.Database.SqlQuery<int>("select next value for seq_teams");
            return rawQuery.Single();
        }
        public override void Insert(teams newentity)
        {
            newentity.team_id = GetTeamId();
            base.Insert(newentity);
        }
    }
}
