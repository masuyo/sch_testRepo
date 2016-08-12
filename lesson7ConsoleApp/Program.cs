using Entities;
using System.Data.SqlClient;
// efölöttit én adtam hozzá
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.GenericRepos;

namespace lesson7ConsoleApp
{
    //mán egyszer commitótam, ez a második
    class Program
    {
        static string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Kurzus\14\lesson7ConsoleApp\Entities\lesson7_nhl_create.mdf;Integrated Security=True";
        static ITeamRepository teamRepo;
        static IResultRepository resultRepo;

        static void InitRepos()
        {
            nhlEntities nhl = new nhlEntities();
            teamRepo = new TeamRepository(nhl);
            resultRepo = new ResultRepository(nhl);
        }

        static void Main(string[] args)
        {
            InitRepos();
            foreach (var akt in teamRepo.GetAll())
            {
                Console.WriteLine("{0} = {1}",akt.team_id,akt.team_name);
            }
            teams Detroit = new teams();
            Detroit.team_name = "Detroit Red Wings";
            teamRepo.Insert(Detroit);

            foreach (var akt in teamRepo.GetAll())
            {
                Console.WriteLine("{0} = {1}", akt.team_id, akt.team_name);
            }

            //foreach (var akt in resultRepo.GetAllResults())
            //{
            //    Console.WriteLine("{0} = {1}", akt.TeamName, akt.NumberOfWins);
            //}

           Console.ReadLine();
        }


	}
}
