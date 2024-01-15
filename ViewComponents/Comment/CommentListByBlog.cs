﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Blog_MVC.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());

		//BU SAYFA BLOGREADALL SAYFASINDAKİ YORUMLAR BÖLÜMÜNÜ GETİRİYOR
		public IViewComponentResult Invoke(int id) //invoke=çağırma
		{
			var values = cm.Getlist(id);
			return View(values);
		}
	}
}