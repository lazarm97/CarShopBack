using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class ModelDto
    {
        public IEnumerable<Model> Models { get; set; }
    }

    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
