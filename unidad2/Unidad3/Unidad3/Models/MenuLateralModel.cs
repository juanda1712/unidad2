using System;
using System.Collections.Generic;
using System.Text;

namespace Unidad3.Models
{
   public class MenuLateralModel
    {
        public MenuLateralModel()
        {
            TargetType = typeof(MenuLateralModel);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type TargetType { get; set; }

    }
}
