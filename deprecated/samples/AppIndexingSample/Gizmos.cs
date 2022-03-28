using System;
using System.Collections.Generic;

namespace AppIndexingSample
{
    public static class Gizmos
    {
        public static List<Gizmo> All = new List<Gizmo> {
            new Gizmo { Id = "1", Name = "Gizmo 1" },
            new Gizmo { Id = "2", Name = "Gizmo 2" },
            new Gizmo { Id = "3", Name = "Gizmo 3" },
            new Gizmo { Id = "4", Name = "Gizmo 4" },
            new Gizmo { Id = "5", Name = "Gizmo 5" },
            new Gizmo { Id = "6", Name = "Gizmo 6" },
            new Gizmo { Id = "7", Name = "Gizmo 7" },
            new Gizmo { Id = "8", Name = "Gizmo 8" },
            new Gizmo { Id = "9", Name = "Gizmo 9" },
        };
    }

    public class Gizmo
    {
        public string Id { get;set; }
        public string Name { get;set; }
    }
}

