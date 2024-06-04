using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBetting.DAL.Services.IDataService
{
    public interface IGenericClass
    {
        Task<IEnumerable<T>> LoadData<T, U>(string SP,U parameters);
        Task SaveData<T>(string SP, T parameters);

    }
}
