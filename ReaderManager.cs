using Manager.Services;
using static Models.ReaderModel;

namespace Manager
{
    public class ReaderManager : IReaderService
    {
        //Temporary data for testing before database connections
        private readonly List<Reader> _reader = new List<Reader>
        {
            new Reader { Id = 1, FirstName = "John", LastName = "Doe", UserName = "Johnny" },
            new Reader { Id = 2, FirstName = "Jane", LastName = "Smith", UserName = "JaneSus" }
        };

        //Function that displays all students within the list
        public IEnumerable<Reader> GetAllReader()
        {
            return _reader;
        }
        //Function to display the details of the student if there is a matching Id
        public Reader GetReaderById(int id)
        {
            return _reader.FirstOrDefault(s => s.Id == id);
        }
        //Function that displays adds a students to the list
        public void AddReader(Reader reader)
        {
            reader.Id = _reader.Max(s => s.Id) + 1;
            _reader.Add(reader);
        }
        //Function that update a student's information if it exists
        public void UpdateReader(int id, Reader reader)
        {
            var existingReader = _reader.FirstOrDefault(s => s.Id == id);
            if (existingReader != null)
            {
                existingReader.FirstName = reader.FirstName;
                existingReader.LastName = reader.LastName;
                existingReader.UserName = reader.UserName;
            }
        }
        //Function that deletes a student from the list
        public void DeleteReader(int id)
        {
            var reader = _reader.FirstOrDefault(s => s.Id == id);
            if (reader != null)
            {
                _reader.Remove(reader);
            }
        }
    }
}