using TrattoriApi.Models;

namespace TrattoriApi.Services
{
    public interface ITrattoriService
    {
        public Trattore AddTrattore(SimpleTrattore trattore);
        public IList<Trattore> GetAll();
        public Trattore GetById(int idTrattore);
        public IList<Trattore> GetByFilter(string color);
        public Trattore Put(SimpleTrattore trattore, int idTrattore);
        public IList<Trattore> Delete(int idTrattore);   

    }
}
