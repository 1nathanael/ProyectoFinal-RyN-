﻿using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal__RyN__
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
