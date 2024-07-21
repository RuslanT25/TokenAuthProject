﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTOs
{
    public class ErrorDTO
    {
        public List<string> Errors { get; private set; }
        public bool IsShow { get; private set; }

        public ErrorDTO()
        {
            Errors = [];
        }

        public ErrorDTO(string error,bool isShow)
        {
            Errors!.Add(error);
            IsShow = isShow;
        }

        public ErrorDTO(List<string> errors,bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}