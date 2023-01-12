using Student.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private IStudentRepository _StudentRepository = null;
        private bool disposedValue = false;
        private StudentContext _context = null;


        public UnitOfWork(StudentContext context)
        {
            this._context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                try
                {

                    return _StudentRepository = _StudentRepository ?? new StudentRepository(_context);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // NLogger<UnitOfWork>.Error(Constants.ExceptionPolicy.DataAccess, ex);
                throw ex;
            }
        }

        #region IDisposable support
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this._context == null)
            {
                return;
            }

            this._context.Dispose();
            this._context = null;
        } 
        #endregion
    }
}
