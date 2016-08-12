using AutoMapper;
using Entities;
using Repository.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NHLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)] //egy példány jön létre mindig
    public class NHLStatService : INHLStatService
    {
        IResultRepository repo;

        public NHLStatService()
        {
            AutoMapperConfig.Init();
            nhlEntities nhl = new nhlEntities();
            repo = new ResultRepository(nhl);
        }
        public List<MatchData> GetAllMatches()
        {
            return repo.GetAllMatches().Select(x => Mapper.Map<Repository.GenericRepos.MatchData, NHLService.MatchData>(x)).ToList();
        }

        public List<GlobalResults> GetAllResults()
        {
            return repo.GetAllResults().Select(x => Mapper.Map<Repository.GenericRepos.GlobalResults, NHLService.GlobalResults>(x)).ToList();
        }
    }
}
