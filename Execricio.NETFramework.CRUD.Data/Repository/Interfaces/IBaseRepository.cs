using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execricio.NETFramework.CRUD.Data.Repository.Interfaces
{
    internal interface IBaseRepository
    {
        IDbConnection GetConnection(bool open = true);
        bool GetStatusConnection();
    }
}
