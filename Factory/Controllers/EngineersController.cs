using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController :Controller
  {
    public readonly FactoryContext _db;

    public EngineersController( FactoryContext db)
    {
      _db =db;
    }
    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList( _db.Machines,"MachineId","Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer ,int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      if(MachineId !=0)
      {
        _db.MAchineEngineer.Add( new MachineEngineer() { MachineId =MachineId , EngineerId =engineer.EngineerId });
        _db.SaveChanges();

      }
      return View();
    }
  }
}
