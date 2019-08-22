﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroClientes
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento{ get; set; }


    }
}
