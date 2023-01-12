using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Repositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }

        /// <summary>
        /// Save Changes
        /// </summary>
        void Save();
    }
}
