using System.ServiceModel;

namespace BookFairService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookFairService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool Connect(string login, string password);
    }
}
