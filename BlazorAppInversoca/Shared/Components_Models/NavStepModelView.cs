﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.Shared.Components_Models
{
   public class NavStepModelView
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Attribute { get; set; }
        public bool isEnabled { get; set; }
        public bool isCurrent { get; set; }
        public bool isCompleted { get; set; }
    }
}
