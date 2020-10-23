using System;
using FullStack.Data;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly FullStackDbContext _context; 

        public InvoicesController(FullStackDbContext context)
        {
            _context = context;
        }
    }
}
