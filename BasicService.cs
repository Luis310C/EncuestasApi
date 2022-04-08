using EncuestasApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncuestasApi
{
    public abstract class BasicService:IDisposable
    {
        protected readonly EncuestasContext _db;
        private bool _disposedValue;
        public BasicService() {
            _db = new EncuestasContext();
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposedValue) {
                if (disposing) {
                    _db.Dispose();
                }
                _disposedValue = true;
            
            }
        }

        public void Dispose() => Dispose(true);
    }
}
