using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLDAL;

namespace MvcApplication.Controllers.WellComePage
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 验证用户信息，验证成功返回Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(string.IsNullOrWhiteSpace(model.Email)||string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.errMassage = "用户名或密码不能为空";
                ViewBag.js = "<script>alert('用户名或密码不能为空');</script>";
                //返回页面并调用页面的js function
                return View();
            }

            UserDAL user = new UserDAL();

            bool result =user.VerifyUser(model.Email, model.Password);
            if (result)
            {
                return Redirect("~/Dashboard/Index");
            }
            else
            {
                ViewBag.errMassage = "用户名或密码不正确";
                ViewBag.js = "<script>alert('用户名或密码不正确');</script>";
                return View();
            }
        }
        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            try
            {
                UserDAL user = new UserDAL();
                if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.Email))
                {
                    ViewBag.js = "<script>alert('数据不能为空');</script>";
                    return View();
                }
                int i = user.CreateUser(model.Name, model.Email, model.Password);
                if (i <= 0)
                {
                    ViewBag.js = "<script>alert('注册失败');</script>";
                    return View();
                }
                else
                {
                    return Redirect("Login");
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
