using Microsoft.EntityFrameworkCore;
using ControleProdutos.Data;
using ControleProdutos.Models;
using ControleProdutos.Controllers;

namespace ControleProdutos.Generic
{
    public class LogUtils
    {
        public void AddLogErro(ControleProdutosContext context, string locErro, string msgDescricao)
        {
            var controller = new LogErrosController(context);
            controller.GravaLogAsync(locErro, msgDescricao).Wait();
        }
    }

}

