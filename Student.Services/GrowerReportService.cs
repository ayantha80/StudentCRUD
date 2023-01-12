using Student.DTO;
using Student.Entities.Models;
using Student.Repositories;
using Student.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _iUnitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _iUnitOfWork = unitOfWork;
        }


        /// <summary>
        /// Student reports list end point
        /// </summary>
        /// <returns>list all records</returns>
        public async Task<List<StudentDTO>> List()
        {
            List<StudentDTO> recordList = new List<StudentDTO>();

            var result = await _iUnitOfWork.StudentRepository.List();

            if (result != null)
            {
                foreach (var record in result)
                {
                    recordList.Add(new StudentDTO()
                    {
                        Address = record.Address,
                        Age = record.Age,
                        City = record.City,
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        State = record.State,
                        Zip = record.Zip,                     

                    });
                }
            }
            return recordList;

        }


        /// <summary>
        /// Select Student record
        /// </summary>
        /// <param name="id">primary key of the record</param>
        /// <returns></returns>
        public async Task<StudentDTO> Select(int id)
        {
            StudentDTO oStudentDTO = new StudentDTO();

            var record = await _iUnitOfWork.StudentRepository.Select(id);

            if (record != null)
            {
                oStudentDTO.Address = record.Address;
                oStudentDTO.Age = record.Age;
                oStudentDTO.City = record.City;
                oStudentDTO.FirstName = record.FirstName;
                oStudentDTO.LastName = record.LastName;
                oStudentDTO.State = record.State;
                oStudentDTO.Zip = record.Zip; 
    }

            return oStudentDTO;

        }


        /// <summary>
        /// Add a Student report
        /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully added record</returns>
        public async Task<StudentDTO> Add(StudentDTO oStudentDTO)
        {
            try
            {
                Student.Entities.Models.Student oStudent = new Student.Entities.Models.Student();               


                oStudent.Address = oStudentDTO.Address;
                oStudent.Age = oStudentDTO.Age;
                oStudent.City = oStudentDTO.City;
                oStudent.FirstName = oStudentDTO.FirstName;
                oStudent.LastName = oStudentDTO.LastName;
                oStudent.State = oStudentDTO.State;
                oStudent.Zip = oStudentDTO.Zip;
                await _iUnitOfWork.StudentRepository.Add(oStudent);
                _iUnitOfWork.Save();

                oStudentDTO.Id = oStudent.Id;

                return oStudentDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Student adding", ex);
            }
        }


        /// <summary>
        /// Edit a Student report
        /// </summary>
        /// <param name="oStudentDTO"></param>
        /// <returns>Successfully edited record</returns>
        public async Task<StudentDTO> Edit(StudentDTO oStudentDTO)
        {
            try
            {
                                                
                var oStudent = await _iUnitOfWork.StudentRepository.Select((int)oStudentDTO.Id);

                oStudent.Address = oStudentDTO.Address;
                oStudent.Age = oStudentDTO.Age;
                oStudent.City = oStudentDTO.City;
                oStudent.FirstName = oStudentDTO.FirstName;
                oStudent.LastName = oStudentDTO.LastName;
                oStudent.State = oStudentDTO.State;
                oStudent.Zip = oStudentDTO.Zip;

                _iUnitOfWork.StudentRepository.Edit(oStudent);
                _iUnitOfWork.Save();

                oStudentDTO.Id = oStudent.Id;

                return oStudentDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Student editing", ex);
            }
        }


        /// <summary>
        /// Delete a Student report
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status</returns>
        public async Task<bool> Delete(int id)
        {
            try
            {
                var record = await _iUnitOfWork.StudentRepository.Select(id);
                _iUnitOfWork.StudentRepository.Delete(record);
                _iUnitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Student deleting", ex);
            }
        }



    }
}
