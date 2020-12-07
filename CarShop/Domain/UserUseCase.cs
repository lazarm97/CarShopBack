﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUseCase
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }

        public virtual Admin Admin { get; set; }
    }
}