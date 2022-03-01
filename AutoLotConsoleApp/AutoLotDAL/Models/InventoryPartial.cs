﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL.Models
{
    public partial class Inventory
    {
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color})";
        // Поскольку столбец PetName может быть пустым, предоставить стандартное имя **No Name**.

        public override string ToString()=> $"{this.PetName??"No Name"} is a {this.Color} {this.Make} with ID: {this.CarId}";
    }
}
