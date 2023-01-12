using Student.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.Repositories
{
    public interface IStudentRepository
    {
        /// <summary>
        /// List all records
        /// </summary>
        /// <returns></returns>
        Task<List<Student.Entities.Models.Student>> List();

        /// <summary>
        /// Select a record
        /// </summary>
        Task<Student.Entities.Models.Student> Select(int id);

        /// <summary>
        /// Add a record
        /// </summary>
        Task Add(Student.Entities.Models.Student Student);

        /// <summary>
        /// Edit a record
        /// </summary>
        void Edit(Student.Entities.Models.Student Student);

        /// <summary>
        /// Delete a record
        /// </summary>
        void Delete(Student.Entities.Models.Student Student);
    }
}
