﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebADMs.Model
{
    public class EveHome
    {
        public string key { get; set; }
        public List<EveSystem> eveSystem { get; set; }
    }
}
