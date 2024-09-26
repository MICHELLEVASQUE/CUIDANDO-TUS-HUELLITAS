using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginproyectvet
{

    public class LocalDbService
    {
        private const string DB_NAME = "demo_calcular.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Citas>();
            _connection.CreateTableAsync<Registro>();
            _connection.CreateTableAsync<MascotaHospitalizada>();
            _connection.CreateTableAsync<Donar>();


        }

        public async Task<List<Registro>> GetRegistros()
        {
            return await _connection.Table<Registro>().ToListAsync();
        }
        public async Task<Registro> GetRegisttrosById(int id)
        {
            return await _connection.Table<Registro>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Registro registro)
        {
            await _connection.InsertAsync(registro);
        }

        public async Task Update(Registro registro)
        {
            await _connection.UpdateAsync(registro);
        }

        public async Task Delete(Registro registro)
        {
            await _connection.DeleteAsync(registro);
        }

        public async Task<List<Citas>> GetCita()
        {
            return await _connection.Table<Citas>().ToListAsync();
        }
        public async Task<Citas> GetCitaById(int id)
        {
            return await _connection.Table<Citas>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Citas citas)
        {
            await _connection.InsertAsync(citas);
        }

        public async Task Update(Citas citas)
        {
            await _connection.UpdateAsync(citas);
        }

        public async Task Delete(Citas citas)
        {
            await _connection.DeleteAsync(citas);
        }
        public async Task<List<MascotaHospitalizada>> GetHospitalizacion()
        {
            return await _connection.Table<MascotaHospitalizada>().ToListAsync();
        }
        public async Task<MascotaHospitalizada> GetHospitalizacionById(int id)
        {
            return await _connection.Table<MascotaHospitalizada>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(MascotaHospitalizada mascotaHospitalizada)
        {
            await _connection.InsertAsync(mascotaHospitalizada);
        }

        public async Task Update(MascotaHospitalizada mascotaHospitalizada)
        {
            await _connection.UpdateAsync(mascotaHospitalizada);
        }

        public async Task Delete(MascotaHospitalizada mascotaHospitalizada)
        {
            await _connection.DeleteAsync(mascotaHospitalizada);
        }
        public async Task<List<Donar>> GetDonar()
        {
            return await _connection.Table<Donar>().ToListAsync();
        }
        public async Task<Donar> GetDonarById(int id)
        {
            return await _connection.Table<Donar>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Donar donar)
        {
            await _connection.InsertAsync(donar);
        }

        public async Task Update(Donar donar)
        {
            await _connection.UpdateAsync(donar);
        }

        public async Task Delete(Donar donar)
        {
            await _connection.DeleteAsync(donar);
        }
    }
}

    
  


     

