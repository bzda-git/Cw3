using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students = new List<Student>
        {
            new Student{idStudent=1, firstName="Jan", lastName="Kowalski", indexNumber="s1234"},
            new Student{idStudent=2, firstName="Anna", lastName="Malewski", indexNumber="s2342"},
            new Student{idStudent=3, firstName="Krzysztof", lastName="Andrzejewicz", indexNumber="s5432"}
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }

  
}
