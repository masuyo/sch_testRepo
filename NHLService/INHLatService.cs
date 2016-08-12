using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NHLService
{
    //commithoz
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INHLStatService
    {
        [OperationContract]
        List<MatchData> GetAllMatches();

        [OperationContract]
        List<GlobalResults> GetAllResults();

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "NHLService.ContractType".

    // DTO - Data Transfer Object
    [DataContract]
    public class GlobalResults
    {
        [DataMember]
        public string TeamName { get; set; }
        [DataMember]
        public int NumberOfWins { get; set; }
    }

    [DataContract]
    public class MatchData
    {
        [DataMember]
        public int Goal1 { get; internal set; }
        [DataMember]
        public int Goal2 { get; internal set; }
        [DataMember]
        public string Team1 { get; internal set; }
        [DataMember]
        public string Team2 { get; internal set; }
    }
}
