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
      return RedirectToAction("Index");
    }
    public ActionResult Details( int id)
    {
      var thisEngineer =_db.Engineers
                        .Include(engineer =>engineer.JoinEntities)
                        .ThenInclude(join =>join.Machine)
                        .FirstOrDefault(engineer=>engineer.EngineerId ==id);
      return View(thisEngineer);
    }
    public ActionResult Edit ( int id)
    {
      var thisEngineer =_db.Engineers.FirstOrDefault(engineer=>engineer.EngineerId ==id);
      ViewBag.MachineId = new SelectList( _db.Machines,"MachineId","Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit (Engineer engineer, int MachineId)
    {
      if(MachineId !=0)
      {
        _db.MAchineEngineer.Add( new MachineEngineer() { MachineId =MachineId , EngineerId =engineer.EngineerId });
        
      }
      _db.Entry(engineer).State =EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddMachine(int id)
    {
      var thisEngineer =_db.Engineers.FirstOrDefault(engineer=>engineer.EngineerId ==id);
      ViewBag.MachineId = new SelectList( _db.Machines,"MachineId","Name");
      return View(thisEngineer);

    }
    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if(MachineId !=0)
      {
        _db.MAchineEngineer.Add( new MachineEngineer() { MachineId =MachineId , EngineerId =engineer.EngineerId });
        _db.SaveChanges();
      }
      
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer =>engineer.EngineerId==id);
      return View(thisEngineer);
    }
  
  }
}
