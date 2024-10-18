using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.ReaderModel;

namespace Manager.Services
{
    public interface IReaderService
    {
        IEnumerable<Reader> GetAllReader();
        Reader GetReaderById(int id);
        void AddReader(Reader reader);
        void UpdateReader(int id, Reader reader);
        void DeleteReader(int id);
    }
}