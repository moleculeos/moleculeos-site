﻿using System.ComponentModel.DataAnnotations;

namespace MoleculeOSSite.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}