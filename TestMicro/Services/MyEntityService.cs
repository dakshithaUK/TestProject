using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMicro.Data;
using TestMicro.Models;

namespace TestMicro.Services
{
    public class MyEntityService
    {
        private readonly MyDbContext _context;

        public MyEntityService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<MyEntity>> GetAllEntitiesAsync()
        {
            return await _context.User.ToListAsync();
            //return await _context.User.Where(u => u.Id == 1).ToListAsync();
        }

        public async Task<MyEntity> GetEntityByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }
    }
}
