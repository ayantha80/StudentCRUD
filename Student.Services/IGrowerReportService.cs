using Student.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Student.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Student reports list end point
        /// </summary>
        /// <returns>list all records</returns>
        Task<List<StudentDTO>> List();

        /// <summary>
        /// Select Student record
        /// </summary>
        /// <param name="id">primary key of the record</param>
        /// <returns></returns>
        Task<StudentDTO> Select(int id);

        /// <summary>
        /// Add a Student report
        /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully added record</returns>
        Task<StudentDTO> Add(StudentDTO oStudentDTO);

        /// <summary>
        /// Edit a Student report
        /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully edited record</returns>
        Task<StudentDTO> Edit(StudentDTO oStudentDTO);

        /// <summary>
        /// Delete a Student report
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status</returns>
        Task<bool> Delete(int id);

    }
}
