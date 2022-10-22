using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using TrattoriApi.Helper;
using TrattoriApi.Models;

namespace TrattoriApi.Services
{
    public class TrattoriServices : ITrattoriService
    {
        private readonly FileHelper _fileHelper = new FileHelper();
        private readonly string _filepath = "Trattori.txt";

        public int IncrementId()
        {
            var trattore= _fileHelper.ReadAndDeserialize(_filepath);
            if (trattore.Count == null)
                return 1;

            return trattore.Max(trattore => trattore.IdTrattori)+1;

        }
        public Trattore Mapping(SimpleTrattore trattore)
        {
            var trattoreMap = new Trattore()
            {
                IdTrattori= IncrementId(),
                Marca=trattore.Marca,
                Modello=trattore.Modello,
                Colore=trattore.Colore

            };
            return  trattoreMap;
        }
        public Trattore AddTrattore(SimpleTrattore trattore)
        {
            var trattoreMap = Mapping(trattore);
            var trattoreList = _fileHelper.ReadAndDeserialize(_filepath);
            trattoreList.Add(trattoreMap);
            _fileHelper.WriteAndSerialize(_filepath, trattoreList);
            return trattoreMap;

        }

        public IList<Trattore> GetAll()=>_fileHelper.ReadAndDeserialize(_filepath);

        public Trattore? GetById(int idTrattore)
        {
           var trattoreReaded = _fileHelper.ReadAndDeserialize(_filepath);
            var trattoreByid = trattoreReaded.FirstOrDefault(trattoreReaded=> trattoreReaded.IdTrattori==idTrattore); 
            return trattoreByid;
        }

        public IList<Trattore> GetByFilter(string colore)
        {
            var trattoreReaded = _fileHelper.ReadAndDeserialize(_filepath);
            var trattoreByColor = trattoreReaded.Where(trattoreReaded => trattoreReaded.Colore == colore).ToList();
            return trattoreByColor;

        }
        public IList<Trattore> Delete(int idTrattore)
        {
            var trattoreReaded = _fileHelper.ReadAndDeserialize(_filepath);
            var trattoreByid = trattoreReaded.FirstOrDefault(trattoreReaded => trattoreReaded.IdTrattori == idTrattore);
            if (trattoreByid != null)
            {
                trattoreReaded.Remove(trattoreByid);
                _fileHelper.WriteAndSerialize(_filepath, trattoreReaded);
                return trattoreReaded;
            }
            return null;

        }

      

        public Trattore Put(SimpleTrattore trattore, int idTrattore)
        {
            var trattoreMap = Mapping(trattore);
            var trattoreReaded = _fileHelper.ReadAndDeserialize(_filepath);
            var trattoreById = GetById(idTrattore);
            if (trattoreById == null)
            {
                trattoreReaded.Add(trattoreMap);
                _fileHelper.WriteAndSerialize(_filepath,trattoreReaded);
            }

            trattoreReaded.Remove(trattoreById);

            var trattoreFound = new Trattore()
            {
                IdTrattori = trattoreById.IdTrattori,
                Marca = trattoreById.Marca,
                Modello = trattoreById.Modello,
                Colore = trattoreById.Colore,

            };
            trattoreReaded.Add(trattoreFound);
            _fileHelper.WriteAndSerialize(_filepath, trattoreReaded);
            return trattoreFound;
        }

      
    }
}
