
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.Controllers
{
  public class  MachinesController:Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db =db;
    }
    public ActionResult Index()
    {
      List<Machine> model=_db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
   
      var thisMachine =_db.Machines
                        .Include(machine =>machine.JoinEntities)
                        .ThenInclude(join =>join.Engineer)
                        .FirstOrDefault(machine =>machine.EngineerId ==id);
      return View(thisMachine);
    }
    
  }
}
