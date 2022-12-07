using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendCase.DataAccess
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private bool disposed = false;
        private DataContext _connection;
        public DataContext Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public UnitOfWork(bool inTransaction = false)
        {
            _connection = new DataContext();

            if (inTransaction)
            {
                _connection.BeginTransaction();
            }
        }

        public void BeginTransaction()
        {
            _connection.BeginTransaction();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _connection.CommitTransaction();
            _connection.Dispose();
        }

        public void UndoChange()
        {
            _connection.RollbackTransaction();
            _connection.Dispose();
        }

        public void SaveChangesAsync()
        {
            _connection.CommitTransactionAsync();
            _connection.DisposeAsync();
        }

        public void UndoChangeAsync()
        {
            _connection.RollbackTransactionAsync();
            _connection.DisposeAsync();
        }

    }
}
