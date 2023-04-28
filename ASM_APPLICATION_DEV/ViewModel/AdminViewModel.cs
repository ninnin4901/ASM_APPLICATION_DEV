using ASM_APPLICATION_DEV.Models;
using ASM_APPLICATION_DEV.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASM_APPLICATION_DEV.ViewModel
{
    public class AdminViewModel
    {
        public List<User> Users { set; get; } = new List<User>();
        public List<Category> Categories { set; get; } = new List<Category>();
    }
}
