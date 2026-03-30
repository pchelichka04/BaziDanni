using System.Data;

namespace BaziDanni_k.p_.Repositories.Common;

public interface IRepository
{
    DataTable GetAll();
    void Insert(Dictionary<string, object?> values);
    void Update(Dictionary<string, object?> values);
    void Delete(object key);
}
