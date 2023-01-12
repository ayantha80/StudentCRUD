using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Student.Entities.Models;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Student.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        /// <summary>
        /// Initalize StudentRepository class
        /// </summary>
        /// <param name="context">dabase context</param>
        public StudentRepository(StudentContext context)
        {
            this.Context = context;
        }

        private StudentContext Context { get; }

        /// <summary>
        /// List all records
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student.Entities.Models.Student>> List()
        {
            return await this.Context.Students.ToListAsync();
        }


        /// <summary>
        /// Select a record
        /// </summary>
        public async Task<Student.Entities.Models.Student> Select(int id)
        {
            return await this.Context.Students.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        /// <summary>
        /// Add a record
        /// </summary>       
        public async Task Add(Student.Entities.Models.Student Student)
        {
            await this.Context.Students.AddAsync(Student);            
        }


        /// <summary>
        /// Edit a record
        /// </summary>
        public void Edit(Student.Entities.Models.Student Student)
        {
             this.Context.Students.Attach(Student);
            
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public  void Delete(Student.Entities.Models.Student Student)
        {
            this.Context.Students.Remove(Student);
        }
    }
}
