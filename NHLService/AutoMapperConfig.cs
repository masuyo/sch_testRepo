using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository;


namespace NHLService
{
    class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.CreateMap<Repository.GenericRepos.MatchData, NHLService.MatchData>();
            Mapper.CreateMap<Repository.GenericRepos.GlobalResults, NHLService.GlobalResults>();

            //.ForMember(dest => dest.TeamName, opt => opt.Ignore())
            //.ForMember(dest => dest.NumberOfWins
        }
    }
}
