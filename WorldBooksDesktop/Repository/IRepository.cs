using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBooksDesktop.Utils;

namespace WorldBooksDesktop.Repository
{
    internal interface IRepository
    {
        Response Get();
        Response GetById(int id);
        Response Create(object obj);
        Response Update(object obj);
        Response Delete(int id);
    }
}
