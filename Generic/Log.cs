using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ControleProdutos.Generic
{
    public class Log
    {
        private readonly ControleProdutosContext _context;

        public Log()
        {
            string connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=123; Database=OriObj";
            var optionsBuilder = new DbContextOptionsBuilder<ControleProdutosContext>();
            optionsBuilder.UseNpgsql(connectionString);
            _context = new ControleProdutosContext(optionsBuilder.Options);
        }
        public void GravarErro(string erro, string descricao, string locErro = "")
        {
            try
            {
                var logErro = new LogErros
                {
                    Err = erro,
                    ErrDesc = descricao,
                    LocErro = locErro,
                    ErrDate = DateTime.Now.ToUniversalTime()
                };
                _context.LogErros.Add(logErro);
                _context.SaveChanges();
            }
            catch 
            {
                 
            }
        }

    }
}
