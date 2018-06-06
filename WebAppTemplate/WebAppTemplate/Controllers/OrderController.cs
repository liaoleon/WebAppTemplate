using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;
using WebAppTemplate.Service;
using WebAppTemplate.Service.Interface;
using WebAppTemplate.ViewModels;

namespace WebAppTemplate.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        //private IUnitOfWork _unitOfWork;
        public OrderController(IOrderService orderService) {
            _orderService = orderService;
            //var db = new NorthwindEntities();
            //_unitOfWork = new UnitOfWork(db);
            //_orderService = new OrderService(new OrderRepo(_unitOfWork),new Order_DetailsRepo(_unitOfWork));
        }
        // GET: Order
        public ActionResult Index()
        {  
            var viewModel = Mapper.Map<List<Orders>, List<OrderViewModel>>(_orderService.GetAll());
            return View(viewModel);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(viewModel);
                }
                var model = Mapper.Map<OrderViewModel, Orders>(viewModel);
                _orderService.Add(model);
                //_unitOfWork.SaveChanges();
                //_unitOfWork.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int OrderID)
        {
            var order = _orderService.GetByID(OrderID);
            if (order == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Orders, OrderViewModel>(order);
            return View(viewModel);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View(viewModel);
                }
                var model = Mapper.Map<OrderViewModel, Orders>(viewModel);
                _orderService.Edit(model);
                //_unitOfWork.SaveChanges();
                //_unitOfWork.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int OrderID)
        {
            var order = _orderService.GetByID(OrderID);
            if (order == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Orders, OrderViewModel>(order);
            return View(viewModel);
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteData(int OrderID)
        {
            try
            {
                _orderService.Delete(OrderID);
                //_unitOfWork.SaveChanges();
                //_unitOfWork.Dispose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
