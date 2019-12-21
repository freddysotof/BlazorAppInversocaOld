using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorAppInversoca.Shared.EFModels
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
